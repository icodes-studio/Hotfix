namespace ILRuntime.Test
{
    public class TestUnitInstance : TestUnit
    {
        public override void Run(bool skipPerformanceTest = false)
        {
            var obj = domain.Instantiate(typeName);
            if (obj != null)
                Invoke(obj, typeName, methodName);
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
