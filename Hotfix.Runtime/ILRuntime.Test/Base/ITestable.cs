using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace ILRuntime.Test
{
    public interface ITestable
    {
        bool Initialize(string fileName);
        bool Initialize(AppDomain domain);
        bool Initialize(AppDomain domain, string type, string method);
        void Run(bool skipPerformanceTest);
        bool Check();
        TestResultInfo CheckResult();
    }
}
