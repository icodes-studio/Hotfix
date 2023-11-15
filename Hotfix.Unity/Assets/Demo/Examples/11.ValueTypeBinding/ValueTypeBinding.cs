using System.Collections;
using UnityEngine;

namespace Hotfix.Demo
{
    public sealed class ValueTypeBinding : ExampleMonoBehaviour
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            // Please comment fowllowing codes to compare the performance difference before and after.
            domain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
            domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
            domain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
        }

        protected override void OnHotfixLoaded()
        {
            StartCoroutine(OnTest());
        }

        private IEnumerator OnTest()
        {
            // If Unity's common value types are not processed, it will generate more extra CPU overhead and GC Alloc.
            // We can solve this problem through value type binding.
            // Only the value types of the Unity required this processing.
            // The value types defined in the Hotfix DLL do not require any processing.
            // Please comment the code in OnInitialize to compare the performance difference before and after.
            yield return new WaitForSeconds(0.5f);
            domain.Invoke("Hotfix.TestValueType", "RunTest1", null, null);
            yield return new WaitForSeconds(0.5f);
            domain.Invoke("Hotfix.TestValueType", "RunTest2", null, null);
            yield return new WaitForSeconds(0.5f);
            domain.Invoke("Hotfix.TestValueType", "RunTest3", null, null);
        }
    }
}
