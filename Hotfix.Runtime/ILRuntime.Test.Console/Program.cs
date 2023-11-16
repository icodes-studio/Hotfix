using System.IO;
using System.Collections.Generic;
using ILRuntime.Runtime.Environment;
using ILRuntime.Runtime.CLRBinding;

namespace ILRuntime.Test.Console
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                System.Console.WriteLine("Usage: mode[gen|test] <path> useJIT[true|false]");
                return -1;
            }

            if (args[0] == "gen")
            {
                var domain = new AppDomain();
                using (FileStream fs = new FileStream(args[1], FileMode.Open, FileAccess.Read))
                {
                    domain.LoadAssembly(fs);

                    ILRuntimeHelper.Initialize(domain);
                    BindingCodeGenerator.GenerateBindingCode(domain, "..\\..\\..\\..\\ILRuntime.Test\\Generated");
                }

                System.Console.WriteLine("Generation done");

                return 0;
            }
            else
            {
                var session = new TestSession();
                session.Load(args[1], args[2].ToLower() == "true");

                int ignoreCount = 0;
                int todoCount = 0;
                var failedTests = new List<TestResultInfo>();

                foreach (var test in session.TestUnits)
                {
                    test.Run(true);
                    var result = test.CheckResult();
                    if (result.Result == TestResult.Failed)
                    {
                        if (result.HasToDo)
                            todoCount++;
                        else
                            failedTests.Add(result);
                    }
                    else if (result.Result == TestResult.Ignored)
                    {
                        ignoreCount++;
                    }

                    System.Console.WriteLine(result.Message);
                    System.Console.WriteLine("-------------------------------");
                }

                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine($"{failedTests.Count} tests failed");
                foreach (var failed in failedTests)
                {
                    System.Console.WriteLine($"Test Name:{failed.TestName}, Message:{failed.Message}");
                    System.Console.WriteLine("-------------------------------");
                }
                System.Console.WriteLine($"Ran {session.TestUnits.Count} tests, {failedTests.Count} failded, {ignoreCount} ignored, {todoCount} todos");
                session.Dispose();

                return failedTests.Count <= 0 ? 0 : -1;
            }
        }
    }
}
