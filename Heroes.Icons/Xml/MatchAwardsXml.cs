using Heroes.Icons.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class MatchAwardsXml : XmlBase, IInitializable, ISettableBuild, IMatchAwards
    {
        private readonly string MatchAwardsLatestZipFileName = "matchawards.zip";
        private readonly string MatchAwardsZipFilePrefix = "matchawards_";
        private readonly SortedDictionary<int, string> MatchAwardsZipFileNamesByBuild = new SortedDictionary<int, string>();

        private readonly string MatchAwardsAssemblyPath;

        private int LowestBuild;
        private int HighestBuild;
        private int SelectedBuild;
        private XDocument MatchAwardsDataXml;

        public MatchAwardsXml()
        {
            MatchAwardsAssemblyPath = XmlAssemblyPath + ".MatchAwards";
        }

        public void Initialize()
        {
            LoadMatchAwardZipFiles();
        }

        public void SetSelectedBuild(int build)
        {
            if (MatchAwardsDataXml != null && SelectedBuild == build)
                return;

            string zipFileToLoad = MatchAwardsLatestZipFileName;

            if (MatchAwardsZipFileNamesByBuild.Count > 0)
            {
                if (MatchAwardsZipFileNamesByBuild.TryGetValue(build, out string zipFileName))
                    zipFileToLoad = zipFileName;
                else if (build < LowestBuild)
                    zipFileToLoad = MatchAwardsZipFileNamesByBuild[LowestBuild];
                else if (build > HighestBuild)
                    zipFileToLoad = MatchAwardsLatestZipFileName;
                else
                    zipFileToLoad = MatchAwardsZipFileNamesByBuild.Aggregate((x, y) => Math.Abs(x.Key - build) < Math.Abs(y.Key - build) ? x : y).Value;
            }

            SelectedBuild = build;
            MatchAwardsDataXml = LoadZipFileFromManifestStream(HeroesIconsAssembly.GetManifestResourceStream($"{MatchAwardsAssemblyPath}.{zipFileToLoad}"), Path.ChangeExtension(zipFileToLoad, "xml"));
        }

        public IEnumerable<MatchAward> Awards()
        {
            List<MatchAward> matchAwards = new List<MatchAward>();
            foreach (XElement awardElement in MatchAwardsDataXml.Root.Elements())
            {
                matchAwards.Add(GetMatchAwardDataFromDataXml(awardElement));
            }

            return matchAwards;
        }

        public MatchAward MatchAward(string awardId)
        {
            return GetMatchAwardDataFromDataXml(MatchAwardsDataXml.Root.Elements().Where(x => x.Attribute("id")?.Value == awardId).FirstOrDefault());
        }

        public int Count()
        {
            return MatchAwardsDataXml.Root.Elements().Count();
        }

        private void LoadMatchAwardZipFiles()
        {
            IEnumerable<string> resourceNames = HeroesIconsAssembly.GetManifestResourceNames().Where(x => x.StartsWith($"{MatchAwardsAssemblyPath}.{MatchAwardsZipFilePrefix}"));

            foreach (string assemblyPath in resourceNames)
            {
                string fileName = GetAssemblyZipFileName(assemblyPath);
                if (int.TryParse(fileName.Split('_').Last(), out int buildNumber))
                    MatchAwardsZipFileNamesByBuild.Add(buildNumber, fileName);
            }

            if (MatchAwardsZipFileNamesByBuild.Count > 0)
            {
                LowestBuild = MatchAwardsZipFileNamesByBuild.Keys.Min();
                HighestBuild = MatchAwardsZipFileNamesByBuild.Keys.Max();
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
