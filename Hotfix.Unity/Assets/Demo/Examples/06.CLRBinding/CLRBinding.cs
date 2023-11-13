using UnityEngine.Profiling;
using UnityEngine;

namespace Hotfix.Demo
{
    public sealed class CLRBinding : ExampleMonoBehaviour
    {
        private bool ready = false;
        private bool executed = false;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // Please put the initializing code in the last step of initialization.
            // Please use the following line after generating the binding code via the menu [ILRuntime/Generate CLR Binding automatically]
            // Please comment or uncomment the following line to compare the impact of CLR binding on running time and GC overhead.
            domain.InitializeBindings();
        }

        protected override void OnHotfixLoaded()
        {
            // In order to make it easier to view the Profiler, the code has been moved to Update.
            ready = true;
        }

        private void Update()
        {
            if (ready == true && executed == false && Time.realtimeSinceStartup > 3)
            {
                executed = true;

                Debug.LogWarning("Before running this Example, please click the menu [ILRuntime/Generate CLR Binding automatically] to generate the required binding code.");

                // By default, the calling method of Unity project from the Hotfix is called via reflection.
                // GC Alloc will be generated in this process, and the execution efficiency will be low.
                // Please uncomment the InitializeBindings method to compare the impact of CLR binding on running time and GC overhead.

                var type = domain.LoadedTypes["Hotfix.TestCLRBinding"];
                var method = type.GetMethod("RunTest", 0);
                var sw = new System.Diagnostics.Stopwatch();
                sw.Reset();
                sw.Start();
                Profiler.BeginSample("RunTest");
                domain.Invoke(method, null, null);
                Profiler.EndSample();
                sw.Stop();

                Debug.Log($"The method executed was: {sw.ElapsedMilliseconds} ms");

                // You can see that there are a lot of differences between the running time and GC Alloc.
                // The reason why RunTest has a 20byte GC Alloc is because the Editor mode ILRuntime will have debugging support.
                // These 20bytes will disappear when it is officially released (turn off Development Build).
            }
        }
    }

    public class CLRBindingTest
    {
        public static float DoSomeTest(int a, float b) => a + b;
    }
}
