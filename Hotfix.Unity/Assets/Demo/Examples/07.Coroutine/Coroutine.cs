using System.Collections;

namespace Hotfix.Unity
{
    public sealed class Coroutine : ExampleMonoBehaviour
    {
        private static Coroutine instance;
        public static Coroutine Instance => instance;

        private void Awake()
        {
            instance = this;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // When using Couroutine, the C# compiler will automatically generate a class that implements the IEnumerator, IEnumerator<object> and IDisposable interfaces.
            // This is cross-domain inheritance, so you need to write a CrossBindingAdaptor
            // See the 04.Inheritance tutorial for details.
            domain.RegisterCrossBindingAdaptor(new CoroutineAdaptor());
            domain.DebugService.StartDebugService(56000);
        }

        protected override void OnHotfixLoaded()
        {
            domain.Invoke("Hotfix.TestCoroutine", "RunTest", null, null);
        }

        public void DoCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}
