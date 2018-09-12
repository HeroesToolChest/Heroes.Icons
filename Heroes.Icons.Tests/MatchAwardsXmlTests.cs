using Heroes.Icons.Models;
using Heroes.Icons.Xml;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class MatchAwardsXmlTests : HeroesIconsBase
    {
        private readonly IMatchAwardsXml MatchAwards;

        public MatchAwardsXmlTests()
        {
            MatchAwards = HeroesIcons.MatchAwards(67985);
        }

        [Fact]
        public void GetTotalCountOfAwardsTest()
        {
            Assert.True(MatchAwards.TotalCountOfAwards() >= 37);
        }

        [Fact]
        public void GetListOfAwardsTest()
        {
            Assert.True(MatchAwards.ListOfAwards().Count == MatchAwards.TotalCountOfAwards());
        }

        [Fact]
        public void MatchAwardsFromIdTest()
        {
            MatchAward matchAward = MatchAwards.GetMatchAward("ZeroOutnumberedDeaths");
            Assert.Equal("Team Player", matchAward.Name);
            Assert.Equal("ZeroOutnumberedDeaths", matchAward.Id);
            Assert.Equal("TeamPlayer", matchAward.ShortName);
            Assert.Equal("storm_ui_mvp_teamplayer_{mvpColor}.png", matchAward.MVPScreenImageFileName);
            Assert.Equal("storm_ui_scorescreen_mvp_teamplayer_{mvpColor}.png", matchAward.ScoreScreenImageFileName);
            Assert.Equal("No Deaths While Outnumbered", matchAward.Description);
        }
    }
}
