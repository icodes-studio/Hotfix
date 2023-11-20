using UnityEngine;

namespace Hotfix.Unity
{
    public delegate void DelegateMethod(int a);
    public delegate string DelegateFunction(int a);

    public sealed class Delegation : ExampleMonoBehaviour
    {
        public static DelegateMethod delegateMethod;
        public static DelegateFunction delegateFunction;
        public static System.Action<string> delegateAction;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // DelegateMethod type is a delegate with an int parameter.
            domain.DelegateManager.RegisterMethodDelegate<int>();
            // If you want a delegate with a return value, you need to use RegisterFunctionDelegate, the return type is the last one.
            domain.DelegateManager.RegisterFunctionDelegate<int, string>();
            // Action<string>'s parameter is a string
            domain.DelegateManager.RegisterMethodDelegate<string>();

            // ILRuntime internally uses Action and Func. so other delegate types need to write convertors.
            domain.DelegateManager.RegisterDelegateConvertor<DelegateMethod>((action) =>
            {
                // It's to convert Action<int> into DelegateMethod
                return new DelegateMethod((a) => ((System.Action<int>)action)(a));
            });

            // The Func<int, string> is converted into DelegateFunction.
            domain.DelegateManager.RegisterDelegateConvertor<DelegateFunction>((action) =>
            {
                return new DelegateFunction((a) => ((System.Func<int, string>)action)(a));
            });

            // Here is an another delegate that is not used in this demo but is often encountered in UGUI, such as UnityAction<float>
            domain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<float>>((action) =>
            {
                return new UnityEngine.Events.UnityAction<float>((a) => ((System.Action<float>)action)(a));
            });
        }

        protected override void OnHotfixLoaded()
        {
            domain.Invoke("Hotfix.TestDelegate", "Initialize", null, null);
            domain.Invoke("Hotfix.TestDelegate", "RunTest", null, null);

            // The delegate is completely used inside the Hotfix DLL and available directly without any processing.
            // If you want to call the delegate across domains (eg. transfer the delegate instance from the Hotfix.dll to the Unity project),
            // You need to register a convertor. This is because in the IL2CPP mode of iOS, types cannot be generated dynamically.
            // In order to avoid unpredictable problems, we did not create delegate instances through reflection, so some registrations need to be done manually.
            // If the delegate convertor is not registered, an error will be reported at runtime and the required registration code will be prompted.
            // Copy and paste it directly to the place where ILRuntime is initialized.

            domain.Invoke("Hotfix.TestDelegate", "Initialize2", null, null);
            domain.Invoke("Hotfix.TestDelegate", "RunTest2", null, null);

            // Using Action or Func as a delegate type, You can avoid writing a convertor in the project.
            // Also, unnecessary cross-domain delegate calls should be minimized.
            // If the delegator is only used in the Hotfix DLL, no registration is required.

            delegateMethod(789);
            Debug.Log(delegateFunction(098));
            delegateAction("Hello from Unity");
        }
    }
}