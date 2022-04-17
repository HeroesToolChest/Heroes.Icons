namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class SprayExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        Spray spray = new Spray
        {
            Id = "SprayAnimatedCarbotsAlarakDark",
        };

        spray.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual(string.Empty, spray.Description!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        Spray spray = new Spray
        {
            Id = "SprayAnimatedCarbotsAlarakDark",
        };

        Assert.ThrowsException<ArgumentNullException>(() => spray.UpdateGameStrings(null!));
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
        writer.WriteStartObject("spray");

        writer.WriteStartObject("name");
        writer.WriteString("SprayAnimatedCarbotsAlarakDark", "Tall, Dark, and Sadistic");
        writer.WriteEndObject();
        writer.WriteStartObject("searchtext");
        writer.WriteString("SprayAnimatedCarbotsAlarakDark", "Dark Nexus Alarak Carbot");
        writer.WriteEndObject();
        writer.WriteStartObject("sortname");
        writer.WriteString("SprayAnimatedCarbotsAlarakDark", "1Animated");
        writer.WriteEndObject();
        writer.WriteStartObject("description");
        writer.WriteString("SprayAnimatedCarbotsAlarakDark", string.Empty);
        writer.WriteEndObject();

        writer.WriteEndObject(); // end spray

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
