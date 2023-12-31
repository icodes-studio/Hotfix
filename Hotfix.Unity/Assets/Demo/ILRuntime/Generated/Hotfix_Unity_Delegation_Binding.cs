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
    unsafe class Hotfix_Unity_Delegation_Binding
    {
        public static void Register(ILRuntime.Runtime.Environment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(Hotfix.Unity.Delegation);

            field = type.GetField("delegateMethod", flag);
            app.RegisterCLRFieldGetter(field, get_delegateMethod_0);
            app.RegisterCLRFieldSetter(field, set_delegateMethod_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_delegateMethod_0, AssignFromStack_delegateMethod_0);
            field = type.GetField("delegateFunction", flag);
            app.RegisterCLRFieldGetter(field, get_delegateFunction_1);
            app.RegisterCLRFieldSetter(field, set_delegateFunction_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_delegateFunction_1, AssignFromStack_delegateFunction_1);
            field = type.GetField("delegateAction", flag);
            app.RegisterCLRFieldGetter(field, get_delegateAction_2);
            app.RegisterCLRFieldSetter(field, set_delegateAction_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_delegateAction_2, AssignFromStack_delegateAction_2);


        }



        static object get_delegateMethod_0(ref object o)
        {
            return Hotfix.Unity.Delegation.delegateMethod;
        }

        static StackObject* CopyToStack_delegateMethod_0(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = Hotfix.Unity.Delegation.delegateMethod;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_delegateMethod_0(ref object o, object v)
        {
            Hotfix.Unity.Delegation.delegateMethod = (Hotfix.Unity.DelegateMethod)v;
        }

        static StackObject* AssignFromStack_delegateMethod_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            Hotfix.Unity.DelegateMethod @delegateMethod = (Hotfix.Unity.DelegateMethod)typeof(Hotfix.Unity.DelegateMethod).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            Hotfix.Unity.Delegation.delegateMethod = @delegateMethod;
            return ptr_of_this_method;
        }

        static object get_delegateFunction_1(ref object o)
        {
            return Hotfix.Unity.Delegation.delegateFunction;
        }

        static StackObject* CopyToStack_delegateFunction_1(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = Hotfix.Unity.Delegation.delegateFunction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_delegateFunction_1(ref object o, object v)
        {
            Hotfix.Unity.Delegation.delegateFunction = (Hotfix.Unity.DelegateFunction)v;
        }

        static StackObject* AssignFromStack_delegateFunction_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            Hotfix.Unity.DelegateFunction @delegateFunction = (Hotfix.Unity.DelegateFunction)typeof(Hotfix.Unity.DelegateFunction).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            Hotfix.Unity.Delegation.delegateFunction = @delegateFunction;
            return ptr_of_this_method;
        }

        static object get_delegateAction_2(ref object o)
        {
            return Hotfix.Unity.Delegation.delegateAction;
        }

        static StackObject* CopyToStack_delegateAction_2(ref object o, ILIntepreter __intp, StackObject* __ret, AutoList __mStack)
        {
            var result_of_this_method = Hotfix.Unity.Delegation.delegateAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_delegateAction_2(ref object o, object v)
        {
            Hotfix.Unity.Delegation.delegateAction = (System.Action<System.String>)v;
        }

        static StackObject* AssignFromStack_delegateAction_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, AutoList __mStack)
        {
            ILRuntime.Runtime.Environment.AppDomain __domain = __intp.AppDomain;
            System.Action<System.String> @delegateAction = (System.Action<System.String>)typeof(System.Action<System.String>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            Hotfix.Unity.Delegation.delegateAction = @delegateAction;
            return ptr_of_this_method;
        }



    }
}
