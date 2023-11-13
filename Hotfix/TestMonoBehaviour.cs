using UnityEngine;

namespace Hotfix
{
    class SomeMonoBehaviour : MonoBehaviour
    {
        private float time;
        private void Awake()
        {
            Debug.Log($"{nameof(SomeMonoBehaviour)}.{nameof(Awake)}()");
        }

        private void Start()
        {
            Debug.Log($"{nameof(SomeMonoBehaviour)}.{nameof(Start)}()");
        }

        private void Update()
        {
            if (Time.time - time > 1f)
            {
                Debug.Log($"{nameof(SomeMonoBehaviour)}.{nameof(Update)}(), t=" + Time.time);
                time = Time.time;
            }
        }

        public void Test()
        {
            Debug.Log($"{nameof(SomeMonoBehaviour)}.{nameof(Test)}()");
        }
    }

    class SomeMonoBehaviour2 : MonoBehaviour
    {
        public GameObject target = null;
        public Texture2D texture = null;
        public void Test2()
        {
            Debug.Log($"{nameof(SomeMonoBehaviour2)}.{nameof(Test2)}()");
        }
    }

    public class TestMonoBehaviour
    {
        public static void RunTest(GameObject go)
        {
            go.AddComponent<SomeMonoBehaviour>();
        }

        public static void RunTest2(GameObject go)
        {
            go.AddComponent<SomeMonoBehaviour2>();
            var mb = go.GetComponent<SomeMonoBehaviour2>();
            Debug.Log($"{nameof(SomeMonoBehaviour2)} = {mb}");
            mb.Test2();
        }
    }
}
