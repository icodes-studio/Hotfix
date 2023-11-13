namespace ILRuntime.Test
{
    public enum TestCLREnum
    {
        Test1 = 0,
        Test2 = 1,
        Test3 = 2
    }

    public class TestCLREnumClass
    {
        public static TestCLREnum Test = TestCLREnum.Test2;
        public static TestCLREnum Test2 => TestCLREnum.Test3;


        public static void TestCLREnumRef(out uint key, out TestCLREnum tag)
        {
            key = 2;
            tag = TestCLREnum.Test2;
        }
    }
}