using UnityEngine;

namespace Hotfix.Unity
{
    public abstract class InheritanceBaseClass
    {
        public virtual int Value
        {
            get { return 0; }
            set { }
        }

        public virtual void TestVirtual(string str)
        {
            Debug.Log($"{nameof(InheritanceBaseClass)}.{nameof(TestVirtual)}(\"{str}\")");
        }

        public abstract void TestAbstract(int number);
    }
}
