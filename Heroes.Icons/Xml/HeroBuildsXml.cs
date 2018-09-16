using Heroes.Icons.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class HeroBuildsXml : XmlBase, IXml, IHeroBuildsXml
    {
        private readonly string BuildsXmlFile = "builds.xml";

        private readonly Dictionary<int, int?> PreviousBuildByBuildNumber = new Dictionary<int, int?>();
        private readonly Dictionary<int, HeroPatchInfo> HeroPatchInfoByBuildNumber = new Dictionary<int, HeroPatchInfo>();

        private readonly string HeroBuildsXmlDirectory;

        public HeroBuildsXml()
        {
            HeroBuildsXmlDirectory = Path.Combine(XmlFolderPath, "HeroBuilds");
        }

        /// <summary>
        /// Gets the oldest build available.
        /// </summary>
        public int OldestBuild { get; private set; }

        /// <summary>
        /// Gets the newest build available.
        /// </summary>
        public int NewestBuild { get; private set; }

        public List<string> Builds { get; private set; } = new List<string>();

        public void Initialize()
        {
            LoadBuildsXml();
        }

        public bool BuildExists(int build)
        {
            return PreviousBuildByBuildNumber.ContainsKey(build);
        }

        public HeroPatchInfo GetPatchInfo(int build)
        {
            return PatchInfo(build);
        }

        public HeroPatchInfo GetPatchInfo(string fullVersion)
        {
            if (int.TryParse(fullVersion.Split('.').Last(), out int build))
            {
                return PatchInfo(build);
            }
            else
            {
                return null;
            }
        }

        private void LoadBuildsXml()
        {
            XDocument buildsXmlData = XDocument.Load(Path.Combine(HeroBuildsXmlDirectory, BuildsXmlFile));
            IEnumerable<XElement> patches = buildsXmlData.Root.Elements("Patch");

            foreach (XElement patch in patches)
            {
                string type = patch.Attribute("type")?.Value;
                string link = patch.Attribute("link")?.Value;
                string previous = patch.Attribute("pre")?.Value;
                string fullVersion = patch.Attribute("version")?.Value;

                int build = 0;

                if (!string.IsNullOrEmpty(fullVersion))
                    build = int.Parse(fullVersion.Split('.').Last());
                else
                    build = int.Parse(patch.Value);

                if (!string.IsNullOrEmpty(previous) && int.TryParse(previous, out int previousBuild))
                    PreviousBuildByBuildNumber[build] = previousBuild;
                else
                    PreviousBuildByBuildNumber[build] = null;

                HeroPatchInfoByBuildNumber[build] = new HeroPatchInfo
                {
                    Build = build,
                    Type = type,
                    Link = link,
                    FullVersion = fullVersion,
                };

                Builds.Add(build.ToString());
            }

            OldestBuild = PreviousBuildByBuildNumber.Keys.Min();
            NewestBuild = PreviousBuildByBuildNumber.Keys.Max();
        }

        private HeroPatchInfo PatchInfo(int build)
        {
            int? previousBuild = GetPreviousBuild(build);
            if (previousBuild.HasValue)
            {
                build = previousBuild.Value;
            }

            if (HeroPatchInfoByBuildNumber.TryGetValue(build, out HeroPatchInfo heroPatchInfo))
                return heroPatchInfo;
            else
                return null;
        }

        private int? GetPreviousBuild(int build)
        {
            if (PreviousBuildByBuildNumber.TryGetValue(build, out int? previousBuild))
            {
                // check to see if it's a previous build
                if (previousBuild.HasValue)
                {
                    return GetPreviousBuild(previousBuild.Value);
                }
                else
                {
                    return build;
                }
            }

            return null;
        }
    }
}
