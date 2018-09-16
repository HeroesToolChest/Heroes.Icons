using Heroes.Icons.Models;
using Heroes.Icons.Xml;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class BattlegroundsXmlTests : HeroesIconsBase
    {
        private readonly IBattlegroundsXml Battlegrounds;
        private readonly IBattlegroundsXml Battlegrounds67621;

        public BattlegroundsXmlTests()
        {
            Battlegrounds = HeroesIcons.Battlegrounds(67985);
            Battlegrounds67621 = HeroesIcons.Battlegrounds(67621);
        }

        [Fact]
        public void GetTotalCountOfBattlegroundsTest()
        {
            Assert.Equal(15, Battlegrounds67621.TotalCountOfBattlegrounds());
            Assert.Equal(26, Battlegrounds67621.TotalCountOfBattlegrounds(true));

            Assert.True(Battlegrounds.TotalCountOfBattlegrounds() >= 15);
            Assert.True(Battlegrounds.TotalCountOfBattlegrounds(true) >= 26);
        }

        [Fact]
        public void BattlegroundsFromMapIdTest()
        {
            Battleground battleground = Battlegrounds67621.GetBattleground("HauntedWoods");
            Assert.Equal("HauntedWoods", battleground.Id);
            Assert.Equal("ui_ingame_mapmechanic_loadscreen_gardenofterror.jpg", battleground.Image);
            Assert.False(battleground.IsBrawl);
            Assert.Equal("Garden of Terror", battleground.Name);
            Assert.Equal("GardenofTerror", battleground.ShortName);
            Assert.Equal("b2d6fe", battleground.TextColor);
            Assert.Equal("0078ff", battleground.TextGlowColor);
        }

        [Fact]
        public void ListOfBrawlBattlegroundsTest()
        {
            Assert.Equal(11, Battlegrounds67621.ListOfBrawlBattlegrounds().Count);
        }

        [Fact]
        public void ListOfBattlegroundsTests()
        {
            Assert.Equal(15, Battlegrounds67621.ListOfBattlegrounds().Count);
            Assert.Equal(26, Battlegrounds67621.ListOfBattlegrounds(true).Count);
        }
    }
}
