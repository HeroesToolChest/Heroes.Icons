using Heroes.Icons.Models;
using Heroes.Models;
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

        public Stream BattlegroundImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Battlegrounds.{fileName}");
        }

        public Stream HomescreenImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Homescreens.{fileName}");
        }

        public Stream HeroSelectImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.HeroSelectPortraits.{fileName}");
        }

        public Stream LeaderboardImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.LeaderboardPortraits.{fileName}");
        }

        public Stream TargetPortraitImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.TargetPortraits.{fileName}");
        }

        public Stream HeroFranchiseImage(HeroFranchise heroFranchise)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Franchises.hero_franchise_{heroFranchise.ToString().ToLower()}.png");
        }

        public Stream HeroRoleImage(string heroRole)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Roles.hero_role_{heroRole.ToLower()}.png");
        }
    }
}
