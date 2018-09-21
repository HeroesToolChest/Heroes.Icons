using Heroes.Icons.Images;
using Heroes.Icons.Xml;

namespace Heroes.Icons
{
    public class HeroesIcons : IHeroesIcons
    {
        private readonly HeroBuildsXml HeroBuildsXml;
        private readonly HeroDataXml HeroDataXml;
        private readonly MatchAwardsXml MatchAwardsXml;
        private readonly BattlegroundsXml BattlegroundsXml;
        private readonly HomescreensXml HomescreensXml;

        public HeroesIcons()
        {
            HeroBuildsXml = new HeroBuildsXml();
            MatchAwardsXml = new MatchAwardsXml();
            BattlegroundsXml = new BattlegroundsXml();
            HomescreensXml = new HomescreensXml();

            HeroBuildsXml.Initialize();
            MatchAwardsXml.Initialize();
            BattlegroundsXml.Initialize();
            HomescreensXml.Initialize();

            // last
            HeroDataXml = new HeroDataXml(HeroBuildsXml);
            HeroDataXml.Initialize();
        }

        public static IHeroImagesStream HeroImages()
        {
            return new HeroImageStream();
        }

        public IHeroBuildsXml HeroBuilds()
        {
            return HeroBuildsXml;
        }

        public IHeroDataXml HeroData()
        {
            HeroDataXml.SetSelectedBuild(int.MaxValue);
            return HeroDataXml;
        }

        public IHeroDataXml HeroData(int build)
        {
            HeroDataXml.SetSelectedBuild(build);
            return HeroDataXml;
        }

        public IMatchAwardsXml MatchAwards()
        {
            MatchAwardsXml.SetSelectedBuild(int.MaxValue);
            return MatchAwardsXml;
        }

        public IMatchAwardsXml MatchAwards(int build)
        {
            MatchAwardsXml.SetSelectedBuild(build);
            return MatchAwardsXml;
        }

        public IBattlegroundsXml Battlegrounds()
        {
            BattlegroundsXml.SetSelectedBuild(int.MaxValue);
            return BattlegroundsXml;
        }

        public IBattlegroundsXml Battlegrounds(int build)
        {
            BattlegroundsXml.SetSelectedBuild(build);
            return BattlegroundsXml;
        }

        public IHomescreensXml Homescreens()
        {
            HomescreensXml.SetSelectedBuild(int.MaxValue);
            return HomescreensXml;
        }
    }
}
