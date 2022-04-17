﻿namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class HeroExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        Hero hero = new Hero
        {
            CUnitId = "HeroAlarak",
            CHeroId = "Alarak",
            Id = "Alarak",
        };

        hero.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Highlord of the Tal'darim", hero.Title);
        Assert.AreEqual("A combo Assassin that can move enemies around and punish mistakes.", hero.Description!.RawDescription);
        Assert.AreEqual("Not all heroes are born of altruism... some, like Alarak, simply desire vengeance. As the new Highlord of the Tal'darim, Alarak leads his people to a destiny free of the corrupt influence of the fallen xel'naga, Amon.", hero.InfoText!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        Hero hero = new Hero
        {
            CUnitId = "HeroAlarak",
            CHeroId = "Alarak",
            Id = "Alarak",
        };

        Assert.ThrowsException<ArgumentNullException>(() => hero.UpdateGameStrings(null!));
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
        writer.WriteStartObject("abiltalent");

        writer.WriteStartObject("cooldown");
        writer.WriteString("AlarakDiscordStrike|AlarakDiscordStrike|Q|False", "Cooldown: 8 seconds");
        writer.WriteEndObject();

        writer.WriteStartObject("energy");
        writer.WriteString("AlarakDiscordStrike|AlarakDiscordStrike|Q|False", "<s val=\"bfd4fd\" name=\"StandardTooltipDetails\">Mana: 55</s>");
        writer.WriteEndObject();

        writer.WriteStartObject("full");
        writer.WriteString("AlarakDiscordStrike|AlarakDiscordStrike|Q|False", "After a <c val=\"bfd4fd\">0.5</c> second delay, enemies in front of Alarak take <c val=\"bfd4fd\">175~~0.04~~</c> damage and are silenced for <c val=\"bfd4fd\">1.5</c> seconds. ");
        writer.WriteEndObject();

        writer.WriteStartObject("life");
        writer.WriteString("AlarakDiscordStrike|AlarakDiscordStrike|Q|False", "No life");
        writer.WriteEndObject();

        writer.WriteStartObject("name");
        writer.WriteString("AlarakDiscordStrike|AlarakDiscordStrike|Q|False", "Discord Strike");
        writer.WriteEndObject();

        writer.WriteStartObject("short");
        writer.WriteString("AlarakDiscordStrike|AlarakDiscordStrike|Q|False", "Damage and silence enemies in an area");
        writer.WriteString("ZuljinWrongPlaceWrongTime|ZuljinWrongPlaceWrongTime|W|False", "Bonus Twin Cleave damage at apex");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end abiltalent

        writer.WriteStartObject("unit");

        writer.WriteStartObject("description");
        writer.WriteString("Alarak", "A combo Assassin that can move enemies around and punish mistakes.");
        writer.WriteEndObject();

        writer.WriteStartObject("difficulty");
        writer.WriteString("Alarak", "Hard");
        writer.WriteEndObject();

        writer.WriteStartObject("expandedrole");
        writer.WriteString("Alarak", "Melee Assassin");
        writer.WriteEndObject();

        writer.WriteStartObject("infotext");
        writer.WriteString("Alarak", "Not all heroes are born of altruism... some, like Alarak, simply desire vengeance. As the new Highlord of the Tal'darim, Alarak leads his people to a destiny free of the corrupt influence of the fallen xel'naga, Amon.");
        writer.WriteEndObject();

        writer.WriteStartObject("role");
        writer.WriteString("Alarak", "Assassin,Warrior");
        writer.WriteEndObject();

        writer.WriteStartObject("searchtext");
        writer.WriteString("Alarak", "Alarak Ascendant Protoss SC SC2 StarCraft Star2 Starcraft2 II 2 Legacy of the Void LotV Covert Ops CO");
        writer.WriteEndObject();

        writer.WriteStartObject("title");
        writer.WriteString("Alarak", "Highlord of the Tal'darim");
        writer.WriteEndObject();

        writer.WriteStartObject("type");
        writer.WriteString("Alarak", "Melee");
        writer.WriteEndObject();

        writer.WriteEndObject(); // unit
        writer.WriteEndObject(); // gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
