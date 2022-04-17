namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class TypeDescriptionDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "typedescriptiondata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly TypeDescriptionDataDocument _typeDescriptionDataDocument;

    public TypeDescriptionDataDocumentTests()
    {
        _typeDescriptionDataDocument = TypeDescriptionDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetTypeDescriptionById("BasicPortrait", out TypeDescription? typeDescription));
        Assert.AreEqual("some basic portrait", typeDescription!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(GetBytesForROM("BasicPortrait"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetTypeDescriptionById("BasicPortrait", out TypeDescription? typeDescription));
        Assert.AreEqual("some basic portrait", typeDescription!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(GetBytesForROM("BasicPortrait"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using TypeDescriptionDataDocument document = TypeDescriptionDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using TypeDescriptionDataDocument document = await TypeDescriptionDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using TypeDescriptionDataDocument document = await TypeDescriptionDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using TypeDescriptionDataDocument document = await TypeDescriptionDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("BasicPortrait", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("BasicPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetTypeDescriptionByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _typeDescriptionDataDocument.GetTypeDescriptionById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _typeDescriptionDataDocument.GetTypeDescriptionById(id);
            });

            return;
        }

        BasicPortraitAsserts(_typeDescriptionDataDocument.GetTypeDescriptionById(id));
    }

    [DataTestMethod]
    [DataRow("BasicPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetTypeDescriptionByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_typeDescriptionDataDocument.TryGetTypeDescriptionById(id, out _));

            return;
        }

        Assert.IsTrue(_typeDescriptionDataDocument.TryGetTypeDescriptionById(id, out TypeDescription? _));
        if (_typeDescriptionDataDocument.TryGetTypeDescriptionById(id, out TypeDescription? typeDescription))
        {
            BasicPortraitAsserts(typeDescription);
        }
    }

    [DataTestMethod]
    [DataRow("zBasicPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetTypeDescriptionByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _typeDescriptionDataDocument.GetTypeDescriptionByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _typeDescriptionDataDocument.GetTypeDescriptionByHyperlinkId(id);
            });

            return;
        }

        BasicPortraitAsserts(_typeDescriptionDataDocument.GetTypeDescriptionByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("zBasicPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetTypeDescriptionByIdHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_typeDescriptionDataDocument.TryGetTypeDescriptionByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_typeDescriptionDataDocument.TryGetTypeDescriptionByHyperlinkId(id, out TypeDescription? typeDescription));
        BasicPortraitAsserts(typeDescription!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("BasicPortrait");
        writer.WriteString("name", "basic portrait name");
        writer.WriteString("hyperlinkId", "zBasicPortrait");
        writer.WriteNumber("iconSlot", 32);
        writer.WriteString("image", "storm_typedescription_basicportrait.png");

        writer.WriteStartObject("textureSheet");
        writer.WriteString("image", "storm_ui_heroes_rewardicons_sheet.png");
        writer.WriteNumber("columns", 5);
        writer.WriteNumber("rows", 12);
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicPortraitAsserts(TypeDescription typeDescription)
    {
        Assert.AreEqual("BasicPortrait", typeDescription.Id);
        Assert.AreEqual("basic portrait name", typeDescription.Name);
        Assert.AreEqual("zBasicPortrait", typeDescription.HyperlinkId);
        Assert.AreEqual(32, typeDescription.IconSlot);
        Assert.AreEqual("storm_typedescription_basicportrait.png", typeDescription.ImageFileName);
        Assert.AreEqual("storm_ui_heroes_rewardicons_sheet.png", typeDescription.TextureSheet.Image);
        Assert.AreEqual(5, typeDescription.TextureSheet.Columns);
        Assert.AreEqual(12, typeDescription.TextureSheet.Rows);
    }
}
