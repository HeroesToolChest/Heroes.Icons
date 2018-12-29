using Heroes.Icons.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class HeroBuildXmlTests : HeroesIconsBase
    {
        private readonly IHeroBuilds HeroBuildsXml;

        public HeroBuildXmlTests()
        {
            HeroBuildsXml = HeroesIcons.HeroBuilds();
        }

        [TestMethod]
        public void BuildListExistsTest()
        {
            Assert.IsTrue(HeroBuildsXml.Builds.Count > 0);
        }

        [TestMethod]
        public void NewestBuildTest()
        {
            Assert.IsTrue(HeroBuildsXml.Builds.Last() == HeroBuildsXml.NewestBuild.ToString());
        }

        [TestMethod]
        public void OldestBuildTest()
        {
            Assert.IsTrue(HeroBuildsXml.Builds.First() == HeroBuildsXml.OldestBuild.ToString());
        }

        [TestMethod]
        public void PatchInfoBuildTest()
        {
            GetPatchInfo(HeroBuildsXml.GetPatchInfo(67621));
        }

        [TestMethod]
        public void PatchInfoFullVersionTest()
        {
            GetPatchInfo(HeroBuildsXml.GetPatchInfo("2.36.2.67621"));
        }

        [TestMethod]
        public void PatchInfoPreviousSelectedBuildTest()
        {
            HeroPatchInfo heroPatchInfo = HeroBuildsXml.GetPatchInfo(65654);

            Assert.AreEqual(65617, heroPatchInfo.Build);
            Assert.AreEqual("2.33.1.65617", heroPatchInfo.FullVersion);
            Assert.AreEqual("http://us.battle.net/heroes/en/blog/21791354", heroPatchInfo.Link);
            Assert.AreEqual("Balance", heroPatchInfo.Type);
            Assert.IsFalse(heroPatchInfo.IsPrevious);
        }

        private void GetPatchInfo(HeroPatchInfo heroPatchInfo)
        {
            Assert.AreEqual(67621, heroPatchInfo.Build);
            Assert.AreEqual("2.36.2.67621", heroPatchInfo.FullVersion);
            Assert.AreEqual("https://heroesofthestorm.com/en-us/blog/22358469", heroPatchInfo.Link);
            Assert.AreEqual("Balance", heroPatchInfo.Type);
            Assert.IsFalse(heroPatchInfo.IsPrevious);
        }
    }
}
