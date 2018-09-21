using Heroes.Icons.Models;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class HeroImagesTests : HeroesIconsBase
    {
        public HeroImagesTests()
        {
        }

        [Fact]
        public void GetTalentImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().TalentImage("storm_ui_icon_abathur_carapace.png"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().TalentImage("storm_btn_d3ros_crusader_blessedhammer.png"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().TalentImage("storm_ui_icon_zuljin_guillotine.png"));
        }

        [Fact]
        public void GetMatchAwardImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().MatchAwardImage("storm_ui_mvp_teamplayer_{mvpColor}.png", MVPAwardColor.Blue));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().MatchAwardImage("storm_ui_mvp_teamplayer_{mvpColor}.png", MVPAwardColor.Red));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().MatchAwardImage("storm_ui_mvp_teamplayer_{mvpColor}.png", MVPAwardColor.Gold));

            Assert.NotNull(Icons.HeroesIcons.HeroImages().MatchAwardImage("storm_ui_scorescreen_mvp_teamplayer_{mvpColor}.png", MVPAwardColor.Blue));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().MatchAwardImage("storm_ui_scorescreen_mvp_teamplayer_{mvpColor}.png", MVPAwardColor.Red));
            Assert.Null(Icons.HeroesIcons.HeroImages().MatchAwardImage("storm_ui_scorescreen_mvp_teamplayer_{mvpColor}.png", MVPAwardColor.Gold));
        }

        [Fact]
        public void GetBattlegroundImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().BattlegroundImage("ui_ingame_mapmechanic_loadscreen_gardenofterror.jpg"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().BattlegroundImage("ui_ingame_mapmechanic_loadscreen_hanamura_rework.jpg"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().BattlegroundImage("storm_ui_homescreenbackground_wcav.jpg"));
        }

        [Fact]
        public void GetHomescreensImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HomescreenImage("storm_ui_homescreenbackground_diablotristram.jpg"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HomescreenImage("storm_ui_homescreenbackground_greymane.jpg"));
        }

        [Fact]
        public void GetHeroSelectPortraitImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroSelectImage("storm_ui_ingame_heroselect_btn_azmodan.png"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroSelectImage("storm_ui_ingame_heroselect_btn_firebat.png"));
        }

        [Fact]
        public void GetLeaderboardPortraitsImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().LeaderboardImage("storm_ui_ingame_hero_leaderboard_chen.png"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().LeaderboardImage("storm_ui_ingame_hero_leaderboard_femalebarbarian.png"));
        }

        [Fact]
        public void GetTargetPortraitsImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().TargetPortraitImage("ui_targetportrait_hero_demonhunter.png"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().TargetPortraitImage("ui_targetportrait_hero_junkrat.png"));
        }

        [Fact]
        public void GetHeroFranchiseImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroFranchiseImage(Heroes.Models.HeroFranchise.Classic));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroFranchiseImage(Heroes.Models.HeroFranchise.Overwatch));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroFranchiseImage(Heroes.Models.HeroFranchise.Warcraft));
            Assert.Null(Icons.HeroesIcons.HeroImages().HeroFranchiseImage(Heroes.Models.HeroFranchise.Unknown));
        }

        [Fact]
        public void GetHeroRoleImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroRoleImage("Assassin"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroRoleImage("warrior"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroRoleImage("support"));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().HeroRoleImage("specialist"));
            Assert.Null(Icons.HeroesIcons.HeroImages().HeroRoleImage("threeforone."));
        }

        [Fact]
        public void GetPartyIconImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().PartyIconImage(PartyIconColor.Blue));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().PartyIconImage(PartyIconColor.Red));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().PartyIconImage(PartyIconColor.Yellow));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().PartyIconImage(PartyIconColor.Teal));
        }

        [Fact]
        public void GetOtherIconImageStreamTest()
        {
            Assert.NotNull(Icons.HeroesIcons.HeroImages().OtherIconImage(OtherIcon.Assist));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().OtherIconImage(OtherIcon.HeroDamage));
            Assert.NotNull(Icons.HeroesIcons.HeroImages().OtherIconImage(OtherIcon.TalentUnavailable));
        }
    }
}
