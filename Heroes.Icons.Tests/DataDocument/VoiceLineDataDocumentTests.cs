namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class VoiceLineDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "voicelinedata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly VoiceLineDataDocument _voiceLineDataDocument;

    public VoiceLineDataDocumentTests()
    {
        _voiceLineDataDocument = VoiceLineDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetVoiceLineById("AbathurBase_VoiceLine01", out VoiceLine? voiceLine));
        Assert.AreEqual("군단을 위하여", voiceLine!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(GetBytesForROM("AbathurBase_VoiceLine01"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetVoiceLineById("AbathurBase_VoiceLine01", out VoiceLine? voiceLine));
        Assert.AreEqual("군단을 위하여", voiceLine!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(GetBytesForROM("AbathurBase_VoiceLine01"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using VoiceLineDataDocument document = VoiceLineDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using VoiceLineDataDocument document = await VoiceLineDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using VoiceLineDataDocument document = await VoiceLineDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using VoiceLineDataDocument document = await VoiceLineDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurBase_VoiceLine01", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("MephistoBase_VoiceLine02")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetVoiceLineByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _voiceLineDataDocument.GetVoiceLineById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _voiceLineDataDocument.GetVoiceLineById(id);
            });

            return;
        }

        BasicMephistoBase_VoiceLine02Asserts(_voiceLineDataDocument.GetVoiceLineById(id));
    }

    [DataTestMethod]
    [DataRow("MephistoBase_VoiceLine02")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetVoiceLineByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_voiceLineDataDocument.TryGetVoiceLineById(id, out _));

            return;
        }

        Assert.IsTrue(_voiceLineDataDocument.TryGetVoiceLineById(id, out VoiceLine? _));
        if (_voiceLineDataDocument.TryGetVoiceLineById(id, out VoiceLine? voiceLine))
        {
            BasicMephistoBase_VoiceLine02Asserts(voiceLine);
        }
    }

    [DataTestMethod]
    [DataRow("AbathurVoiceLine01")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetVoiceLineByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _voiceLineDataDocument.GetVoiceLineByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _voiceLineDataDocument.GetVoiceLineByHyperlinkId(id);
            });

            return;
        }

        BasicAbathurBase_VoiceLine01Asserts(_voiceLineDataDocument.GetVoiceLineByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("MephistoVoiceLine02")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetVoiceLineByIdHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_voiceLineDataDocument.TryGetVoiceLineByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_voiceLineDataDocument.TryGetVoiceLineByHyperlinkId(id, out VoiceLine? voiceLine));
        BasicMephistoBase_VoiceLine02Asserts(voiceLine!);
    }

    [DataTestMethod]
    [DataRow("MP02")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetVoiceLineByAttributeIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _voiceLineDataDocument.GetVoiceLineByAttributeId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _voiceLineDataDocument.GetVoiceLineByAttributeId(id);
            });

            return;
        }

        BasicMephistoBase_VoiceLine02Asserts(_voiceLineDataDocument.GetVoiceLineByAttributeId(id));
    }

    [DataTestMethod]
    [DataRow("MP02")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetVoiceLineByAttributeIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_voiceLineDataDocument.TryGetVoiceLineByAttributeId(id, out _));

            return;
        }

        Assert.IsTrue(_voiceLineDataDocument.TryGetVoiceLineByAttributeId(id, out VoiceLine? voiceLine));
        BasicMephistoBase_VoiceLine02Asserts(voiceLine!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new();
        using Utf8JsonWriter writer = new(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("AbathurBase_VoiceLine01");
        writer.WriteString("name", "For the Swarm");
        writer.WriteString("hyperlinkId", "AbathurVoiceLine01");
        writer.WriteString("attributeId", "AB01");
        writer.WriteString("rarity", "Common");
        writer.WriteString("releaseDate", "2014-03-13");
        writer.WriteString("image", "storm_ui_voice_abathur.png");
        writer.WriteString("sortName", "xxabathur");
        writer.WriteString("description", "asdf");
        writer.WriteEndObject();

        writer.WriteStartObject("MephistoBase_VoiceLine02");
        writer.WriteString("name", "You Are Too Late");
        writer.WriteString("hyperlinkId", "MephistoVoiceLine02");
        writer.WriteString("attributeId", "MP02");
        writer.WriteString("rarity", "Common");
        writer.WriteString("releaseDate", "2014-03-13");
        writer.WriteString("image", "storm_ui_voice_mephisto.png");
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicAbathurBase_VoiceLine01Asserts(VoiceLine voiceLine)
    {
        Assert.AreEqual("AbathurBase_VoiceLine01", voiceLine.Id);
        Assert.AreEqual("For the Swarm", voiceLine.Name);
        Assert.AreEqual("AbathurVoiceLine01", voiceLine.HyperlinkId);
        Assert.AreEqual("AB01", voiceLine.AttributeId);
        Assert.AreEqual(Rarity.Common, voiceLine.Rarity);
        Assert.AreEqual(new DateTime(2014, 3, 13), voiceLine.ReleaseDate);
        Assert.AreEqual("xxabathur", voiceLine.SortName);
        Assert.AreEqual("asdf", voiceLine.Description?.RawDescription);
        Assert.AreEqual("storm_ui_voice_abathur.png", voiceLine.ImageFileName);
    }

    private static void BasicMephistoBase_VoiceLine02Asserts(VoiceLine voiceLine)
    {
        Assert.AreEqual("MephistoBase_VoiceLine02", voiceLine.Id);
        Assert.AreEqual("You Are Too Late", voiceLine.Name);
        Assert.AreEqual("MephistoVoiceLine02", voiceLine.HyperlinkId);
        Assert.AreEqual("MP02", voiceLine.AttributeId);
        Assert.AreEqual(Rarity.Common, voiceLine.Rarity);
        Assert.AreEqual(new DateTime(2014, 3, 13), voiceLine.ReleaseDate);
        Assert.IsNull(voiceLine.SortName);
        Assert.IsNull(voiceLine.Description?.RawDescription);
        Assert.AreEqual("storm_ui_voice_mephisto.png", voiceLine.ImageFileName);
    }
}
