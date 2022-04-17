﻿namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class AnnouncerDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "announcerdata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly AnnouncerDataDocument _announcerDataDocument;

    public AnnouncerDataDocumentTests()
    {
        _announcerDataDocument = AnnouncerDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetAnnouncerById("AbathurA", out Announcer _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(GetBytesForROM("AbathurA"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetAnnouncerById("AbathurA", out Announcer _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(GetBytesForROM("AbathurA"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using AnnouncerDataDocument document = AnnouncerDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using AnnouncerDataDocument document = await AnnouncerDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using AnnouncerDataDocument document = await AnnouncerDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using AnnouncerDataDocument document = await AnnouncerDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("Adjutant")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetAnnouncerByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerById(id);
            });

            return;
        }

        BasicAdjutantAsserts(_announcerDataDocument.GetAnnouncerById(id));
    }

    [DataTestMethod]
    [DataRow("Adjutant")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetAnnouncerByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_announcerDataDocument.TryGetAnnouncerById(id, out _));

            return;
        }

        Assert.IsTrue(_announcerDataDocument.TryGetAnnouncerById(id, out Announcer? _));
        if (_announcerDataDocument.TryGetAnnouncerById(id, out Announcer? announcer))
        {
            BasicAdjutantAsserts(announcer);
        }
    }

    [DataTestMethod]
    [DataRow("AdjutantAnnouncer")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetAnnouncerByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerByHyperlinkId(id);
            });

            return;
        }

        BasicAdjutantAsserts(_announcerDataDocument.GetAnnouncerByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("AdjutantAnnouncer")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetAnnouncerByIdHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_announcerDataDocument.TryGetAnnouncerByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_announcerDataDocument.TryGetAnnouncerByHyperlinkId(id, out Announcer? announcer));
        BasicAdjutantAsserts(announcer!);
    }

    [DataTestMethod]
    [DataRow("AADJ")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetAnnouncerByAttributeIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerByAttributeId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerByAttributeId(id);
            });

            return;
        }

        BasicAdjutantAsserts(_announcerDataDocument.GetAnnouncerByAttributeId(id));
    }

    [DataTestMethod]
    [DataRow("AADJ")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetAnnouncerByAttributeIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_announcerDataDocument.TryGetAnnouncerByAttributeId(id, out _));

            return;
        }

        Assert.IsTrue(_announcerDataDocument.TryGetAnnouncerByAttributeId(id, out Announcer? announcer));
        BasicAdjutantAsserts(announcer!);
    }

    [DataTestMethod]
    [DataRow("AI")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetAnnouncerByHeroIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerByHeroId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _announcerDataDocument.GetAnnouncerByHeroId(id);
            });

            return;
        }

        BasicAdjutantAsserts(_announcerDataDocument.GetAnnouncerByHeroId(id));
    }

    [DataTestMethod]
    [DataRow("AI")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetAnnouncerByHeroIdTest(string id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_announcerDataDocument.TryGetAnnouncerByHeroId(id, out _));

            return;
        }

        Assert.IsTrue(_announcerDataDocument.TryGetAnnouncerByHeroId(id, out Announcer? announcer));
        BasicAdjutantAsserts(announcer!);
    }

    [TestMethod]
    public void UpdateGameStringsTest()
    {
        Announcer announcer = new Announcer
        {
            Id = "AbathurA",
        };

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());
        gameStringDocument.UpdateGameStrings(announcer);

        Assert.ThrowsException<ArgumentNullException>(() => gameStringDocument.UpdateGameStrings(announcer: null!));

        Assert.AreEqual("Abathur Announcer", announcer.Name);
        Assert.AreEqual("asdf", announcer.Description?.RawDescription);
        Assert.AreEqual("asdfsn", announcer.SortName);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("AbathurA");
        writer.WriteString("name", "Abathur Announcer");
        writer.WriteString("hyperlinkId", "AbathurAnnouncer");
        writer.WriteString("attributeId", "AB01");
        writer.WriteString("rarity", "Legendary");
        writer.WriteString("category", "Starcraft");
        writer.WriteString("gender", "Unknown");
        writer.WriteString("heroId", "Abathur");
        writer.WriteString("releaseDate", "2014-03-13");
        writer.WriteString("image", "storm_ui_announcer_abathur.png");
        writer.WriteEndObject();

        writer.WriteStartObject("Adjutant");
        writer.WriteString("name", "Adjutant Announcer");
        writer.WriteString("hyperlinkId", "AdjutantAnnouncer");
        writer.WriteString("attributeId", "AADJ");
        writer.WriteString("rarity", "Legendary");
        writer.WriteString("category", "Starcraft");
        writer.WriteString("gender", "Female");
        writer.WriteString("heroId", "AI");
        writer.WriteString("releaseDate", "2018-03-27");
        writer.WriteString("image", "storm_ui_announcer_adjutant.png");
        writer.WriteString("description", "Ann");
        writer.WriteString("sortName", "adj");
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static byte[] LoadEnusLocalizedStringData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);

        writer.WriteStartObject();

        writer.WriteStartObject("meta");
        writer.WriteString("locale", "enus");
        writer.WriteEndObject(); // meta

        writer.WriteStartObject("gamestrings");
        writer.WriteStartObject("announcer");

        writer.WriteStartObject("name");
        writer.WriteString("AbathurA", "Abathur Announcer");
        writer.WriteString("Adjutant", "Adjutant Announcer");
        writer.WriteEndObject();
        writer.WriteStartObject("description");
        writer.WriteString("AbathurA", "asdf");
        writer.WriteString("Adjutant", "qwer");
        writer.WriteEndObject();
        writer.WriteStartObject("sortName");
        writer.WriteString("AbathurA", "asdfsn");
        writer.WriteString("Adjutant", "qwersn");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end announcer

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicAdjutantAsserts(Announcer announcer)
    {
        Assert.AreEqual("Adjutant", announcer.Id);
        Assert.AreEqual("Adjutant Announcer", announcer.Name);
        Assert.AreEqual("AdjutantAnnouncer", announcer.HyperlinkId);
        Assert.AreEqual("AADJ", announcer.AttributeId);
        Assert.AreEqual(Rarity.Legendary, announcer.Rarity);
        Assert.AreEqual("Starcraft", announcer.CollectionCategory);
        Assert.AreEqual("Female", announcer.Gender);
        Assert.AreEqual("AI", announcer.HeroId);
        Assert.AreEqual(new DateTime(2018, 3, 27), announcer.ReleaseDate);
        Assert.AreEqual("storm_ui_announcer_adjutant.png", announcer.ImageFileName);
        Assert.AreEqual("Ann", announcer.Description?.RawDescription);
        Assert.AreEqual("adj", announcer.SortName);
    }
}
