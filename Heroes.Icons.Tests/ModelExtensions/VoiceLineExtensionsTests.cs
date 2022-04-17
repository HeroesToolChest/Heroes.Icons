namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class VoiceLineExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        VoiceLine voiceLine = new VoiceLine
        {
            Id = "AbathurBase_VoiceLine01",
        };

        voiceLine.UpdateGameStrings(gameStringDocument);

        Assert.IsNull(voiceLine.Description?.RawDescription);
        Assert.AreEqual("For the Swarm", voiceLine.Name);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        VoiceLine voiceLine = new VoiceLine
        {
            Id = "AbathurBase_VoiceLine01",
        };

        Assert.ThrowsException<ArgumentNullException>(() => voiceLine.UpdateGameStrings(null!));
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
        writer.WriteStartObject("voiceline");

        writer.WriteStartObject("name");
        writer.WriteString("AbathurBase_VoiceLine01", "For the Swarm");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end voice line

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
