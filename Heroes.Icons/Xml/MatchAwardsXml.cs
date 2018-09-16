using Heroes.Icons.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class MatchAwardsXml : XmlBase, IXml, IXmlMultipleBuild, IMatchAwardsXml
    {
        private readonly string MatchAwardsLatestZipFileName = "matchawards.zip";
        private readonly string MatchAwardsZipFileFormat = "matchawards_{0}.zip";
        private readonly SortedDictionary<int, string> MatchAwardsFilePathsByBuild = new SortedDictionary<int, string>();

        private readonly string MatchAwardsDirectory;

        private int LowestBuild;
        private int HighestBuild;
        private XDocument MatchAwardsDataXml;

        public MatchAwardsXml()
        {
            MatchAwardsDirectory = Path.Combine(XmlFolderPath, "MatchAwards");
        }

        public void Initialize()
        {
            LoadMatchAwardFiles();
        }

        public void SetSelectedBuild(int build)
        {
            string zipFileToLoad = MatchAwardsLatestZipFileName;

            if (MatchAwardsFilePathsByBuild.Count > 0)
            {
                if (MatchAwardsFilePathsByBuild.TryGetValue(build, out string filePath))
                    zipFileToLoad = Path.GetFileName(filePath);
                else if (build < LowestBuild)
                    zipFileToLoad = MatchAwardsFilePathsByBuild[LowestBuild];
                else if (build > HighestBuild)
                    zipFileToLoad = MatchAwardsLatestZipFileName;
                else
                    zipFileToLoad = MatchAwardsFilePathsByBuild.Aggregate((x, y) => Math.Abs(x.Key - build) < Math.Abs(y.Key - build) ? x : y).Value;
            }

            MatchAwardsDataXml = LoadZipFile(Path.Combine(MatchAwardsDirectory, zipFileToLoad), Path.ChangeExtension(zipFileToLoad, "xml"));
        }

        public List<MatchAward> ListOfAwards()
        {
            List<MatchAward> matchAwards = new List<MatchAward>();
            foreach (XElement awardElement in MatchAwardsDataXml.Root.Elements())
            {
                matchAwards.Add(GetMatchAwardDataFromDataXml(awardElement));
            }

            return matchAwards;
        }

        public MatchAward GetMatchAward(string awardId)
        {
            return GetMatchAwardDataFromDataXml(MatchAwardsDataXml.Root.Elements().Where(x => x.Attribute("id")?.Value == awardId).FirstOrDefault());
        }

        public int TotalCountOfAwards()
        {
            return MatchAwardsDataXml.Root.Elements().Count();
        }

        private void LoadMatchAwardFiles()
        {
            foreach (string filePath in Directory.EnumerateFiles(MatchAwardsDirectory, string.Format(MatchAwardsZipFileFormat, "*")))
            {
                if (int.TryParse(Path.GetFileNameWithoutExtension(filePath).Split('_').Last(), out int buildNumber))
                    MatchAwardsFilePathsByBuild.Add(buildNumber, filePath);
            }

            if (MatchAwardsFilePathsByBuild.Count > 0)
            {
                LowestBuild = MatchAwardsFilePathsByBuild.Keys.Min();
                HighestBuild = MatchAwardsFilePathsByBuild.Keys.Max();
            }
            else
            {
                LowestBuild = 0;
                HighestBuild = int.MaxValue;
            }
        }

        private MatchAward GetMatchAwardDataFromDataXml(XElement matchAwardElement)
        {
            if (matchAwardElement == null)
                return null;

            MatchAward matchAward = new MatchAward()
            {
                Id = matchAwardElement.Attribute("id")?.Value,
                ShortName = matchAwardElement.Name.LocalName,
                Name = matchAwardElement.Name.LocalName,
                MVPScreenImageFileName = matchAwardElement.Element("MVPScreen")?.Value,
                ScoreScreenImageFileName = matchAwardElement.Element("ScoreScreen")?.Value,
                Description = matchAwardElement.Element("Description")?.Value,
            };

            string name = matchAwardElement.Attribute("name")?.Value;
            if (!string.IsNullOrEmpty(name))
                matchAward.Name = name;

            return matchAward;
        }
    }
}
