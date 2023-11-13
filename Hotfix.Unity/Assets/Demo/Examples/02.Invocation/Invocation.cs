using System.Collections.Generic;
using UnityEngine;
using ILRuntime.CLR.TypeSystem;

namespace Hotfix.Demo
{
    public sealed class Invocation : ExampleMonoBehaviour
    {
        protected override void OnHotfixLoaded()
        {
            // Calling a static method without parameters.
            domain.Invoke("Hotfix.TestClass", "HelloWorld", null, null);

            // Call static method with parameters.
            domain.Invoke("Hotfix.TestClass", "StaticMethod", null, 123);

            // How to call via IMethod - You can reduce the time to find methods.
            var type = domain.LoadedTypes["Hotfix.TestClass"];
            var method = type.GetMethod("StaticMethod", 1);
            domain.Invoke(method, null, 123);

            // How to call a method using stack allocation.
            using (var context = domain.BeginInvoke(method))
            {
                context.PushInteger(123);
                context.Invoke();
            }

            // How to get a method by specifying the parameter type.
            var intType = domain.GetType(typeof(int));
            var parameters = new List<IType> { intType };
            method = type.GetMethod("StaticMethod", parameters, null);
            domain.Invoke(method, null, 456);

            // Create an instance of Hotfix.TestClass via AppDomain.
            object obj = domain.Instantiate("Hotfix.TestClass", new object[] { 233 });
            method = type.GetMethod("get_ID", 0);
            using (var context = domain.BeginInvoke(method))
            {
                context.PushObject(obj);
                context.Invoke();
                int id = context.ReadInteger();
                Debug.Log($"Hotfix.TestClass.ID = {id}");
            }

            // Create an instance of Hotfix.TestClass via IType.
            obj = ((ILType)type).Instantiate();
            using (var context = domain.BeginInvoke(method))
            {
                context.PushObject(obj);
                context.Invoke();
                int id = context.ReadInteger();
                Debug.Log($"Hotfix.TestClass.ID = {id}");
            }

            // Generic method call.
            IType stringType = domain.GetType(typeof(string));
            IType[] genericArguments = new IType[] { stringType };
            domain.InvokeGenericMethod("Hotfix.TestClass", "GenericMethod", genericArguments, null, "TestString");

            // How to get an IMethod from the generic.
            parameters.Clear();
            parameters.Add(intType);
            genericArguments = new IType[] { intType };
            method = type.GetMethod("GenericMethod", parameters, genericArguments);
            domain.Invoke(method, null, 33333);

            // Calling methods with ref/out parameters.
            method = type.GetMethod("RefOutMethod", 3);
            int initialVal = 500;
            using (var context = domain.BeginInvoke(method))
            {
                // Push null value for the first ref/out parameter
                context.PushObject(null);
                // Push initial value for the second ref/out parameter
                context.PushInteger(initialVal);
                // this
                context.PushObject(obj);
                // Parameter 1
                context.PushInteger(100);
                // Parameter 2: It's a ref/out, We need to push a reference. The reference position 0 is the position of the first PushObject(null)
                context.PushReference(0);
                // Parameter 3: It's a ref/out, We need to push a reference. The reference position 1 is the position of the second PushObject(initialVal)
                context.PushReference(1);
                // Calling method
                context.Invoke();
                // Reads the value of the reference position 0.
                List<int> list = context.ReadObject<List<int>>(0);
                // Reads the value of the reference position 1.
                initialVal = context.ReadInteger(1);

                Debug.Log($"list[0]={list[0]}, val={initialVal}");
            }
        }
    }
}