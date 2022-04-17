namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class MatchAwardDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "matchawarddata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly MatchAwardDataDocument _matchAwardDataDocument;

    public MatchAwardDataDocumentTests()
    {
        _matchAwardDataDocument = MatchAwardDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetMatchAwardById("HatTrick", out MatchAward _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(GetBytesForROM("HatTrick"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetMatchAwardById("HatTrick", out MatchAward _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(GetBytesForROM("HatTrick"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MatchAwardDataDocument document = MatchAwardDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MatchAwardDataDocument document = await MatchAwardDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MatchAwardDataDocument document = await MatchAwardDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using MatchAwardDataDocument document = await MatchAwardDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("HatTrick", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("ClutchHealer")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetMatchAwardByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _matchAwardDataDocument.GetMatchAwardById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _matchAwardDataDocument.GetMatchAwardById(id);
            });

            return;
        }

        BasicClutchHealerAsserts(_matchAwardDataDocument.GetMatchAwardById(id));
    }

    [DataTestMethod]
    [DataRow("ClutchHealer")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryMatchAwardByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_matchAwardDataDocument.TryGetMatchAwardById(id, out _));

            return;
        }

        Assert.IsTrue(_matchAwardDataDocument.TryGetMatchAwardById(id, out MatchAward? _));
        if (_matchAwardDataDocument.TryGetMatchAwardById(id, out MatchAward? matchAward))
        {
            BasicClutchHealerAsserts(matchAward);
        }
    }

    [DataTestMethod]
    [DataRow("EndOfMatchAwardClutchHealerBoolean")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetMatchAwardByGameLinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _matchAwardDataDocument.GetMatchAwardByGameLinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _matchAwardDataDocument.GetMatchAwardByGameLinkId(id);
            });

            return;
        }

        BasicClutchHealerAsserts(_matchAwardDataDocument.GetMatchAwardByGameLinkId(id));
    }

    [DataTestMethod]
    [DataRow("EndOfMatchAwardClutchHealerBoolean")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetMatchAwardByGameLinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_matchAwardDataDocument.TryGetMatchAwardByGameLinkId(id, out _));

            return;
        }

        Assert.IsTrue(_matchAwardDataDocument.TryGetMatchAwardByGameLinkId(id, out MatchAward? matchAward));
        BasicClutchHealerAsserts(matchAward!);
    }

    [DataTestMethod]
    [DataRow("AwCH")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetMatchAwardByTagTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _matchAwardDataDocument.GetMatchAwardByTag(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _matchAwardDataDocument.GetMatchAwardByTag(id);
            });

            return;
        }

        BasicClutchHealerAsserts(_matchAwardDataDocument.GetMatchAwardByTag(id));
    }

    [DataTestMethod]
    [DataRow("AwCH")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetMatchAwardByTagTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_matchAwardDataDocument.TryGetMatchAwardByTag(id, out _));

            return;
        }

        Assert.IsTrue(_matchAwardDataDocument.TryGetMatchAwardByTag(id, out MatchAward? matchAward));
        BasicClutchHealerAsserts(matchAward!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new();
        using Utf8JsonWriter writer = new(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("ClutchHealer");
        writer.WriteString("name", "Clutch Healer");
        writer.WriteString("gameLink", "EndOfMatchAwardClutchHealerBoolean");
        writer.WriteString("tag", "AwCH");
        writer.WriteString("mvpScreenIcon", "storm_ui_mvp_clutchhealer_%color%.png");
        writer.WriteString("scoreScreenIcon", "storm_ui_scorescreen_mvp_clutchhealer_%team%.png");
        writer.WriteString("description", "Many Heals That Saved a Dying Ally");
        writer.WriteEndObject();

        writer.WriteStartObject("HatTrick");
        writer.WriteString("name", "Hat Trick");
        writer.WriteString("gameLink", "EndOfMatchAwardHatTrickBoolean");
        writer.WriteString("tag", "AwHT");
        writer.WriteString("mvpScreenIcon", "storm_ui_mvp_hattrick_%color%.png");
        writer.WriteString("scoreScreenIcon", "storm_ui_scorescreen_mvp_hattrick_%team%.png");
        writer.WriteString("description", "First Three Kills of Match");
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicClutchHealerAsserts(MatchAward matchAward)
    {
        Assert.AreEqual("ClutchHealer", matchAward.Id);
        Assert.AreEqual("Clutch Healer", matchAward.Name);
        Assert.AreEqual("EndOfMatchAwardClutchHealerBoolean", matchAward.HyperlinkId);
        Assert.AreEqual("AwCH", matchAward.Tag);
        Assert.AreEqual("storm_ui_mvp_clutchhealer_%color%.png", matchAward.MVPScreenImageFileName);
        Assert.AreEqual("storm_ui_scorescreen_mvp_clutchhealer_%team%.png", matchAward.ScoreScreenImageFileName);
        Assert.AreEqual("Many Heals That Saved a Dying Ally", matchAward.Description?.RawDescription);
    }
}
