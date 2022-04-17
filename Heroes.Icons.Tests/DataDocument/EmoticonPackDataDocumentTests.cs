using Heroes.Icons.DataDocument;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class EmoticonPackDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "emoticonpackdata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly EmoticonPackDataDocument _emoticonPackDataDocument;

    public EmoticonPackDataDocumentTests()
    {
        _emoticonPackDataDocument = EmoticonPackDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetEmoticonPackById("CassiaEmoticonPack2", out EmoticonPack? emoticonPack));
        Assert.AreEqual("카시아 팩 2", emoticonPack!.Name);
        Assert.AreEqual("대화에서 실감나는 감정 표현을 할 수 있는 카시아 이모티콘입니다. 아래의 이모티콘에 마우스 커서를 올려 놓으면 명령어를 확인할 수 있습니다.", emoticonPack!.Description?.RawDescription);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CassiaEmoticonPack2", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CassiaEmoticonPack2", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(GetBytesForROM("CatSpooky18Pack"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetEmoticonPackById("CatSpooky18Pack", out EmoticonPack? emoticonPack));
        Assert.AreEqual("저주받은 고양이 이모티콘 팩", emoticonPack!.Name);
        Assert.IsNull(emoticonPack!.Description?.RawDescription);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(GetBytesForROM("CatSpooky18Pack"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CatSpooky18Pack", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CatSpooky18Pack", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CatSpooky18Pack", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using EmoticonPackDataDocument document = EmoticonPackDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CatSpooky18Pack", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using EmoticonPackDataDocument document = await EmoticonPackDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CatSpooky18Pack", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using EmoticonPackDataDocument document = await EmoticonPackDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CatSpooky18Pack", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using EmoticonPackDataDocument document = await EmoticonPackDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("CatSpooky18Pack", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("CassiaEmoticonPack2")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetEmoticonPackByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _emoticonPackDataDocument.GetEmoticonPackById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _emoticonPackDataDocument.GetEmoticonPackById(id);
            });

            return;
        }

        BasicCassiaEmoticonPack2Asserts(_emoticonPackDataDocument.GetEmoticonPackById(id));
    }

    [DataTestMethod]
    [DataRow("CatSpooky18Pack")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetEmoticonPackByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_emoticonPackDataDocument.TryGetEmoticonPackById(id, out _));

            return;
        }

        Assert.IsTrue(_emoticonPackDataDocument.TryGetEmoticonPackById(id, out EmoticonPack? _));
        if (_emoticonPackDataDocument.TryGetEmoticonPackById(id, out EmoticonPack? emoticonPack))
        {
            BasicCatSpooky18PackAsserts(emoticonPack);
        }
    }

    [DataTestMethod]
    [DataRow("CassiaEmoticonPack2")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetEmoticonPackByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _emoticonPackDataDocument.GetEmoticonPackByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _emoticonPackDataDocument.GetEmoticonPackByHyperlinkId(id);
            });

            return;
        }

        BasicCassiaEmoticonPack2Asserts(_emoticonPackDataDocument.GetEmoticonPackByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("CatSpooky18Pack")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetEmoticonPackByIdHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_emoticonPackDataDocument.TryGetEmoticonPackByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_emoticonPackDataDocument.TryGetEmoticonPackByHyperlinkId(id, out EmoticonPack? emoticonPack));
        BasicCatSpooky18PackAsserts(emoticonPack!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("CassiaEmoticonPack2");
        writer.WriteString("name", "Cassia Pack 2");
        writer.WriteString("hyperlinkId", "CassiaEmoticonPack2");
        writer.WriteString("rarity", "Common");
        writer.WriteString("category", "Diablo");
        writer.WriteString("releaseDate", "2017-03-14");
        writer.WriteString("description", "Cassia emojis that can be used to express emotions or ideas in chat. Hover over an emoji below to view its text command.");
        writer.WriteStartArray("emoticons");
        writer.WriteStringValue("cassia_angry");
        writer.WriteStringValue("cassia_cool");
        writer.WriteStringValue("cassia_embarrassed");
        writer.WriteStringValue("cassia_inlove");
        writer.WriteStringValue("cassia_surprised");
        writer.WriteEndArray();
        writer.WriteEndObject();

        writer.WriteStartObject("CatSpooky18Pack");
        writer.WriteString("name", "Cursed Cats Emoji Pack");
        writer.WriteString("hyperlinkId", "CatSpooky18Pack");
        writer.WriteString("rarity", "Common");
        writer.WriteString("category", "SeasonalEvents");
        writer.WriteString("event", "HallowsEnd");
        writer.WriteString("releaseDate", "2018-09-25");
        writer.WriteString("sortName", "aaCat");
        writer.WriteStartArray("emoticons");
        writer.WriteStringValue("cat_dealwithit_anim");
        writer.WriteStringValue("cat_puke_anim");
        writer.WriteStringValue("cat_blink_anim");
        writer.WriteStringValue("cat_gleam_anim");
        writer.WriteStringValue("cat_grumpy_anim");
        writer.WriteEndArray();
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicCassiaEmoticonPack2Asserts(EmoticonPack emoticonPack)
    {
        Assert.AreEqual("CassiaEmoticonPack2", emoticonPack.Id);
        Assert.AreEqual("Cassia Pack 2", emoticonPack.Name);
        Assert.AreEqual("CassiaEmoticonPack2", emoticonPack.HyperlinkId);
        Assert.AreEqual(Rarity.Common, emoticonPack.Rarity);
        Assert.AreEqual("Diablo", emoticonPack.CollectionCategory);
        Assert.IsNull(emoticonPack.EventName);
        Assert.AreEqual(new DateTime(2017, 3, 14), emoticonPack.ReleaseDate);
        Assert.AreEqual("Cassia emojis that can be used to express emotions or ideas in chat. Hover over an emoji below to view its text command.", emoticonPack.Description?.RawDescription);
        Assert.AreEqual(5, emoticonPack.EmoticonIds.Count);
        Assert.AreEqual("cassia_angry", emoticonPack.EmoticonIds.ToList()[0]);
    }

    private static void BasicCatSpooky18PackAsserts(EmoticonPack emoticonPack)
    {
        Assert.AreEqual("CatSpooky18Pack", emoticonPack.Id);
        Assert.AreEqual("Cursed Cats Emoji Pack", emoticonPack.Name);
        Assert.AreEqual("CatSpooky18Pack", emoticonPack.HyperlinkId);
        Assert.AreEqual(Rarity.Common, emoticonPack.Rarity);
        Assert.AreEqual("SeasonalEvents", emoticonPack.CollectionCategory);
        Assert.AreEqual("HallowsEnd", emoticonPack.EventName);
        Assert.AreEqual(new DateTime(2018, 9, 25), emoticonPack.ReleaseDate);
        Assert.IsNull(emoticonPack.Description?.RawDescription);
        Assert.AreEqual(5, emoticonPack.EmoticonIds.Count);
        Assert.AreEqual("cat_dealwithit_anim", emoticonPack.EmoticonIds.ToList()[0]);
    }
}
