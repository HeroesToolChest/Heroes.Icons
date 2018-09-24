using Heroes.Icons.Xml;

namespace Heroes.Icons
{
    public interface IHeroesIcons
    {
        /// <summary>
        /// Returns the interface to access hero data based on the latest build.
        /// </summary>
        /// <returns></returns>
        IHeroesData HeroesData();

        /// <summary>
        /// Returns the interface to access hero data based on the specified build.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        IHeroesData HeroesData(int build);

        /// <summary>
        /// Returns the interface to access the hero build data.
        /// </summary>
        /// <returns></returns>
        IHeroBuilds HeroBuilds();

        /// <summary>
        /// Returns the interface to access the match award data on the latest build.
        /// </summary>
        /// <returns></returns>
        IMatchAwards MatchAwards();

        /// <summary>
        /// Returns the interface to access the match award data on the specified build.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        IMatchAwards MatchAwards(int build);

        /// <summary>
        /// Returns the interface to access the battleground data on the latest build.
        /// </summary>
        /// <returns></returns>
        IBattlegrounds Battlegrounds();

        /// <summary>
        /// Returns the interface to access the battleground data on the specified build.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        IBattlegrounds Battlegrounds(int build);

        /// <summary>
        /// Returns the interface to access the homescreens data.
        /// </summary>
        /// <returns></returns>
        IHomescreens Homescreens();
    }
}
