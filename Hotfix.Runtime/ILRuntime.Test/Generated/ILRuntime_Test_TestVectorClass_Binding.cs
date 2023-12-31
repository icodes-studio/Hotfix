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
    unsafe class ILRuntime_Test_TestVectorClass_Binding
    {
        public static void Register(ILRuntime.Runtime.Environment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ILRuntime.Test.TestVectorClass);
            args = new Type[]{};
            method = type.GetMethod("get_Vector2", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Vector2_0);
            args = new Type[]{typeof(System.Int32), typeof(System.String), typeof(ILRuntime.Test.TestVector3), typeof(ILRuntime.Test.TestVectorClass)};
            method = type.GetMethod("ValueTypePerfTest", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ValueTypePerfTest_1);
            args = new Type[]{typeof(ILRuntime.Test.TestVector3)};
            method = type.GetMethod("set_Vector2", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_Vector2_2);
            args = new Type[]{};
            method = type.GetMethod("get_Obj", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Obj_3);
            args = new Type[]{typeof(System.Int32), typeof(System.String), typeof(ILRuntime.Test.TestVectorClass), typeof(ILRuntime.Test.TestVectorClass)};
            method = type.GetMethod("ValueTypePerfTest2", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ValueTypePerfTest2_4);

            field = type.GetField("vector", flag);
            app.RegisterCLRFieldGetter(field, get_vector_0);
            app.RegisterCLRFieldSetter(field, set_vector_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_vector_0, AssignFromStack_vector_0);

            args = new Type[]{};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }


        static StackObject* get_Vector2_0(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.TestVectorClass instance_of_this_method = (ILRuntime.Test.TestVectorClass)typeof(ILRuntime.Test.TestVectorClass).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.Vector2;

            if (ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder != null) {
                ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static StackObject* ValueTypePerfTest_1(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.TestVectorClass @d = (ILRuntime.Test.TestVectorClass)typeof(ILRuntime.Test.TestVectorClass).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ILRuntime.Test.TestVector3 @c = new ILRuntime.Test.TestVector3();
            if (ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder != null) {
                ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder.ParseValue(ref @c, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @c = (ILRuntime.Test.TestVector3)typeof(ILRuntime.Test.TestVector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)16);
                __intp.Free(ptr_of_this_method);
            }

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.String @b = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            System.Int32 @a = ptr_of_this_method->Value;


            ILRuntime.Test.TestVectorClass.ValueTypePerfTest(@a, @b, @c, @d);

            return __ret;
        }

        static StackObject* set_Vector2_2(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.TestVector3 @value = new ILRuntime.Test.TestVector3();
            if (ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder != null) {
                ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder.ParseValue(ref @value, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @value = (ILRuntime.Test.TestVector3)typeof(ILRuntime.Test.TestVector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)16);
                __intp.Free(ptr_of_this_method);
            }

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ILRuntime.Test.TestVectorClass instance_of_this_method = (ILRuntime.Test.TestVectorClass)typeof(ILRuntime.Test.TestVectorClass).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Vector2 = value;

            return __ret;
        }

        static StackObject* get_Obj_3(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.TestVectorClass instance_of_this_method = (ILRuntime.Test.TestVectorClass)typeof(ILRuntime.Test.TestVectorClass).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.Obj;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* ValueTypePerfTest2_4(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ILRuntime.Test.TestVectorClass @d = (ILRuntime.Test.TestVectorClass)typeof(ILRuntime.Test.TestVectorClass).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ILRuntime.Test.TestVectorClass @c = (ILRuntime.Test.TestVectorClass)typeof(ILRuntime.Test.TestVectorClass).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.String @b = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            System.Int32 @a = ptr_of_this_method->Value;


            ILRuntime.Test.TestVectorClass.ValueTypePerfTest2(@a, @b, @c, @d);

            return __ret;
        }


        static object get_vector_0(ref object o)
        {
            return ((ILRuntime.Test.TestVectorClass)o).vector;
        }

        static StackObject* CopyToStack_vector_0(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = ((ILRuntime.Test.TestVectorClass)o).vector;
            if (ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder != null) {
                ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder.PushValue(ref result_of_this_method, __intp, __ret, __mStack);
                return __ret + 1;
            } else {
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
            }
        }

        static void set_vector_0(ref object o, object v)
        {
            ((ILRuntime.Test.TestVectorClass)o).vector = (ILRuntime.Test.TestVector3)v;
        }

        static StackObject* AssignFromStack_vector_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            ILRuntime.Test.TestVector3 @vector = new ILRuntime.Test.TestVector3();
            if (ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder != null) {
                ILRuntime.Runtime.Generated.CLRBindings.s_ILRuntime_Test_TestVector3_Binding_Binder.ParseValue(ref @vector, __intp, ptr_of_this_method, __mStack, true);
            } else {
                @vector = (ILRuntime.Test.TestVector3)typeof(ILRuntime.Test.TestVector3).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)16);
            }
            ((ILRuntime.Test.TestVectorClass)o).vector = @vector;
            return ptr_of_this_method;
        }


        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, AutoList __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);

            var result_of_this_method = new ILRuntime.Test.TestVectorClass();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
