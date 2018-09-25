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

        public IHeroBuilds HeroBuilds()
        {
            return HeroBuildsXml;
        }

        public IHeroesData HeroesData()
        {
            HeroesDataXml.SetSelectedBuild(int.MaxValue);
            return HeroesDataXml;
        }

        public IHeroesData HeroesData(int build)
        {
            HeroesDataXml.SetSelectedBuild(build);
            return HeroesDataXml;
        }

        public IMatchAwards MatchAwards()
        {
            MatchAwardsXml.SetSelectedBuild(int.MaxValue);
            return MatchAwardsXml;
        }

        public IMatchAwards MatchAwards(int build)
        {
            MatchAwardsXml.SetSelectedBuild(build);
            return MatchAwardsXml;
        }

        public IBattlegrounds Battlegrounds()
        {
            BattlegroundsXml.SetSelectedBuild(int.MaxValue);
            return BattlegroundsXml;
        }

        public IBattlegrounds Battlegrounds(int build)
        {
            BattlegroundsXml.SetSelectedBuild(build);
            return BattlegroundsXml;
        }

        public IHomescreens Homescreens()
        {
            HomescreensXml.SetSelectedBuild(int.MaxValue);
            return HomescreensXml;
        }
    }
}
