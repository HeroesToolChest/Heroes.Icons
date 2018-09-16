using Heroes.Icons.Models;
using System.IO;

namespace Heroes.Icons.Images
{
    public interface IHeroImagesStream
    {
        /// <summary>
        /// Returns the image stream for the talent.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <returns></returns>
        Stream TalentImage(string fileName);

        /// <summary>
        /// Returns the image stream for the match award.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <param name="awardColor">The color type of the award.</param>
        /// <returns></returns>
        Stream MatchAwardImage(string fileName, MVPAwardColor awardColor);

        /// <summary>
        /// Returns the image stream for the battleground.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <returns></returns>
        Stream BattlegroundImage(string fileName);

        /// <summary>
        /// Returns the image stream for the homescreen.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <returns></returns>
        Stream HomescreenImage(string fileName);

        /// <summary>
        /// Returns the image stream for the hero select image.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <returns></returns>
        Stream HeroSelectImage(string fileName);

        /// <summary>
        /// Returns the image stream for the leaderboard image.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <returns></returns>
        Stream LeaderboardImage(string fileName);

        /// <summary>
        /// Returns the image stream for the target portrait image.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <returns></returns>
        Stream TargetPortraitImage(string fileName);
    }
}