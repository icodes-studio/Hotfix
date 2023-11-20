#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using ILRuntime.Runtime.Environment;

namespace Hotfix.Unity
{
    public class ILRuntimeCrossBinding
    {
        [MenuItem("ILRuntime/Generate Cross Binding Adaptor", priority = 10)]
        static void GenerateCrossbindingAdaptor()
        {
            // Cross-domain inheritance has too many specificities, so automatic generation cannot achieve completely side-effect.
            // The automatic code generation provided here is mainly to generate an initial template for everyone to simplify everyone's work.
            // In most cases, you can just use the automatically generated template.
            // If you encounter problems, you can manually modify the generated file.
            // You need to deal with the issue of overwriting by yourself.

            using (var writer = new StreamWriter("Assets/Demo/Examples/04.Inheritance/InheritanceBaseClassAdaptor.cs"))
            {
                writer.WriteLine(
                    CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(
                        typeof(InheritanceBaseClass), "Hotfix.Unity"));
            }

            AssetDatabase.Refresh();
        }
    }
}
#endif
