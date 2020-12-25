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
    public class LootChestDataDocumentTests : DataDocumentBase, IDataDocument
    {
        private readonly string _dataFile = Path.Combine("JsonData", "lootChestdata_76893_kokr.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

        private readonly LootChestDataDocument _lootChestDataDocument;

        public LootChestDataDocumentTests()
        {
            _lootChestDataDocument = LootChestDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
            using LootChestDataDocument document = LootChestDataDocument.Parse(_dataFile, gameStringDocument);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.TryGetLootChestById("EpicProgChest", out LootChest? lootChest));
            Assert.AreEqual("Epic Chest", lootChest!.Name);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileLocaleTest()
        {
            using LootChestDataDocument document = LootChestDataDocument.Parse(_dataFile, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileTest()
        {
            using LootChestDataDocument document = LootChestDataDocument.Parse(_dataFile);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using LootChestDataDocument document = LootChestDataDocument.Parse(GetBytesForROM("EpicProgChest"), gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.TryGetLootChestById("EpicProgChest", out LootChest? lootChest));
            Assert.AreEqual("Epic Chest", lootChest!.Name);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMLocaleTest()
        {
            using LootChestDataDocument document = LootChestDataDocument.Parse(GetBytesForROM("EpicProgChest"), Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using LootChestDataDocument document = LootChestDataDocument.Parse(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using LootChestDataDocument document = LootChestDataDocument.Parse(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGameStringStreamTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using LootChestDataDocument document = LootChestDataDocument.Parse(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamAsyncTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using LootChestDataDocument document = await LootChestDataDocument.ParseAsync(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using LootChestDataDocument document = await LootChestDataDocument.ParseAsync(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using LootChestDataDocument document = await LootChestDataDocument.ParseAsync(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("EpicProgChest", out JsonElement _));
        }

        [DataTestMethod]
        [DataRow("EpicProgChest")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetLootChestByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _lootChestDataDocument.GetLootChestById(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _lootChestDataDocument.GetLootChestById(id);
                });

                return;
            }

            EpicProgChestAsserts(_lootChestDataDocument.GetLootChestById(id));
        }

        [DataTestMethod]
        [DataRow("EpicProgChest")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetLootChestByIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_lootChestDataDocument.TryGetLootChestById(id, out _));

                return;
            }

            Assert.IsTrue(_lootChestDataDocument.TryGetLootChestById(id, out LootChest? _));
            if (_lootChestDataDocument.TryGetLootChestById(id, out LootChest? lootChest))
            {
                EpicProgChestAsserts(lootChest);
            }
        }

        [DataTestMethod]
        [DataRow("xEpicProgChest")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetLootChestByHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _lootChestDataDocument.GetLootChestByHyperlinkId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _lootChestDataDocument.GetLootChestByHyperlinkId(id);
                });

                return;
            }

            EpicProgChestAsserts(_lootChestDataDocument.GetLootChestByHyperlinkId(id));
        }

        [DataTestMethod]
        [DataRow("xEpicProgChest")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetLootChestByIdHyperlinkIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_lootChestDataDocument.TryGetLootChestByHyperlinkId(id, out _));

                return;
            }

            Assert.IsTrue(_lootChestDataDocument.TryGetLootChestByHyperlinkId(id, out LootChest? lootChest));
            EpicProgChestAsserts(lootChest!);
        }

        [DataTestMethod]
        [DataRow("LootChestEpic")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetLootChestByTypeDescriptionTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _lootChestDataDocument.GetLootChestByTypeDescription(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _lootChestDataDocument.GetLootChestByTypeDescription(id);
                });

                return;
            }

            EpicProgChestAsserts(_lootChestDataDocument.GetLootChestByTypeDescription(id));
        }

        [DataTestMethod]
        [DataRow("LootChestEpic")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetLootChestByIdTypeDescriptionTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_lootChestDataDocument.TryGetLootChestByTypeDescription(id, out _));

                return;
            }

            Assert.IsTrue(_lootChestDataDocument.TryGetLootChestByTypeDescription(id, out LootChest? lootChest));
            EpicProgChestAsserts(lootChest!);
        }

        private static byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("EpicProgChest");
            writer.WriteString("name", "Epic Chest");
            writer.WriteString("hyperlinkId", "xEpicProgChest");
            writer.WriteString("rarity", "Epic");
            writer.WriteNumber("maxRerolls", 3);
            writer.WriteString("typeDescription", "LootChestEpic");
            writer.WriteString("event", "some event");
            writer.WriteString("description", "A Loot Chest that guarantees at least one Epic or better item.");
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }

        private static void EpicProgChestAsserts(LootChest lootChest)
        {
            Assert.AreEqual("EpicProgChest", lootChest.Id);
            Assert.AreEqual("Epic Chest", lootChest.Name);
            Assert.AreEqual("xEpicProgChest", lootChest.HyperlinkId);
            Assert.AreEqual(Rarity.Epic, lootChest.Rarity);
            Assert.AreEqual(3, lootChest.MaxRerolls);
            Assert.AreEqual("LootChestEpic", lootChest.TypeDescription);
            Assert.AreEqual("some event", lootChest.EventName);
            Assert.AreEqual("A Loot Chest that guarantees at least one Epic or better item.", lootChest.Description!.RawDescription);
        }
    }
}
