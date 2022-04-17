namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class LootChestExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        LootChest lootChest = new LootChest
        {
            Id = "EpicProgChest",
        };

        lootChest.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Epic Chest", lootChest.Name);
        Assert.AreEqual("A Loot Chest that guarantees at least one Epic or better item.", lootChest.Description!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        LootChest lootChest = new LootChest
        {
            Id = "EpicProgChest",
        };

        Assert.ThrowsException<ArgumentNullException>(() => lootChest.UpdateGameStrings(null!));
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
        writer.WriteStartObject("lootchest");

        writer.WriteStartObject("name");
        writer.WriteString("EpicProgChest", "Epic Chest");
        writer.WriteEndObject();
        writer.WriteStartObject("description");
        writer.WriteString("EpicProgChest", "A Loot Chest that guarantees at least one Epic or better item.");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
