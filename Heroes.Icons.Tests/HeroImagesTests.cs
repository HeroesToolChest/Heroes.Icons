using Heroes.Icons.Models;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class HeroImagesTests : HeroesIconsBase
    {
        private readonly IHeroesData HeroesData;
        private readonly IMatchAwards MatchAwards;
        private readonly IBattlegrounds Battlegrounds;
        private readonly IHomescreens Homescreens;

        public HeroImagesTests()
        {
            HeroesData = HeroesIcons.HeroesData(67143);
            MatchAwards = HeroesIcons.MatchAwards(67143);
            Battlegrounds = HeroesIcons.Battlegrounds(67143);
            Homescreens = HeroesIcons.Homescreens();
        }

        [TestMethod]
        public void GetTalentImageStreamTest()
        {
            Hero hero = HeroesData.HeroData("Valeera");
            Assert.IsNotNull(hero.GetTalent("ValeeraSinisterStrike").AbilityTalentImage());
            Assert.IsNotNull(hero.GetTalent("ValeeraSmokeBomb").AbilityTalentImage());
            Assert.IsNotNull(hero.GetTalent("ValeeraStealth").AbilityTalentImage());

            Assert.IsNotNull(hero.GetTalent("nothing").AbilityTalentImage());
            Assert.IsNotNull(hero.GetTalent(null).AbilityTalentImage());
        }

        [TestMethod]
        public void GetMatchAwardImageStreamTest()
        {
            MatchAward matchAward = MatchAwards.MatchAward("ZeroOutnumberedDeaths");

            Assert.IsNotNull(matchAward.MatchAwardMVPScreenImage(MVPAwardColor.Gold));
            Assert.IsNotNull(matchAward.MatchAwardMVPScreenImage(MVPAwardColor.Blue));
            Assert.IsNotNull(matchAward.MatchAwardMVPScreenImage(MVPAwardColor.Red));

            Assert.IsNotNull(matchAward.MatchAwardScoreScreenImage(ScoreScreenAwardColor.Blue));
            Assert.IsNotNull(matchAward.MatchAwardScoreScreenImage(ScoreScreenAwardColor.Red));
        }

        [TestMethod]
        public void GetBattlegroundImageStreamTest()
        {
            Battleground battleground = Battlegrounds.Battleground("HauntedWoods");
            Assert.IsNotNull(battleground.BattlegroundImage());
        }

        [TestMethod]
        public void GetHomescreensImageStreamTest()
        {
            Homescreen homescreen = Homescreens.Homescreens().ToList().FirstOrDefault();
            Assert.IsNotNull(homescreen.HomescreenImage());
        }

        [TestMethod]
        public void GetHeroPortraitImageStreamTests()
        {
            Hero hero = HeroesData.HeroData("Yrel");
            Assert.IsNotNull(hero.HeroPortrait.HeroSelectImage());
            Assert.IsNotNull(hero.HeroPortrait.LeaderboardImage());
            Assert.IsNotNull(hero.HeroPortrait.TargetPortraitImage());
        }

        [TestMethod]
        public void GetHeroFranchiseImageStreamTest()
        {
            Hero hero = HeroesData.HeroData("Zeratul");
            Assert.IsNotNull(hero.HeroFranchiseImage());
        }

        [TestMethod]
        public void GetHeroRoleImageStreamTest()
        {
            Hero hero = HeroesData.HeroData("Anubarak");
            Assert.IsNotNull(hero.HeroRoleImage());

            hero = HeroesData.HeroData("Varian");
            Assert.IsNotNull(hero.HeroRoleImage());
        }

        [TestMethod]
        public void GetPartyIconImageStreamTest()
        {
            Assert.IsNotNull(ImageStreams.PartyIconImage(PartyIconColor.Blue));
            Assert.IsNotNull(ImageStreams.PartyIconImage(PartyIconColor.Red));
            Assert.IsNotNull(ImageStreams.PartyIconImage(PartyIconColor.Yellow));
            Assert.IsNotNull(ImageStreams.PartyIconImage(PartyIconColor.Teal));
        }

        [TestMethod]
        public void GetOtherIconImageStreamTest()
        {
            Assert.IsNotNull(ImageStreams.OtherIconImage(OtherIcon.Assist));
            Assert.IsNotNull(ImageStreams.OtherIconImage(OtherIcon.HeroDamage));
            Assert.IsNotNull(ImageStreams.OtherIconImage(OtherIcon.TalentUnavailable));
        }
    }
}
