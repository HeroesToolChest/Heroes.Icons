using Heroes.Icons.DataDocument;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.Tests.DataDocument
{
    [TestClass]
    public class BannerDataDocumentTests : DataDocumentBase, IDataDocument
    {
        private readonly string _dataFile = Path.Combine("JsonData", "bannerdata_76893_kokr.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

        private readonly BannerDataDocument _bannerDataDocument;

        public BannerDataDocumentTests()
        {
            _bannerDataDocument = BannerDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
            using BannerDataDocument document = BannerDataDocument.Parse(_dataFile, gameStringDocument);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.TryGetBannerById("BannerD3DemonHunter", out Banner _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileLocaleTest()
        {
            using BannerDataDocument document = BannerDataDocument.Parse(_dataFile, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileTest()
        {
            using BannerDataDocument document = BannerDataDocument.Parse(_dataFile);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using BannerDataDocument document = BannerDataDocument.Parse(GetBytesForROM("BannerD3DemonHunter"), gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.TryGetBannerById("BannerD3DemonHunter", out Banner _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMLocaleTest()
        {
            using BannerDataDocument document = BannerDataDocument.Parse(GetBytesForROM("BannerD3DemonHunter"), Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BannerDataDocument document = BannerDataDocument.Parse(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BannerDataDocument document = BannerDataDocument.Parse(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGameStringStreamTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BannerDataDocument document = BannerDataDocument.Parse(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamAsyncTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BannerDataDocument document = await BannerDataDocument.ParseAsync(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BannerDataDocument document = await BannerDataDocument.ParseAsync(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BannerDataDocument document = await BannerDataDocument.ParseAsync(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BannerD3DemonHunter", out JsonElement _));
        }

        [DataTestMethod]
        [DataRow("BannerD3DemonHunterRare")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetBannerByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bannerDataDocument.GetBannerById(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _bannerDataDocument.GetBannerById(id);
                });

                return;
            }

            BasicBannerD3DemonHunterRareAsserts(_bannerDataDocument.GetBannerById(id));
        }

        [DataTestMethod]
        [DataRow("BannerD3DemonHunterRare")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetBannerByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bannerDataDocument.TryGetBannerById(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_bannerDataDocument.TryGetBannerById(id, out _));

                return;
            }

            Assert.IsTrue(_bannerDataDocument.TryGetBannerById(id, out Banner? _));
            if (_bannerDataDocument.TryGetBannerById(id, out Banner? banner))
            {
                BasicBannerD3DemonHunterRareAsserts(banner);
            }
        }

        [DataTestMethod]
        [DataRow("DemonHunterWarbanner")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetBannerByHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bannerDataDocument.GetBannerByHyperlinkId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _bannerDataDocument.GetBannerByHyperlinkId(id);
                });

                return;
            }

            BasicBannerD3DemonHunterRareAsserts(_bannerDataDocument.GetBannerByHyperlinkId(id));
        }

        [DataTestMethod]
        [DataRow("DemonHunterWarbanner")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetBannerByIdHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bannerDataDocument.TryGetBannerByHyperlinkId(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_bannerDataDocument.TryGetBannerByHyperlinkId(id, out _));

                return;
            }

            Assert.IsTrue(_bannerDataDocument.TryGetBannerByHyperlinkId(id, out Banner? banner));
            BasicBannerD3DemonHunterRareAsserts(banner!);
        }

        [DataTestMethod]
        [DataRow("BN08")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetBannerByAttributeIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bannerDataDocument.GetBannerByAttributeId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _bannerDataDocument.GetBannerByAttributeId(id);
                });

                return;
            }

            BasicBannerD3DemonHunterRareAsserts(_bannerDataDocument.GetBannerByAttributeId(id));
        }

        [DataTestMethod]
        [DataRow("BN08")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetBannerByAttributeIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bannerDataDocument.TryGetBannerByAttributeId(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_bannerDataDocument.TryGetBannerByAttributeId(id, out _));

                return;
            }

            Assert.IsTrue(_bannerDataDocument.TryGetBannerByAttributeId(id, out Banner? banner));
            BasicBannerD3DemonHunterRareAsserts(banner!);
        }

        private static byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("BannerD3DemonHunter");
            writer.WriteString("name", "Demon Hunter Banner");
            writer.WriteString("hyperlinkId", "DemonHunterBanner");
            writer.WriteString("attributeId", "BN05");
            writer.WriteString("rarity", "Common");
            writer.WriteString("category", "Diablo");
            writer.WriteString("releaseDate", "2014-03-13");
            writer.WriteString("sortName", "3DemBaseVar0");
            writer.WriteString("description", "The demon hunters are neither a people, nor a nation. Instead, they are survivors bound by vengeance.");
            writer.WriteEndObject();

            writer.WriteStartObject("BannerD3DemonHunterRare");
            writer.WriteString("name", "Demon Hunter Warbanner");
            writer.WriteString("hyperlinkId", "DemonHunterWarbanner");
            writer.WriteString("attributeId", "BN08");
            writer.WriteString("rarity", "Rare");
            writer.WriteString("category", "Diablo");
            writer.WriteString("releaseDate", "2014-03-13");
            writer.WriteString("sortName", "3DemRareVar0");
            writer.WriteString("description", "Only a hunter whose hatred is fully tempered by discipline will ever bear the sigil of the Order-masters.");
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }

        private static void BasicBannerD3DemonHunterRareAsserts(Banner banner)
        {
            Assert.AreEqual("BannerD3DemonHunterRare", banner.Id);
            Assert.AreEqual("Demon Hunter Warbanner", banner.Name);
            Assert.AreEqual("DemonHunterWarbanner", banner.HyperlinkId);
            Assert.AreEqual("BN08", banner.AttributeId);
            Assert.AreEqual(Rarity.Rare, banner.Rarity);
            Assert.AreEqual("Diablo", banner.CollectionCategory);
            Assert.AreEqual(new DateTime(2014, 3, 13), banner.ReleaseDate);
            Assert.AreEqual("3DemRareVar0", banner.SortName);
            Assert.AreEqual("Only a hunter whose hatred is fully tempered by discipline will ever bear the sigil of the Order-masters.", banner.Description?.RawDescription);
        }
    }
}
