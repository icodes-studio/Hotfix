using System.Collections.Generic;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Runtime.Environment;
using UnityEngine;

namespace Hotfix.Unity
{
    public sealed class MonoBehaviourTest : ExampleMonoBehaviour
    {
        private static MonoBehaviourTest instance;
        public static MonoBehaviourTest Instance => instance;

        private void Awake()
        {
            instance = this;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            domain.RegisterCrossBindingAdaptor(new MonoBehaviourTestAdaptor());
        }

        protected override void OnHotfixLoaded()
        {
            // It is possible to use MonoBehaviour in the Hotfix DLL, but it's not recommended.
            // Because it will require a lot of extra work to fully support all the features of MonoBehaviour.
            // Moreover, using MonoBehaviour to do game logic will be a nightmare when the project scale reaches a certain level.
            // so... It should be avoided as much as possible.

            // Directly calling GameObject.AddComponent<T> will report an error.
            // We need to hijack the AddComponent method and implement it ourselves
            SetupAddComponent();
            domain.Invoke("Hotfix.TestMonoBehaviour", "RunTest", null, gameObject);

            // GetComponent is similar to AddComponent and needs to be handled by ourselves
            SetupGetComponent();
            domain.Invoke("Hotfix.TestMonoBehaviour", "RunTest2", null, gameObject);

            // So how do we get the MonoBehaviour of the Hotfix DLL from the Unity main project?
            // This requires us to implement a GetComponent method ourselves
            var type = domain.LoadedTypes["Hotfix.SomeMonoBehaviour2"] as ILType;
            var smb = GetComponent(type);
            var method = type.GetMethod("Test2");
            domain.Invoke(method, smb, null);
        }

        private unsafe void SetupAddComponent()
        {
            // This should usually be written in OnInitialize. It is written here for demonstration.
            var methods = typeof(GameObject).GetMethods();
            foreach (var method in methods)
            {
                if (method.Name == "AddComponent" && method.GetGenericArguments().Length == 1)
                    domain.RegisterCLRMethodRedirection(method, AddComponent);
            }
        }

        private unsafe void SetupGetComponent()
        {
            // This should usually be written in OnInitialize. It is written here for demonstration.
            var methods = typeof(GameObject).GetMethods();
            foreach (var method in methods)
            {
                if (method.Name == "GetComponent" && method.GetGenericArguments().Length == 1)
                    domain.RegisterCLRMethodRedirection(method, GetComponent);
            }
        }

        private unsafe static StackObject* AddComponent(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            AppDomain __domain = __intp.AppDomain;
            var ptr = __esp - 1;

            // The first parameter of a member method is this
            GameObject instance = StackObject.ToObject(ptr, __domain, __mStack) as GameObject;
            if (instance == null)
                throw new System.NullReferenceException();

            __intp.Free(ptr);

            // AddComponent should have and only 1 generic parameter
            var genericArgument = __method.GenericArguments;
            if (genericArgument != null && genericArgument.Length == 1)
            {
                var type = genericArgument[0];
                object res;
                if (type is CLRType)
                {
                    // In this case, we do not require any special processing and can directly call the Unity interface.
                    res = instance.AddComponent(type.TypeForCLR);
                }
                else
                {
                    // The types in the Hotfix DLL is troublesome. We have to manually create the instance ourselves.
                    var ilInstance = new ILTypeInstance(type as ILType, false);
                    // Create an Adaptor instance
                    var clrInstance = instance.AddComponent<MonoBehaviourTestAdaptor.Adaptor>();
                    // The instance created by Unity does not a instance in the Hotfix DLL, so it needs to be assigned manually.
                    clrInstance.ILInstance = ilInstance;
                    clrInstance.AppDomain = __domain;
                    // The CLRInstance created by default is not a valid instance through AddComponent, so it must be replaced manually.
                    ilInstance.CLRInstance = clrInstance;
                    // The instance handed to ILRuntime should be ILInstance
                    res = clrInstance.ILInstance;
                    // Because we were not ready when Unity calls Awake method, so call it again manually.
                    clrInstance.Awake();
                }
                return ILIntepreter.PushObject(ptr, __mStack, res);
            }
            return __esp;
        }

        private unsafe static StackObject* GetComponent(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            var __domain = __intp.AppDomain;
            var ptr = __esp - 1;

            // The first parameter of a member method is this
            var instance = StackObject.ToObject(ptr, __domain, __mStack) as GameObject;
            if (instance == null)
                throw new System.NullReferenceException();
            __intp.Free(ptr);

            // GetComponent should have and only 1 generic parameter
            var genericArgument = __method.GenericArguments;
            if (genericArgument != null && genericArgument.Length == 1)
            {
                var type = genericArgument[0];
                object res = null;
                if (type is CLRType)
                {
                    // In this case, we do not require any special processing and can directly call the Unity interface.
                    res = instance.GetComponent(type.TypeForCLR);
                }
                else
                {
                    // The MonoBehaviour in all DLLs is actually this component.
                    var clrInstances = instance.GetComponents<MonoBehaviourTestAdaptor.Adaptor>();
                    for (int i = 0; i < clrInstances.Length; i++)
                    {
                        var clrInstance = clrInstances[i];
                        if (clrInstance.ILInstance != null)
                        {
                            if (clrInstance.ILInstance.Type == type)
                            {
                                // The instance handed to ILRuntime should be ILInstance
                                res = clrInstance.ILInstance;
                                break;
                            }
                        }
                    }
                }
                return ILIntepreter.PushObject(ptr, __mStack, res);
            }
            return __esp;
        }

        private MonoBehaviourTestAdaptor.Adaptor GetComponent(ILType type)
        {
            var components = GetComponents<MonoBehaviourTestAdaptor.Adaptor>();
            for (int i = 0; i < components.Length; i++)
            {
                var instance = components[i];
                if (instance.ILInstance != null && instance.ILInstance.Type == type)
                    return instance;
            }
            return null;
        }
    }
}
