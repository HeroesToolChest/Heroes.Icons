namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class TypeDescriptionExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        LootChest lootChest = new()
        {
            Id = "BasicPortrait",
        };

        lootChest.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("some name", lootChest.Name);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        LootChest lootChest = new()
        {
            Id = "BasicPortrait",
        };

        Assert.ThrowsException<ArgumentNullException>(() => lootChest.UpdateGameStrings(null!));
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
        writer.WriteStartObject("lootchest");

        writer.WriteStartObject("name");
        writer.WriteString("BasicPortrait", "some name");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
