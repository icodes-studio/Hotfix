using UnityEngine;

namespace Hotfix
{
    class TestValueType
    {
        public static void RunTest1()
        {
            var sw = new System.Diagnostics.Stopwatch();
            var a = new Vector3(1, 2, 3);
            var b = Vector3.one;

            Debug.Log($"a + b = {a + b}");
            Debug.Log($"a - b = {a - b}");
            Debug.Log($"a * 2 = {a * 2}");
            Debug.Log($"2 * a = {2 * a}");
            Debug.Log($"a / 2 = {a / 2}");
            Debug.Log($"-a = {-a}");
            Debug.Log($"a == b = {a == b}");
            Debug.Log($"a != b = {a != b}");
            Debug.Log($"a dot b = {Vector3.Dot(a, b)}");
            Debug.Log($"a cross b = {Vector3.Cross(a, b)}");
            Debug.Log($"a distance b = {Vector3.Distance(a, b)}");
            Debug.Log($"a.magnitude = {a.magnitude}");
            Debug.Log($"a.normalized = {a.normalized}");
            Debug.Log($"a.sqrMagnitude = {a.sqrMagnitude}");

            sw.Start();
            float dot = 0;
            for (int i = 0; i < 100000; i++)
            {
                a += Vector3.one;
                dot += Vector3.Dot(a, Vector3.zero);
            }
            sw.Stop();

            Debug.Log($"Value: a={a},dot={dot}, time={sw.ElapsedMilliseconds}ms");
        }

        public static void RunTest2()
        {
            var sw = new System.Diagnostics.Stopwatch();
            var a = new Quaternion(1, 2, 3, 4);
            var b = Quaternion.identity;
            var c = new Vector3(2, 3, 4);

            Debug.Log($"a * b = {a * b}");
            Debug.Log($"a * c = {a * c}");
            Debug.Log($"a == b = {a == b}");
            Debug.Log($"a != b = {a != b}");
            Debug.Log($"a dot b = {Quaternion.Dot(a, b)}");
            Debug.Log($"a angle b = {Quaternion.Angle(a, b)}");
            Debug.Log($"a.eulerAngles = {a.eulerAngles}");
            Debug.Log($"Quaternion.Euler(c) = {Quaternion.Euler(c)}");
            Debug.Log($"Quaternion.Euler(2,3,4) = {Quaternion.Euler(2, 3, 4)}");

            sw.Start();
            var rot = Quaternion.Euler(c);
            float dot = 0;
            for (int i = 0; i < 100000; i++)
            {
                a *= rot;
                dot += Quaternion.Dot(a, b);
            }
            sw.Stop();

            Debug.Log($"Value: a={a},dot={dot}, time={sw.ElapsedMilliseconds}ms");
        }

        public static void RunTest3()
        {
            var sw = new System.Diagnostics.Stopwatch();
            var a = new Vector2(1, 2);
            var b = Vector2.one;

            Debug.Log($"a + b = {a + b}");
            Debug.Log($"a - b = {a - b}");
            Debug.Log($"a * 2 = {a * 2}");
            Debug.Log($"2 * a = {2 * a}");
            Debug.Log($"a / 2 = {a / 2}");
            Debug.Log($"-a = {-a}");
            Debug.Log($"a == b = {a == b}");
            Debug.Log($"a != b = {a != b}");
            Debug.Log($"(Vector3)a = {(Vector3)a}");
            Debug.Log($"(Vector2)Vector3.one = {(Vector2)Vector3.one}");
            Debug.Log($"a dot b = {Vector2.Dot(a, b)}");
            Debug.Log($"a distance b = {Vector2.Distance(a, b)}");
            Debug.Log($"a.magnitude = {a.magnitude}");
            Debug.Log($"a.normalized = {a.normalized}");
            Debug.Log($"a.sqrMagnitude = {a.sqrMagnitude}");

            sw.Start();
            float dot = 0;
            for (int i = 0; i < 100000; i++)
            {
                a += Vector2.one;
                dot += Vector2.Dot(a, Vector2.zero);
            }
            sw.Stop();

            Debug.Log($"Value: a={a},dot={dot}, time={sw.ElapsedMilliseconds}ms");
        }
    }
}
