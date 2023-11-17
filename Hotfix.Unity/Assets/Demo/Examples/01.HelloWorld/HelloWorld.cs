namespace Hotfix.Unity
{
    public sealed class HelloWorld : ExampleMonoBehaviour
    {
        protected override void OnHotfixLoaded()
        {
            domain.Invoke("Hotfix.TestClass", "HelloWorld", null, null);
        }
    }
}