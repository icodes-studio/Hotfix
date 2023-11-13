namespace ILRuntime.Test
{
    public enum TestResult
    {
        None,
        Pass,
        Failed,
        Ignored,
    }

    public class TestResultInfo
    {
        public TestResultInfo(string testName, TestResult result, string message, bool isToDo)
        {
            TestName = testName;
            Result = result;
            Message = message;
            HasToDo = isToDo;
        }

        public string TestName
        { 
            get; 
            private set;
        }

        public TestResult Result
        {
            get;
            private set;
        }

        public string Message
        {
            get;
            private set;
        }

        public bool HasToDo
        {
            get;
            private set;
        }
    }
}
