using Heroes.Icons.Images;
using Heroes.Icons.Xml;

namespace Heroes.Icons
{
    public class HeroesIcons : IHeroesIcons
    {
        private readonly HeroBuildsXml HeroBuildsXml;
        private readonly HeroesDataXml HeroesDataXml;
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
            HeroesDataXml = new HeroesDataXml(HeroBuildsXml);
            HeroesDataXml.Initialize();
        }

        public static IHeroImagesStream HeroImages()
        {
            return new HeroImageStream();
        }

        public IHeroBuildsXml HeroBuilds()
        {
            return HeroBuildsXml;
        }

        public IHeroesDataXml HeroesData()
        {
            HeroesDataXml.SetSelectedBuild(int.MaxValue);
            return HeroesDataXml;
        }

        public IHeroesDataXml HeroData(int build)
        {
            HeroesDataXml.SetSelectedBuild(build);
            return HeroesDataXml;
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
