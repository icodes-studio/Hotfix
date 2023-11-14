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
    unsafe class ILRuntime_Test_ClassInheritanceTest_Binding
    {
        public static void Register(ILRuntime.Runtime.Environment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ILRuntime.Test.ClassInheritanceTest);
            args = new Type[]{};
            method = type.GetMethod("TestAbstract", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestAbstract_0);
            args = new Type[]{};
            method = type.GetMethod("TestVirtual", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestVirtual_1);
            args = new Type[]{};
            method = type.GetMethod("TestField", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestField_2);
            args = new Type[]{typeof(ILRuntime.Test.InterfaceTest)};
            method = type.GetMethod("Test3", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Test3_3);
            args = new Type[]{typeof(System.Int64).MakeByRefType()};
            method = type.GetMethod("TestLongRef", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, TestLongRef_4);

            field = type.GetField("TestVal2", flag);
            app.RegisterCLRFieldGetter(field, get_TestVal2_0);
            app.RegisterCLRFieldSetter(field, set_TestVal2_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_TestVal2_0, AssignFromStack_TestVal2_0);
            field = type.GetField("staticField", flag);
            app.RegisterCLRFieldGetter(field, get_staticField_1);
            app.RegisterCLRFieldSetter(field, set_staticField_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_staticField_1, AssignFromStack_staticField_1);


        }


        static StackObject* TestAbstract_0(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.ClassInheritanceTest instance_of_this_method = (ILRuntime.Test.ClassInheritanceTest)typeof(ILRuntime.Test.ClassInheritanceTest).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.TestAbstract();

            return __ret;
        }

        static StackObject* TestVirtual_1(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.ClassInheritanceTest instance_of_this_method = (ILRuntime.Test.ClassInheritanceTest)typeof(ILRuntime.Test.ClassInheritanceTest).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.TestVirtual();

            return __ret;
        }

        static StackObject* TestField_2(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.ClassInheritanceTest instance_of_this_method = (ILRuntime.Test.ClassInheritanceTest)typeof(ILRuntime.Test.ClassInheritanceTest).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.TestField();

            return __ret;
        }

        static StackObject* Test3_3(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.InterfaceTest @ins = (ILRuntime.Test.InterfaceTest)typeof(ILRuntime.Test.InterfaceTest).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);


            ILRuntime.Test.ClassInheritanceTest.Test3(@ins);

            return __ret;
        }

        static StackObject* TestLongRef_4(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int64 @i = __intp.RetriveInt64(ptr_of_this_method, __mStack);


            ILRuntime.Test.ClassInheritanceTest.TestLongRef(ref @i);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            switch(ptr_of_this_method->ObjectType)
            {
                case ObjectTypes.StackObjectReference:
                    {
                        var ___dst = ILIntepreter.ResolveReference(ptr_of_this_method);
                        ___dst->ObjectType = ObjectTypes.Long;
                        *(long*)&___dst->Value = @i;
                    }
                    break;
                case ObjectTypes.FieldReference:
                    {
                        var ___obj = __mStack[ptr_of_this_method->Value];
                        if(___obj is ILTypeInstance)
                        {
                            ((ILTypeInstance)___obj)[ptr_of_this_method->ValueLow] = @i;
                        }
                        else
                        {
                            var ___type = __domain.GetType(___obj.GetType()) as CLRType;
                            ___type.SetFieldValue(ptr_of_this_method->ValueLow, ref ___obj, @i);
                        }
                    }
                    break;
                case ObjectTypes.StaticFieldReference:
                    {
                        var ___type = __domain.GetType(ptr_of_this_method->Value);
                        if(___type is ILType)
                        {
                            ((ILType)___type).StaticInstance[ptr_of_this_method->ValueLow] = @i;
                        }
                        else
                        {
                            ((CLRType)___type).SetStaticFieldValue(ptr_of_this_method->ValueLow, @i);
                        }
                    }
                    break;
                 case ObjectTypes.ArrayReference:
                    {
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as System.Int64[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = @i;
                    }
                    break;
            }

            __intp.Free(ptr_of_this_method);
            return __ret;
        }


        static object get_TestVal2_0(ref object o)
        {
            return ((ILRuntime.Test.ClassInheritanceTest)o).TestVal2;
        }

        static StackObject* CopyToStack_TestVal2_0(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ((ILRuntime.Test.ClassInheritanceTest)o).TestVal2;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }

        static void set_TestVal2_0(ref object o, object v)
        {
            ((ILRuntime.Test.ClassInheritanceTest)o).TestVal2 = (System.Int32)v;
        }

        static StackObject* AssignFromStack_TestVal2_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            System.Int32 @TestVal2 = ptr_of_this_method->Value;
            ((ILRuntime.Test.ClassInheritanceTest)o).TestVal2 = @TestVal2;
            return ptr_of_this_method;
        }

        static object get_staticField_1(ref object o)
        {
            return ILRuntime.Test.ClassInheritanceTest.staticField;
        }

        static StackObject* CopyToStack_staticField_1(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ILRuntime.Test.ClassInheritanceTest.staticField;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_staticField_1(ref object o, object v)
        {
            ILRuntime.Test.ClassInheritanceTest.staticField = (System.IDisposable)v;
        }

        static StackObject* AssignFromStack_staticField_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            System.IDisposable @staticField = (System.IDisposable)typeof(System.IDisposable).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ILRuntime.Test.ClassInheritanceTest.staticField = @staticField;
            return ptr_of_this_method;
        }



    }
}
