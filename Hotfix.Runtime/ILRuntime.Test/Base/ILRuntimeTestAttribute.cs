using System;

namespace ILRuntime.Test
{
    public class ILRuntimeTestAttribute : Attribute
    {
        public bool Ignored { get; set; }
        public bool IsToDo { get; set; }
        public bool IsPerformanceTest { get; set; }
        public Type ExpectException { get; set; }
    }
}
