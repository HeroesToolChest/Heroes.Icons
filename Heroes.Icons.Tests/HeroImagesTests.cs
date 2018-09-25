using Heroes.Icons.Models;
using Heroes.Models;
using System.Linq;
using Xunit;

namespace Heroes.Icons.Tests
{
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

        [Fact]
        public void GetTalentImageStreamTest()
        {
            Hero hero = HeroesData.HeroData("Valeera");
            Assert.NotNull(hero.GetTalent("ValeeraSinisterStrike").AbilityTalentImage());
            Assert.NotNull(hero.GetTalent("ValeeraSmokeBomb").AbilityTalentImage());
            Assert.NotNull(hero.GetTalent("ValeeraStealth").AbilityTalentImage());

            Assert.NotNull(hero.GetTalent("nothing").AbilityTalentImage());
            Assert.NotNull(hero.GetTalent(null).AbilityTalentImage());
        }

        [Fact]
        public void GetMatchAwardImageStreamTest()
        {
            MatchAward matchAward = MatchAwards.MatchAward("ZeroOutnumberedDeaths");

            Assert.NotNull(matchAward.MatchAwardMVPScreenImage(MVPAwardColor.Gold));
            Assert.NotNull(matchAward.MatchAwardMVPScreenImage(MVPAwardColor.Blue));
            Assert.NotNull(matchAward.MatchAwardMVPScreenImage(MVPAwardColor.Red));

            Assert.NotNull(matchAward.MatchAwardScoreScreenImage(ScoreScreenAwardColor.Blue));
            Assert.NotNull(matchAward.MatchAwardScoreScreenImage(ScoreScreenAwardColor.Red));
        }

        [Fact]
        public void GetBattlegroundImageStreamTest()
        {
            Battleground battleground = Battlegrounds.Battleground("HauntedWoods");
            Assert.NotNull(battleground.BattlegroundImage());
        }

        [Fact]
        public void GetHomescreensImageStreamTest()
        {
            Homescreen homescreen = Homescreens.Homescreens().ToList().FirstOrDefault();
            Assert.NotNull(homescreen.HomescreenImage());
        }

        [Fact]
        public void GetHeroPortraitImageStreamTests()
        {
            Hero hero = HeroesData.HeroData("Yrel");
            Assert.NotNull(hero.HeroPortrait.HeroSelectImage());
            Assert.NotNull(hero.HeroPortrait.LeaderboardImage());
            Assert.NotNull(hero.HeroPortrait.TargetPortraitImage());
        }

        [Fact]
        public void GetHeroFranchiseImageStreamTest()
        {
            Hero hero = HeroesData.HeroData("Zeratul");
            Assert.NotNull(hero.HeroFranchiseImage());
        }

        [Fact]
        public void GetHeroRoleImageStreamTest()
        {
            Hero hero = HeroesData.HeroData("Anubarak");
            Assert.NotNull(hero.HeroRoleImage());

            hero = HeroesData.HeroData("Varian");
            Assert.NotNull(hero.HeroRoleImage());
        }

        [Fact]
        public void GetPartyIconImageStreamTest()
        {
            Assert.NotNull(ImageStreams.PartyIconImage(PartyIconColor.Blue));
            Assert.NotNull(ImageStreams.PartyIconImage(PartyIconColor.Red));
            Assert.NotNull(ImageStreams.PartyIconImage(PartyIconColor.Yellow));
            Assert.NotNull(ImageStreams.PartyIconImage(PartyIconColor.Teal));
        }

        [Fact]
        public void GetOtherIconImageStreamTest()
        {
            Assert.NotNull(ImageStreams.OtherIconImage(OtherIcon.Assist));
            Assert.NotNull(ImageStreams.OtherIconImage(OtherIcon.HeroDamage));
            Assert.NotNull(ImageStreams.OtherIconImage(OtherIcon.TalentUnavailable));
        }
    }
}
