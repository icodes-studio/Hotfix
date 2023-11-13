using System;
using ILRuntime.Runtime.Environment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;
using UnityEngine;

namespace Hotfix.Demo
{
    public class MonoBehaviourAdapter : CrossBindingAdaptor
    {
        public override Type BaseCLRType
        {
            get { return typeof(MonoBehaviour); }
        }

        public override Type AdaptorType
        {
            get { return typeof(Adaptor); }
        }

        public override object CreateCLRInstance(ILRuntime.Runtime.Environment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adaptor(appdomain, instance);
        }

        // In order to fully realize all the features of MonoBehaviour, this Adapter needs to be extended.
        // Here I only give some ideas and implement the most commonly used Awake, Start and Update.
        public class Adaptor : MonoBehaviour, CrossBindingAdaptorType
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
                set { instance = value; }
            }

            public ILRuntime.Runtime.Environment.AppDomain AppDomain
            { 
                get { return appdomain; }
                set { appdomain = value; }
            }

            IMethod mAwakeMethod;
            bool mAwakeMethodGot;
            public void Awake()
            {
                // Unity will call Awake before ILRuntime prepares this instance, so it will not be used here for now.
                if (instance != null)
                {
                    if (!mAwakeMethodGot)
                    {
                        mAwakeMethod = instance.Type.GetMethod("Awake", 0);
                        mAwakeMethodGot = true;
                    }

                    if (mAwakeMethod != null)
                    {
                        appdomain.Invoke(mAwakeMethod, instance, null);
                    }
                }
            }

            IMethod mStartMethod;
            bool mStartMethodGot;
            void Start()
            {
                if (!mStartMethodGot)
                {
                    mStartMethod = instance.Type.GetMethod("Start", 0);
                    mStartMethodGot = true;
                }

                if (mStartMethod != null)
                {
                    appdomain.Invoke(mStartMethod, instance, null);
                }
            }

            IMethod mUpdateMethod;
            bool mUpdateMethodGot;
            void Update()
            {
                if (!mUpdateMethodGot)
                {
                    mUpdateMethod = instance.Type.GetMethod("Update", 0);
                    mUpdateMethodGot = true;
                }

                if (mUpdateMethod != null)
                {
                    appdomain.Invoke(mUpdateMethod, instance, null);
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