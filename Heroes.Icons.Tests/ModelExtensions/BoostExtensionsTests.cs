namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class BoostExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        Boost boost = new Boost
        {
            Id = "30DayPromo",
        };

        boost.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("30 Day Boost", boost.Name);
        Assert.AreEqual("xyz30DayBoost", boost.SortName);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        Boost boost = new Boost
        {
            Id = "30DayPromo",
        };

        Assert.ThrowsException<ArgumentNullException>(() => boost.UpdateGameStrings(null!));
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
        writer.WriteStartObject("boost");

        writer.WriteStartObject("name");
        writer.WriteString("30DayPromo", "30 Day Boost");
        writer.WriteEndObject();
        writer.WriteStartObject("sortname");
        writer.WriteString("30DayPromo", "xyz30DayBoost");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
