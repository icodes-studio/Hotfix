#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using ILRuntime.Runtime.Environment;
using ILRuntime.Runtime.CLRBinding;
using UnityEngine;

namespace Hotfix.Unity
{
    public class ILRuntimeCLRBinding
    {
        [MenuItem("ILRuntime/Generate CLR Binding automatically", priority = 11)]
        static void GenerateCLRBindingFromHotfix()
        {
            var domain = new AppDomain();
            using (var file = new FileStream("Assets/StreamingAssets/Hotfix.dll", FileMode.Open, FileAccess.Read))
            {
                domain.LoadAssembly(file);
                InitILRuntime(domain);
                BindingCodeGenerator.GenerateBindingCode(domain, "Assets/Demo/ILRuntime/Generated");
            }

            AssetDatabase.Refresh();
        }

        [MenuItem("ILRuntime/Remove All CLR Bindins", priority = 12)]
        static void RemoveAllCLRBindins()
        {
            Directory.Delete("Assets/Demo/ILRuntime/Generated", true);
            AssetDatabase.Refresh();
        }


        static void InitILRuntime(AppDomain domain)
        {
            domain.RegisterCrossBindingAdaptor(new MonoBehaviourTestAdapter());
            domain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
            domain.RegisterCrossBindingAdaptor(new InheritanceBaseClassAdapter());
            domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
            domain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
            domain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
        }
    }
}
#endif
