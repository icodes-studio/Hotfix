using System;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Environment;
using ILRuntime.Runtime.Intepreter;
#if DEBUG && !DISABLE_ILRUNTIME_DEBUG
using AutoList = System.Collections.Generic.List<object>;
#else
using AutoList = ILRuntime.Other.UncheckedList<object>;
#endif

namespace Hotfix.Unity
{
    // All adaptors should inherit CrossBindingAdaptor
    public class InheritanceBaseClassAdaptor : CrossBindingAdaptor
    {
        public override Type BaseCLRType
        {
            get
            {
                return typeof(Hotfix.Unity.InheritanceBaseClass);
            }
        }

        public override Type AdaptorType
        {
            get
            {
                return typeof(Adaptor);
            }
        }

        public override object CreateCLRInstance(ILRuntime.Runtime.Environment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adaptor(appdomain, instance);
        }

        // The Adaptor class should inherit the type you want to inherit from ILRuntime, and implement the CrossBindingAdaptorType interface
        public class Adaptor : Hotfix.Unity.InheritanceBaseClass, CrossBindingAdaptorType
        {
            CrossBindingFunctionInfo<System.Int32> mget_Value_0 = new CrossBindingFunctionInfo<System.Int32>("get_Value");
            CrossBindingMethodInfo<System.Int32> mset_Value_1 = new CrossBindingMethodInfo<System.Int32>("set_Value");
            CrossBindingMethodInfo<System.String> mTestVirtual_2 = new CrossBindingMethodInfo<System.String>("TestVirtual");
            CrossBindingMethodInfo<System.Int32> mTestAbstract_3 = new CrossBindingMethodInfo<System.Int32>("TestAbstract");

            bool isInvokingToString;
            ILTypeInstance instance;
            ILRuntime.Runtime.Environment.AppDomain appdomain;

            public Adaptor()
            {

            }

            public Adaptor(ILRuntime.Runtime.Environment.AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance { get { return instance; } }

            // For virtual method, you must add a bool variable to determine if it's already invoking,
            // otherwise it will cause stackoverflow if you call base.TestVirtual() inside ILRuntime
            public override void TestVirtual(System.String str)
            {
                if (mTestVirtual_2.CheckShouldInvokeBase(this.instance))
                    base.TestVirtual(str);
                else
                    mTestVirtual_2.Invoke(this.instance, str);
            }

            public override void TestAbstract(System.Int32 number)
            {
                mTestAbstract_3.Invoke(this.instance, number);
            }

            public override System.Int32 Value
            {
            get
            {
                if (mget_Value_0.CheckShouldInvokeBase(this.instance))
                    return base.Value;
                else
                    return mget_Value_0.Invoke(this.instance);

            }
            set
            {
                if (mset_Value_1.CheckShouldInvokeBase(this.instance))
                    base.Value = value;
                else
                    mset_Value_1.Invoke(this.instance, value);

            }
            }

            public override string ToString()
            {
                IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
                m = instance.Type.GetVirtualMethod(m);
                if (m == null || m is ILMethod)
                {
                    if (!isInvokingToString)
                    {
                        isInvokingToString = true;
                        string res = instance.ToString();
                        isInvokingToString = false;
                        return res;
                    }
                    else
                        return instance.Type.FullName;
                }
                else
                    return instance.Type.FullName;
            }
        }
    }
}

