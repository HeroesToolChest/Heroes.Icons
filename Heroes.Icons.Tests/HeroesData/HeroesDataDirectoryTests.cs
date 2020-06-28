using Heroes.Icons.DataDocument;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Heroes.Icons.HeroesData.Tests
{
    [TestClass]
    public class HeroesDataDirectoryTests
    {
        private readonly string _testFolder = "heroesdataTestFolders";
        private readonly HeroesDataDirectory _heroesDataDirectory;

        public HeroesDataDirectoryTests()
        {
            _heroesDataDirectory = new HeroesDataDirectory("heroesdataTestFolders");
        }

        [TestMethod]
        public void HeroesDataDirectoryContructorThrowExceptionsTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new HeroesDataDirectory(null!));
            Assert.ThrowsException<ArgumentException>(() => new HeroesDataDirectory(string.Empty));
            Assert.ThrowsException<DirectoryNotFoundException>(() => new HeroesDataDirectory("someDirectory"));
        }

        [TestMethod]
        public void NoVersionsLoadedTest()
        {
            HeroesDataDirectory heroesDataDirectory = new HeroesDataDirectory(Path.Join("heroesdataTestFolders", "someOther"));
            Assert.IsNull(heroesDataDirectory.NewestVersion);
            Assert.IsNull(heroesDataDirectory.OldestVersion);
        }

        [TestMethod]
        public void GetVersionsStaticMethodTest()
        {
            List<HeroesDataVersion> list = HeroesDataDirectory.GetVersions(_testFolder).OrderByDescending(x => x).ToList();
            Assert.AreEqual(0, list.Where(x => x.IsPtr).Count());
            Assert.AreEqual(6, list.Count);

            List<HeroesDataVersion> listWithPtr = HeroesDataDirectory.GetVersions(_testFolder, true).OrderByDescending(x => x).ToList();
            Assert.IsTrue(listWithPtr.Where(x => x.IsPtr).Any());
            Assert.AreEqual(8, listWithPtr.Count);
        }

        [TestMethod]
        public void GetVersionsStaticMethodExceptionsTest()
        {
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(null!).ToList());
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(string.Empty).ToList());
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(" ").ToList());
        }

        [TestMethod]
        public void VersionExistsStaticMethodTest()
        {
            Assert.IsTrue(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(2, 47, 3, 76124)));
            Assert.IsTrue(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(2, 48, 0, 76268, true)));
            Assert.IsFalse(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(77, 23, 1, 76268, true)));
        }

        [TestMethod]
        public void VersionExistsStaticMethodExceptionsTest()
        {
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(null!, new HeroesDataVersion(1, 1, 1, 1)));
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(string.Empty, new HeroesDataVersion(1, 1, 1, 1)));
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(" ", new HeroesDataVersion(1, 1, 1, 1)));
            Assert.ThrowsException<ArgumentNullException>(() => HeroesDataDirectory.VersionExists("path", null!));
        }

        [TestMethod]
        public void VersionsTest()
        {
            List<HeroesDataVersion> list = _heroesDataDirectory.Versions.ToList();
            Assert.AreEqual(8, list.Count);
        }

        [TestMethod]
        public void VersionExistsTest()
        {
            Assert.IsFalse(_heroesDataDirectory.VersionExists(new HeroesDataVersion(-1, 234, 234, 34234234)));
            Assert.IsTrue(_heroesDataDirectory.VersionExists(new HeroesDataVersion(2, 47, 3, 76124)));
        }

        [TestMethod]
        public void BuildExistsTest()
        {
            Assert.IsFalse(_heroesDataDirectory.BuildExists(34234234));
            Assert.IsTrue(_heroesDataDirectory.BuildExists(76124));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        [DataRow(2, 40, 3, 70000, false, false, Localization.KOKR)]
        [DataRow(2, 48, 3, 77205, false, false, Localization.KOKR)]
        [DataRow(2, 48, 3, 77205, false, true, Localization.KOKR)]
        [DataRow(2, 48, 4, 77406, false, true, Localization.KOKR)]
        [DataRow(2, 48, 4, 77407, false, true, Localization.KOKR)]
        [DataRow(8, 50, 3, 9999999, false, false, Localization.KOKR)]
        public void HeroDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            HeroDataDocument dataDocument = _heroesDataDirectory.HeroData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetHeroById("Abathur", out Hero? hero, false, false, false, false));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
        }

        [DataTestMethod]
        [DataRow(2, 48, 3, 77205, false, true, Localization.KOKR)]
        public void HeroDataLoadDuplicateDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            HeroDataDocument heroDataDocument = _heroesDataDirectory.HeroData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(heroDataDocument.TryGetHeroById("Abathur", out Hero? hero, false, false, false, false));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty("this is some text."));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void AnnouncerDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            AnnouncerDataDocument dataDocument = _heroesDataDirectory.AnnouncerData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetAnnouncerById("AbathurA", out Announcer? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false)]
        public void BehaviorVeterancyDataTest(int major, int minor, int revision, int build, bool isPtr)
        {
            BehaviorVeterancyDataDocument dataDocument = _heroesDataDirectory.BehaviorVeterancyData(new HeroesDataVersion(major, minor, revision, build, isPtr));
            Assert.IsTrue(dataDocument.TryGetBehaviorVeterancyById("alteracpass-CoreScaling", out BehaviorVeterancy? value));

            Assert.IsTrue(value!.CombineModifications);
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void EmoticonDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            EmoticonDataDocument dataDocument = _heroesDataDirectory.EmoticonData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetEmoticonById("cat_blink_anim", out Emoticon? value));

            if (gamestrings)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Description?.RawDescription));
            }
            else
            {
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Description?.RawDescription));
            }
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void EmoticonPackDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            EmoticonPackDataDocument dataDocument = _heroesDataDirectory.EmoticonPackData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetEmoticonPackById("CassiaEmoticonPack2", out EmoticonPack? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void HeroSkinDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            HeroSkinDataDocument dataDocument = _heroesDataDirectory.HeroSkinData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetHeroSkinById("AbathurBaseVar3", out HeroSkin? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void MatchAwardDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            MatchAwardDataDocument dataDocument = _heroesDataDirectory.MatchAwardData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetMatchAwardById("HatTrick", out MatchAward? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void MountDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            MountDataDocument dataDocument = _heroesDataDirectory.MountData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetMountById("AlarakTaldarimMarch", out Mount? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void PortraitPackDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            PortraitPackDataDocument dataDocument = _heroesDataDirectory.PortraitPackData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetPortraitPackById("AbathurToys18Portrait", out PortraitPack? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void RewardPortraitDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            RewardPortraitDataDocument dataDocument = _heroesDataDirectory.RewardPortraitData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetRewardPortraitById("1YearAnniversaryPortrait", out RewardPortrait? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void SprayDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            SprayDataDocument dataDocument = _heroesDataDirectory.SprayData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetSprayById("SprayAnimatedCookieAbathur", out Spray? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void UnitDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            UnitDataDocument dataDocument = _heroesDataDirectory.UnitData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetUnitById("AbathurEvolvedMonstrosity", out Unit? value, false, false));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Description?.RawDescription));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Description?.RawDescription));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void VoiceLineDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            VoiceLineDataDocument dataDocument = _heroesDataDirectory.VoiceLineData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetVoiceLineById("AbathurBase_VoiceLine01", out VoiceLine? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [DataTestMethod]
        [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
        [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
        public void BannerDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            BannerDataDocument dataDocument = _heroesDataDirectory.BannerData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(dataDocument.TryGetBannerById("BannerD3DemonHunter", out Banner? value));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
        }

        [TestMethod]
        public void DataExceptionsTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.HeroData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.AnnouncerData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.BannerData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.BehaviorVeterancyData(null!));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.EmoticonData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.EmoticonPackData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.HeroSkinData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.MatchAwardData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.MountData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.PortraitPackData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.RewardPortraitData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.SprayData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UnitData(null!, true, Localization.KOKR));
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.VoiceLineData(null!, true, Localization.KOKR));
        }
    }
}