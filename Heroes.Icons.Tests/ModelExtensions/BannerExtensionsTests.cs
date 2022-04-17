namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class BannerExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        Banner banner = new Banner
        {
            Id = "BannerD3DemonHunterRare",
        };

        banner.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Only a hunter whose hatred is fully tempered by discipline will ever bear the sigil of the Order-masters.", banner.Description!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        Banner banner = new Banner
        {
            Id = "BannerD3DemonHunter",
        };

        Assert.ThrowsException<ArgumentNullException>(() => banner.UpdateGameStrings(null!));
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
        writer.WriteStartObject("banner");

        writer.WriteStartObject("description");
        writer.WriteString("BannerD3DemonHunter", "The demon hunters are neither a people, nor a nation. Instead, they are survivors bound by vengeance.");
        writer.WriteString("BannerD3DemonHunterRare", "Only a hunter whose hatred is fully tempered by discipline will ever bear the sigil of the Order-masters.");
        writer.WriteEndObject();
        writer.WriteStartObject("name");
        writer.WriteString("BannerD3DemonHunter", "Demon Hunter Banner");
        writer.WriteString("BannerD3DemonHunterRare", "Demon Hunter Warbanner");
        writer.WriteEndObject();
        writer.WriteStartObject("sortname");
        writer.WriteString("BannerD3DemonHunter", "3DemBaseVar0");
        writer.WriteString("BannerD3DemonHunterRare", "3DemRareVar0");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end banner

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
