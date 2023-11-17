using UnityEngine;

namespace Hotfix
{
    // NOTE: Only one class or interface from the main Unity project is allowed,
    // but there can be any number of interfaces in the Hotfix DLL
    public class TestInheritance : Unity.InheritanceBaseClass
    {
        public override int Value
        { 
            get; set;
        }

        public override void TestAbstract(int number)
        {
            Debug.Log($"{nameof(TestInheritance)}.{nameof(TestAbstract)}({number})");
        }

        public override void TestVirtual(string str)
        {
            base.TestVirtual(str);
            Debug.Log($"{nameof(TestInheritance)}.{nameof(TestVirtual)}(\"{str}\")");
        }

        public static TestInheritance NewObject()
        {
            return new TestInheritance();
        }
    }
}
