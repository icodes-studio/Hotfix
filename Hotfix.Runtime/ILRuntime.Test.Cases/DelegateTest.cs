using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ILRuntime.Test.Cases
{
    public class DelegateTest
    {
        static TestDelegate testDele;

        public static void DelegateTest01()
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest += IntTest;
            ILRuntime.Test.DelegateTest.IntDelegateTest += IntTest2;

            DelegateTestCls cls = new DelegateTestCls(1000);
            ILRuntime.Test.DelegateTest.IntDelegateTest += cls.IntTest;
            ILRuntime.Test.DelegateTest.IntDelegateTest += cls.IntTest2;

            ILRuntime.Test.DelegateTest.IntDelegateTest(123);

            ILRuntime.Test.DelegateTest.IntDelegateEventTest += IntTest;
            ILRuntime.Test.DelegateTest.TestEvent();
            ILRuntime.Test.DelegateTest.IntDelegateEventTest -= IntTest;

            ILRuntime.Test.DelegateTest test = new ILRuntime.Test.DelegateTest();
            test.IntDelegateEventTest2 += IntTest;
            test.TestEvent2();
            test.IntDelegateEventTest2 -= IntTest;

        }

        public static void DelegateTest02()
        {
            Action<int> a = null;
            a += IntTest;
            a += IntTest2;

            DelegateTestCls cls = new DelegateTestCls(1000);
            a += cls.IntTest;
            a += cls.IntTest2;
            a += (i) =>
            {
                Console.WriteLine("lambda a=" + i);
            };
            a(123);
        }

        public static int DelegateTest03()
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest2 += IntTest3;

            DelegateTestCls cls = new DelegateTestCls(1000);
            ILRuntime.Test.DelegateTest.IntDelegateTest2 += cls.IntTest3;

            int val = ILRuntime.Test.DelegateTest.IntDelegateTest2(123);
            return val;
        }

        delegate int TestDelegate(int b);


        public static int DelegateTest04()
        {
            Func<int, int> a = null;
            a += IntTest3;

            DelegateTestCls cls = new DelegateTestCls(1000);
            a += cls.IntTest3;
            a += (i) =>
            {
                Console.WriteLine("lambda a=" + i);
                return i + 300;
            };
            int val = a(123);

            return val;
        }

        public static int DelegateTest05()
        {
            testDele += IntTest3;

            DelegateTestCls cls = new DelegateTestCls(1000);
            testDele += cls.IntTest3;

            int val = testDele(123);
            return val;
        }

        public static void DelegateTest06()
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest = null;
            ILRuntime.Test.DelegateTest.IntDelegateTest += IntTest;
            ILRuntime.Test.DelegateTest.IntDelegateTest -= IntTest;
            ILRuntime.Test.DelegateTest.IntDelegateTest += IntTest2;
            ILRuntime.Test.DelegateTest.IntDelegateTest(1000);
        }

        public static void DelegateTest07()
        {
            Test07Sub(IntTest);
            Test07Sub2(IntTest);
        }

        public static void DelegateTest08()
        {
            testDele = null;
            testDele += IntTest3;
            testDele -= IntTest3;
            testDele += IntTest3;
            Console.WriteLine(testDele(1000));
        }

        public static void DelegateTest09()
        {
            Test09Sub(IntTest3);
            Test09Sub2(IntTest3);
        }
        public static void DelegateTest10()
        {
            Action<int, string, string> a = (b, c, d) =>
            {
                Action act = () =>
                {
                    Console.WriteLine(string.Format("{0},{1},{2}", b, c, d));
                };
                act();
            };

            a(1, "2", "3");
        }

        public static void DelegateTest11()
        {
            ILRuntime.Test.DelegateTest.GenericDelegateTest = CallBack;
            ILRuntime.Test.BaseClassTest.DoTest();
        }

        public static void DelegateTest12()
        {
            testDele += IntTest3;
            Dictionary<int, TestDelegate> dic = new Dictionary<int, TestDelegate>();
            dic[0] = testDele;
            dic[1] = IntTest3;
            Console.WriteLine(dic[0](1000));
            Console.WriteLine(dic[1](1000));

        }

        public static void DelegateTest13()
        {
            Action<int> a = null;
            a += IntTest;
            a += IntTest2;

            a -= IntTest;
            a -= IntTest2;

            Console.WriteLine(a == null);
        }

        public static void DelegateTest14()
        {
            Action<string> a = null;
            a += TestString;
            a += TestString2;
            a += TestString3;
            a += TestString4;

            a("ffff");
        }

        public static void DelegateTest15()
        {
            DelegateTestCls cls = new DelegateTestCls(123);
            DelegateTest15Sub(cls.IntTest);
        }

        static void DelegateTest15Sub(Action<int> test)
        {
            test(555);
        }

        public static void DelegateTest16()
        {
            System.Action a = () => { };
            System.Action<int> a_2 = (i) => { };
            int a3 = 2;
            Console.WriteLine(typeof(System.Action) == a.GetType());  //false, should be true
            Console.WriteLine(typeof(int) == a3.GetType());  //false, should be true
        }

        public static void DelegateTest17()
        {
            Action a = () => { };
            Console.WriteLine(a.GetHashCode());
        }

        public static void DelegateTest18()
        {
            ILRuntime.Test.DelegateTest.EnumDelegateTest = DelegateTest18Sub;
            ILRuntime.Test.DelegateTest.TestEnumDelegate();
        }

        static void DelegateTest18Sub(ILRuntime.Test.TestCLREnum e)
        {
            switch (e)
            {
                case ILRuntime.Test.TestCLREnum.Test1:
                    Console.WriteLine("Test1");
                    break;
                case ILRuntime.Test.TestCLREnum.Test2:
                    Console.WriteLine("Test2");
                    break;
                case ILRuntime.Test.TestCLREnum.Test3:
                    Console.WriteLine("Test3");
                    break;
                default:
                    throw new Exception("Should not be here");
            }
        }
        public static void DelegateTest19()
        {
            ILRuntime.Test.DelegateTest.EnumDelegateTest2 = DelegateTest19Sub;
            ILRuntime.Test.DelegateTest.TestEnumDelegate2();
        }

        static ILRuntime.Test.TestCLREnum DelegateTest19Sub()
        {
            return ILRuntime.Test.TestCLREnum.Test2;
        }

        static int test20Val;
        public static void DelegateTest20()
        {
            test20Val = 0;
            Action<int> act = (b) => test20Val += b + 2;
            act += (b) => test20Val += b + 3;

            act(1);
            if (test20Val != 7)
                throw new Exception(test20Val.ToString());

            test20Val = 0;
            List<Action<int>> lst = new List<Action<int>>();
            lst.Add(act);

            lst[0](1);
            if (test20Val != 7)
                throw new Exception(test20Val.ToString());

        }

        public static void DelegateTest21()
        {
            test20Val = 0;
            Func<int, int> act = (b) => test20Val += b + 2;
            act += (b) => test20Val += b + 3;

            var val = act(1);
            if (val != 7)
                throw new Exception(test20Val.ToString());

            test20Val = 0;
            List<Func<int, int>> lst = new List<Func<int, int>>();
            lst.Add(act);

            val = lst[0](1);
            if (val != 7)
                throw new Exception(test20Val.ToString());

        }

        public static void DelegateTest22()
        {
            DelegateTest22Sub<string, Object>("11", "22", DelegateTest22Sub2);
        }
        static void DelegateTest22Sub<T, U>(string str, Object obj, Action<T, U> action)
        {
            Action<string, Object> callback = action as Action<string, Object>;//在此用as转换为泛型委托时，提示空引用
            callback(str, obj);
        }

        static void DelegateTest22Sub2(string str, Object obj)
        {
            string res = str + obj;
            if (res != "1122")
                throw new Exception();
        }
        static void TestString(string a)
        {
            Console.WriteLine("test1:" + a);
        }

        static void TestString2(string a)
        {
            Console.WriteLine("test2:" + a);
        }

        static void TestString3(string a)
        {
            Console.WriteLine("test3:" + a);
        }

        static void TestString4(string a)
        {
            Console.WriteLine("test4:" + a);
        }

        static void CallBack(ILRuntime.Test.BaseClassTest a)
        {
            a.testField = true;
            Console.WriteLine(a.testField);
        }

        static void Test07Sub(ILRuntime.Test.IntDelegate action)
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest = action;
        }

        static void Test07Sub2(ILRuntime.Test.IntDelegate action)
        {
            Console.WriteLine("Test Result=" + (ILRuntime.Test.DelegateTest.IntDelegateTest == action));
        }

        static void Test09Sub(TestDelegate action)
        {
            testDele = action;
        }

        static void Test09Sub2(TestDelegate action)
        {
            Console.WriteLine("Test Result=" + (testDele == action));
        }
        static void IntTest(int a)
        {
            Console.WriteLine("dele a=" + a);
        }

        static void IntTest2(int a)
        {
            Console.WriteLine("dele2 a=" + a);
        }

        static int IntTest3(int a)
        {
            Console.WriteLine("dele3 a=" + a);
            return a + 100;
        }

        static void FacadeAction(bool v)
        {
            Console.WriteLine(v);
        }

        public static void DelegateTest23()
        {
            DelegateTestCls.FacadeAction = FacadeAction;
            DelegateTestCls.FacadeAction2 = FacadeAction;
            DelegateTestCls.FacadeAction3 = FacadeAction;
            DelegateTestCls.FacadeAction4 = FacadeAction;
            DelegateTest23Sub();
        }
        static float[] ParamArray = new float[4];
        static void DelegateTest23Sub()
        {
            DelegateTestCls.FacadeAction?.Invoke(1 == ParamArray[0] ? true : false);
            DelegateTestCls.FacadeAction2?.Invoke(1 == ParamArray[1] ? true : false);
            DelegateTestCls.FacadeAction3?.Invoke(1 == ParamArray[2] ? true : false);
            DelegateTestCls.FacadeAction4?.Invoke(1 == ParamArray[3] ? true : false);

        }
        class DelegateTestCls : DelegateTestClsBase
        {
            public static Action<bool> FacadeAction;
            public static Action<bool> FacadeAction2;
            public static Action<bool> FacadeAction3;
            public static Action<bool> FacadeAction4;

            public DelegateTestCls(int b)
            {
                this.b = b;
            }
            public override void IntTest(int a)
            {
                base.IntTest(a);
                Console.WriteLine("dele3 a=" + (a + b));
            }


            public override int IntTest3(int a)
            {
                Console.WriteLine("dele5 a=" + a);
                return a + 200;
            }
        }

        class DelegateTestClsBase
        {
            protected int b;
            public virtual void IntTest(int a)
            {
                Console.WriteLine("dele3base a=" + (a + b));
            }
            public virtual void IntTest2(int a)
            {
                Console.WriteLine("dele4 a=" + (a + b));
            }

            public virtual int IntTest3(int a)
            {
                return a + b;
            }
        }

        public static void DelegateTest24()
        {
            List<ILRuntime.Test.TestVector3> list = new List<ILRuntime.Test.TestVector3>();
            list.Add(new ILRuntime.Test.TestVector3(1, 2, 3));
            list.Add(new ILRuntime.Test.TestVector3(2, 3, 4));
            list.Add(new ILRuntime.Test.TestVector3(3, 4, 5));
            var res = list.Sum(v => v.X);
            Console.WriteLine(res);
            if (res != 6)
                throw new Exception();
        }

        public static void DelegateTest25()
        {
            testDele = Delegate.CreateDelegate(typeof(TestDelegate), typeof(DelegateTest).GetMethod(nameof(IntTest3))) as TestDelegate;

            var res = testDele(100);
            if (res != 200)
                throw new Exception();
        }

        [ILRuntime.Test.ILRuntimeTest(IsToDo = true)]
        public static void DelegateTest26()
        {
            testDele = Delegate.CreateDelegate(typeof(TestDelegate), typeof(ILRuntime.Test.DelegateTest).GetMethod(nameof(ILRuntime.Test.DelegateTest.TestIntDelegate))) as TestDelegate;

            var res = testDele(100);
            if (res != 200)
                throw new Exception();
        }

        [ILRuntime.Test.ILRuntimeTest(IsToDo = true)]
        public static void DelegateTest27()
        {
            testDele = ILRuntime.Test.DelegateTest.TestIntDelegate;

            var res = testDele(100);
            if (res != 200)
                throw new Exception();
        }

        public static void DelegateTest28()
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = Delegate.CreateDelegate(typeof(ILRuntime.Test.IntDelegate2), typeof(DelegateTest).GetMethod(nameof(IntTest3))) as ILRuntime.Test.IntDelegate2;

            var res = ILRuntime.Test.DelegateTest.IntDelegateTest2(100);
            if (res != 200)
                throw new Exception();
        }

        public static void DelegateTest29()
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = Delegate.CreateDelegate(typeof(ILRuntime.Test.IntDelegate2), typeof(ILRuntime.Test.DelegateTest).GetMethod(nameof(ILRuntime.Test.DelegateTest.TestIntDelegate))) as ILRuntime.Test.IntDelegate2;

            var res = ILRuntime.Test.DelegateTest.IntDelegateTest2(100);
            if (res != 333)
                throw new Exception();
        }

        public static void DelegateTest30()
        {
            DelegateTestCls cls = new DelegateTestCls(100);
            testDele = Delegate.CreateDelegate(typeof(TestDelegate), cls, nameof(DelegateTestCls.IntTest3)) as TestDelegate;

            var res = testDele(100);
            if (res != 300)
                throw new Exception();
        }

        public static void DelegateTest31()
        {
            DelegateTestCls cls = new DelegateTestCls(100);
            testDele = Delegate.CreateDelegate(typeof(TestDelegate), cls, typeof(DelegateTestCls).GetMethod(nameof(DelegateTestCls.IntTest3))) as TestDelegate;

            var res = testDele(100);
            if (res != 300)
                throw new Exception();
        }

        public static void DelegateTest32()
        {
            DelegateTestCls cls = new DelegateTestCls(100);
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = Delegate.CreateDelegate(typeof(ILRuntime.Test.IntDelegate2), cls, nameof(DelegateTestCls.IntTest3)) as ILRuntime.Test.IntDelegate2;

            var res = ILRuntime.Test.DelegateTest.IntDelegateTest2(100);
            if (res != 300)
                throw new Exception();
        }

        public static void DelegateTest33()
        {
            DelegateTestCls cls = new DelegateTestCls(100);
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = Delegate.CreateDelegate(typeof(ILRuntime.Test.IntDelegate2), cls, typeof(DelegateTestCls).GetMethod(nameof(DelegateTestCls.IntTest3))) as ILRuntime.Test.IntDelegate2;

            var res = ILRuntime.Test.DelegateTest.IntDelegateTest2(100);
            if (res != 300)
                throw new Exception();
        }

        public static void DelegateTest34()
        {
            ILRuntime.Test.DelegateTest cls = new ILRuntime.Test.DelegateTest();
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = Delegate.CreateDelegate(typeof(ILRuntime.Test.IntDelegate2), cls, nameof(ILRuntime.Test.DelegateTest.TestIntDelegateInstance)) as ILRuntime.Test.IntDelegate2;

            var res = ILRuntime.Test.DelegateTest.IntDelegateTest2(100);
            if (res != 999)
                throw new Exception();
        }

        public static void DelegateTest35()
        {
            ILRuntime.Test.DelegateTest cls = new ILRuntime.Test.DelegateTest();
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = Delegate.CreateDelegate(typeof(ILRuntime.Test.IntDelegate2), cls, typeof(ILRuntime.Test.DelegateTest).GetMethod(nameof(ILRuntime.Test.DelegateTest.TestIntDelegateInstance))) as ILRuntime.Test.IntDelegate2;

            var res = ILRuntime.Test.DelegateTest.IntDelegateTest2(100);
            if (res != 999)
                throw new Exception();
        }

        class B
        {

        }

        class A
        {
            public int a = 123;
            private void test(B b)
            {
                if (b != null && b.GetType() == typeof(B) && a == 123)
                    Console.WriteLine("OK");
                else
                    throw new Exception();
            }

            public static void Test2(B b)
            {
                if (b != null && b.GetType() == typeof(B))
                    Console.WriteLine("OK2");
                else
                    throw new Exception();
            }
        }
        delegate void TestDele(B a);
        public static void DelegateTest36()
        {
            A target = new A();
            Type type = target.GetType();

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance);
            for (int methodInfoIndex = 0; methodInfoIndex < methodInfos.Length; methodInfoIndex++)
            {
                MethodInfo methodInfo = methodInfos[methodInfoIndex];
                ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                Type actionType = typeof(Action<>).MakeGenericType(parameterInfos[0].ParameterType);
                Delegate action = Delegate.CreateDelegate(actionType, target, methodInfo);
                action.DynamicInvoke(new B());
            }
        }

        public static void DelegateTest37()
        {
            A target = new A();
            Type type = target.GetType();

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance);
            for (int methodInfoIndex = 0; methodInfoIndex < methodInfos.Length; methodInfoIndex++)
            {
                MethodInfo methodInfo = methodInfos[methodInfoIndex];
                Type actionType = typeof(TestDele);
                Delegate action = Delegate.CreateDelegate(actionType, target, methodInfo);
                action.DynamicInvoke(new B());
            }
        }

        public static void DelegateTest38()
        {
            A target = new A();
            Type type = target.GetType();

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance);
            for (int methodInfoIndex = 0; methodInfoIndex < methodInfos.Length; methodInfoIndex++)
            {
                MethodInfo methodInfo = methodInfos[methodInfoIndex];
                Type actionType = typeof(TestDele);
                Delegate action = methodInfo.CreateDelegate(actionType, target);
                action.DynamicInvoke(new B());
            }
        }

        public static void DelegateTest39()
        {
            A target = new A();
            Type type = target.GetType();

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Static);
            for (int methodInfoIndex = 0; methodInfoIndex < methodInfos.Length; methodInfoIndex++)
            {
                MethodInfo methodInfo = methodInfos[methodInfoIndex];
                Type actionType = typeof(TestDele);
                Delegate action = methodInfo.CreateDelegate(actionType, null);
                action.DynamicInvoke(new B());
            }
        }

        public static void DelegateTest40()
        {
            A target = new A();
            Type type = target.GetType();

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Static);
            for (int methodInfoIndex = 0; methodInfoIndex < methodInfos.Length; methodInfoIndex++)
            {
                MethodInfo methodInfo = methodInfos[methodInfoIndex];
                Type actionType = typeof(TestDele);
                Delegate action = methodInfo.CreateDelegate(actionType);
                action.DynamicInvoke(new B());
            }
        }
        public static void DelegateTest41()
        {
            ILRuntime.Test.BindableProperty<long> t = new ILRuntime.Test.BindableProperty<long>(10000);
            t.OnChangeWithOldVal += Message;
            t.Value = 1234;
        }
        public static void DelegateTest42()
        {
            ILRuntime.Test.DelegateTest cls = new ILRuntime.Test.DelegateTest();
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = cls.TestIntDelegateInstance;

            if (ILRuntime.Test.DelegateTest.IntDelegateTest2.Target != cls)
                throw new Exception();

            ILRuntime.Test.DelegateTest.IntDelegateTest2 = ILRuntime.Test.DelegateTest.TestIntDelegate;
            if (ILRuntime.Test.DelegateTest.IntDelegateTest2.Target != null)
                throw new Exception();

            DelegateTestCls cls2 = new DelegateTestCls(100);
            testDele = cls2.IntTest3;

            if (testDele.Target != cls2)
                throw new Exception();

            testDele = IntTest3;
            if (testDele.Target != null)
                throw new Exception();

        }

        static event Action<float, double, int> OnIntEvent;
        static void Message<T>(T oldVal, T newVal)
        {
            Console.WriteLine(typeof(T));
            Console.WriteLine(oldVal);
            Console.WriteLine(newVal);
        }

        public static void DelegateTest43()
        {
            OnIntEvent += DelegateTest43Sub;
            OnIntEvent(1, 2, 3);
            OnIntEvent -= DelegateTest43Sub;
            if (OnIntEvent != null)
                throw new Exception();
        }

        static void DelegateTest43Sub(float a, double b, int c)
        {
            if (a != 1 || b != 2 || c != 3)
                throw new Exception();
            Console.WriteLine($"a={a}, b={b}, c={c}");
        }

        public static void DelegateTest44()
        {
            ILRuntime.Test.TestSession.LastSession.AppDomain.AllowUnboundCLRMethod = false;
        }

        public static void DelegateTest45()
        {
            ILRuntime.Test.DelegateTest.OnIntEvent += DelegateTest43Sub;
            ILRuntime.Test.DelegateTest.TestEvent3(1, 2, 3);
            ILRuntime.Test.DelegateTest.OnIntEvent -= DelegateTest43Sub;
            ILRuntime.Test.TestSession.LastSession.AppDomain.AllowUnboundCLRMethod = true;
            if (!ILRuntime.Test.DelegateTest.TestEvent4())
                throw new Exception();
        }
    }
}
