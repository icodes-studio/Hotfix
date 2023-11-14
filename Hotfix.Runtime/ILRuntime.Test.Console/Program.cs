﻿using System.IO;
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
                System.Console.WriteLine("Usage: ILRuntime.Test.Console path useJIT[true|false]");
                return -1;
            }

            //var domain = new AppDomain();
            //using (FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read))
            //{
            //    domain.LoadAssembly(fs);

            //    ILRuntimeHelper.Initialize(domain);
            //    BindingCodeGenerator.GenerateBindingCode(domain, "..\\..\\..\\..\\ILRuntime.Test\\Generated");
            //}

            //System.Console.WriteLine("Done");

            //return 0;

            string path = args[0];
            bool useJIT = args[1].ToLower() == "true";
            var session = new TestSession();
            session.Load(path, useJIT);

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