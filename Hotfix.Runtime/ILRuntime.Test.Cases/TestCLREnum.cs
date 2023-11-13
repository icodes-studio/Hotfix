using System;
using System.Collections.Generic;

namespace ILRuntime.Test.Cases
{
    public class TestCLREnum
    {
        public static string Test00()
        {
            var str = ILRuntime.Test.TestCLREnum.Test1.ToString();
            Console.WriteLine("Test10 : " + str);
            if (str == "Test1")
            {
                return str;
            }
            throw new Exception("Test Fail");
        }

        public static string Test01()
        {
            var str = ILRuntime.Test.TestCLREnum.Test1 + 1;
            Console.WriteLine(str);
            if (str.ToString() == "Test2")
            {
                return str.ToString();
            }
            throw new Exception("Test Fail");
        }

        enum MyEnum9 { AAA }

        public static void Test02()
        {
            object o = MyEnum9.AAA;
            Console.WriteLine(o is MyEnum9); //true
            Console.WriteLine(o is Enum); //false  should be true
        }

        public static void Test03()
        {
            Console.WriteLine(new List<object>() { MyEnum9.AAA }.Contains((MyEnum9)123)); //should be true,because two items are ilenuminstancetype
        }

        public static void Test04()
        {
            Console.WriteLine(MyEnum9.AAA.GetType());//shouild be Enum20
        }

        public static void Test05()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>() { { MyEnum9.AAA, MyEnum9.AAA } };
            Console.WriteLine(dict.ContainsKey(MyEnum9.AAA)); //false, should be true
            Console.WriteLine(dict.ContainsValue(MyEnum9.AAA));

        }
        static ILRuntime.Test.TestCLREnum clrEnumTestField = ILRuntime.Test.TestCLREnum.Test2;
        public static void Test06()
        {
            var res = ILRuntime.Test.TestCLREnumClass.Test == ILRuntime.Test.TestCLREnum.Test2;
            Console.WriteLine(res);
            if (!res)
                throw new Exception();
            res = ILRuntime.Test.TestCLREnumClass.Test2 == ILRuntime.Test.TestCLREnum.Test3;
            Console.WriteLine(res);
            if (!res)
                throw new Exception();
            res = clrEnumTestField == ILRuntime.Test.TestCLREnum.Test2;
            Console.WriteLine(res);
            if (!res)
                throw new Exception();
        }
    }
}