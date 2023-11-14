using System;
using System.Collections.Generic;
using System.Reflection;
#if DEBUG && !DISABLE_ILRUNTIME_DEBUG
using AutoList = System.Collections.Generic.List<object>;
#else
using AutoList = ILRuntime.Other.UncheckedList<object>;
#endif
namespace ILRuntime.Runtime.Generated
{
    class CLRBindings
    {

//will auto register in unity
#if UNITY_5_3_OR_NEWER
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
#endif
        static private void RegisterBindingAction()
        {
            ILRuntime.Runtime.CLRBinding.CLRBindingUtils.RegisterBindingAction(Initialize);
        }

        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestVector3> s_ILRuntime_Test_TestVector3_Binding_Binder = null;
        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestVectorStruct> s_ILRuntime_Test_TestVectorStruct_Binding_Binder = null;
        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestVectorStruct2> s_ILRuntime_Test_TestVectorStruct2_Binding_Binder = null;
        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<System.Collections.Generic.KeyValuePair<System.UInt32, ILRuntime.Runtime.Intepreter.ILTypeInstance>> s_System_Collections_Generic_KeyValuePair_2_UInt32_ILTypeInstance_Binding_Binder = null;
        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestStructA> s_ILRuntime_Test_TestStructA_Binding_Binder = null;
        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestStructB> s_ILRuntime_Test_TestStructB_Binding_Binder = null;
        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.Fixed64> s_ILRuntime_Test_Fixed64_Binding_Binder = null;
        internal static ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.Fixed64Vector2> s_ILRuntime_Test_Fixed64Vector2_Binding_Binder = null;

        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        public static void Initialize(ILRuntime.Runtime.Environment.AppDomain app)
        {
            System_Collections_Generic_EqualityComparer_1_Int32_Binding.Register(app);
            System_Object_Binding.Register(app);
            System_String_Binding.Register(app);
            System_Collections_Generic_EqualityComparer_1_Single_Binding.Register(app);
            System_Collections_Generic_EqualityComparer_1_String_Binding.Register(app);
            System_Collections_Generic_EqualityComparer_1_ILTypeInstance_Binding.Register(app);
            System_Activator_Binding.Register(app);
            System_Int32_Binding.Register(app);
            System_Exception_Binding.Register(app);
            System_Console_Binding.Register(app);
            System_Single_Binding.Register(app);
            System_Type_Binding.Register(app);
            System_Math_Binding.Register(app);
            System_Int32_Array_Binding.Register(app);
            System_Int32_Array_Binding_Array_Binding.Register(app);
            System_Double_Binding.Register(app);
            System_Array_Binding.Register(app);
            ILRuntime_Test_TestVector3_Binding.Register(app);
            System_Int32_Array3_Binding.Register(app);
            System_Int32_Array2_Binding.Register(app);
            ILRuntime_Test_TestClass4_Binding.Register(app);
            System_UInt16_Binding.Register(app);
            System_Int64_Binding.Register(app);
            System_Byte_Binding.Register(app);
            System_Char_Binding.Register(app);
            System_Runtime_CompilerServices_AsyncTaskMethodBuilder_Binding.Register(app);
            System_Runtime_CompilerServices_AsyncTaskMethodBuilder_1_Int32_Binding.Register(app);
            System_Runtime_CompilerServices_AsyncVoidMethodBuilder_Binding.Register(app);
            System_Threading_Tasks_Task_Binding.Register(app);
            System_Collections_Generic_List_1_Int32_Binding.Register(app);
            System_Runtime_CompilerServices_TaskAwaiter_Binding.Register(app);
            System_Threading_Tasks_Task_1_Int32_Binding.Register(app);
            System_Runtime_CompilerServices_TaskAwaiter_1_Int32_Binding.Register(app);
            System_Collections_IDictionary_Binding.Register(app);
            System_Collections_ObjectModel_ReadOnlyCollection_1_Int32_Binding.Register(app);
            System_Collections_Generic_IEnumerator_1_Int32_Binding.Register(app);
            System_Collections_IEnumerator_Binding.Register(app);
            System_IDisposable_Binding.Register(app);
            ILRuntime_Test_TestClass3_Binding.Register(app);
            ILRuntime_Test_StaticGenericMethods_Binding.Register(app);
            ILRuntime_Test_TestSession_Binding.Register(app);
            ILRuntime_Runtime_Environment_AppDomain_Binding.Register(app);
            ILRuntime_Test_TestCLRBinding_Binding.Register(app);
            System_Runtime_CompilerServices_AsyncTaskMethodBuilder_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_List_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);
            System_Threading_Tasks_Task_1_ILTypeInstance_Binding.Register(app);
            System_Runtime_CompilerServices_TaskAwaiter_1_ILTypeInstance_Binding.Register(app);
            ILRuntime_Test_DelegateTest_Binding.Register(app);
            ILRuntime_Test_IntDelegate_Binding.Register(app);
            System_Func_3_ILTypeInstance_String_String_Binding.Register(app);
            System_Action_1_Int32_Binding.Register(app);
            System_Func_2_String_String_Binding.Register(app);
            System_Func_1_String_Binding.Register(app);
            System_Linq_Enumerable_Binding.Register(app);
            ILRuntime_Test_IntDelegate2_Binding.Register(app);
            System_Func_2_Int32_Int32_Binding.Register(app);
            System_Action_3_Int32_String_String_Binding.Register(app);
            ILRuntime_Test_BaseClassTest_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding.Register(app);
            System_Action_1_String_Binding.Register(app);
            System_Collections_Generic_List_1_Action_1_Int32_Binding.Register(app);
            System_Collections_Generic_List_1_Func_2_Int32_Int32_Binding.Register(app);
            System_Action_2_String_Object_Binding.Register(app);
            System_Boolean_Binding.Register(app);
            System_Action_1_Boolean_Binding.Register(app);
            System_Collections_Generic_List_1_TestVector3_Binding.Register(app);
            System_Reflection_MethodBase_Binding.Register(app);
            System_Reflection_ParameterInfo_Binding.Register(app);
            System_Reflection_MethodInfo_Binding.Register(app);
            ILRuntime_Test_BindableProperty_1_Int64_Binding.Register(app);
            System_Threading_Interlocked_Binding.Register(app);
            System_Action_3_Single_Double_Int32_Binding.Register(app);
            System_Action_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int64_Int32_Binding.Register(app);
            System_Enum_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_Int64_Binding.Register(app);
            System_Reflection_MemberInfo_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_Int32_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_String_Int32_Binding.Register(app);
            System_Collections_Generic_List_1_Dictionary_2_String_Object_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_Object_Binding.Register(app);
            ILRuntime_Test_ClassInheritanceTest_Binding.Register(app);
            System_Object_Array_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_List_1_Int32_Binding.Register(app);
            ILRuntime_Test_ExtensionClass_Binding.Register(app);
            ILRuntime_Test_GenericExtensions_Binding.Register(app);
            ILRuntime_Test_ExtensionClass_1_Int32_Binding.Register(app);
            ILRuntime_Test_SubExtensionClass_Binding.Register(app);
            ILRuntime_Test_SubExtensionClass_1_Int32_Binding.Register(app);
            System_ArgumentException_Binding.Register(app);
            System_Action_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_String_Array_Array_Binding.Register(app);
            System_String_Array_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_String_Array_Array_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_String_Array_Array_Binding.Register(app);
            LitJson_JsonMapper_Binding.Register(app);
            System_IComparable_1_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_Single_Array_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_Single_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_List_1_Int32_Binding.Register(app);
            System_Collections_Generic_List_1_ILRuntime_Test_ClassInheritanceTestAdaptor_Binding_Adaptor_Binding.Register(app);
            ILRuntime_Test_ClassInheritanceTest2_1_ILRuntime_Test_ClassInheritanceTest2Adaptor_Binding_Adaptor_Binding.Register(app);
            ILRuntime_Test_TestClass2_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILRuntime_Test_TestClass3Adaptor_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILRuntime_Test_ClassInheritanceTestAdaptor_Binding_Adaptor_Binding.Register(app);
            ILRuntime_Test_TestHashMap_2_Int32_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_IEnumerator_1_KeyValuePair_2_Int32_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_ILTypeInstance_Binding.Register(app);
            ILRuntime_Test_TestHashMap_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_IEnumerator_1_KeyValuePair_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_List_1_ILRuntime_Test_TestClass3Adaptor_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            ILRuntime_Test_TestStruct_Binding.Register(app);
            ILRuntime_Test_TestVector3NoBinding_Binding.Register(app);
            System_Convert_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Boolean_Binding.Register(app);
            System_Reflection_FieldInfo_Binding.Register(app);
            ILRuntime_Test_TestCLRAttribute_Binding.Register(app);
            System_Reflection_PropertyInfo_Binding.Register(app);
            System_Collections_Generic_List_1_String_Binding.Register(app);
            System_Collections_Generic_List_1_FieldInfo_Binding.Register(app);
            ILRuntime_Test_TestCLREnumClass_Binding.Register(app);
            System_Nullable_1_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_List_1_String_Binding.Register(app);
            System_Collections_Generic_List_1_String_Binding_Enumerator_Binding.Register(app);
            System_ValueType_Binding.Register(app);
            System_Diagnostics_Stopwatch_Binding.Register(app);
            ILRuntime_Test_TestVectorClass_Binding.Register(app);
            System_Func_4_Int32_Single_Int16_Double_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int64_Int64_Array_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Int32_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_Int32_Binding.Register(app);
            System_Collections_Generic_IEnumerator_1_KeyValuePair_2_Int32_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Array_Binding.Register(app);
            System_Collections_Generic_List_1_List_1_Int32_Binding.Register(app);
            System_Collections_Generic_List_1_List_1_List_1_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_ILTypeInstance_Int32_Binding.Register(app);
            System_Collections_Generic_List_1_Int32_Array_Binding.Register(app);
            System_Collections_Generic_List_1_Object_Binding.Register(app);
            System_GC_Binding.Register(app);
            System_Linq_IGrouping_2_Byte_Byte_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding_ValueCollection_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding_ValueCollection_Binding_Enumerator_Binding.Register(app);
            System_NotSupportedException_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Type_Int32_Binding.Register(app);
            System_NotImplementedException_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Object_Object_Binding.Register(app);
            System_Reflection_CustomAttributeExtensions_Binding.Register(app);
            System_Attribute_Binding.Register(app);
            ILRuntime_Test_TestVectorStruct_Binding.Register(app);
            ILRuntime_Test_TestVectorStruct2_Binding.Register(app);
            System_DateTime_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_UInt32_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_UInt32_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_UInt32_ILTypeInstance_Binding.Register(app);
            System_AccessViolationException_Binding.Register(app);
            System_Func_1_TestVector3_Binding.Register(app);
            ILRuntime_Test_JInt_Binding.Register(app);
            System_Collections_Generic_List_1_TestVector3NoBinding_Binding.Register(app);
            ILRuntime_Test_TestStructA_Binding.Register(app);
            ILRuntime_Test_TestStructB_Binding.Register(app);
            ILRuntime_Test_Fixed64_Binding.Register(app);
            ILRuntime_Test_Fixed64Vector2_Binding.Register(app);

            ILRuntime.CLR.TypeSystem.CLRType __clrType = null;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(ILRuntime.Test.TestVector3));
            s_ILRuntime_Test_TestVector3_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestVector3>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(ILRuntime.Test.TestVectorStruct));
            s_ILRuntime_Test_TestVectorStruct_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestVectorStruct>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(ILRuntime.Test.TestVectorStruct2));
            s_ILRuntime_Test_TestVectorStruct2_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestVectorStruct2>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(System.Collections.Generic.KeyValuePair<System.UInt32, ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            s_System_Collections_Generic_KeyValuePair_2_UInt32_ILTypeInstance_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<System.Collections.Generic.KeyValuePair<System.UInt32, ILRuntime.Runtime.Intepreter.ILTypeInstance>>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(ILRuntime.Test.TestStructA));
            s_ILRuntime_Test_TestStructA_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestStructA>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(ILRuntime.Test.TestStructB));
            s_ILRuntime_Test_TestStructB_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.TestStructB>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(ILRuntime.Test.Fixed64));
            s_ILRuntime_Test_Fixed64_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.Fixed64>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(ILRuntime.Test.Fixed64Vector2));
            s_ILRuntime_Test_Fixed64Vector2_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Environment.ValueTypeBinder<ILRuntime.Test.Fixed64Vector2>;
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        public static void Shutdown(ILRuntime.Runtime.Environment.AppDomain app)
        {
            s_ILRuntime_Test_TestVector3_Binding_Binder = null;
            s_ILRuntime_Test_TestVectorStruct_Binding_Binder = null;
            s_ILRuntime_Test_TestVectorStruct2_Binding_Binder = null;
            s_System_Collections_Generic_KeyValuePair_2_UInt32_ILTypeInstance_Binding_Binder = null;
            s_ILRuntime_Test_TestStructA_Binding_Binder = null;
            s_ILRuntime_Test_TestStructB_Binding_Binder = null;
            s_ILRuntime_Test_Fixed64_Binding_Binder = null;
            s_ILRuntime_Test_Fixed64Vector2_Binding_Binder = null;
        }
    }
}
