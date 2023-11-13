using UnityEngine;

namespace Hotfix
{
    public class TestCoroutine
    {
        public static void RunTest()
        {
            Demo.Coroutine.Instance.DoCoroutine(Coroutine());
        }

        static System.Collections.IEnumerator Coroutine()
        {
            Debug.Log($"Start Coroutine, t={Time.time}");
            yield return new WaitForSeconds(3);
            Debug.Log($"Waited for 3 seconds, t={Time.time}");
        }
    }
}
