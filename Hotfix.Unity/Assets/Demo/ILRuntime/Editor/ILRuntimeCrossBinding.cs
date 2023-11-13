#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using ILRuntime.Runtime.Environment;

namespace Hotfix.Demo
{
    public class ILRuntimeCrossBinding
    {
        [MenuItem("ILRuntime/Generate Cross Binding Adapter", priority = 10)]
        static void GenerateCrossbindingAdapter()
        {
            // Since cross-domain inheritance has too many specificities, automatic generation cannot achieve completely side-effect - free generation.
            // Therefore, the automatic code generation provided here is mainly to generate an initial template for everyone to simplify everyone's work.
            // In most cases, you can just use the automatically generated template.
            // If you encounter problems, you can manually modify the generated file, so you need to deal with the issue of overwriting by yourself.

            using (var writer = new StreamWriter("Assets/Demo/Examples/04.Inheritance/InheritanceBaseClassAdapter.cs"))
            {
                writer.WriteLine(
                    CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(
                        typeof(InheritanceBaseClass), "Hotfix.Demo"));
            }

            AssetDatabase.Refresh();
        }
    }
}
#endif
