namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class RewardPortraitDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "rewardportraitdata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly RewardPortraitDataDocument _rewardPortraitDataDocument;

    public RewardPortraitDataDocumentTests()
    {
        _rewardPortraitDataDocument = RewardPortraitDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetRewardPortraitById("1YearAnniversaryPortrait", out RewardPortrait? rewardPortrait));
        Assert.AreEqual("1주년 기념 초상화", rewardPortrait!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("1YearAnniversaryPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("1YearAnniversaryPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(GetBytesForROM("AbathurCarbotsPortrait"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetRewardPortraitById("AbathurCarbotsPortrait", out RewardPortrait? rewardPortrait));
        Assert.AreEqual("카봇 아바투르 초상화", rewardPortrait!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(GetBytesForROM("AbathurCarbotsPortrait"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurCarbotsPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurCarbotsPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurCarbotsPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using RewardPortraitDataDocument document = RewardPortraitDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurCarbotsPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using RewardPortraitDataDocument document = await RewardPortraitDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurCarbotsPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using RewardPortraitDataDocument document = await RewardPortraitDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurCarbotsPortrait", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using RewardPortraitDataDocument document = await RewardPortraitDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurCarbotsPortrait", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("1YearAnniversaryPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetRewardPortraitByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _rewardPortraitDataDocument.GetRewardPortraitById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _rewardPortraitDataDocument.GetRewardPortraitById(id);
            });

            return;
        }

        Basic1YearAnniversaryPortraitAsserts(_rewardPortraitDataDocument.GetRewardPortraitById(id));
    }

    [DataTestMethod]
    [DataRow("AbathurCarbotsPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetRewardPortraitByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_rewardPortraitDataDocument.TryGetRewardPortraitById(id, out _));

            return;
        }

        Assert.IsTrue(_rewardPortraitDataDocument.TryGetRewardPortraitById(id, out RewardPortrait? _));
        if (_rewardPortraitDataDocument.TryGetRewardPortraitById(id, out RewardPortrait? rewardPortrait))
        {
            BasicAbathurCarbotsPortraitAsserts(rewardPortrait);
        }
    }

    [DataTestMethod]
    [DataRow("1YearAnniversaryPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetRewardPortraitByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _rewardPortraitDataDocument.GetRewardPortraitByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _rewardPortraitDataDocument.GetRewardPortraitByHyperlinkId(id);
            });

            return;
        }

        Basic1YearAnniversaryPortraitAsserts(_rewardPortraitDataDocument.GetRewardPortraitByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("CarbotAbathurPortrait")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetRewardPortraitByHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_rewardPortraitDataDocument.TryGetRewardPortraitByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_rewardPortraitDataDocument.TryGetRewardPortraitByHyperlinkId(id, out RewardPortrait? rewardPortrait));
        BasicAbathurCarbotsPortraitAsserts(rewardPortrait!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("1YearAnniversaryPortrait");
        writer.WriteString("name", "1 Year Anniversary Portrait");
        writer.WriteString("hyperlinkId", "1YearAnniversaryPortrait");
        writer.WriteString("rarity", "Common");
        writer.WriteString("category", "PortraitAchievements1");
        writer.WriteString("description", "Thank you for joining us during the celebration of Heroes of the Storm's first anniversary. To many more years to come! Oh, and don't forget to grab a slice of cake!");
        writer.WriteNumber("iconSlot", 23);
        writer.WriteStartObject("textureSheet");
        writer.WriteString("image", "ui_heroes_portraits_sheet5.png");
        writer.WriteNumber("columns", 6);
        writer.WriteNumber("rows", 6);
        writer.WriteEndObject();
        writer.WriteString("image", "storm_portrait_2015tespamembershipportrait.png");
        writer.WriteEndObject();

        writer.WriteStartObject("AbathurCarbotsPortrait");
        writer.WriteString("name", "Carbot Abathur Portrait");
        writer.WriteString("hyperlinkId", "CarbotAbathurPortrait");
        writer.WriteString("rarity", "Common");
        writer.WriteString("category", "HeroStormPortrait");
        writer.WriteString("description", "You have unlocked this portrait in your Collection");
        writer.WriteString("descriptionUnearned", "Forge using Shards, purchase with Gems, or receive in a Loot Chest to unlock.");
        writer.WriteString("descriptionUnearned", "Forge using Shards, purchase with Gems, or receive in a Loot Chest to unlock.");
        writer.WriteString("heroId", "Abathur");
        writer.WriteString("portraitPackId", "AbathurCarbotsPortrait");
        writer.WriteNumber("iconSlot", 18);
        writer.WriteStartObject("textureSheet");
        writer.WriteString("image", "ui_heroes_portraits_sheet25.png");
        writer.WriteNumber("columns", 6);
        writer.WriteNumber("rows", 6);
        writer.WriteEndObject();
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void Basic1YearAnniversaryPortraitAsserts(RewardPortrait rewardPortrait)
    {
        Assert.AreEqual("1YearAnniversaryPortrait", rewardPortrait.Id);
        Assert.AreEqual("1 Year Anniversary Portrait", rewardPortrait.Name);
        Assert.AreEqual("1YearAnniversaryPortrait", rewardPortrait.HyperlinkId);
        Assert.AreEqual(Rarity.Common, rewardPortrait.Rarity);
        Assert.AreEqual("PortraitAchievements1", rewardPortrait.CollectionCategory);
        Assert.AreEqual("Thank you for joining us during the celebration of Heroes of the Storm's first anniversary. To many more years to come! Oh, and don't forget to grab a slice of cake!", rewardPortrait.Description?.RawDescription);
        Assert.IsNull(rewardPortrait.DescriptionUnearned);
        Assert.IsNull(rewardPortrait.HeroId);
        Assert.IsNull(rewardPortrait.PortraitPackId);
        Assert.AreEqual(23, rewardPortrait.IconSlot);
        Assert.AreEqual("ui_heroes_portraits_sheet5.png", rewardPortrait.TextureSheet.Image);
        Assert.AreEqual(6, rewardPortrait.TextureSheet.Columns);
        Assert.AreEqual(6, rewardPortrait.TextureSheet.Rows);
        Assert.AreEqual("storm_portrait_2015tespamembershipportrait.png", rewardPortrait.ImageFileName);
    }

    private static void BasicAbathurCarbotsPortraitAsserts(RewardPortrait rewardPortrait)
    {
        Assert.AreEqual("AbathurCarbotsPortrait", rewardPortrait.Id);
        Assert.AreEqual("Carbot Abathur Portrait", rewardPortrait.Name);
        Assert.AreEqual("CarbotAbathurPortrait", rewardPortrait.HyperlinkId);
        Assert.AreEqual(Rarity.Common, rewardPortrait.Rarity);
        Assert.AreEqual("HeroStormPortrait", rewardPortrait.CollectionCategory);
        Assert.AreEqual("You have unlocked this portrait in your Collection", rewardPortrait.Description?.RawDescription);
        Assert.AreEqual("Forge using Shards, purchase with Gems, or receive in a Loot Chest to unlock.", rewardPortrait.DescriptionUnearned?.RawDescription);
        Assert.AreEqual("Abathur", rewardPortrait.HeroId);
        Assert.AreEqual("AbathurCarbotsPortrait", rewardPortrait.PortraitPackId);
        Assert.AreEqual(18, rewardPortrait.IconSlot);
        Assert.AreEqual("ui_heroes_portraits_sheet25.png", rewardPortrait.TextureSheet.Image);
        Assert.AreEqual(6, rewardPortrait.TextureSheet.Columns);
        Assert.AreEqual(6, rewardPortrait.TextureSheet.Rows);
    }
}
