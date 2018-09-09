using Heroes.Icons.Images;
using Heroes.Icons.Xml;

namespace Heroes.Icons
{
    public class HeroesIcons : IHeroesIcons
    {
        private readonly HeroImageStream HeroImageStream;
        private readonly HeroBuildsXml HeroBuildsXml;
        private readonly HeroDataXml HeroDataXml;

        public HeroesIcons()
        {
            HeroImageStream = new HeroImageStream();
            HeroBuildsXml = new HeroBuildsXml();
            HeroBuildsXml.Initialize();

            HeroDataXml = new HeroDataXml(HeroBuildsXml);
        }

        public IHeroImagesStream HeroImages()
        {
            return HeroImageStream;
        }

        public IHeroDataXml HeroData(int build)
        {
            HeroDataXml.SetSelectedBuild(build);
            return HeroDataXml;
        }

        public IHeroBuildsXml HeroBuilds()
        {
            return HeroBuildsXml;
        }
    }
}
