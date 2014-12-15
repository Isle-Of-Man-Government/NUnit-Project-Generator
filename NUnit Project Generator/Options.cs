using CommandLine;

namespace NUnitProjectGenerator
{
    internal class Options
    {
        [Option('d', "directory", Required = true, 
            HelpText = "Full path to the root of the directory to search")]
        public string TestRootDirectory { get; set; }

        [Option('e', "exclude", Required = false, 
            HelpText = "Optional argument to exclude folder")]
        public string FolderToExclude { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}
