using Heroes.Icons.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class BattlegroundsXml : XmlBase, IXml, IXmlMultipleBuild, IBattlegroundsXml
    {
        private readonly string BattlegroundsLatestZipFileName = "battlegrounds.zip";
        private readonly string BattlegroundsZipFileFormat = "battlegrounds_{0}.zip";
        private readonly SortedDictionary<int, string> BattlegroundsFilePathsByBuild = new SortedDictionary<int, string>();

        private readonly string BattlegroundsDirectory;

        private int LowestBuild;
        private int HighestBuild;
        private XDocument BattlegroundsDataXml;

        public BattlegroundsXml()
        {
            BattlegroundsDirectory = Path.Combine(XmlFolderPath, "Battlegrounds");
        }

        public void Initialize()
        {
            LoadBattlegroundZipFiles();
        }

        public void SetSelectedBuild(int build)
        {
            string zipFileToLoad = BattlegroundsLatestZipFileName;

            if (BattlegroundsFilePathsByBuild.Count > 0)
            {
                if (BattlegroundsFilePathsByBuild.TryGetValue(build, out string filePath))
                    zipFileToLoad = Path.GetFileName(filePath);
                else if (build < LowestBuild)
                    zipFileToLoad = BattlegroundsFilePathsByBuild[LowestBuild];
                else if (build > HighestBuild)
                    zipFileToLoad = BattlegroundsLatestZipFileName;
                else
                    zipFileToLoad = BattlegroundsFilePathsByBuild.Aggregate((x, y) => Math.Abs(x.Key - build) < Math.Abs(y.Key - build) ? x : y).Value;
            }

            BattlegroundsDataXml = LoadZipFile(Path.Combine(BattlegroundsDirectory, Path.GetFileName(zipFileToLoad)), Path.ChangeExtension(zipFileToLoad, "xml"));
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
            foreach (string filePath in Directory.EnumerateFiles(BattlegroundsDirectory, string.Format(BattlegroundsZipFileFormat, "*")))
            {
                if (int.TryParse(Path.GetFileNameWithoutExtension(filePath).Split('_').Last(), out int buildNumber))
                    BattlegroundsFilePathsByBuild.Add(buildNumber, filePath);
            }

            if (BattlegroundsFilePathsByBuild.Count > 0)
            {
                LowestBuild = BattlegroundsFilePathsByBuild.Keys.Min();
                HighestBuild = BattlegroundsFilePathsByBuild.Keys.Max();
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
