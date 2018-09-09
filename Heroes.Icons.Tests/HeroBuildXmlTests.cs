using Heroes.Icons.Models;
using Heroes.Icons.Xml;
using System.Linq;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class HeroBuildXmlTests : HeroesIconsBase
    {
        private readonly IHeroBuildsXml HeroBuildsXml;

        public HeroBuildXmlTests()
        {
            HeroBuildsXml = HeroesIcons.HeroBuilds();
        }

        [Fact]
        public void BuildListExistsTest()
        {
            Assert.True(HeroBuildsXml.Builds.Count > 0);
        }

        [Fact]
        public void NewestBuildTest()
        {
            Assert.True(HeroBuildsXml.Builds.Last() == HeroBuildsXml.NewestBuild.ToString());
        }

        [Fact]
        public void OldestBuildTest()
        {
            Assert.True(HeroBuildsXml.Builds.First() == HeroBuildsXml.OldestBuild.ToString());
        }

        [Fact]
        public void PatchInfoBuildTest()
        {
            GetPatchInfo(HeroBuildsXml.GetPatchInfo(67621));
        }

        [Fact]
        public void PatchInfoFullVersionTest()
        {
            GetPatchInfo(HeroBuildsXml.GetPatchInfo("2.36.2.67621"));
        }

        [Fact]
        public void PatchInfoPreviousSelectedBuildTest()
        {
            HeroPatchInfo heroPatchInfo = HeroBuildsXml.GetPatchInfo(65654);

            Assert.Equal(65617, heroPatchInfo.Build);
            Assert.Equal("2.33.1.65617", heroPatchInfo.FullVersion);
            Assert.Equal("http://us.battle.net/heroes/en/blog/21791354", heroPatchInfo.Link);
            Assert.Equal("Balance", heroPatchInfo.Type);
            Assert.False(heroPatchInfo.IsPrevious);
        }

        private void GetPatchInfo(HeroPatchInfo heroPatchInfo)
        {
            Assert.Equal(67621, heroPatchInfo.Build);
            Assert.Equal("2.36.2.67621", heroPatchInfo.FullVersion);
            Assert.Equal("https://heroesofthestorm.com/en-us/blog/22358469", heroPatchInfo.Link);
            Assert.Equal("Balance", heroPatchInfo.Type);
            Assert.False(heroPatchInfo.IsPrevious);
        }
    }
}
