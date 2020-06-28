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
        public void GetHeroDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            HeroDataDocument heroDataDocument = _heroesDataDirectory.HeroData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(heroDataDocument.TryGetHeroById("Abathur", out Hero? hero, false, false, false, false));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
        }

        [DataTestMethod]
        [DataRow(2, 48, 3, 77205, false, true, Localization.KOKR)]
        public void GetHeroDataLoadDuplicateDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
        {
            HeroDataDocument heroDataDocument = _heroesDataDirectory.HeroData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
            Assert.IsTrue(heroDataDocument.TryGetHeroById("Abathur", out Hero? hero, false, false, false, false));

            if (gamestrings)
                Assert.IsTrue(!string.IsNullOrEmpty("this is some text."));
            else
                Assert.IsFalse(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
        }

        [TestMethod]
        public void HeroDataExceptionsTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.HeroData(null!, true, Localization.KOKR));
        }
    }
}