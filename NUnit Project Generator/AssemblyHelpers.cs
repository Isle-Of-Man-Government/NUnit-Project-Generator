using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using NUnit.Framework;

namespace NUnitProjectGenerator
{
    public static class AssmeblyHelpers
    {
        public static IEnumerable<string> GetTestAssemblies(string RootDirectory)
        {
            var AllAssembliesInDirectory = Directory.GetFiles(RootDirectory, "*.dll", SearchOption.AllDirectories);
            var TestDlls = new Dictionary<string, string>();

            foreach (var Dll in AllAssembliesInDirectory)
            {
                if (!ContainsTests(Dll))
                {
                    continue;
                }

                var AssemblyName = Path.GetFileNameWithoutExtension(Dll) ?? string.Empty;
                if (!TestDlls.ContainsKey(AssemblyName))
                {
                    TestDlls.Add(AssemblyName, Dll);
                }
            }
            return TestDlls.Select(x => x.Value).ToArray();
        }

         
        private static bool ContainsTests(string Dll)
        {
            var LoadedAssembly = Assembly.LoadFrom(Dll);

            return LoadedAssembly.GetReferencedAssemblies().Any(x => x.Name.Equals("nunit.framework"))
                && LoadedAssembly.GetTypes().Any(x => Attribute.IsDefined(x, typeof(TestFixtureAttribute)));
        }
    }
}
