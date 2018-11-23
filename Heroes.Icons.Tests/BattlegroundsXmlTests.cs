using Heroes.Icons.Models;
using System.Linq;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class BattlegroundsXmlTests : HeroesIconsBase
    {
        private readonly IBattlegrounds Battlegrounds;
        private readonly IBattlegrounds Battlegrounds67621;

        public BattlegroundsXmlTests()
        {
            Battlegrounds = HeroesIcons.Battlegrounds(67985);
            Battlegrounds67621 = HeroesIcons.Battlegrounds(67621);
        }

        [Fact]
        public void GetTotalCountOfBattlegroundsTest()
        {
            Assert.Equal(15, Battlegrounds67621.Count());
            Assert.Equal(26, Battlegrounds67621.Count(true));

            Assert.True(Battlegrounds.Count() >= 15);
            Assert.True(Battlegrounds.Count(true) >= 26);
        }

        [Fact]
        public void BattlegroundsFromMapIdTest()
        {
            Battleground battleground = Battlegrounds67621.Battleground("HauntedWoods");
            Assert.Equal("HauntedWoods", battleground.Id);
            Assert.Equal("ui_ingame_mapmechanic_loadscreen_gardenofterror.jpg", battleground.ImageFileName);
            Assert.False(battleground.IsBrawl);
            Assert.Equal("Garden of Terror", battleground.Name);
            Assert.Equal("GardenofTerror", battleground.ShortName);
            Assert.Equal("#b2d6fe", battleground.TextHexColor);
            Assert.Equal("#0078ff", battleground.TextHexGlowColor);
        }

        [Fact]
        public void ListOfBrawlBattlegroundsTest()
        {
            Assert.Equal(11, Battlegrounds67621.BrawlBattlegrounds().Count());

            IBattlegrounds battlegrounds = HeroesIcons.Battlegrounds();
            Assert.Equal(11, battlegrounds.BrawlBattlegrounds().Count());
        }

        [Fact]
        public void ListOfBattlegroundsTests()
        {
            Assert.Equal(15, Battlegrounds67621.Battlegrounds().Count());
            Assert.Equal(26, Battlegrounds67621.Battlegrounds(true).Count());
        }

        [Fact]
        public void ListOfBattlegroundAliasesTest()
        {
            Assert.Equal(11, Battlegrounds67621.Battleground("逃离布莱克西斯（英雄难度）").GetsListOfAliases().Count());
            Assert.Equal(11, Battlegrounds67621.Battleground("a fuite de Braxis (héroïque)").GetsListOfAliases().Count());
            Assert.Equal(11, Battlegrounds67621.Battleground("Escape From Braxis (Heroic)").GetsListOfAliases().Count());
        }

        [Fact]
        public void LoadCorrectBattlegroundTests()
        {
            IBattlegrounds battleground = HeroesIcons.Battlegrounds(70200);
            battleground.Battleground("Dragon Shire").ImageFileName = "ui_ingame_mapmechanic_loadscreen_dragonshire2.jpg";

            IBattlegrounds battleground2 = HeroesIcons.Battlegrounds(69823);
            battleground2.Battleground("Dragon Shire").ImageFileName = "ui_ingame_mapmechanic_loadscreen_dragonshire.jpg";
        }
    }
}
