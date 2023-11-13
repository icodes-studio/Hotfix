using System;
using System.IO;
using System.Text;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Intepreter;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace ILRuntime.Test
{
    public abstract class TestUnit : ITestable
    {
        protected AppDomain domain;
        protected string assemblyName;
        protected string typeName;
        protected string methodName;
        protected bool isToDo;
        protected TestResult pass;
        protected StringBuilder message = null;

        public string TestName
        { 
            get { return $"{typeName}.{methodName}"; }
        }

        public bool Initialize(string fileName)
        {
            assemblyName = fileName;
            if (File.Exists(assemblyName) == false)
                return false;

            using (var dll = new FileStream(assemblyName, FileMode.Open, FileAccess.Read))
            {
                domain = new AppDomain();
                var path = Path.GetDirectoryName(assemblyName);
                var name = Path.GetFileNameWithoutExtension(assemblyName);
                using (var pdb = new FileStream($"{path}\\{name}.pdb", FileMode.Open))
                    domain.LoadAssembly(dll, pdb, new Mono.Cecil.Pdb.PdbReaderProvider());
            }

            return true;
        }

        public bool Initialize(AppDomain domain)
        {
            if (domain == null)
                return false;

            this.domain = domain;
            return true;
        }

        public bool Initialize(AppDomain domain, string type, string method)
        {
            if (domain == null)
                return false;

            this.typeName = type;
            this.methodName = method;
            this.domain = domain;

            return true;
        }

        public abstract void Run(bool skipPerformanceTest = false);

        public abstract bool Check();

        public abstract TestResultInfo CheckResult();

        public Object Instance(string type) => throw new NotImplementedException();

        public void Invoke(object instance, string type, string method)
        {
            message = new StringBuilder();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            domain.Invoke(type, method, instance, null);
            sw.Stop();
            message.AppendLine($"Elappsed Time:{sw.ElapsedMilliseconds}ms\n");
        }

        public void Invoke(string type, string method, bool skipPerformanceTest)
        {
            message = new StringBuilder();
            Type expectException = null;
            isToDo = false;

            try
            {
                var sw = new System.Diagnostics.Stopwatch();
                Console.WriteLine($"Invoking {type}.{method}");

                sw.Start();
                var imethod = domain.LoadedTypes[type].GetMethod(method, 0) as ILMethod;
                var attributes = imethod.ReflectionMethodInfo.GetCustomAttributes(typeof(ILRuntimeTestAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = attributes[0] as ILRuntimeTestAttribute;
                    if (attribute.Ignored)
                    {
                        pass = TestResult.Ignored;
                        return;
                    }
                    isToDo = attribute.IsToDo;
                    if (attribute.IsPerformanceTest && skipPerformanceTest)
                    {
                        pass = TestResult.Ignored;
                        return;
                    }
                    expectException = attribute.ExpectException;
                }

                var res = domain.Invoke(imethod, null);
                sw.Stop();

                if (res != null)
                    message.AppendLine($"Return:{res}");

                message.AppendLine($"Elappsed Time:{sw.ElapsedMilliseconds}ms\n");
                if (expectException != null)
                {
                    message.AppendLine($"Test ran completed without exception, but expecting {expectException}");
                    pass = TestResult.Failed;
                }
                else
                {
                    pass = TestResult.Pass;
                }
            }
            catch (ILRuntimeException e)
            {
                if (e.InnerException.GetType() != expectException)
                {
                    message.AppendLine(e.ToString());
                    message.AppendLine(e.InnerException.ToString());
                    pass = TestResult.Failed;
                }
                else
                {
                    pass = TestResult.Pass;
                }
            }
            catch (Exception e)
            {
                if (e.GetType() != expectException)
                {
                    message.AppendLine(e.ToString());
                    pass = TestResult.Failed;
                }
                else
                {
                    pass = TestResult.Pass;
                }
            }
        }
    }
}
