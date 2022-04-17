﻿using Heroes.Icons.ModelExtensions;
using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class TalentExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId("ZuljinWrongPlaceWrongTime", "ZuljinWrongPlaceWrongTime")
            {
                AbilityType = AbilityTypes.W,
            },
            Tier = TalentTiers.Level1,
        };

        talent.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Bonus Twin Cleave damage at apex", talent.Tooltip.ShortTooltip!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId("ZuljinWrongPlaceWrongTime", "ZuljinWrongPlaceWrongTime")
            {
                AbilityType = AbilityTypes.W,
            },
            Tier = TalentTiers.Level1,
        };

        Assert.ThrowsException<ArgumentNullException>(() => talent.UpdateGameStrings(null!));
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

        writer.WriteStartObject("difficulty");
        writer.WriteString("Alarak", "Hard");
        writer.WriteEndObject();

        writer.WriteStartObject("expandedrole");
        writer.WriteString("Alarak", "Melee Assassin");
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
