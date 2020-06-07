using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Heroes.Icons.HeroesData.Tests
{
    [TestClass]
    public class HeroesDataVersionTests
    {
        [DataTestMethod]
        [DataRow(0, 0, 0, 00000)]
        [DataRow(-1, -1, -1, -1, false)]
        [DataRow(-567, -324, -23, -234234, false)]
        public void VersionMinimumTest(int major, int minor, int revision, int build, bool isPtr = false)
        {
            HeroesDataVersion heroesVersion = new HeroesDataVersion(major, minor, revision, build, isPtr);

            Assert.AreEqual(0, heroesVersion.Major);
            Assert.AreEqual(0, heroesVersion.Minor);
            Assert.AreEqual(0, heroesVersion.Revision);
            Assert.AreEqual(0, heroesVersion.Build);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, 11111)]
        [DataRow(1, 1, 1, 11111, false)]
        public void EqualsTest(int major, int minor, int revision, int build, bool isPtr = false)
        {
            Assert.AreEqual(new HeroesDataVersion(major, minor, revision, build, isPtr), new HeroesDataVersion(major, minor, revision, build, isPtr));
        }

        [TestMethod]
        public void EqualsMethodTest()
        {
            Assert.IsFalse(new HeroesDataVersion(2, 45, 124, 154787, false).Equals((int?)null));
            Assert.IsFalse(new HeroesDataVersion(2, 45, 124, 154787, false).Equals(5));

            HeroesDataVersion version = new HeroesDataVersion(2, 45, 124, 154787, false);
            Assert.IsTrue(version.Equals(obj: version));
        }

        [TestMethod]
        public void CompareToMethodTest()
        {
            Assert.AreEqual(1, new HeroesDataVersion(2, 45, 124, 154787, false).CompareTo((int?)null));
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new HeroesDataVersion(2, 45, 124, 154787, false).CompareTo(5);
            });

            Assert.AreEqual(0, new HeroesDataVersion(2, 45, 124, 154787, false).CompareTo(obj: new HeroesDataVersion(2, 45, 124, 154787, false)));

            HeroesDataVersion version = new HeroesDataVersion(2, 45, 124, 154787, false);
            Assert.AreEqual(0, version.CompareTo(obj: version));
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 11111)]
        [DataRow(-1, 1, 1, 11111, false)]
        [DataRow(-1, 1, 1, 20, true)]
        [DataRow(-1, 2, 1, 11111, false)]
        [DataRow(1, 1, -1, 11111, false)]
        [DataRow(1, 1, 1, 11111, false)]
        public void NotEqualsTest(int major, int minor, int revision, int build, bool isPtr = false)
        {
            HeroesDataVersion heroesVersion = new HeroesDataVersion(1, 1, 1, 11111, true);

            Assert.AreNotEqual(heroesVersion, new HeroesDataVersion(major, minor, revision, build, isPtr));
        }

        [TestMethod]
        public void NotSameObjectTest()
        {
            HeroesDataVersion heroesVersion = new HeroesDataVersion(1, 1, 1, 11111, true);

            Assert.AreNotEqual(new List<string>() { "asdf" }, heroesVersion);
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 11111, false)]
        public void OperatorEqualTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
#pragma warning disable SA1131 // Use readable conditions
            Assert.IsFalse(null! == new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsFalse(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) == null!);

            Assert.IsTrue(null! == (HeroesDataVersion)null!);
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) == new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 11111, false, 3, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 3, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 8, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 12112, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 11111, true)]
        [DataRow(2, 2, 2, 11111, false, 2, 4, 78, 45781, false)]
        public void OperatorNotEqualTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
#pragma warning disable SA1131 // Use readable conditions
            Assert.IsTrue(null! != new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsTrue(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) != null!);

            Assert.IsFalse(null! != (HeroesDataVersion)null!);
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) != new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
        }

        [DataTestMethod]
        [DataRow(1, 2, 2, 11111, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 1, 2, 11111, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 0, 11111, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 10000, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 10000, true, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 10000, false, 2, 2, 2, 10000, true)]
        public void OperatorLessThanTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
#pragma warning disable SA1131 // Use readable conditions
            Assert.IsTrue(null! < new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsFalse(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) < null!);

            Assert.IsFalse(null! < (HeroesDataVersion)null!);
            Assert.IsFalse(new HeroesDataVersion(major, minor, revision, build, isPtr) < new HeroesDataVersion(major, minor, revision, build, isPtr));
            Assert.IsFalse(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) < new HeroesDataVersion(major, minor, revision, build, isPtr));
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) < new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
        }

        [DataTestMethod]
        [DataRow(1, 2, 2, 11111, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 1, 2, 11111, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 0, 11111, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 10000, false, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 10000, true, 2, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 10000, true, 2, 2, 2, 10000, true)]
        public void OperatorLessThanOrEqualTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
#pragma warning disable SA1131 // Use readable conditions
            Assert.IsTrue(null! <= new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsFalse(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) <= null!);

            Assert.IsTrue(null! <= (HeroesDataVersion)null!);
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) <= new HeroesDataVersion(major, minor, revision, build, isPtr));
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) <= new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 11111, false, 1, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 1, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 0, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 10000, false)]
        [DataRow(2, 2, 2, 11111, true, 2, 2, 2, 11111, false)]
        public void OperatorGreaterThanTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
#pragma warning disable SA1131 // Use readable conditions
            Assert.IsFalse(null! > new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsTrue(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) > null!);

            Assert.IsFalse(null! > (HeroesDataVersion)null!);
            Assert.IsFalse(new HeroesDataVersion(major, minor, revision, build, isPtr) > new HeroesDataVersion(major, minor, revision, build, isPtr));
            Assert.IsFalse(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) > new HeroesDataVersion(major, minor, revision, build, isPtr));
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) > new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 11111, false, 1, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 1, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 0, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 10000, false)]
        [DataRow(2, 2, 2, 11111, true, 2, 2, 2, 10000, false)]
        [DataRow(2, 2, 2, 10000, true, 2, 2, 2, 10000, true)]
        public void OperatorGreaterThanOrEqualTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
#pragma warning disable SA1131 // Use readable conditions
            Assert.IsFalse(null! >= new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsTrue(new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2) >= null!);

            Assert.IsTrue(null! >= (HeroesDataVersion)null!);
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) >= new HeroesDataVersion(major, minor, revision, build, isPtr));
            Assert.IsTrue(new HeroesDataVersion(major, minor, revision, build, isPtr) >= new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2));
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 11111, false)]
        public void GetHashCodeEqualTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
            Assert.AreEqual(new HeroesDataVersion(major, minor, revision, build, isPtr).GetHashCode(), new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2).GetHashCode());
        }

        [DataTestMethod]
        [DataRow(2, 2, 2, 11111, false, 0, 2, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 74, 2, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 247, 11111, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 12457, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 11112, false)]
        [DataRow(2, 2, 2, 11111, false, 2, 2, 2, 11111, true)]
        [DataRow(2, 2, 2, 11111, true, 2, 2, 2, 11111, false)]
        public void GetHashCodeNotEqualTest(int major, int minor, int revision, int build, bool isPtr, int major2, int minor2, int revision2, int build2, bool isPtr2)
        {
            Assert.AreNotEqual(new HeroesDataVersion(major, minor, revision, build, isPtr).GetHashCode(), new HeroesDataVersion(major2, minor2, revision2, build2, isPtr2).GetHashCode());
        }

        [TestMethod]
        public void TryParseExceptionsTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                if (HeroesDataVersion.TryParse(string.Empty, out HeroesDataVersion? _))
                {
                }
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                if (HeroesDataVersion.TryParse(null!, out HeroesDataVersion? _))
                {
                }
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                if (HeroesDataVersion.TryParse("   ", out HeroesDataVersion? _))
                {
                }
            });
        }

        [TestMethod]
        public void ParseExceptionsTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                HeroesDataVersion.Parse(string.Empty);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                HeroesDataVersion.Parse(null!);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                HeroesDataVersion.Parse("  ");
            });
        }

        [DataTestMethod]
        [DataRow("2.34.3.34567", 2, 34, 3, 34567, false)]
        [DataRow("0.0.0.0", 0, 0, 0, 0, false)]
        [DataRow("-12.-45.-458.-45787", 0, 0, 0, 0, false)]
        [DataRow("-12.-45.-458.97", 0, 0, 0, 97, false)]
        [DataRow("2.34.3.34567_ptr", 2, 34, 3, 34567, true)]
        [DataRow("2.34.3.34567_PTr", 2, 34, 3, 34567, true)]
        public void TryParseSuccessTest(string value, int major, int minor, int revision, int build, bool isPtr)
        {
            Assert.IsTrue(HeroesDataVersion.TryParse(value, out HeroesDataVersion? result));
            Assert.AreEqual(major, result!.Major);
            Assert.AreEqual(minor, result.Minor);
            Assert.AreEqual(revision, result.Revision);
            Assert.AreEqual(build, result.Build);
            Assert.AreEqual(isPtr, result.IsPtr);
        }

        [DataTestMethod]
        [DataRow("2.34.3.34567a")]
        [DataRow("k2.34.3.34567")]
        [DataRow("2.34k.3.34567")]
        [DataRow("2.34.3&.34567")]
        [DataRow("2.34.3.34567.4")]
        [DataRow("2.34.3")]
        [DataRow("2.34.3.34567_uu")]
        [DataRow("2.34.3.34567_ptr_ptr")]
        [DataRow("2.34.3.34567_dfg")]
        [DataRow("2.34.3.345679a_ptr")]
        public void TryParseFailTest(string value)
        {
            Assert.IsFalse(HeroesDataVersion.TryParse(value, out HeroesDataVersion? _));
        }

        [DataTestMethod]
        [DataRow("2.34.3.34567", 2, 34, 3, 34567, false)]
        [DataRow("0.0.0.0", 0, 0, 0, 0, false)]
        [DataRow("-12.-45.-458.-45787", 0, 0, 0, 0, false)]
        [DataRow("-12.-45.-458.97", 0, 0, 0, 97, false)]
        [DataRow("2.34.3.34567_ptr", 2, 34, 3, 34567, true)]
        [DataRow("2.34.3.34567_PTr", 2, 34, 3, 34567, true)]
        public void ParseSuccessTest(string value, int major, int minor, int revision, int build, bool isPtr)
        {
            HeroesDataVersion version = HeroesDataVersion.Parse(value);
            Assert.AreEqual(major, version!.Major);
            Assert.AreEqual(minor, version.Minor);
            Assert.AreEqual(revision, version.Revision);
            Assert.AreEqual(build, version.Build);
            Assert.AreEqual(isPtr, version.IsPtr);
        }

        [DataTestMethod]
        [DataRow("2.34.3.34567a")]
        [DataRow("k2.34.3.34567")]
        [DataRow("2.34k.3.34567")]
        [DataRow("2.34.3&.34567")]
        [DataRow("2.34.3.34567.4")]
        [DataRow("2.34.3")]
        [DataRow("2.34.3.34567_uu")]
        [DataRow("2.34.3.34567_ptr_ptr")]
        [DataRow("2.34.3.34567_dfg")]
        [DataRow("2.34.3.345679a_ptr")]
        public void ParseFailTest(string value)
        {
            Assert.ThrowsException<FormatException>(() => { HeroesDataVersion.Parse(value); });
        }
    }
}