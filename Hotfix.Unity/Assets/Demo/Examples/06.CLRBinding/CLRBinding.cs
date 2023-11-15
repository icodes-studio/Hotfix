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

            // Please use the following line after generating the binding code via the menu [ILRuntime/Generate CLR Binding automatically]
            // Please comment or uncomment the following line to compare the impact of CLR binding on running time and GC overhead.
            domain.InitializeBindings();

            // Above(domain.InitializeBindings) eventually calls the code below.
            // CLRBindings.Initialize
            // {
            //    UnityEngine_Debug_Binding.Register(app);
            //    System_String_Binding.Register(app);
            //    System_Collections_Generic_List_1_Int32_Binding.Register(app);
            //    Hotfix_Demo_CLRBindingTest_Binding.Register(app);
            //    Hotfix_Demo_DelegateMethod_Binding.Register(app);
            //    Hotfix_Demo_DelegateFunction_Binding.Register(app);
            //    System_Action_1_String_Binding.Register(app);
            //    Hotfix_Demo_Delegation_Binding.Register(app);
            //    System_Int32_Binding.Register(app);
            //    Hotfix_Demo_Coroutine_Binding.Register(app);
            //    UnityEngine_Time_Binding.Register(app);
            //    UnityEngine_WaitForSeconds_Binding.Register(app);
            //    System_NotSupportedException_Binding.Register(app);
            //    Hotfix_Demo_InheritanceBaseClass_Binding.Register(app);
            //    System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);
            //    System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            //    System_Collections_Generic_Dictionary_2_String_Int32_Binding.Register(app);
            //    LitJson_JsonMapper_Binding.Register(app);
            //    System_Single_Binding.Register(app);
            //    UnityEngine_MonoBehaviour_Binding.Register(app);
            //    UnityEngine_GameObject_Binding.Register(app);
            //    System_Diagnostics_Stopwatch_Binding.Register(app);
            //    System_Text_StringBuilder_Binding.Register(app);
            //    Hotfix_Demo_Performance_Binding.Register(app);
            //    UnityEngine_Transform_Binding.Register(app);
            //    UnityEngine_Object_Binding.Register(app);
            //    System_Int64_Binding.Register(app);
            //    UnityEngine_Vector3_Binding.Register(app);
            //    System_Type_Binding.Register(app);
            //    UnityEngine_Renderer_Binding.Register(app);
            //    UnityEngine_Input_Binding.Register(app);
            //    UnityEngine_Quaternion_Binding.Register(app);
            //    UnityEngine_Vector2_Binding.Register(app);
            //    ...
            // }
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

                // Before running this Example, please click the menu [ILRuntime/Generate CLR Binding automatically] to generate the required binding code.
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
            }
        }
    }

    public class CLRBindingTest
    {
        public static float DoSomeTest(int a, float b) => a + b;
    }
}
