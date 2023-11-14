using System.Collections.Generic;
using UnityEngine;

namespace Hotfix
{
    public class TestClass
    {
        private int id;
        public int ID => id;

        public TestClass()
        {
            Debug.Log($"{nameof(TestClass)}()");
            this.id = 0;
        }

        public TestClass(int id)
        {
            Debug.Log($"{nameof(TestClass)}({id})");
            this.id = id;
        }

        public static void HelloWorld()
        {
            Debug.Log("Hello World");
        }

        public static void StaticMethod(int a)
        {
            Debug.Log($"{nameof(TestClass)}.{nameof(StaticMethod)}({a})");
        }

        public static void StaticMethod(float a)
        {
            Debug.Log($"{nameof(TestClass)}.{nameof(StaticMethod)}({a})");
        }

        public static void GenericMethod<T>(T a)
        {
            Debug.Log($"{nameof(TestClass)}.{nameof(GenericMethod)}({a})");
        }

        public void RefOutMethod(int addition, out List<int> list, ref int val)
        {
            Debug.Log($"{nameof(TestClass)}.{nameof(RefOutMethod)}({addition}, ...)");

            val = val + addition + id;
            list = new List<int> { id };
        }
    }
}
