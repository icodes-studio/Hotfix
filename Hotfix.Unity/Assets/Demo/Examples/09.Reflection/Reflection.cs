using UnityEngine;

namespace Hotfix.Demo
{
    public sealed class Reflection : ExampleMonoBehaviour
    {
        protected override void OnHotfixLoaded()
        {
            // Reflection is a very frequently used function in C# projects. ILRuntime also supports reflection.
            // There is no difference between using reflection in the Hotfix DLL and native C#.
            // This demo introduces how to reflect the types of the Hotfix DLL in the main project.
            // Suppose that we want to create an instance of Hotfix.TestClass through reflection
            // Obviously we cannot get the type information through Activator or Type.GetType("Hotfix.TestClass")
            // We need to obtain the types in the Hotfix DLL through the AppDomain

            // LoadedTypes returns the IType, but we need to obtain the corresponding System.Type to continue using the reflection interface
            var loadedType = domain.LoadedTypes["Hotfix.TestClass"];
            var type = loadedType.ReflectionType;
            
            // After obtaining the Type, we can make reflective calls in the familiar way.
            var ctor = type.GetConstructor(new System.Type[0]);
            var instance = ctor.Invoke(null);
            Debug.Log(instance);

            // Let’s try using reflection to assign values ​​to fields.
            var field = type.GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(instance, 111111);

            // We use reflection to call the property to check the value just assigned
            var property = type.GetProperty("ID");
            var value = property.GetValue(instance, null);
            Debug.Log($"ID = {value}");
        }
    }
}
