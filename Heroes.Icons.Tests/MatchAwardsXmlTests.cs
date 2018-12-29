using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class MatchAwardsXmlTests : HeroesIconsBase
    {
        private readonly IMatchAwards MatchAwards;

        public MatchAwardsXmlTests()
        {
            MatchAwards = HeroesIcons.MatchAwards(67985);
        }

        [TestMethod]
        public void GetTotalCountOfAwardsTest()
        {
            Assert.IsTrue(MatchAwards.Count() >= 37);
        }

        [TestMethod]
        public void GetListOfAwardsTest()
        {
            Assert.IsTrue(MatchAwards.Awards().Count() == MatchAwards.Count());

            IMatchAwards matchAwards = HeroesIcons.MatchAwards();
            Assert.IsTrue(matchAwards.Awards().Count() == MatchAwards.Count());
        }

        [TestMethod]
        public void MatchAwardsFromIdTest()
        {
            MatchAward matchAward = MatchAwards.MatchAward("ZeroOutnumberedDeaths");
            Assert.AreEqual("Team Player", matchAward.Name);
            Assert.AreEqual("ZeroOutnumberedDeaths", matchAward.ShortName);
            Assert.AreEqual("storm_ui_mvp_teamplayer_%color%.png", matchAward.MVPScreenImageFileName);
            Assert.AreEqual("storm_ui_scorescreen_mvp_teamplayer_%team%.png", matchAward.ScoreScreenImageFileName);
            Assert.AreEqual("No Deaths While Outnumbered", matchAward.Description.PlainText);
        }
    }
}
