namespace Hotfix.Unity
{
    public sealed class LitJson : ExampleMonoBehaviour
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            global::LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(domain);
        }

        protected override void OnHotfixLoaded()
        {
            // LitJson needs to be initialized before use, please see the initialization in the OnInitialize method
            // The use of LitJson is very simple. The JsonMapper class provides conversion methods from objects to Json and Json to objects.
            // For specific usage methods, please see the code in the Hotfix DLL project.
            domain.Invoke("Hotfix.TestJson", "RunTest", null, null);
        }
    }
}
