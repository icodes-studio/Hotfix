using System.Collections.Generic;
using UnityEngine;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.Utils;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Runtime.Environment;

namespace Hotfix.Unity
{
    public sealed class CLRRedirection : ExampleMonoBehaviour
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            unsafe
            {
                domain.RegisterCLRMethodRedirection(
                    typeof(Debug).GetMethod("Log", new System.Type[] { typeof(object) }), Log);
            }
        }

        protected override void OnHotfixLoaded()
        {
            // CLR redirection is needed when we want to hijack the original method implementation and add some special processing.
            // CLR redirection is closely related to the underlying implementation of ILRuntime.
            // You need to first read the documents on the implementation principle of ILRuntime to fully understand this Example.

            // The following introduces a typical usage of CLR redirection.
            // For example, when we call Debug.Log in a DLL, the stack in the DLL cannot be displayed by default.
            // However, after CLR redirection, the stack in the DLL can be displayed.
            // Please remove the register code in the OnInitialize method and compare the logs of the next line.
            domain.Invoke("Hotfix.TestCLRRedirection", "RunTest", null, null);
        }

        // Writing a redirection method may be difficult for those who are new to ILRuntime.
        // A simpler way is to generate binding code through CLR binding, and then modify it on this basis.
        // For example, the following code is copied and modified from UnityEngine_Debug_Binding.
        // Please see relevant tutorials and documentation on how to do CLR binding.
        unsafe static StackObject* Log(ILIntepreter intp, StackObject* esp, IList<object> stack, CLRMethod method, bool isNewObj)
        {
            // The calling convention of ILRuntime clears the stack for the callee,
            // so after executing this function, the parameters need to be cleared from the stack
            // and the return value is placed on the top of the stack.
            AppDomain domain = intp.AppDomain;

            // This is the value of the ESP stack pointer after the last method returns.
            // It should return the cleaned parameters and point to the return value.
            // Here, you only need to return the value of the cleaned parameters.
            StackObject* ret = ILIntepreter.Minus(esp, 1);

            // Take the parameters of the Log method.
            // If there are two parameters, the first parameter is ESP-2 and the second parameter is ESP-1.
            // Because of Mono's bug, the direct value of -2 will be wrong, so ILIntepreter.Minus must be called.
            StackObject* pointerOfThisMethod = ILIntepreter.Minus(esp, 1);

            // Here, the value on the stack pointer is converted into an object.
            // If it is a basic type, the value can be accessed directly through ptr->Value and ptr->ValueLow.
            // For details, please see the ILRuntime implementation principle document.
            object message = typeof(object).CheckCLRTypes(StackObject.ToObject(pointerOfThisMethod, domain, stack));

            // All non-basic types must call Free to release the managed stack
            intp.Free(pointerOfThisMethod);

            // Before actually calling Debug.Log, we first obtain the stack in the DLL
            var stacktrace = domain.DebugService.GetStackTrace(intp);

            // We add the Hotfix DLL stack after the message
            Debug.Log(message + "\n" + stacktrace);

            return ret;
        }
    }
}
