namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class RewardPortraitExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        RewardPortrait rewardPortrait = new RewardPortrait
        {
            Id = "1YearAnniversaryPortrait",
        };

        rewardPortrait.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("1 Year Anniversary Portrait", rewardPortrait.Name);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        RewardPortrait rewardPortrait = new RewardPortrait
        {
            Id = "2016FallGlobalChampionshipPortrait",
        };

        Assert.ThrowsException<ArgumentNullException>(() => rewardPortrait.UpdateGameStrings(null!));
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
        writer.WriteStartObject("rewardportrait");

        writer.WriteStartObject("name");
        writer.WriteString("1YearAnniversaryPortrait", "1 Year Anniversary Portrait");
        writer.WriteString("2016FallGlobalChampionshipPortrait", "2016 Fall Global Championship Portrait");
        writer.WriteEndObject();
        writer.WriteStartObject("description");
        writer.WriteString("1YearAnniversaryPortrait", "Thank you for joining us during the celebration of Heroes of the Storm's first anniversary. To many more years to come! Oh, and don't forget to grab a slice of cake!t");
        writer.WriteString("2016FallGlobalChampionshipPortrait", "Thank you for watching the live stream of the 2016 Fall Global Championship. Please accept this portrait as a token of our appreciation!");
        writer.WriteEndObject();
        writer.WriteStartObject("descriptionunearned");
        writer.WriteString("2016FallGlobalChampionshipPortrait", "Thank you for watching the live stream of the 2016 Fall Global Championship. Please accept this portrait as a token of our appreciation!");
        writer.WriteEndObject();
        writer.WriteEndObject(); // end portrait

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
