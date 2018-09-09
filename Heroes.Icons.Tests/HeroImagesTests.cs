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
        public void GetImageStreamTest()
        {
            Assert.NotNull(HeroImages.TalentImage("storm_ui_icon_abathur_carapace.png"));
            Assert.NotNull(HeroImages.TalentImage("storm_btn_d3ros_crusader_blessedhammer.png"));
            Assert.NotNull(HeroImages.TalentImage("storm_ui_icon_zuljin_guillotine.png"));
        }
    }
}
