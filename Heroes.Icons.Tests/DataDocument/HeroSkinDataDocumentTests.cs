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
    public class HeroSkinDataDocumentTests : DataDocumentBase, IDataDocument
    {
        private readonly string _dataFile = Path.Combine("JsonData", "heroskindata_76893_kokr.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

        private readonly HeroSkinDataDocument _heroSkinDataDocument;

        public HeroSkinDataDocumentTests()
        {
            _heroSkinDataDocument = HeroSkinDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(_dataFile, gameStringDocument);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.TryGetHeroSkinById("AbathurBaseVar3", out HeroSkin? heroSkin));
            Assert.AreEqual("칼디르 아바투르", heroSkin!.Name);
            Assert.AreEqual("케리건이 지배하는 저그 군단의 진화 군주인 아바투르는, 저그를 유전자 단계에서부터 발전시키기 위해 끊임없이 노력합니다. 불완전과 혼돈에 대한 그의 증오는 대명사와 어미에 대한 그의 증오에 거의 맞먹습니다.", heroSkin!.InfoText?.RawDescription);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileLocaleTest()
        {
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(_dataFile, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileTest()
        {
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(_dataFile);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(GetBytesForROM("AbathurBaseVar3"), gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.TryGetHeroSkinById("AbathurBaseVar3", out HeroSkin? heroSkin));
            Assert.AreEqual("칼디르 아바투르", heroSkin!.Name);
            Assert.AreEqual("케리건이 지배하는 저그 군단의 진화 군주인 아바투르는, 저그를 유전자 단계에서부터 발전시키기 위해 끊임없이 노력합니다. 불완전과 혼돈에 대한 그의 증오는 대명사와 어미에 대한 그의 증오에 거의 맞먹습니다.", heroSkin!.InfoText?.RawDescription);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMLocaleTest()
        {
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(GetBytesForROM("AbathurBaseVar3"), Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGameStringStreamTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using HeroSkinDataDocument document = HeroSkinDataDocument.Parse(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamAsyncTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using HeroSkinDataDocument document = await HeroSkinDataDocument.ParseAsync(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using HeroSkinDataDocument document = await HeroSkinDataDocument.ParseAsync(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using HeroSkinDataDocument document = await HeroSkinDataDocument.ParseAsync(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBaseVar3", out JsonElement _));
        }

        [DataTestMethod]
        [DataRow("AbathurBone")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetHeroSkinByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _heroSkinDataDocument.GetHeroSkinById(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _heroSkinDataDocument.GetHeroSkinById(id);
                });

                return;
            }

            BasicAbathurBoneAsserts(_heroSkinDataDocument.GetHeroSkinById(id));
        }

        [DataTestMethod]
        [DataRow("AbathurBone")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetHeroSkinByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _heroSkinDataDocument.TryGetHeroSkinById(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_heroSkinDataDocument.TryGetHeroSkinById(id, out _));

                return;
            }

            Assert.IsTrue(_heroSkinDataDocument.TryGetHeroSkinById(id, out HeroSkin? _));
            if (_heroSkinDataDocument.TryGetHeroSkinById(id, out HeroSkin? heroSkin))
            {
                BasicAbathurBoneAsserts(heroSkin);
            }
        }

        [DataTestMethod]
        [DataRow("BoneAbathur")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetHeroSkinByHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _heroSkinDataDocument.GetHeroSkinByHyperlinkId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _heroSkinDataDocument.GetHeroSkinByHyperlinkId(id);
                });

                return;
            }

            BasicAbathurBoneAsserts(_heroSkinDataDocument.GetHeroSkinByHyperlinkId(id));
        }

        [DataTestMethod]
        [DataRow("BoneAbathur")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetHeroSkinByIdHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _heroSkinDataDocument.TryGetHeroSkinByHyperlinkId(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_heroSkinDataDocument.TryGetHeroSkinByHyperlinkId(id, out _));

                return;
            }

            Assert.IsTrue(_heroSkinDataDocument.TryGetHeroSkinByHyperlinkId(id, out HeroSkin? heroSkin));
            BasicAbathurBoneAsserts(heroSkin!);
        }

        [DataTestMethod]
        [DataRow("Aba1")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetHeroSkinByAttributeIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _heroSkinDataDocument.GetHeroSkinByAttributeId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _heroSkinDataDocument.GetHeroSkinByAttributeId(id);
                });

                return;
            }

            BasicAbathurBoneAsserts(_heroSkinDataDocument.GetHeroSkinByAttributeId(id));
        }

        [DataTestMethod]
        [DataRow("Aba1")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetHeroSkinByAttributeIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _heroSkinDataDocument.TryGetHeroSkinByAttributeId(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_heroSkinDataDocument.TryGetHeroSkinByAttributeId(id, out _));

                return;
            }

            Assert.IsTrue(_heroSkinDataDocument.TryGetHeroSkinByAttributeId(id, out HeroSkin? heroSkin));
            BasicAbathurBoneAsserts(heroSkin!);
        }

        private static byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("AbathurBaseVar3");
            writer.WriteString("name", "Kaldir Abathur");
            writer.WriteString("hyperlinkId", "KaldirAbathur");
            writer.WriteString("attributeId", "Aba0");
            writer.WriteString("rarity", "Rare");
            writer.WriteString("releaseDate", "2017-04-25");
            writer.WriteString("sortName", "zxAbathurVar1");
            writer.WriteString("searchText", "Blue");
            writer.WriteString("infoText", "Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.");
            writer.WriteEndObject();

            writer.WriteStartObject("AbathurBone");
            writer.WriteString("name", "Bone Abathur");
            writer.WriteString("hyperlinkId", "BoneAbathur");
            writer.WriteString("attributeId", "Aba1");
            writer.WriteString("rarity", "Common");
            writer.WriteString("releaseDate", "2014-03-13");
            writer.WriteString("sortName", "zxAbathurVar0");
            writer.WriteString("searchText", "White Pink");
            writer.WriteString("infoText", "Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.");
            writer.WriteStartArray("features");
            writer.WriteStringValue("AlteredVO");
            writer.WriteStringValue("ThemedAbilities");
            writer.WriteStringValue("ThemedAnimations");
            writer.WriteEndArray();
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }

        private static void BasicAbathurBoneAsserts(HeroSkin heroSkin)
        {
            Assert.AreEqual("AbathurBone", heroSkin.Id);
            Assert.AreEqual("Bone Abathur", heroSkin.Name);
            Assert.AreEqual("BoneAbathur", heroSkin.HyperlinkId);
            Assert.AreEqual("Aba1", heroSkin.AttributeId);
            Assert.AreEqual(Rarity.Common, heroSkin.Rarity);
            Assert.AreEqual(new DateTime(2014, 3, 13), heroSkin.ReleaseDate);
            Assert.AreEqual("zxAbathurVar0", heroSkin.SortName);
            Assert.AreEqual("White Pink", heroSkin.SearchText);
            Assert.AreEqual("Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.", heroSkin.InfoText?.RawDescription);
            Assert.IsTrue(heroSkin.Features.Contains("AlteredVO"));
            Assert.IsTrue(heroSkin.Features.Contains("ThemedAbilities"));
            Assert.IsTrue(heroSkin.Features.Contains("ThemedAnimations"));
        }
    }
}
