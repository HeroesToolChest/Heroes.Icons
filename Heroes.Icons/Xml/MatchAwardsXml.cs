using Heroes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class MatchAwardsXml : XmlBase, IInitializable, ISettableBuild, IMatchAwards
    {
        private readonly string MatchAwardsLatestZipFileName = "awards_{0}.zip";
        private readonly string MatchAwardsZipFilePrefix = "awards_";
        private readonly SortedDictionary<int, string> MatchAwardsZipFileNamesByBuild = new SortedDictionary<int, string>();

        private readonly string MatchAwardsAssemblyPath;

        private int LowestBuild;
        private int HighestBuild;
        private int SelectedBuild;
        private XDocument MatchAwardsDataXml;

        public MatchAwardsXml()
        {
            MatchAwardsAssemblyPath = XmlAssemblyPath + ".MatchAwards";
            MatchAwardsLatestZipFileName = string.Format(MatchAwardsLatestZipFileName, Localization);
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
            return GetMatchAwardDataFromDataXml(MatchAwardsDataXml.Root.Element(awardId));
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
                if (int.TryParse(fileName.Split('_')[1], out int buildNumber))
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
                ShortName = matchAwardElement.Name.LocalName,
                Tag = matchAwardElement.Attribute("tag")?.Value,
                Name = matchAwardElement.Attribute("name")?.Value,
                MVPScreenImageFileName = matchAwardElement.Element("MVPScreenIcon")?.Value,
                ScoreScreenImageFileName = matchAwardElement.Element("ScoreScreenIcon")?.Value,
                Description = new TooltipDescription(matchAwardElement.Element("Description")?.Value),
            };

            return matchAward;
        }
    }
}
