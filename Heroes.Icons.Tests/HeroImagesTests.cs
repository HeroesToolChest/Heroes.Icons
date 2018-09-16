using Heroes.Icons.Images;
using Xunit;

namespace Heroes.Icons.Tests
{
    public class HeroImagesTests : HeroesIconsBase
    {
        private readonly IHeroImagesStream HeroImages;

        public HeroImagesTests()
        {
            HeroImages = HeroesIcons.HeroImages();
        }

        [Fact]
        public void GetTalentImageStreamTest()
        {
            Assert.NotNull(HeroImages.TalentImage("storm_ui_icon_abathur_carapace.png"));
            Assert.NotNull(HeroImages.TalentImage("storm_btn_d3ros_crusader_blessedhammer.png"));
            Assert.NotNull(HeroImages.TalentImage("storm_ui_icon_zuljin_guillotine.png"));
        }

        [Fact]
        public void GetMatchAwardImageStreamTest()
        {
            Assert.NotNull(HeroImages.MatchAwardImage("storm_ui_mvp_teamplayer_{mvpColor}.png", Models.MVPAwardColor.Blue));
            Assert.NotNull(HeroImages.MatchAwardImage("storm_ui_mvp_teamplayer_{mvpColor}.png", Models.MVPAwardColor.Red));
            Assert.NotNull(HeroImages.MatchAwardImage("storm_ui_mvp_teamplayer_{mvpColor}.png", Models.MVPAwardColor.Gold));

            Assert.NotNull(HeroImages.MatchAwardImage("storm_ui_scorescreen_mvp_teamplayer_{mvpColor}.png", Models.MVPAwardColor.Blue));
            Assert.NotNull(HeroImages.MatchAwardImage("storm_ui_scorescreen_mvp_teamplayer_{mvpColor}.png", Models.MVPAwardColor.Red));
            Assert.Null(HeroImages.MatchAwardImage("storm_ui_scorescreen_mvp_teamplayer_{mvpColor}.png", Models.MVPAwardColor.Gold));
        }

        [Fact]
        public void GetBattlegroundImageStreamTest()
        {
            Assert.NotNull(HeroImages.BattlegroundImage("ui_ingame_mapmechanic_loadscreen_gardenofterror.jpg"));
            Assert.NotNull(HeroImages.BattlegroundImage("ui_ingame_mapmechanic_loadscreen_hanamura_rework.jpg"));
            Assert.NotNull(HeroImages.BattlegroundImage("storm_ui_homescreenbackground_wcav.jpg"));
        }

        [Fact]
        public void GetHomescreensImageStreamTest()
        {
            Assert.NotNull(HeroImages.HomescreenImage("storm_ui_homescreenbackground_diablotristram.jpg"));
            Assert.NotNull(HeroImages.HomescreenImage("storm_ui_homescreenbackground_greymane.jpg"));
        }

        [Fact]
        public void GetHeroSelectPortraitImageStreamTest()
        {
            Assert.NotNull(HeroImages.HeroSelectImage("storm_ui_ingame_heroselect_btn_azmodan.png"));
            Assert.NotNull(HeroImages.HeroSelectImage("storm_ui_ingame_heroselect_btn_firebat.png"));
        }

        [Fact]
        public void GetLeaderboardPortraitsImageStreamTest()
        {
            Assert.NotNull(HeroImages.LeaderboardImage("storm_ui_ingame_hero_leaderboard_chen.png"));
            Assert.NotNull(HeroImages.LeaderboardImage("storm_ui_ingame_hero_leaderboard_femalebarbarian.png"));
        }

        [Fact]
        public void GetTargetPortraitsImageStreamTest()
        {
            Assert.NotNull(HeroImages.TargetPortraitImage("ui_targetportrait_hero_demonhunter.png"));
            Assert.NotNull(HeroImages.TargetPortraitImage("ui_targetportrait_hero_junkrat.png"));
        }

        [Fact]
        public void GetHeroFranchiseImageStreamTest()
        {
            Assert.NotNull(HeroImages.HeroFranchiseImage(Heroes.Models.HeroFranchise.Classic));
            Assert.NotNull(HeroImages.HeroFranchiseImage(Heroes.Models.HeroFranchise.Overwatch));
            Assert.NotNull(HeroImages.HeroFranchiseImage(Heroes.Models.HeroFranchise.Warcraft));
            Assert.Null(HeroImages.HeroFranchiseImage(Heroes.Models.HeroFranchise.Unknown));
        }

        [Fact]
        public void GetHeroRoleImageStreamTest()
        {
            Assert.NotNull(HeroImages.HeroRoleImage("Assassin"));
            Assert.NotNull(HeroImages.HeroRoleImage("warrior"));
            Assert.NotNull(HeroImages.HeroRoleImage("support"));
            Assert.NotNull(HeroImages.HeroRoleImage("specialist"));
            Assert.Null(HeroImages.HeroRoleImage("threeforone."));
        }
    }
}
