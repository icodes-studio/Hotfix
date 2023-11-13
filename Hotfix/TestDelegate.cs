using UnityEngine;

namespace Hotfix
{
    public class TestDelegate
    {
        static Demo.DelegateMethod delegateMethod;
        static Demo.DelegateFunction delegateFunction;
        static System.Action<string> delegateAction;

        public static void Initialize()
        {
            delegateMethod = OnMethod;
            delegateFunction = OnFunction;
            delegateAction = OnAction;
        }

        public static void RunTest()
        {
            delegateMethod(123);
            Debug.Log(delegateFunction(456));
            delegateAction("action test");
        }

        public static void Initialize2()
        {
            Demo.Delegation.delegateMethod = OnMethod;
            Demo.Delegation.delegateFunction = OnFunction;
            Demo.Delegation.delegateAction = OnAction;
        }

        public static void RunTest2()
        {
            Demo.Delegation.delegateMethod(123);
            Debug.Log(Demo.Delegation.delegateFunction(456));
            Demo.Delegation.delegateAction("action test");
        }

        static void OnMethod(int a)
        {
            Debug.Log($"{nameof(TestDelegate)}.{nameof(OnMethod)}, a = {a}");
        }

        static string OnFunction(int a)
        {
            return a.ToString();
        }

        static void OnAction(string a)
        {
            Debug.Log($"{nameof(TestDelegate)}.{nameof(OnAction)}, a = {a}");
        }
    }
}
