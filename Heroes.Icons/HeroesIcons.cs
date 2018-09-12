using Heroes.Icons.Images;
using Heroes.Icons.Xml;

namespace Heroes.Icons
{
    public class HeroesIcons : IHeroesIcons
    {
        private readonly HeroImageStream HeroImageStream;
        private readonly HeroBuildsXml HeroBuildsXml;
        private readonly HeroDataXml HeroDataXml;
        private readonly MatchAwardsXml MatchAwardsXml;

        public HeroesIcons()
        {
            HeroImageStream = new HeroImageStream();
            HeroBuildsXml = new HeroBuildsXml();
            MatchAwardsXml = new MatchAwardsXml();

            HeroBuildsXml.Initialize();
            MatchAwardsXml.Initialize();

            HeroDataXml = new HeroDataXml(HeroBuildsXml);
        }

        public IHeroImagesStream HeroImages()
        {
            return HeroImageStream;
        }

        public IHeroBuildsXml HeroBuilds()
        {
            return HeroBuildsXml;
        }

        public IHeroDataXml HeroData(int build)
        {
            HeroDataXml.SetSelectedBuild(build);
            return HeroDataXml;
        }

        public IMatchAwardsXml MatchAwards(int build)
        {
            MatchAwardsXml.SetSelectedBuild(build);
            return MatchAwardsXml;
        }
    }
}
