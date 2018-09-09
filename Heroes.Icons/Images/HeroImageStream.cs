using System.IO;
using System.Reflection;

namespace Heroes.Icons.Images
{
    internal class HeroImageStream : IHeroImagesStream
    {
        private readonly Assembly HeroesIconsAssembly = Assembly.GetExecutingAssembly();
        private readonly string StreamFilePath = "Heroes.Icons.Images";

        public HeroImageStream()
        {
        }

        public Stream TalentImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Talents.{fileName}");
        }
    }
}
