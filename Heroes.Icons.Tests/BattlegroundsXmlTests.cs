using Heroes.Icons.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class BattlegroundsXmlTests : HeroesIconsBase
    {
        private readonly IBattlegrounds Battlegrounds;
        private readonly IBattlegrounds Battlegrounds67621;

        public BattlegroundsXmlTests()
        {
            Battlegrounds = HeroesIcons.Battlegrounds(67985);
            Battlegrounds67621 = HeroesIcons.Battlegrounds(67621);
        }

        [TestMethod]
        public void GetTotalCountOfBattlegroundsTest()
        {
            Assert.AreEqual(15, Battlegrounds67621.Count());
            Assert.AreEqual(26, Battlegrounds67621.Count(true));

            Assert.IsTrue(Battlegrounds.Count() >= 15);
            Assert.IsTrue(Battlegrounds.Count(true) >= 26);
        }

        [TestMethod]
        public void BattlegroundsFromMapIdTest()
        {
            Battleground battleground = Battlegrounds67621.Battleground("HauntedWoods");
            Assert.AreEqual("HauntedWoods", battleground.Id);
            Assert.AreEqual("ui_ingame_mapmechanic_loadscreen_gardenofterror.jpg", battleground.ImageFileName);
            Assert.IsFalse(battleground.IsBrawl);
            Assert.AreEqual("Garden of Terror", battleground.Name);
            Assert.AreEqual("GardenofTerror", battleground.ShortName);
            Assert.AreEqual("#b2d6fe", battleground.TextHexColor);
            Assert.AreEqual("#0078ff", battleground.TextHexGlowColor);
        }

        [TestMethod]
        public void ListOfBrawlBattlegroundsTest()
        {
            Assert.AreEqual(11, Battlegrounds67621.BrawlBattlegrounds().Count());

            IBattlegrounds battlegrounds = HeroesIcons.Battlegrounds();
            Assert.AreEqual(11, battlegrounds.BrawlBattlegrounds().Count());
        }

        [TestMethod]
        public void ListOfBattlegroundsTests()
        {
            Assert.AreEqual(15, Battlegrounds67621.Battlegrounds().Count());
            Assert.AreEqual(26, Battlegrounds67621.Battlegrounds(true).Count());
        }

        [TestMethod]
        public void ListOfBattlegroundAliasesTest()
        {
            Assert.AreEqual(11, Battlegrounds67621.Battleground("逃离布莱克西斯（英雄难度）").GetsListOfAliases().Count());
            Assert.AreEqual(11, Battlegrounds67621.Battleground("a fuite de Braxis (héroïque)").GetsListOfAliases().Count());
            Assert.AreEqual(11, Battlegrounds67621.Battleground("Escape From Braxis (Heroic)").GetsListOfAliases().Count());
        }

        [TestMethod]
        public void LoadCorrectBattlegroundTests()
        {
            IBattlegrounds battleground = HeroesIcons.Battlegrounds(70200);
            battleground.Battleground("Dragon Shire").ImageFileName = "ui_ingame_mapmechanic_loadscreen_dragonshire2.jpg";

            IBattlegrounds battleground2 = HeroesIcons.Battlegrounds(69823);
            battleground2.Battleground("Dragon Shire").ImageFileName = "ui_ingame_mapmechanic_loadscreen_dragonshire.jpg";
        }
    }
}
