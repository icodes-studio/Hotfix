using System;

namespace ILRuntime.Test
{
    [AttributeUsage(AttributeTargets.All)]
    public class TestCLRAttribute : Attribute
    {
        public string Name;
    }
}