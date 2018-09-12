using Heroes.Icons.Models;
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

        public Stream MatchAwardImage(string fileName, MVPAwardColor awardColor)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Awards.{fileName.Replace("{mvpColor}", awardColor.ToString().ToLower())}");
        }
    }
}
