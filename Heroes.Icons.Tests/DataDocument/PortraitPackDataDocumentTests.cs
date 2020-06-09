using Heroes.Icons.DataDocument;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.Tests.DataDocument
{
    [TestClass]
    public class PortraitPackDataDocumentTests : DataDocumentBase, IDataDocument
    {
        private readonly string _dataFile = Path.Combine("JsonData", "portraitpackdata_76893_kokr.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

        private readonly PortraitPackDataDocument _portraitPackDataDocument;

        public PortraitPackDataDocumentTests()
        {
            _portraitPackDataDocument = PortraitPackDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(_dataFile, gameStringDocument);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.TryGetPortraitPackById("AbathurToys18Portrait", out PortraitPack? portraitPack));
            Assert.AreEqual("애벌레투르 초상화", portraitPack!.Name);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileLocaleTest()
        {
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(_dataFile, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurToys18Portrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileTest()
        {
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(_dataFile);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurToys18Portrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(GetBytesForROM("AdmiralKrakenovPortrait"), gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.TryGetPortraitPackById("AdmiralKrakenovPortrait", out PortraitPack? portraitPack));
            Assert.AreEqual("크라케노프 제독 초상화", portraitPack!.Name);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMLocaleTest()
        {
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(GetBytesForROM("AdmiralKrakenovPortrait"), Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AdmiralKrakenovPortrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AdmiralKrakenovPortrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AdmiralKrakenovPortrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGameStringStreamTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using PortraitPackDataDocument document = PortraitPackDataDocument.Parse(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AdmiralKrakenovPortrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamAsyncTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using PortraitPackDataDocument document = await PortraitPackDataDocument.ParseAsync(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AdmiralKrakenovPortrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using PortraitPackDataDocument document = await PortraitPackDataDocument.ParseAsync(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AdmiralKrakenovPortrait", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using PortraitPackDataDocument document = await PortraitPackDataDocument.ParseAsync(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AdmiralKrakenovPortrait", out JsonElement _));
        }

        [DataTestMethod]
        [DataRow("AbathurToys18Portrait")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetPortraitPackByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _portraitPackDataDocument.GetPortraitPackById(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _portraitPackDataDocument.GetPortraitPackById(id);
                });

                return;
            }

            BasicAbathurToys18PortraitAsserts(_portraitPackDataDocument.GetPortraitPackById(id));
        }

        [DataTestMethod]
        [DataRow("AdmiralKrakenovPortrait")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetPortraitPackByIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_portraitPackDataDocument.TryGetPortraitPackById(id, out _));

                return;
            }

            Assert.IsTrue(_portraitPackDataDocument.TryGetPortraitPackById(id, out PortraitPack? _));
            if (_portraitPackDataDocument.TryGetPortraitPackById(id, out PortraitPack? portraitPack))
            {
                BasicAdmiralKrakenovPortraitAsserts(portraitPack);
            }
        }

        [DataTestMethod]
        [DataRow("AbathurToys18Portrait")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetPortraitPackByHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _portraitPackDataDocument.GetPortraitPackByHyperlinkId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _portraitPackDataDocument.GetPortraitPackByHyperlinkId(id);
                });

                return;
            }

            BasicAbathurToys18PortraitAsserts(_portraitPackDataDocument.GetPortraitPackByHyperlinkId(id));
        }

        [DataTestMethod]
        [DataRow("AdmiralKrakenovPortrait")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetPortraitPackByHyperlinkIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_portraitPackDataDocument.TryGetPortraitPackByHyperlinkId(id, out _));

                return;
            }

            Assert.IsTrue(_portraitPackDataDocument.TryGetPortraitPackByHyperlinkId(id, out PortraitPack? portraitPack));
            BasicAdmiralKrakenovPortraitAsserts(portraitPack!);
        }

        private static byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("AbathurToys18Portrait");
            writer.WriteString("name", "Gingerbread Abathur");
            writer.WriteString("hyperlinkId", "AbathurToys18Portrait");
            writer.WriteString("rarity", "Common");
            writer.WriteString("event", "WinterVeil");
            writer.WriteEndObject();

            writer.WriteStartObject("AdmiralKrakenovPortrait");
            writer.WriteString("name", "Admiral Krakenov Portrait");
            writer.WriteString("hyperlinkId", "AdmiralKrakenovPortrait");
            writer.WriteString("rarity", "Common");
            writer.WriteString("sortName", "asdf");
            writer.WriteStartArray("rewardPortraitIds");
            writer.WriteStringValue("StukovPortraitPirate");
            writer.WriteEndArray();
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }

        private static void BasicAbathurToys18PortraitAsserts(PortraitPack portraitPack)
        {
            Assert.AreEqual("AbathurToys18Portrait", portraitPack.Id);
            Assert.AreEqual("Gingerbread Abathur", portraitPack.Name);
            Assert.AreEqual("AbathurToys18Portrait", portraitPack.HyperlinkId);
            Assert.AreEqual(Rarity.Common, portraitPack.Rarity);
            Assert.AreEqual("WinterVeil", portraitPack.EventName);
            Assert.IsNull(portraitPack.SortName);
            Assert.AreEqual(0, portraitPack.RewardPortraitIds.Count);
        }

        private static void BasicAdmiralKrakenovPortraitAsserts(PortraitPack portraitPack)
        {
            Assert.AreEqual("AdmiralKrakenovPortrait", portraitPack.Id);
            Assert.AreEqual("Admiral Krakenov Portrait", portraitPack.Name);
            Assert.AreEqual("AdmiralKrakenovPortrait", portraitPack.HyperlinkId);
            Assert.AreEqual(Rarity.Common, portraitPack.Rarity);
            Assert.IsNull(portraitPack.EventName);
            Assert.AreEqual("asdf", portraitPack.SortName);
            Assert.AreEqual(1, portraitPack.RewardPortraitIds.Count);
            Assert.AreEqual("StukovPortraitPirate", portraitPack.RewardPortraitIds.ToList()[0]);
        }
    }
}
