namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class BehaviorVeterancyDataDocumentTests : DataDocumentBase
{
    private readonly string _dataFile = Path.Combine("JsonData", "behaviorveterancydata_76893_kokr.json");

    private readonly BehaviorVeterancyDataDocument _behaviorVeterancyDataDocument;

    public BehaviorVeterancyDataDocumentTests()
    {
        _behaviorVeterancyDataDocument = BehaviorVeterancyDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using BehaviorVeterancyDataDocument document = BehaviorVeterancyDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("alteracpass-CoreScaling", out JsonElement jsonElement));
        Assert.IsTrue(jsonElement!.GetProperty("combineXP").GetBoolean());
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using BehaviorVeterancyDataDocument document = BehaviorVeterancyDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("alteracpass-CoreScaling", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using BehaviorVeterancyDataDocument document = BehaviorVeterancyDataDocument.Parse(GetBytesForROM("alteracpass-CoreScaling"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("alteracpass-CoreScaling", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BehaviorVeterancyDataDocument document = BehaviorVeterancyDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("alteracpass-CoreScaling", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BehaviorVeterancyDataDocument document = await BehaviorVeterancyDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("alteracpass-CoreScaling", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("alteracpass-CoreScaling")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetBehaviorVeterancyByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _behaviorVeterancyDataDocument.GetBehaviorVeterancyById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _behaviorVeterancyDataDocument.GetBehaviorVeterancyById(id);
            });

            return;
        }

        BasicAlteracpassCoreScalingAsserts(_behaviorVeterancyDataDocument.GetBehaviorVeterancyById(id));
    }

    [DataTestMethod]
    [DataRow("alteracpass-CoreScaling")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetBehaviorVeterancyByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_behaviorVeterancyDataDocument.TryGetBehaviorVeterancyById(id, out _));

            return;
        }

        Assert.IsTrue(_behaviorVeterancyDataDocument.TryGetBehaviorVeterancyById(id, out BehaviorVeterancy? _));
        if (_behaviorVeterancyDataDocument.TryGetBehaviorVeterancyById(id, out BehaviorVeterancy? behaviorVeterancy))
        {
            BasicAlteracpassCoreScalingAsserts(behaviorVeterancy);
        }
    }

    [DataTestMethod]
    [DataRow("ExcellentMana")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetBehaviorVeterancyByIdExcellentManaTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_behaviorVeterancyDataDocument.TryGetBehaviorVeterancyById(id, out _));

            return;
        }

        Assert.IsTrue(_behaviorVeterancyDataDocument.TryGetBehaviorVeterancyById(id, out BehaviorVeterancy? _));
        if (_behaviorVeterancyDataDocument.TryGetBehaviorVeterancyById(id, out BehaviorVeterancy? behaviorVeterancy))
        {
            BasicExcellentManaAsserts(behaviorVeterancy);
        }
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("alteracpass-CoreScaling");
        writer.WriteBoolean("combineModifications", true);
        writer.WriteBoolean("combineXP", true);
        writer.WriteStartArray("veterancyLevels");

        writer.WriteStartObject();
        writer.WriteNumber("minVeterancyXP", 1);
        writer.WriteEndObject();

        writer.WriteStartObject();
        writer.WriteNumber("minVeterancyXP", 1);
        writer.WriteStartObject("modifications");
        writer.WriteStartObject("vitalMax");
        writer.WriteNumber("Life", 405);
        writer.WriteNumber("Shields", 0);
        writer.WriteEndObject(); // vital max
        writer.WriteStartObject("vitalRegen");
        writer.WriteNumber("Shields", 0);
        writer.WriteEndObject(); // vital regen
        writer.WriteEndObject(); // modifications
        writer.WriteEndObject();

        writer.WriteStartObject();
        writer.WriteNumber("minVeterancyXP", 1);
        writer.WriteStartObject("modifications");
        writer.WriteNumber("killXPBonus", 1.0);
        writer.WriteStartObject("damageDealtScaled");
        writer.WriteNumber("Basic", 1.25);
        writer.WriteEndObject();
        writer.WriteStartObject("damageDealtFraction");
        writer.WriteNumber("Ability", 0.05);
        writer.WriteEndObject();
        writer.WriteStartObject("vitalMaxFraction");
        writer.WriteNumber("Life", 0.1);
        writer.WriteEndObject();
        writer.WriteStartObject("vitalRegenFraction");
        writer.WriteNumber("Life", 1.10);
        writer.WriteEndObject();
        writer.WriteEndObject(); // modifications
        writer.WriteEndObject();

        writer.WriteEndArray();

        writer.WriteEndObject();

        writer.WriteStartObject("ExcellentMana");
        writer.WriteBoolean("combineModifications", true);
        writer.WriteBoolean("combineXP", true);
        writer.WriteStartArray("veterancyLevels");

        writer.WriteStartObject();
        writer.WriteNumber("minVeterancyXP", 0);
        writer.WriteEndObject();

        writer.WriteEndArray();

        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicAlteracpassCoreScalingAsserts(BehaviorVeterancy behaviorVeterancy)
    {
        Assert.AreEqual("alteracpass-CoreScaling", behaviorVeterancy.Id);

        Assert.IsTrue(behaviorVeterancy.IsMapUnique);
        Assert.AreEqual("alteracpass", behaviorVeterancy.MapName);

        Assert.IsTrue(behaviorVeterancy.CombineModifications);
        Assert.IsTrue(behaviorVeterancy.CombineXP);

        List<VeterancyLevel> list = behaviorVeterancy.VeterancyLevels.ToList();
        Assert.AreEqual(1, list[0].MinimumVeterancyXP);
        Assert.AreEqual("Life", list[1].VeterancyModification.VitalMaxCollection.ToList()[0].Type);
        Assert.AreEqual(405, list[1].VeterancyModification.VitalMaxCollection.ToList()[0].Value);
        Assert.AreEqual("Shields", list[1].VeterancyModification.VitalMaxCollection.ToList()[1].Type);
        Assert.AreEqual(0, list[1].VeterancyModification.VitalMaxCollection.ToList()[1].Value);

        Assert.AreEqual("Shields", list[1].VeterancyModification.VitalRegenCollection.ToList()[0].Type);
        Assert.AreEqual(0, list[1].VeterancyModification.VitalRegenCollection.ToList()[0].Value);

        Assert.AreEqual(1.0, list[2].VeterancyModification.KillXpBonus);
        Assert.AreEqual("Basic", list[2].VeterancyModification.DamageDealtScaledCollection.ToList()[0].Type);
        Assert.AreEqual(1.25, list[2].VeterancyModification.DamageDealtScaledCollection.ToList()[0].Value);
        Assert.AreEqual("Ability", list[2].VeterancyModification.DamageDealtFractionCollection.ToList()[0].Type);
        Assert.AreEqual(0.05, list[2].VeterancyModification.DamageDealtFractionCollection.ToList()[0].Value);
        Assert.AreEqual("Life", list[2].VeterancyModification.VitalMaxFractionCollection.ToList()[0].Type);
        Assert.AreEqual(0.1, list[2].VeterancyModification.VitalMaxFractionCollection.ToList()[0].Value);
        Assert.AreEqual("Life", list[2].VeterancyModification.VitalRegenFractionCollection.ToList()[0].Type);
        Assert.AreEqual(1.10, list[2].VeterancyModification.VitalRegenFractionCollection.ToList()[0].Value);
    }

    private static void BasicExcellentManaAsserts(BehaviorVeterancy behaviorVeterancy)
    {
        Assert.AreEqual("ExcellentMana", behaviorVeterancy.Id);

        Assert.IsFalse(behaviorVeterancy.IsMapUnique);
        Assert.IsNull(behaviorVeterancy.MapName);

        Assert.IsTrue(behaviorVeterancy.CombineModifications);
        Assert.IsTrue(behaviorVeterancy.CombineXP);
    }
}
