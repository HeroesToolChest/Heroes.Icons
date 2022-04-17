namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class SprayDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "spraydata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly SprayDataDocument _sprayDataDocument;

    public SprayDataDocumentTests()
    {
        _sprayDataDocument = SprayDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using SprayDataDocument document = SprayDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetSprayById("SprayAnimatedCookieAbathur", out Spray? spray));
        Assert.AreEqual("과자 아바투르", spray!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using SprayDataDocument document = SprayDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using SprayDataDocument document = SprayDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using SprayDataDocument document = SprayDataDocument.Parse(GetBytesForROM("SprayAnimatedCookieAbathur"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetSprayById("SprayAnimatedCookieAbathur", out Spray? spray));
        Assert.AreEqual("과자 아바투르", spray!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using SprayDataDocument document = SprayDataDocument.Parse(GetBytesForROM("SprayAnimatedCookieAbathur"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using SprayDataDocument document = SprayDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using SprayDataDocument document = SprayDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using SprayDataDocument document = SprayDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using SprayDataDocument document = await SprayDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using SprayDataDocument document = await SprayDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using SprayDataDocument document = await SprayDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("SprayAnimatedCookieAbathur", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("SprayAnimatedCookieButcher")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetSprayByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _sprayDataDocument.GetSprayById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _sprayDataDocument.GetSprayById(id);
            });

            return;
        }

        BasicSprayAnimatedCookieButcherAsserts(_sprayDataDocument.GetSprayById(id));
    }

    [DataTestMethod]
    [DataRow("SprayAnimatedCookieButcher")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetSprayByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_sprayDataDocument.TryGetSprayById(id, out _));

            return;
        }

        Assert.IsTrue(_sprayDataDocument.TryGetSprayById(id, out Spray? _));
        if (_sprayDataDocument.TryGetSprayById(id, out Spray? spray))
        {
            BasicSprayAnimatedCookieButcherAsserts(spray);
        }
    }

    [DataTestMethod]
    [DataRow("GingerbreadAbathur")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetSprayByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _sprayDataDocument.GetSprayByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _sprayDataDocument.GetSprayByHyperlinkId(id);
            });

            return;
        }

        BasicSprayAnimatedCookieAbathurAsserts(_sprayDataDocument.GetSprayByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("GingerbreadButcher")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetSprayByIdHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_sprayDataDocument.TryGetSprayByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_sprayDataDocument.TryGetSprayByHyperlinkId(id, out Spray? spray));
        BasicSprayAnimatedCookieButcherAsserts(spray!);
    }

    [DataTestMethod]
    [DataRow("Sy02")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetSprayByAttributeIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _sprayDataDocument.GetSprayByAttributeId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _sprayDataDocument.GetSprayByAttributeId(id);
            });

            return;
        }

        BasicSprayAnimatedCookieButcherAsserts(_sprayDataDocument.GetSprayByAttributeId(id));
    }

    [DataTestMethod]
    [DataRow("Sy02")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetSprayByAttributeIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_sprayDataDocument.TryGetSprayByAttributeId(id, out _));

            return;
        }

        Assert.IsTrue(_sprayDataDocument.TryGetSprayByAttributeId(id, out Spray? spray));
        BasicSprayAnimatedCookieButcherAsserts(spray!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new();
        using Utf8JsonWriter writer = new(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("SprayAnimatedCookieAbathur");
        writer.WriteString("name", "Gingerbread Abathur");
        writer.WriteString("hyperlinkId", "GingerbreadAbathur");
        writer.WriteString("attributeId", "Sy01");
        writer.WriteString("rarity", "Rare");
        writer.WriteString("category", "SeasonalEvents");
        writer.WriteString("event", "WinterVeil");
        writer.WriteString("releaseDate", "2017-12-12");
        writer.WriteString("sortName", "4WinterA17Cookie");
        writer.WriteString("image", "storm_lootspray_animated_cookie_abathur.gif");
        writer.WriteString("description", "asdf");
        writer.WriteString("searchText", "cookie");
        writer.WriteStartObject("animation");
        writer.WriteString("texture", "storm_lootspray_animated_cookie_abathur.png");
        writer.WriteNumber("frames", 2);
        writer.WriteNumber("duration", 2000);
        writer.WriteEndObject();
        writer.WriteEndObject();

        writer.WriteStartObject("SprayAnimatedCookieButcher");
        writer.WriteString("name", "Gingerbread Butcher");
        writer.WriteString("hyperlinkId", "GingerbreadButcher");
        writer.WriteString("attributeId", "Sy02");
        writer.WriteString("rarity", "Rare");
        writer.WriteString("category", "SeasonalEvents");
        writer.WriteString("event", "WinterVeil");
        writer.WriteString("releaseDate", "2017-12-12");
        writer.WriteString("sortName", "4WinterA17Cookie");
        writer.WriteString("image", "storm_lootspray_animated_cookie_butcher.gif");
        writer.WriteStartObject("animation");
        writer.WriteString("texture", "storm_lootspray_animated_cookie_butcher.png");
        writer.WriteNumber("frames", 2);
        writer.WriteNumber("duration", 2000);
        writer.WriteEndObject();
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicSprayAnimatedCookieAbathurAsserts(Spray spray)
    {
        Assert.AreEqual("SprayAnimatedCookieAbathur", spray.Id);
        Assert.AreEqual("Gingerbread Abathur", spray.Name);
        Assert.AreEqual("GingerbreadAbathur", spray.HyperlinkId);
        Assert.AreEqual("Sy01", spray.AttributeId);
        Assert.AreEqual(Rarity.Rare, spray.Rarity);
        Assert.AreEqual("SeasonalEvents", spray.CollectionCategory);
        Assert.AreEqual("WinterVeil", spray.EventName);
        Assert.AreEqual(new DateTime(2017, 12, 12), spray.ReleaseDate);
        Assert.AreEqual("4WinterA17Cookie", spray.SortName);
        Assert.AreEqual("asdf", spray.Description?.RawDescription);
        Assert.AreEqual("cookie", spray.SearchText);
        Assert.AreEqual(2, spray.AnimationCount);
        Assert.AreEqual(2000, spray.AnimationDuration);
        Assert.AreEqual("storm_lootspray_animated_cookie_abathur.png", spray.TextureSheet.Image);
    }

    private static void BasicSprayAnimatedCookieButcherAsserts(Spray spray)
    {
        Assert.AreEqual("SprayAnimatedCookieButcher", spray.Id);
        Assert.AreEqual("Gingerbread Butcher", spray.Name);
        Assert.AreEqual("GingerbreadButcher", spray.HyperlinkId);
        Assert.AreEqual("Sy02", spray.AttributeId);
        Assert.AreEqual(Rarity.Rare, spray.Rarity);
        Assert.AreEqual("SeasonalEvents", spray.CollectionCategory);
        Assert.AreEqual("WinterVeil", spray.EventName);
        Assert.AreEqual(new DateTime(2017, 12, 12), spray.ReleaseDate);
        Assert.AreEqual("4WinterA17Cookie", spray.SortName);
        Assert.IsNull(spray.Description?.RawDescription);
        Assert.IsNull(spray.SearchText);
        Assert.AreEqual(2, spray.AnimationCount);
        Assert.AreEqual(2000, spray.AnimationDuration);
        Assert.AreEqual("storm_lootspray_animated_cookie_butcher.png", spray.TextureSheet.Image);
    }
}
