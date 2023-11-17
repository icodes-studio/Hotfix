﻿using System.Collections.Generic;
using System;
using System.Collections;
using ILRuntime.Runtime.Environment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;

namespace Hotfix.Unity
{
    public class CoroutineAdapter : CrossBindingAdaptor
    {
        public override Type BaseCLRType
        {
            get { return null; }
        }

        public override Type[] BaseCLRTypes
        {
            get
            {
                // Cross-domain inheritance can only have one Adapter,
                // so you should try to avoid a class implementing multiple external interfaces at the same time.
                // For coroutine, it is IEnumerator<object>, IEnumerator and IDisposable.
                return new Type[] { typeof(IEnumerator<object>), typeof(IEnumerator), typeof(IDisposable) };
            }
        }

        public override Type AdaptorType
        {
            get { return typeof(Adaptor); }
        }

        public override object CreateCLRInstance(ILRuntime.Runtime.Environment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adaptor(appdomain, instance);
        }

        // The class generated by Coroutine implements IEnumerator<System.Object>, IEnumerator, and IDisposable, so they must be implemented.
        // This can be known through IL decompilation software such as Reflector.
        internal class Adaptor : IEnumerator<System.Object>, IEnumerator, IDisposable, CrossBindingAdaptorType
        {
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

            public ILTypeInstance ILInstance
            { 
                get { return instance; }
            }

            IMethod mCurrentMethod;
            bool mCurrentMethodGot;
            public object Current
            {
                get
                {
                    if (!mCurrentMethodGot)
                    {
                        mCurrentMethod = instance.Type.GetMethod("get_Current", 0);
                        if (mCurrentMethod == null)
                            mCurrentMethod = instance.Type.GetMethod("System.Collections.IEnumerator.get_Current", 0);

                        mCurrentMethodGot = true;
                    }

                    if (mCurrentMethod != null)
                    {
                        var res = appdomain.Invoke(mCurrentMethod, instance, null);
                        return res;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            IMethod mDisposeMethod;
            bool mDisposeMethodGot;
            public void Dispose()
            {
                if (!mDisposeMethodGot)
                {
                    mDisposeMethod = instance.Type.GetMethod("Dispose", 0);
                    if (mDisposeMethod == null)
                    {
                        mDisposeMethod = instance.Type.GetMethod("System.IDisposable.Dispose", 0);
                    }
                    mDisposeMethodGot = true;
                }

                if (mDisposeMethod != null)
                {
                    appdomain.Invoke(mDisposeMethod, instance, null);
                }
            }

            IMethod mMoveNextMethod;
            bool mMoveNextMethodGot;
            public bool MoveNext()
            {
                if (!mMoveNextMethodGot)
                {
                    mMoveNextMethod = instance.Type.GetMethod("MoveNext", 0);
                    mMoveNextMethodGot = true;
                }

                if (mMoveNextMethod != null)
                {
                    return (bool)appdomain.Invoke(mMoveNextMethod, instance, null);
                }
                else
                {
                    return false;
                }
            }

            IMethod mResetMethod;
            bool mResetMethodGot;
            public void Reset()
            {
                if (!mResetMethodGot)
                {
                    mResetMethod = instance.Type.GetMethod("Reset", 0);
                    mResetMethodGot = true;
                }

                if (mResetMethod != null)
                {
                    appdomain.Invoke(mResetMethod, instance, null);
                }
            }

            public override string ToString()
            {
                IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
                m = instance.Type.GetVirtualMethod(m);
                if (m == null || m is ILMethod)
                    return instance.ToString();
                else
                    return instance.Type.FullName;
            }
        }
    }
}