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
    }
}
