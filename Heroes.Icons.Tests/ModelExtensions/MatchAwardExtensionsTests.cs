namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class MatchAwardExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        MatchAward matchAward = new()
        {
            Id = "ClutchHealer",
        };

        matchAward.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Many Heals That Saved a Dying Ally", matchAward.Description!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        MatchAward matchAward = new()
        {
            Id = "ClutchHealer",
        };

        Assert.ThrowsException<ArgumentNullException>(() => matchAward.UpdateGameStrings(null!));
    }

    private static byte[] LoadEnusLocalizedStringData()
    {
        using MemoryStream memoryStream = new();
        using Utf8JsonWriter writer = new(memoryStream);

        writer.WriteStartObject();

        writer.WriteStartObject("meta");
        writer.WriteString("locale", "enus");
        writer.WriteEndObject(); // meta

        writer.WriteStartObject("gamestrings");
        writer.WriteStartObject("award");

        writer.WriteStartObject("name");
        writer.WriteString("ClutchHealer", "Clutch Healer");
        writer.WriteString("MostCoinsPaid", "Moneybags");
        writer.WriteEndObject();
        writer.WriteStartObject("description");
        writer.WriteString("ClutchHealer", "Many Heals That Saved a Dying Ally");
        writer.WriteString("MostCoinsPaid", "High Coins Delivered");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end match award

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
