using System.IO;

namespace Heroes.Icons.Images
{
    public interface IHeroImagesStream
    {
        /// <summary>
        /// Returns the image Stream.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <returns></returns>
        Stream TalentImage(string fileName);
    }
}