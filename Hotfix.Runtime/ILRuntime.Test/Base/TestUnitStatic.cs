namespace ILRuntime.Test
{
    public class TestUnitStatic : TestUnit
    {
        public override void Run(bool skipPerformanceTest = false)
        {
            Invoke(typeName, methodName, skipPerformanceTest);
        }

        public override bool Check()
        {
            return pass == TestResult.Pass || pass == TestResult.Ignored;
        }

        public override TestResultInfo CheckResult()
        {
            return new TestResultInfo($"{typeName}.{methodName}", pass, message.ToString(), isToDo);
        }
    }
}
