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
    public class BundleDataDocumentTests : DataDocumentBase, IDataDocument
    {
        private readonly string _dataFile = Path.Combine("JsonData", "bundledata_76893_kokr.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

        private readonly BundleDataDocument _bundleDataDocument;

        public BundleDataDocumentTests()
        {
            _bundleDataDocument = BundleDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
            using BundleDataDocument document = BundleDataDocument.Parse(_dataFile, gameStringDocument);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.TryGetBundleById("RaiderRexxarBundle", out Bundle? bundle));
            Assert.AreEqual("특공대원 렉사르 묶음 상품", bundle!.Name);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileLocaleTest()
        {
            using BundleDataDocument document = BundleDataDocument.Parse(_dataFile, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileTest()
        {
            using BundleDataDocument document = BundleDataDocument.Parse(_dataFile);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using BundleDataDocument document = BundleDataDocument.Parse(GetBytesForROM("RaiderRexxarBundle"), gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.TryGetBundleById("RaiderRexxarBundle", out Bundle? bundle));
            Assert.AreEqual("특공대원 렉사르 묶음 상품", bundle!.Name);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMLocaleTest()
        {
            using BundleDataDocument document = BundleDataDocument.Parse(GetBytesForROM("RaiderRexxarBundle"), Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BundleDataDocument document = BundleDataDocument.Parse(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BundleDataDocument document = BundleDataDocument.Parse(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGameStringStreamTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BundleDataDocument document = BundleDataDocument.Parse(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamAsyncTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BundleDataDocument document = await BundleDataDocument.ParseAsync(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BundleDataDocument document = await BundleDataDocument.ParseAsync(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using BundleDataDocument document = await BundleDataDocument.ParseAsync(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("RaiderRexxarBundle", out JsonElement _));
        }

        [DataTestMethod]
        [DataRow("RaiderRexxarBundle")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetBundleByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bundleDataDocument.GetBundleById(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _bundleDataDocument.GetBundleById(id);
                });

                return;
            }

            RaiderRexxarBundleAsserts(_bundleDataDocument.GetBundleById(id));
        }

        [DataTestMethod]
        [DataRow("RaiderRexxarBundle")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetBundleByIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_bundleDataDocument.TryGetBundleById(id, out _));

                return;
            }

            Assert.IsTrue(_bundleDataDocument.TryGetBundleById(id, out Bundle? _));
            if (_bundleDataDocument.TryGetBundleById(id, out Bundle? bundle))
            {
                RaiderRexxarBundleAsserts(bundle);
            }
        }

        [DataTestMethod]
        [DataRow("RaiderRexxarBundle")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetBundleByHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _bundleDataDocument.GetBundleByHyperlinkId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _bundleDataDocument.GetBundleByHyperlinkId(id);
                });

                return;
            }

            RaiderRexxarBundleAsserts(_bundleDataDocument.GetBundleByHyperlinkId(id));
        }

        [DataTestMethod]
        [DataRow("RaiderRexxarBundle")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetBundleByIdHyperlinkIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_bundleDataDocument.TryGetBundleByHyperlinkId(id, out _));

                return;
            }

            Assert.IsTrue(_bundleDataDocument.TryGetBundleByHyperlinkId(id, out Bundle? bundle));
            RaiderRexxarBundleAsserts(bundle!);
        }

        private static byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("RaiderRexxarBundle");
            writer.WriteString("name", "Raider Rexxar Bundle");
            writer.WriteString("hyperlinkId", "RaiderRexxarBundle");
            writer.WriteString("sortName", "xxxRaiderRexxarBundle");
            writer.WriteString("event", "halloween");
            writer.WriteString("releaseDate", "2016-09-27");
            writer.WriteBoolean("isDynamicContent", true);
            writer.WriteString("franchise", "Warcraft");

            writer.WriteStartArray("heroes");
            writer.WriteStringValue("Rexxar");
            writer.WriteEndArray();

            writer.WriteStartArray("skins");
            writer.WriteStartObject();
            writer.WriteStartArray("Rexxar");
            writer.WriteStringValue("RexxarMarine");
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.WriteEndArray();

            writer.WriteStartArray("mounts");
            writer.WriteStringValue("mount1");
            writer.WriteStringValue("mount2");
            writer.WriteEndArray();

            writer.WriteString("image", "storm_ui_bundles_h20_raiderrexxar.png");
            writer.WriteString("boostId", "boost1Id");
            writer.WriteNumber("goldBonus", 40);
            writer.WriteNumber("gemsBonus", 80);
            writer.WriteString("lootChestBonus", "lootChestBonus");

            writer.WriteEndObject();

            writer.WriteStartObject("QhiraHeroicBundle");
            writer.WriteString("name", "Qhira Heroic Bundle");
            writer.WriteString("hyperlinkId", "QhiraHeroicBundle");
            writer.WriteString("releaseDate", "2019-08-06");
            writer.WriteBoolean("isDynamicContent", true);
            writer.WriteString("image", "storm_ui_bundles_h47_madaxe19nexushunterskinpack.png");

            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }

        private static void RaiderRexxarBundleAsserts(Bundle bundle)
        {
            Assert.AreEqual("RaiderRexxarBundle", bundle.Id);
            Assert.AreEqual("Raider Rexxar Bundle", bundle.Name);
            Assert.AreEqual("RaiderRexxarBundle", bundle.HyperlinkId);
            Assert.AreEqual("xxxRaiderRexxarBundle", bundle.SortName);
            Assert.AreEqual("halloween", bundle.EventName);
            Assert.AreEqual(new DateTime(2016, 9, 27), bundle.ReleaseDate);
            Assert.IsTrue(bundle.IsDynamicContent);
            Assert.AreEqual(Franchise.Warcraft, bundle.Franchise);
            Assert.IsTrue(bundle.HeroIds.Contains("Rexxar"));
            Assert.IsTrue(bundle.HeroSkins.ToList().Contains("RexxarMarine"));
            Assert.IsTrue(bundle.TryGetSkinIdsByHeroId("Rexxar", out _));
            Assert.IsTrue(bundle.MountIds.ToList().Contains("mount2"));
            Assert.AreEqual("storm_ui_bundles_h20_raiderrexxar.png", bundle.ImageFileName);
            Assert.AreEqual("boost1Id", bundle.BoostBonusId);
            Assert.AreEqual(40, bundle.GoldBonus);
            Assert.AreEqual(80, bundle.GemsBonus);
        }
    }
}
