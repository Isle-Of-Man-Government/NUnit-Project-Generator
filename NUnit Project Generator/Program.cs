using System;
using System.Linq;

namespace NUnitProjectGenerator
{
    class Program
    {
        static void Main(string[] Args)
        {
            var Options = new Options();
            if(CommandLine.Parser.Default.ParseArguments(Args, Options))
            {                
                var Dlls = Helpers.GetTestAssemblies(Options.TestRootDirectory);

                if(!String.IsNullOrEmpty(Options.FolderToExclude))
                {
                    Dlls = Dlls.Where(x => !x.Contains(Options.FolderToExclude));
                }
                Helpers.CreateProjectFile(Dlls, Options.TestRootDirectory);
            }
            else
            {
                throw new ArgumentException("Invalid command line arguments");
            }            
        }        
    }
}
