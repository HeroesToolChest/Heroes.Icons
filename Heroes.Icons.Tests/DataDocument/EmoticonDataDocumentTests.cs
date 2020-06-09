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
    public class EmoticonDataDocumentTests : DataDocumentBase, IDataDocument
    {
        private readonly string _dataFile = Path.Combine("JsonData", "emoticondata_76893_kokr.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

        private readonly EmoticonDataDocument _emoticonDataDocument;

        public EmoticonDataDocumentTests()
        {
            _emoticonDataDocument = EmoticonDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(_dataFile, gameStringDocument);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.TryGetEmoticonById("abathur_mecha_angry", out Emoticon? emoticon));
            Assert.AreEqual("Angry", emoticon!.Name);
            Assert.AreEqual("제노공학 아바투르 화남 :제노아바 화:", emoticon!.Description?.RawDescription);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileLocaleTest()
        {
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(_dataFile, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("abathur_mecha_angry", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentFileTest()
        {
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(_dataFile);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("abathur_mecha_angry", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(GetBytesForROM("cat_blink_anim"), gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.TryGetEmoticonById("cat_blink_anim", out Emoticon? emoticon));
            Assert.AreEqual("Unknown", emoticon!.Name);
            Assert.AreEqual("저주받은 고양이 점멸 :고양점멸:", emoticon!.Description?.RawDescription);
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentROMLocaleTest()
        {
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(GetBytesForROM("cat_blink_anim"), Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("cat_blink_anim", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("cat_blink_anim", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGSDTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("cat_blink_anim", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public void DataDocumentStreamWithGameStringStreamTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using EmoticonDataDocument document = EmoticonDataDocument.Parse(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("abstract_rofl_casesensitive", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamAsyncTest()
        {
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using EmoticonDataDocument document = await EmoticonDataDocument.ParseAsync(stream, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("abstract_rofl_casesensitive", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using EmoticonDataDocument document = await EmoticonDataDocument.ParseAsync(stream, gameStringDocument);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("abstract_rofl_casesensitive", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataDocument")]
        public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
        {
            using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using FileStream stream = new FileStream(_dataFile, FileMode.Open);
            using EmoticonDataDocument document = await EmoticonDataDocument.ParseAsync(stream, streamGameString);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("abstract_rofl_casesensitive", out JsonElement _));
        }

        [DataTestMethod]
        [DataRow("cat_blink_anim")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetEmoticonByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _emoticonDataDocument.GetEmoticonById(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _emoticonDataDocument.GetEmoticonById(id);
                });

                return;
            }

            Basiccat_blink_animAsserts(_emoticonDataDocument.GetEmoticonById(id));
        }

        [DataTestMethod]
        [DataRow("abathur_mecha_angry")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetEmoticonByIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_emoticonDataDocument.TryGetEmoticonById(id, out _));

                return;
            }

            Assert.IsTrue(_emoticonDataDocument.TryGetEmoticonById(id, out Emoticon? _));
            if (_emoticonDataDocument.TryGetEmoticonById(id, out Emoticon? emoticon))
            {
                Basicabathur_mecha_angryAsserts(emoticon);
            }
        }

        [DataTestMethod]
        [DataRow("abstract_rofl_casesensitive")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetEmoticonByHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _emoticonDataDocument.GetEmoticonByHyperlinkId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _emoticonDataDocument.GetEmoticonByHyperlinkId(id);
                });

                return;
            }

            Basicabstract_rofl_casesensitiveAsserts(_emoticonDataDocument.GetEmoticonByHyperlinkId(id));
        }

        [DataTestMethod]
        [DataRow("abstract_rofl_casesensitive")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetEmoticonByIdHyperlinkIdTest(string? id)
        {
            if (id is null || id == "asdf")
            {
                Assert.IsFalse(_emoticonDataDocument.TryGetEmoticonByHyperlinkId(id, out _));

                return;
            }

            Assert.IsTrue(_emoticonDataDocument.TryGetEmoticonByHyperlinkId(id, out Emoticon? emoticon));
            Basicabstract_rofl_casesensitiveAsserts(emoticon!);
        }

        private static byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("cat_blink_anim");
            writer.WriteString("expression", "Unknown");
            writer.WriteString("description", "Cursed Cats Blink :catblink:");
            writer.WriteString("descriptionLocked", "(Locked) Cursed Cats Blink");
            writer.WriteStartArray("aliases");
            writer.WriteStringValue(":catblink:");
            writer.WriteEndArray();
            writer.WriteString("image", "storm_emoji_cat_blink_anim_sheet_0.gif");
            writer.WriteStartObject("animation");
            writer.WriteString("texture", "storm_emoji_cat_blink_anim_sheet.png");
            writer.WriteNumber("frames", 29);
            writer.WriteNumber("duration", 50);
            writer.WriteNumber("width", 38);
            writer.WriteNumber("columns", 4);
            writer.WriteNumber("rows", 8);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.WriteStartObject("abstract_rofl_casesensitive");
            writer.WriteString("expression", "Rofl");
            writer.WriteString("searchText", "rofl abstract");
            writer.WriteString("hyperlinkId", "abstract_rofl_casesensitive");
            writer.WriteBoolean("caseSensitive", true);
            writer.WriteBoolean("isHidden", true);
            writer.WriteStartArray("localizedAliases");
            writer.WriteStringValue(":D");
            writer.WriteEndArray();
            writer.WriteEndObject();

            writer.WriteStartObject("abathur_mecha_angry");
            writer.WriteString("expression", "Angry");
            writer.WriteString("description", "Xenotech Abathur Angry :abaxangry:");
            writer.WriteString("descriptionLocked", "(Locked) Xenotech Abathur Angry");
            writer.WriteStartArray("aliases");
            writer.WriteStringValue(":abathurxenotechangry:");
            writer.WriteStringValue(":abaxangry:");
            writer.WriteEndArray();
            writer.WriteString("heroId", "Abathur");
            writer.WriteString("heroSkinId", "AbathurMecha");
            writer.WriteString("image", "storm_emoji_abathur_mecha_sheet_0.png");
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }

        private static void Basiccat_blink_animAsserts(Emoticon emoticon)
        {
            Assert.AreEqual("cat_blink_anim", emoticon.Id);
            Assert.AreEqual("Unknown", emoticon.Name);
            Assert.AreEqual(string.Empty, emoticon.HyperlinkId);
            Assert.IsFalse(emoticon.IsHidden);
            Assert.IsFalse(emoticon.IsAliasCaseSensitive);
            Assert.AreEqual("Cursed Cats Blink :catblink:", emoticon.Description?.RawDescription);
            Assert.AreEqual("(Locked) Cursed Cats Blink", emoticon.DescriptionLocked?.RawDescription);
            Assert.AreEqual(1, emoticon.UniversalAliases.Count);
            Assert.AreEqual(":catblink:", emoticon.UniversalAliases.ToList()[0]);
            Assert.AreEqual("storm_emoji_cat_blink_anim_sheet_0.gif", emoticon.Image.FileName);
            Assert.AreEqual("storm_emoji_cat_blink_anim_sheet.png", emoticon.TextureSheet.Image);
            Assert.AreEqual(29, emoticon.Image.Count);
            Assert.AreEqual(50, emoticon.Image.DurationPerFrame);
            Assert.AreEqual(38, emoticon.Image.Width);
            Assert.AreEqual(4, emoticon.TextureSheet.Columns);
            Assert.AreEqual(8, emoticon.TextureSheet.Rows);
        }

        private static void Basicabstract_rofl_casesensitiveAsserts(Emoticon emoticon)
        {
            Assert.AreEqual("abstract_rofl_casesensitive", emoticon.Id);
            Assert.AreEqual("Rofl", emoticon.Name);
            Assert.AreEqual("abstract_rofl_casesensitive", emoticon.HyperlinkId);
            Assert.IsNull(emoticon.Description?.RawDescription);
            Assert.AreEqual(0, emoticon.UniversalAliases.Count);
            Assert.AreEqual(":D", emoticon.LocalizedAliases.ToList()[0]);
            Assert.AreEqual(true, emoticon.IsAliasCaseSensitive);
            Assert.AreEqual(true, emoticon.IsHidden);
            Assert.AreEqual(2, emoticon.SearchTexts.Count);
            Assert.AreEqual("rofl", emoticon.SearchTexts.ToList()[0]);
        }

        private static void Basicabathur_mecha_angryAsserts(Emoticon emoticon)
        {
            Assert.AreEqual("abathur_mecha_angry", emoticon.Id);
            Assert.AreEqual("Angry", emoticon.Name);
            Assert.AreEqual(string.Empty, emoticon.HyperlinkId);
            Assert.AreEqual("Xenotech Abathur Angry :abaxangry:", emoticon.Description?.RawDescription);
            Assert.AreEqual("(Locked) Xenotech Abathur Angry", emoticon.DescriptionLocked?.RawDescription);
            Assert.AreEqual(2, emoticon.UniversalAliases.Count);
            Assert.AreEqual(":abathurxenotechangry:", emoticon.UniversalAliases.ToList()[0]);
            Assert.AreEqual("storm_emoji_abathur_mecha_sheet_0.png", emoticon.Image.FileName);
        }
    }
}
