using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Icons.HeroesData.Tests
{
    [TestClass]
    public class HeroesDataDirectoryTests
    {
        private readonly string _testFolder = "heroesdataTestFolders";

        [TestMethod]
        public void GetVersionsTest()
        {
            List<HeroesDataVersion> list = HeroesDataDirectory.GetVersions(_testFolder).ToList();

            HeroesDataVersion first = list[0];

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(76003, first.Build);
            Assert.AreEqual(2, first.Major);
            Assert.AreEqual(47, first.Minor);
            Assert.AreEqual(2, first.Revision);
            Assert.IsFalse(first.IsPtr);

            HeroesDataVersion third = list[2];

            Assert.AreEqual(76268, third.Build);
            Assert.AreEqual(2, third.Major);
            Assert.AreEqual(48, third.Minor);
            Assert.AreEqual(0, third.Revision);
            Assert.IsTrue(third.IsPtr);
        }

        [TestMethod]
        public void GetVersionsExceptionsTest()
        {
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(null!));
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(string.Empty));
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(" "));
        }

        [TestMethod]
        public void VersionExistsTest()
        {
            Assert.IsTrue(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(2, 47, 3, 76124)));
            Assert.IsTrue(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(2, 48, 0, 76268, true)));
            Assert.IsFalse(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(77, 23, 1, 76268, true)));
        }

        [TestMethod]
        public void VersionExistsExceptionsTest()
        {
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(null!, new HeroesDataVersion(1, 1, 1, 1)));
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(string.Empty, new HeroesDataVersion(1, 1, 1, 1)));
            Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(" ", new HeroesDataVersion(1, 1, 1, 1)));
            Assert.ThrowsException<ArgumentNullException>(() => HeroesDataDirectory.VersionExists("path", null!));
        }
    }
}