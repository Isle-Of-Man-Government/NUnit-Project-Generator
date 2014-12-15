NUnit-Project-Generator
=======================

This is a simple CLI for generating an NUnit project file.

The project generator will look through a given directory for any DLLs that reference `nunit.framework` and contain
classes that use the `[TestFixture]` attribute and generate an NUnit project file that includes those assemblies.

It supports the following command line arguments:

* `directory` (short name `d`) The full path to the root of the directory to search
* `exclude` (short name `e`) An optional argument for a folder to exclude from the search
