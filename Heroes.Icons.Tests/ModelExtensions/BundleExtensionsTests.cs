namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class BundleExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        Bundle bundle = new()
        {
            Id = "RaiderRexxarBundle",
        };

        bundle.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("특공대원 렉사르 묶음 상품", bundle.Name);
        Assert.AreEqual("xyzRaiderRexxarBundle", bundle.SortName);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        Bundle bundle = new()
        {
            Id = "RaiderRexxarBundle",
        };

        Assert.ThrowsException<ArgumentNullException>(() => bundle.UpdateGameStrings(null!));
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
        writer.WriteStartObject("bundle");

        writer.WriteStartObject("name");
        writer.WriteString("RaiderRexxarBundle", "특공대원 렉사르 묶음 상품");
        writer.WriteEndObject();
        writer.WriteStartObject("sortname");
        writer.WriteString("RaiderRexxarBundle", "xyzRaiderRexxarBundle");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
