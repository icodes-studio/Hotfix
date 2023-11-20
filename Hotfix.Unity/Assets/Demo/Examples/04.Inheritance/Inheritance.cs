﻿using UnityEngine;

namespace Hotfix.Unity
{
    public sealed class Inheritance : ExampleMonoBehaviour
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            // Register the adaptor, which is automatically generated by [ILRuntime/Generate Cross Binding Adaptor] menu command
            domain.RegisterCrossBindingAdaptor(new InheritanceBaseClassAdaptor());
        }

        protected override void OnHotfixLoaded()
        {
            // Let’s call the member method.
            var instance = domain.Instantiate<InheritanceBaseClass>("Hotfix.TestInheritance");
            instance.TestAbstract(123);
            instance.TestVirtual("Hello");
            instance.Value = 233;
            Debug.Log($"instance.Value={instance.Value}");

            // Now create an instance another way.
            instance = domain.Invoke("Hotfix.TestInheritance", "NewObject", null, null) as InheritanceBaseClass;
            instance.TestAbstract(456);
            instance.TestVirtual("World");
            instance.Value = 2333333;
            Debug.Log($"instance.Value={instance.Value}");
        }
    }
}
