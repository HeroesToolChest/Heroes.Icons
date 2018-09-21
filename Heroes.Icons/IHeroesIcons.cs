using Heroes.Icons.Images;
using Heroes.Icons.Xml;

namespace Heroes.Icons
{
    public interface IHeroesIcons
    {
        /// <summary>
        /// Returns the interface to access image streams.
        /// </summary>
        /// <returns></returns>
        IHeroImagesStream HeroImages();

        /// <summary>
        /// Returns the interface to access hero data based on the latest build.
        /// </summary>
        /// <returns></returns>
        IHeroDataXml HeroData();

        /// <summary>
        /// Returns the interface to access hero data based on the specified build.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        IHeroDataXml HeroData(int build);

        /// <summary>
        /// Returns the interface to access the hero build data.
        /// </summary>
        /// <returns></returns>
        IHeroBuildsXml HeroBuilds();

        /// <summary>
        /// Returns the interface to access the match award data on the latest build.
        /// </summary>
        /// <returns></returns>
        IMatchAwardsXml MatchAwards();

        /// <summary>
        /// Returns the interface to access the match award data on the specified build.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        IMatchAwardsXml MatchAwards(int build);

        /// <summary>
        /// Returns the interface to access the battleground data on the latest build.
        /// </summary>
        /// <returns></returns>
        IBattlegroundsXml Battlegrounds();

        /// <summary>
        /// Returns the interface to access the battleground data on the specified build.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        IBattlegroundsXml Battlegrounds(int build);

        /// <summary>
        /// Returns the interface to access the homescreens data.
        /// </summary>
        /// <returns></returns>
        IHomescreensXml Homescreens();
    }
}
