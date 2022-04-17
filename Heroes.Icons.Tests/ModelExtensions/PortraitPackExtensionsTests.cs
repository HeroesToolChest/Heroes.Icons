namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class PortraitPackExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        PortraitPack portraitPack = new PortraitPack
        {
            Id = "AbathurToys18Portrait",
        };

        portraitPack.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Caterpillathur Portrait", portraitPack.Name);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        PortraitPack portraitPack = new PortraitPack
        {
            Id = "AdmiralKrakenovPortrait",
        };

        Assert.ThrowsException<ArgumentNullException>(() => portraitPack.UpdateGameStrings(null!));
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
        writer.WriteStartObject("portrait");

        writer.WriteStartObject("name");
        writer.WriteString("AbathurToys18Portrait", "Caterpillathur Portrait");
        writer.WriteString("AdmiralKrakenovPortrait", "Admiral Krakenov Portrait");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end portrait

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
