﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;

namespace NUnitProjectGenerator
{
    public static class ProjectFileGenerator
    {
        public static void Create(IEnumerable<string> Assemblies, string OutputDirectory)
        {
            var Document = new XElement("NUnitProject");
            Document.Add(new XElement("Settings", new object[] {
                new XAttribute("activeconfig", "Debug"),
                new XAttribute("processModel", "Default"),
                new XAttribute("domainUsage", "Default")
            }));

            var ConfigSection = new XElement("Config", new object[] {
                new XAttribute("name", "Debug"),
                new XAttribute("binpathtype", "Auto")
            });

            foreach (var Assembly in Assemblies)
            {
                ConfigSection.Add(new XElement("assembly", new XAttribute("path", Assembly)));
            }

            Document.Add(ConfigSection);
            File.WriteAllText(OutputDirectory + "//AutogeneratedProject.nunit", Document.ToString());
            Console.WriteLine("NUnit file autogenerated and output to location: {0}", OutputDirectory);
        }
        
    }
}
