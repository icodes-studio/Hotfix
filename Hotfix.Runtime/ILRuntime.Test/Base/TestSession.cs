using System.IO;
using System.Linq;
using System.Collections.Generic;
using ILRuntime.Runtime;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Debugger;
using ILRuntime.Runtime.Generated;
using Mono.Cecil.Cil;
using Mono.Cecil.Pdb;
using Mono.Cecil.Mdb;
using AppDomain = ILRuntime.Runtime.Environment.AppDomain;

namespace ILRuntime.Test
{
    public sealed class TestSession
    {
        private AppDomain domain;
        private FileStream dll;
        private FileStream pdb;

        public List<TestUnit> TestUnits
        {
            get;
            private set;
        } = new List<TestUnit>();

        public static TestSession LastSession
        {
            get;
            private set;
        }

        public AppDomain AppDomain => domain;

        public void Load(string assemblyPath, bool useJIT)
        {
            dll = new FileStream(assemblyPath, FileMode.Open, FileAccess.Read);
            {
                var path = Path.GetDirectoryName(assemblyPath);
                var name = Path.GetFileNameWithoutExtension(assemblyPath);
                var pdbPath = Path.Combine(path, name) + ".pdb";
                if (File.Exists(pdbPath) == false)
                {
                    name = Path.GetFileName(assemblyPath);
                    pdbPath = Path.Combine(path, name) + ".mdb";
                }

                domain = new AppDomain(useJIT ? ILRuntimeJITFlags.JITImmediately : ILRuntimeJITFlags.None);
                try
                {
                    DebuggerServer.GetProjectNameFunction = () => "ILRuntime.Test";
                    domain.DebugService.StartDebugService(56000);
                }
                catch
                {
                }

                pdb = new FileStream(pdbPath, FileMode.Open);
                {
                    ISymbolReaderProvider symbolReaderProvider = null;
                    if (pdbPath.EndsWith(".pdb"))
                    {
                        symbolReaderProvider = new PdbReaderProvider();
                    }
                    else if (pdbPath.EndsWith (".mdb"))
                    {
                        symbolReaderProvider = new MdbReaderProvider ();
                    }

                    domain.LoadAssembly(dll, pdb, symbolReaderProvider);
                }

                ILRuntimeHelper.Initialize(domain);
                CLRBindings.Initialize(domain);
                domain.InitializeBindings(true);
                LoadTest();
            }

            LastSession = this;
        }

        private void LoadTest()
        {
            var types = domain?.LoadedTypes.Values.ToList();
            foreach (var type in types)
            {
                var itype = type as ILType;
                if (itype == null)
                    continue;

                var methods = itype.GetMethods();
                foreach (var method in methods)
                {
                    string fullName = itype.FullName;

                    if (method.ParameterCount == 0 && method.IsStatic && ((ILMethod)method).Definition.IsPublic)
                    {
                        var testUnit = new TestUnitStatic();
                        testUnit.Initialize(domain, fullName, method.Name);
                        TestUnits.Add(testUnit);
                    }
                }
            }
        }

        public void Dispose()
        {
            dll?.Close();
            pdb?.Close();
            domain?.Dispose();
            TestUnits?.Clear();
        }
    }
}
