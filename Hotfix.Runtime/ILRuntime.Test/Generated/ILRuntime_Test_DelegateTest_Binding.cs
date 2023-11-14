using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Environment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;
#if DEBUG && !DISABLE_ILRUNTIME_DEBUG
using AutoList = System.Collections.Generic.List<object>;
#else
using AutoList = ILRuntime.Other.UncheckedList<object>;
#endif
namespace ILRuntime.Runtime.Generated
{
    unsafe class ILRuntime_Test_DelegateTest_Binding
    {
        public static void Register(ILRuntime.Runtime.Environment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ILRuntime.Test.DelegateTest);
            args = new Type[]{typeof(ILRuntime.Test.IntDelegate)};
            method = type.GetMethod("add_IntDelegateEventTest", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, add_IntDelegateEventTest_0);
            args = new Type[]{};
            method = type.GetMethod("TestEvent", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestEvent_1);
            args = new Type[]{typeof(ILRuntime.Test.IntDelegate)};
            method = type.GetMethod("remove_IntDelegateEventTest", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, remove_IntDelegateEventTest_2);
            args = new Type[]{typeof(ILRuntime.Test.IntDelegate)};
            method = type.GetMethod("add_IntDelegateEventTest2", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, add_IntDelegateEventTest2_3);
            args = new Type[]{};
            method = type.GetMethod("TestEvent2", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestEvent2_4);
            args = new Type[]{typeof(ILRuntime.Test.IntDelegate)};
            method = type.GetMethod("remove_IntDelegateEventTest2", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, remove_IntDelegateEventTest2_5);
            args = new Type[]{};
            method = type.GetMethod("TestEnumDelegate", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestEnumDelegate_6);
            args = new Type[]{};
            method = type.GetMethod("TestEnumDelegate2", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestEnumDelegate2_7);
            args = new Type[]{typeof(System.Action<System.Single, System.Double, System.Int32>)};
            method = type.GetMethod("add_OnIntEvent", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, add_OnIntEvent_8);
            args = new Type[]{typeof(System.Single), typeof(System.Double), typeof(System.Int32)};
            method = type.GetMethod("TestEvent3", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestEvent3_9);
            args = new Type[]{typeof(System.Action<System.Single, System.Double, System.Int32>)};
            method = type.GetMethod("remove_OnIntEvent", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, remove_OnIntEvent_10);
            args = new Type[]{};
            method = type.GetMethod("TestEvent4", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestEvent4_11);

            field = type.GetField("IntDelegateTest", flag);
            app.RegisterCLRFieldGetter(field, get_IntDelegateTest_0);
            app.RegisterCLRFieldSetter(field, set_IntDelegateTest_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_IntDelegateTest_0, AssignFromStack_IntDelegateTest_0);
            field = type.GetField("IntDelegateTest2", flag);
            app.RegisterCLRFieldGetter(field, get_IntDelegateTest2_1);
            app.RegisterCLRFieldSetter(field, set_IntDelegateTest2_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_IntDelegateTest2_1, AssignFromStack_IntDelegateTest2_1);
            field = type.GetField("GenericDelegateTest", flag);
            app.RegisterCLRFieldGetter(field, get_GenericDelegateTest_2);
            app.RegisterCLRFieldSetter(field, set_GenericDelegateTest_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_GenericDelegateTest_2, AssignFromStack_GenericDelegateTest_2);
            field = type.GetField("EnumDelegateTest", flag);
            app.RegisterCLRFieldGetter(field, get_EnumDelegateTest_3);
            app.RegisterCLRFieldSetter(field, set_EnumDelegateTest_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_EnumDelegateTest_3, AssignFromStack_EnumDelegateTest_3);
            field = type.GetField("EnumDelegateTest2", flag);
            app.RegisterCLRFieldGetter(field, get_EnumDelegateTest2_4);
            app.RegisterCLRFieldSetter(field, set_EnumDelegateTest2_4);
            app.RegisterCLRFieldBinding(field, CopyToStack_EnumDelegateTest2_4, AssignFromStack_EnumDelegateTest2_4);
            field = type.GetField("DelegatePerformanceTest", flag);
            app.RegisterCLRFieldGetter(field, get_DelegatePerformanceTest_5);
            app.RegisterCLRFieldSetter(field, set_DelegatePerformanceTest_5);
            app.RegisterCLRFieldBinding(field, CopyToStack_DelegatePerformanceTest_5, AssignFromStack_DelegatePerformanceTest_5);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* add_IntDelegateEventTest_0(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.IntDelegate @value = (ILRuntime.Test.IntDelegate)typeof(ILRuntime.Test.IntDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);


            ILRuntime.Test.DelegateTest.IntDelegateEventTest += value;

            return __ret;
        }

        static StackObject* TestEvent_1(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            ILRuntime.Test.DelegateTest.TestEvent();

            return __ret;
        }

        static StackObject* remove_IntDelegateEventTest_2(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.IntDelegate @value = (ILRuntime.Test.IntDelegate)typeof(ILRuntime.Test.IntDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);


            ILRuntime.Test.DelegateTest.IntDelegateEventTest -= value;

            return __ret;
        }

        static StackObject* add_IntDelegateEventTest2_3(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.IntDelegate @value = (ILRuntime.Test.IntDelegate)typeof(ILRuntime.Test.IntDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ILRuntime.Test.DelegateTest instance_of_this_method = (ILRuntime.Test.DelegateTest)typeof(ILRuntime.Test.DelegateTest).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IntDelegateEventTest2 += value;

            return __ret;
        }

        static StackObject* TestEvent2_4(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.DelegateTest instance_of_this_method = (ILRuntime.Test.DelegateTest)typeof(ILRuntime.Test.DelegateTest).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.TestEvent2();

            return __ret;
        }

        static StackObject* remove_IntDelegateEventTest2_5(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.IntDelegate @value = (ILRuntime.Test.IntDelegate)typeof(ILRuntime.Test.IntDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ILRuntime.Test.DelegateTest instance_of_this_method = (ILRuntime.Test.DelegateTest)typeof(ILRuntime.Test.DelegateTest).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.IntDelegateEventTest2 -= value;

            return __ret;
        }

        static StackObject* TestEnumDelegate_6(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            ILRuntime.Test.DelegateTest.TestEnumDelegate();

            return __ret;
        }

        static StackObject* TestEnumDelegate2_7(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            ILRuntime.Test.DelegateTest.TestEnumDelegate2();

            return __ret;
        }

        static StackObject* add_OnIntEvent_8(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Action<System.Single, System.Double, System.Int32> @value = (System.Action<System.Single, System.Double, System.Int32>)typeof(System.Action<System.Single, System.Double, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);


            ILRuntime.Test.DelegateTest.OnIntEvent += value;

            return __ret;
        }

        static StackObject* TestEvent3_9(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @c = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Double @b = *(double*)&ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.Single @a = *(float*)&ptr_of_this_method->Value;


            ILRuntime.Test.DelegateTest.TestEvent3(@a, @b, @c);

            return __ret;
        }

        static StackObject* remove_OnIntEvent_10(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Action<System.Single, System.Double, System.Int32> @value = (System.Action<System.Single, System.Double, System.Int32>)typeof(System.Action<System.Single, System.Double, System.Int32>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);


            ILRuntime.Test.DelegateTest.OnIntEvent -= value;

            return __ret;
        }

        static StackObject* TestEvent4_11(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ILRuntime.Test.DelegateTest.TestEvent4();

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }


        static object get_IntDelegateTest_0(ref object o)
        {
            return ILRuntime.Test.DelegateTest.IntDelegateTest;
        }

        static StackObject* CopyToStack_IntDelegateTest_0(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ILRuntime.Test.DelegateTest.IntDelegateTest;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_IntDelegateTest_0(ref object o, object v)
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest = (ILRuntime.Test.IntDelegate)v;
        }

        static StackObject* AssignFromStack_IntDelegateTest_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            ILRuntime.Test.IntDelegate @IntDelegateTest = (ILRuntime.Test.IntDelegate)typeof(ILRuntime.Test.IntDelegate).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            ILRuntime.Test.DelegateTest.IntDelegateTest = @IntDelegateTest;
            return ptr_of_this_method;
        }

        static object get_IntDelegateTest2_1(ref object o)
        {
            return ILRuntime.Test.DelegateTest.IntDelegateTest2;
        }

        static StackObject* CopyToStack_IntDelegateTest2_1(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ILRuntime.Test.DelegateTest.IntDelegateTest2;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_IntDelegateTest2_1(ref object o, object v)
        {
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = (ILRuntime.Test.IntDelegate2)v;
        }

        static StackObject* AssignFromStack_IntDelegateTest2_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            ILRuntime.Test.IntDelegate2 @IntDelegateTest2 = (ILRuntime.Test.IntDelegate2)typeof(ILRuntime.Test.IntDelegate2).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            ILRuntime.Test.DelegateTest.IntDelegateTest2 = @IntDelegateTest2;
            return ptr_of_this_method;
        }

        static object get_GenericDelegateTest_2(ref object o)
        {
            return ILRuntime.Test.DelegateTest.GenericDelegateTest;
        }

        static StackObject* CopyToStack_GenericDelegateTest_2(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ILRuntime.Test.DelegateTest.GenericDelegateTest;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_GenericDelegateTest_2(ref object o, object v)
        {
            ILRuntime.Test.DelegateTest.GenericDelegateTest = (System.Action<ILRuntime.Test.BaseClassTest>)v;
        }

        static StackObject* AssignFromStack_GenericDelegateTest_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            System.Action<ILRuntime.Test.BaseClassTest> @GenericDelegateTest = (System.Action<ILRuntime.Test.BaseClassTest>)typeof(System.Action<ILRuntime.Test.BaseClassTest>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            ILRuntime.Test.DelegateTest.GenericDelegateTest = @GenericDelegateTest;
            return ptr_of_this_method;
        }

        static object get_EnumDelegateTest_3(ref object o)
        {
            return ILRuntime.Test.DelegateTest.EnumDelegateTest;
        }

        static StackObject* CopyToStack_EnumDelegateTest_3(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ILRuntime.Test.DelegateTest.EnumDelegateTest;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_EnumDelegateTest_3(ref object o, object v)
        {
            ILRuntime.Test.DelegateTest.EnumDelegateTest = (System.Action<ILRuntime.Test.TestCLREnum>)v;
        }

        static StackObject* AssignFromStack_EnumDelegateTest_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            System.Action<ILRuntime.Test.TestCLREnum> @EnumDelegateTest = (System.Action<ILRuntime.Test.TestCLREnum>)typeof(System.Action<ILRuntime.Test.TestCLREnum>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            ILRuntime.Test.DelegateTest.EnumDelegateTest = @EnumDelegateTest;
            return ptr_of_this_method;
        }

        static object get_EnumDelegateTest2_4(ref object o)
        {
            return ILRuntime.Test.DelegateTest.EnumDelegateTest2;
        }

        static StackObject* CopyToStack_EnumDelegateTest2_4(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ILRuntime.Test.DelegateTest.EnumDelegateTest2;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_EnumDelegateTest2_4(ref object o, object v)
        {
            ILRuntime.Test.DelegateTest.EnumDelegateTest2 = (System.Func<ILRuntime.Test.TestCLREnum>)v;
        }

        static StackObject* AssignFromStack_EnumDelegateTest2_4(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            System.Func<ILRuntime.Test.TestCLREnum> @EnumDelegateTest2 = (System.Func<ILRuntime.Test.TestCLREnum>)typeof(System.Func<ILRuntime.Test.TestCLREnum>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            ILRuntime.Test.DelegateTest.EnumDelegateTest2 = @EnumDelegateTest2;
            return ptr_of_this_method;
        }

        static object get_DelegatePerformanceTest_5(ref object o)
        {
            return ILRuntime.Test.DelegateTest.DelegatePerformanceTest;
        }

        static StackObject* CopyToStack_DelegatePerformanceTest_5(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ILRuntime.Test.DelegateTest.DelegatePerformanceTest;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_DelegatePerformanceTest_5(ref object o, object v)
        {
            ILRuntime.Test.DelegateTest.DelegatePerformanceTest = (System.Func<System.Int32, System.Single, System.Int16, System.Double>)v;
        }

        static StackObject* AssignFromStack_DelegatePerformanceTest_5(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            System.Func<System.Int32, System.Single, System.Int16, System.Double> @DelegatePerformanceTest = (System.Func<System.Int32, System.Single, System.Int16, System.Double>)typeof(System.Func<System.Int32, System.Single, System.Int16, System.Double>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            ILRuntime.Test.DelegateTest.DelegatePerformanceTest = @DelegatePerformanceTest;
            return ptr_of_this_method;
        }


        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new ILRuntime.Test.DelegateTest();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
