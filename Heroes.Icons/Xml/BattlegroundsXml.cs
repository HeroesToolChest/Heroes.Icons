using Heroes.Icons.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class BattlegroundsXml : XmlBase, IInitializable, ISettableBuild, IBattlegrounds
    {
        private readonly string BattlegroundsLatestZipFileName = "battlegrounds.zip";
        private readonly string BattlegroundsZipFilePrefix = "battlegrounds_";
        private readonly SortedDictionary<int, string> BattlegroundsZipFileNamesByBuild = new SortedDictionary<int, string>();

        private readonly string BattlegroundsAssemblyPath;

        private int LowestBuild;
        private int HighestBuild;
        private XDocument BattlegroundsDataXml;

        public BattlegroundsXml()
        {
            BattlegroundsAssemblyPath = XmlAssemblyPath + ".Battlegrounds";
        }

        public void Initialize()
        {
            LoadBattlegroundZipFiles();
        }

        public void SetSelectedBuild(int build)
        {
            if (BattlegroundsDataXml != null)
                return;

            string zipFileToLoad = BattlegroundsLatestZipFileName;

            if (BattlegroundsZipFileNamesByBuild.Count > 0)
            {
                if (BattlegroundsZipFileNamesByBuild.TryGetValue(build, out string zipFileName))
                    zipFileToLoad = Path.GetFileName(zipFileName);
                else if (build < LowestBuild)
                    zipFileToLoad = BattlegroundsZipFileNamesByBuild[LowestBuild];
                else if (build > HighestBuild)
                    zipFileToLoad = BattlegroundsLatestZipFileName;
                else
                    zipFileToLoad = BattlegroundsZipFileNamesByBuild.Aggregate((x, y) => Math.Abs(x.Key - build) < Math.Abs(y.Key - build) ? x : y).Value;
            }

            BattlegroundsDataXml = LoadZipFileFromManifestStream(HeroesIconsAssembly.GetManifestResourceStream($"{BattlegroundsAssemblyPath}.{zipFileToLoad}"), Path.ChangeExtension(zipFileToLoad, "xml"));
        }

        public IEnumerable<Battleground> Battlegrounds(bool includeBrawl = false)
        {
            List<Battleground> battleground = new List<Battleground>();
            if (includeBrawl)
            {
                foreach (XElement battlegroundElement in BattlegroundsDataXml.Root.Elements())
                {
                    battleground.Add(GetBattlegroundDataFromDataXml(battlegroundElement));
                }
            }
            else
            {
                foreach (XElement battlegroundElement in BattlegroundsDataXml.Root.Elements().Where(x => x.Attribute("brawl")?.Value != "true"))
                {
                    battleground.Add(GetBattlegroundDataFromDataXml(battlegroundElement));
                }
            }

            return battleground;
        }

        public IEnumerable<Battleground> BrawlBattlegrounds()
        {
            List<Battleground> battleground = new List<Battleground>();
            foreach (XElement battlegroundElement in BattlegroundsDataXml.Root.Elements().Where(x => x.Attribute("brawl")?.Value == "true"))
            {
                battleground.Add(GetBattlegroundDataFromDataXml(battlegroundElement));
            }

            return battleground;
        }

        public Battleground Battleground(string name)
        {
            Battleground battleground = GetBattlegroundDataFromDataXml(BattlegroundsDataXml.Root.Elements().FirstOrDefault(x => x.Attribute("id")?.Value == name));
            if (battleground == null)
            {
                battleground = GetBattlegroundDataFromDataXml(BattlegroundsDataXml.Root.Elements().FirstOrDefault(x => x.Attribute("name")?.Value == name));

                if (battleground == null)
                {
                    foreach (XElement battlegroundElement in BattlegroundsDataXml.Root.Elements().Where(x => x.Element("Aliases")?.Value != string.Empty))
                    {
                        string aliases = battlegroundElement.Element("Aliases")?.Value;
                        if (!string.IsNullOrEmpty(aliases) && aliases.Contains(name))
                        {
                            battleground = GetBattlegroundDataFromDataXml(battlegroundElement);
                        }
                    }
                }
            }

            return battleground;
        }

        public int Count(bool includeBrawl = false)
        {
            if (includeBrawl)
                return BattlegroundsDataXml.Root.Elements().Count();
            else
                return BattlegroundsDataXml.Root.Elements().Where(x => x.Attribute("brawl")?.Value != "true").Count();
        }

        private void LoadBattlegroundZipFiles()
        {
            IEnumerable<string> resourceNames = HeroesIconsAssembly.GetManifestResourceNames().Where(x => x.StartsWith($"{BattlegroundsAssemblyPath}.{BattlegroundsZipFilePrefix}"));

            foreach (string assemblyPath in resourceNames)
            {
                string fileName = GetAssemblyZipFileName(assemblyPath);
                if (int.TryParse(fileName.Split('_').Last(), out int buildNumber))
                    BattlegroundsZipFileNamesByBuild.Add(buildNumber, fileName);
            }

            if (BattlegroundsZipFileNamesByBuild.Count > 0)
            {
                LowestBuild = BattlegroundsZipFileNamesByBuild.Keys.Min();
                HighestBuild = BattlegroundsZipFileNamesByBuild.Keys.Max();
            }
            else
            {
                LowestBuild = 0;
                HighestBuild = int.MaxValue;
            }
        }

        private Battleground GetBattlegroundDataFromDataXml(XElement battlegroundElement)
        {
            if (battlegroundElement == null)
                return null;

            Battleground battleground = new Battleground()
            {
                Id = battlegroundElement.Attribute("id")?.Value,
                ShortName = battlegroundElement.Name.LocalName,
                Name = battlegroundElement.Name.LocalName,
            };

            string name = battlegroundElement.Attribute("name")?.Value;
            if (!string.IsNullOrEmpty(name))
                battleground.Name = name;

            XElement textElement = battlegroundElement.Element("Text");

            string colorString = textElement.Element("TextColor")?.Value;
            if (!string.IsNullOrEmpty(colorString))
                battleground.TextHexColor = $"#{colorString}";

            colorString = textElement.Element("GlowColor")?.Value;
            if (!string.IsNullOrEmpty(colorString))
                battleground.TextHexGlowColor = $"#{colorString}";

            battleground.ImageFileName = battlegroundElement.Element("Image")?.Value;

            string aliasesString = battlegroundElement.Element("Aliases")?.Value;
            if (!string.IsNullOrEmpty(aliasesString))
            {
                foreach (string alias in aliasesString.Split('~'))
                {
                    battleground.AddAlias(alias);
                }
            }

            return battleground;
        }
    }
}
