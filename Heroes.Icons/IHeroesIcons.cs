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
        /// Returns the interface to access the match awards data.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        IMatchAwardsXml MatchAwards(int build);
    }
}
