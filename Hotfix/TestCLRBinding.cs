namespace Hotfix
{
    public class TestCLRBinding
    {
        public static void RunTest()
        {
            for (int i = 0; i < 100000; i++)
            {
                Demo.CLRBindingTest.DoSomeTest(i, i);
            }
        }
    }
}
