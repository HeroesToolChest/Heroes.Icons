﻿namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class HeroSkinExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        HeroSkin heroSkin = new()
        {
            Id = "AbathurBaseVar3",
        };

        heroSkin.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.", heroSkin.InfoText!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        HeroSkin heroSkin = new()
        {
            Id = "AbathurBaseVar3",
        };

        Assert.ThrowsException<ArgumentNullException>(() => heroSkin.UpdateGameStrings(null!));
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
        writer.WriteStartObject("heroskin");

        writer.WriteStartObject("infotext");
        writer.WriteString("AbathurBaseVar3", "Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.");
        writer.WriteString("AbathurBone", "Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.");
        writer.WriteEndObject();
        writer.WriteStartObject("name");
        writer.WriteString("AbathurBaseVar3", "Kaldir Abathur");
        writer.WriteString("AbathurBone", "Bone Abathur");
        writer.WriteEndObject();
        writer.WriteStartObject("searchtext");
        writer.WriteString("AbathurBaseVar3", "Blue");
        writer.WriteString("AbathurBone", "White Pink");
        writer.WriteEndObject();
        writer.WriteStartObject("sortname");
        writer.WriteString("AbathurBaseVar3", "zxAbathurVar1");
        writer.WriteString("AbathurBone", "zxAbathurVar0");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end hero skin

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
