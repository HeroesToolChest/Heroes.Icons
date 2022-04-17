namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class MountDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "mountdata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly MountDataDocument _mountDataDocument;

    public MountDataDocumentTests()
    {
        _mountDataDocument = MountDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using MountDataDocument document = MountDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetMountById("AlarakTaldarimMarch", out Mount? mount));
        Assert.AreEqual("군주의 승천", mount!.Name);
        Assert.AreEqual("그가 공중에 살짝만 떠올라도 당신은 군주를 따라잡을 수 없습니다.", mount!.InfoText?.RawDescription);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using MountDataDocument document = MountDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using MountDataDocument document = MountDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using MountDataDocument document = MountDataDocument.Parse(GetBytesForROM("AlarakTaldarimMarch"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetMountById("AlarakTaldarimMarch", out Mount? mount));
        Assert.AreEqual("군주의 승천", mount!.Name);
        Assert.AreEqual("그가 공중에 살짝만 떠올라도 당신은 군주를 따라잡을 수 없습니다.", mount!.InfoText?.RawDescription);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using MountDataDocument document = MountDataDocument.Parse(GetBytesForROM("AlarakTaldarimMarch"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MountDataDocument document = MountDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MountDataDocument document = MountDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MountDataDocument document = MountDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MountDataDocument document = await MountDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MountDataDocument document = await MountDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MountDataDocument document = await MountDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AlarakTaldarimMarch", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("AnubarakWings")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetMountByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _mountDataDocument.GetMountById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _mountDataDocument.GetMountById(id);
            });

            return;
        }

        BasicAnubarakWingsAsserts(_mountDataDocument.GetMountById(id));
    }

    [DataTestMethod]
    [DataRow("AnubarakWings")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetMountByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_mountDataDocument.TryGetMountById(id, out _));

            return;
        }

        Assert.IsTrue(_mountDataDocument.TryGetMountById(id, out Mount? _));
        if (_mountDataDocument.TryGetMountById(id, out Mount? mount))
        {
            BasicAnubarakWingsAsserts(mount);
        }
    }

    [DataTestMethod]
    [DataRow("CryptLordWings")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetMountByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _mountDataDocument.GetMountByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _mountDataDocument.GetMountByHyperlinkId(id);
            });

            return;
        }

        BasicAnubarakWingsAsserts(_mountDataDocument.GetMountByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("CryptLordWings")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetMountByIdHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_mountDataDocument.TryGetMountByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_mountDataDocument.TryGetMountByHyperlinkId(id, out Mount? mount));
        BasicAnubarakWingsAsserts(mount!);
    }

    [DataTestMethod]
    [DataRow("AnWg")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetMountByAttributeIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _mountDataDocument.GetMountByAttributeId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _mountDataDocument.GetMountByAttributeId(id);
            });

            return;
        }

        BasicAnubarakWingsAsserts(_mountDataDocument.GetMountByAttributeId(id));
    }

    [DataTestMethod]
    [DataRow("AnWg")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetMountByAttributeIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_mountDataDocument.TryGetMountByAttributeId(id, out _));

            return;
        }

        Assert.IsTrue(_mountDataDocument.TryGetMountByAttributeId(id, out Mount? mount));
        BasicAnubarakWingsAsserts(mount!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new();
        using Utf8JsonWriter writer = new(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("AlarakTaldarimMarch");
        writer.WriteString("name", "Highlord's Ascent");
        writer.WriteString("hyperlinkId", "HighlordsAscent");
        writer.WriteString("attributeId", "Alru");
        writer.WriteString("rarity", "Common");
        writer.WriteString("type", "AlarakTaldarimMarch");
        writer.WriteString("category", "Unique");
        writer.WriteString("releaseDate", "2014-03-13");
        writer.WriteString("sortName", "1HeroAlarak");
        writer.WriteString("searchText", "Highlord's Ascent");
        writer.WriteString("infoText", "Should he choose to float only an inch off the ground, you would still be beneath the Highlord.");
        writer.WriteEndObject();

        writer.WriteStartObject("AnubarakWings");
        writer.WriteString("name", "Crypt Lord Wings");
        writer.WriteString("hyperlinkId", "CryptLordWings");
        writer.WriteString("attributeId", "AnWg");
        writer.WriteString("rarity", "Common");
        writer.WriteString("type", "AnubarakWings");
        writer.WriteString("category", "Unique");
        writer.WriteString("releaseDate", "2014-03-13");
        writer.WriteString("sortName", "1HeroAnubarak");
        writer.WriteString("searchText", "Crypt Lord Wings");
        writer.WriteString("infoText", "In the years following the Third War, Azerothian scholars hypothesized that the wings of spiderlords were vestigal, incapable of flight. They were very wrong..");
        writer.WriteString("franchise", "Warcraft");

        writer.WriteStartArray("variationMounts");
        writer.WriteStringValue("ArmoredHorseBrown");
        writer.WriteStringValue("ArmoredHorsePurple");
        writer.WriteEndArray();

        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicAnubarakWingsAsserts(Mount mount)
    {
        Assert.AreEqual("AnubarakWings", mount.Id);
        Assert.AreEqual("Crypt Lord Wings", mount.Name);
        Assert.AreEqual("CryptLordWings", mount.HyperlinkId);
        Assert.AreEqual("AnWg", mount.AttributeId);
        Assert.AreEqual(Rarity.Common, mount.Rarity);
        Assert.AreEqual("AnubarakWings", mount.MountCategory);
        Assert.AreEqual("Unique", mount.CollectionCategory);
        Assert.AreEqual(new DateTime(2014, 3, 13), mount.ReleaseDate);
        Assert.AreEqual("1HeroAnubarak", mount.SortName);
        Assert.AreEqual("Crypt Lord Wings", mount.SearchText);
        Assert.AreEqual("In the years following the Third War, Azerothian scholars hypothesized that the wings of spiderlords were vestigal, incapable of flight. They were very wrong..", mount.InfoText?.RawDescription);
        Assert.AreEqual(Franchise.Warcraft, mount.Franchise);
        Assert.AreEqual(2, mount.VariationMountIds.Count);
        Assert.AreEqual("ArmoredHorsePurple", mount.VariationMountIds.ToList()[1]);
    }
}
