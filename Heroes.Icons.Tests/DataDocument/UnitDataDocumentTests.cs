﻿namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class UnitDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "unitdata_76003_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly UnitDataDocument _unitDataDocument;

    public UnitDataDocumentTests()
    {
        _unitDataDocument = UnitDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [DataTestMethod]
    [DataRow("AbathurEvolvedMonstrosity", false, false)]
    [DataRow("AbathurEvolvedMonstrosity", true, false)]
    [DataRow("AbathurEvolvedMonstrosity", false, true)]
    [DataRow("AbathurEvolvedMonstrosity", true, true)]
    [DataRow(null, true, true)]
    [DataRow("asdf", true, true)]
    public void GetUnitByIdTest(string id, bool abilities, bool subAbilities)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _unitDataDocument.GetUnitById(id!, abilities, subAbilities);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _unitDataDocument.GetUnitById(id, abilities, subAbilities);
            });

            return;
        }

        Unit unit = _unitDataDocument.GetUnitById(id, abilities, subAbilities);

        BasicAbathurEvolvedMonstrosityAsserts(unit);

        Assert.AreEqual(755, unit.Life.LifeMax);
        Assert.AreEqual(0.04, unit.Life.LifeScaling);
        Assert.AreEqual("Life", unit.Life.LifeType);
        Assert.AreEqual(5.4256, unit.Life.LifeRegenerationRate);
        Assert.AreEqual(0.04, unit.Life.LifeRegenerationRateScaling);

        Assert.AreEqual(755, unit.Shield.ShieldMax);
        Assert.AreEqual(0.04, unit.Shield.ShieldScaling);
        Assert.AreEqual("Shield", unit.Shield.ShieldType);
        Assert.AreEqual(5, unit.Shield.ShieldRegenerationDelay);
        Assert.AreEqual(5.245, unit.Shield.ShieldRegenerationRate);
        Assert.AreEqual(0.04, unit.Shield.ShieldRegenerationRateScaling);

        Assert.AreEqual(755, unit.Energy.EnergyMax);
        Assert.AreEqual("Ammo", unit.Energy.EnergyType);
        Assert.AreEqual(5.4256, unit.Energy.EnergyRegenerationRate);

        List<UnitArmor> unitArmorList = unit.Armor.ToList();

        Assert.AreEqual("structure", unitArmorList[0].Type);
        Assert.AreEqual(30, unitArmorList[0].BasicArmor);
        Assert.AreEqual(20, unitArmorList[0].AbilityArmor);
        Assert.AreEqual(30, unitArmorList[0].SplashArmor);

        Assert.AreEqual("hero", unitArmorList[1].Type);
        Assert.AreEqual(10, unitArmorList[1].BasicArmor);
        Assert.AreEqual(0, unitArmorList[1].AbilityArmor);
        Assert.AreEqual(0, unitArmorList[1].SplashArmor);

        List<UnitWeapon> unitWeapons = unit.Weapons.ToList();

        Assert.AreEqual("AllianceSuperCavalryWeapon", unitWeapons[0].WeaponNameId);
        Assert.AreEqual(5, unitWeapons[0].Range);
        Assert.AreEqual(3.9, unitWeapons[0].Period);
        Assert.AreEqual(454, unitWeapons[0].Damage);
        Assert.AreEqual(0.65, unitWeapons[0].DamageScaling);
        Assert.AreEqual(3.9, unitWeapons[0].Period);
        Assert.AreEqual("minion", unitWeapons[0].AttributeFactors.ToList()[0].Type);
        Assert.AreEqual(1.5, unitWeapons[0].AttributeFactors.ToList()[0].Value);

        Assert.AreEqual("AlteracBossWeaponParent", unitWeapons[1].WeaponNameId);
        Assert.AreEqual(4, unitWeapons[1].Range);
        Assert.AreEqual(40.1, unitWeapons[1].Period);
        Assert.AreEqual("summoned", unitWeapons[1].AttributeFactors.ToList()[1].Type);
        Assert.AreEqual(1.0, unitWeapons[1].AttributeFactors.ToList()[1].Value);

        if (abilities)
        {
            List<Ability> abilitiesList = unit.Abilities.ToList();
            Assert.AreEqual(AbilityTiers.Basic, abilitiesList[0].Tier);
            Assert.AreEqual("AlteracBossWhirlwind", abilitiesList[0].AbilityTalentId?.ReferenceId);
            Assert.AreEqual("AlteracBossWhirlwind", abilitiesList[0].AbilityTalentId?.ButtonId);
            Assert.AreEqual("Whirlwind", abilitiesList[0].Name);
            Assert.AreEqual("storm_ui_icon_sonya_whirlwind.png", abilitiesList[0].IconFileName);
            Assert.AreEqual("Cooldown: 12 seconds", abilitiesList[0].Tooltip.Cooldown.CooldownTooltip?.RawDescription);
            Assert.AreEqual("Damage nearby enemies", abilitiesList[0].Tooltip.ShortTooltip?.RawDescription);
            Assert.AreEqual(AbilityTypes.Q, abilitiesList[0].AbilityTalentId.AbilityType);

            Assert.AreEqual(AbilityTiers.Hidden, abilitiesList[3].Tier);
            Assert.AreEqual("AlteracBossChargeApproach", abilitiesList[3].AbilityTalentId?.ReferenceId);
            Assert.AreEqual("AlteracBossCharge", abilitiesList[3].AbilityTalentId?.ButtonId);
            Assert.AreEqual("Charge", abilitiesList[3].Name);
        }

        if (subAbilities)
        {
            List<Ability> abilitiesList = unit.SubAbilities().ToList();

            Assert.AreEqual(AbilityTiers.Interact, abilitiesList[0].Tier);
            Assert.AreEqual("WitchDoctorGargantuanStomp", abilitiesList[0].AbilityTalentId?.ReferenceId);
            Assert.AreEqual("WitchDoctorGargantuanStomp", abilitiesList[0].AbilityTalentId?.ButtonId);
            Assert.AreEqual("Gargantuan Stomp", abilitiesList[0].Name);
            Assert.AreEqual("AlteracBossWhirlwind", abilitiesList[0].ParentLink?.ReferenceId);
            Assert.AreEqual("AlteracBossWhirlwind", abilitiesList[0].ParentLink?.ButtonId);
            Assert.AreEqual(0.125, abilitiesList[0].Tooltip.Cooldown?.ToggleCooldown);

            Assert.AreEqual(AbilityTiers.MapMechanic, abilitiesList[1].Tier);
            Assert.AreEqual("VoidPrisonCancel", abilitiesList[1].AbilityTalentId?.ReferenceId);
            Assert.AreEqual("ZeratulVoidPrisonCancel", abilitiesList[1].AbilityTalentId?.ButtonId);

            Assert.AreEqual(AbilityTiers.MapMechanic, abilitiesList[2].Tier);
            Assert.AreEqual("MapMechanicAbilityInstant", abilitiesList[2].AbilityTalentId?.ReferenceId);
            Assert.AreEqual("MapMechanicAbility", abilitiesList[2].AbilityTalentId?.ButtonId);

            Assert.AreEqual(AbilityTiers.Hidden, abilitiesList[3].Tier);
            Assert.AreEqual("AlteracBossChargeApproach", abilitiesList[3].ParentLink?.ReferenceId);
            Assert.AreEqual("AlteracBossCharge", abilitiesList[3].ParentLink?.ButtonId);
            Assert.AreEqual(AbilityTypes.Hidden, abilitiesList[3].ParentLink?.AbilityType);
            Assert.AreEqual(true, abilitiesList[3].ParentLink?.IsPassive);
            Assert.AreEqual("AbathurAssumingDirectControlCancel", abilitiesList[3].AbilityTalentId?.ReferenceId);
            Assert.AreEqual("AbathurSymbioteCancel", abilitiesList[3].AbilityTalentId?.ButtonId);
            Assert.AreEqual(AbilityTypes.Heroic, abilitiesList[3].AbilityTalentId.AbilityType);
        }
    }

    [DataTestMethod]
    [DataRow("AbathurEvolvedMonstrosity", true, true)]
    [DataRow(null, true, true)]
    [DataRow("asdf", true, true)]
    public void TryGetUnitByIdTest(string? id, bool abilities, bool subAbilities)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_unitDataDocument.TryGetUnitById(id, out _, abilities, subAbilities));

            return;
        }

        Assert.IsTrue(_unitDataDocument.TryGetUnitById(id, out Unit? unit, abilities, subAbilities));
        BasicAbathurEvolvedMonstrosityAsserts(unit!);
    }

    [DataTestMethod]
    [DataRow("AbathurEvolvedMonstrosity2", false, false)]
    [DataRow("AbathurEvolvedMonstrosity2", true, false)]
    [DataRow("AbathurEvolvedMonstrosity2", false, true)]
    [DataRow("AbathurEvolvedMonstrosity2", true, true)]
    [DataRow(null, true, true)]
    [DataRow("asdf", true, true)]
    public void GetUnitByHyperlinkIdTest(string id, bool abilities, bool subAbilities)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _unitDataDocument.GetUnitByHyperlinkId(id!, abilities, subAbilities);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _unitDataDocument.GetUnitByHyperlinkId(id, abilities, subAbilities);
            });

            return;
        }

        BasicAbathurEvolvedMonstrosityAsserts(_unitDataDocument.GetUnitByHyperlinkId(id, abilities, subAbilities));
    }

    [DataTestMethod]
    [DataRow("tombofthespiderqueen-JungleGraveGolemLaner", true, true)]
    [DataRow(null, true, true)]
    [DataRow("asdf", true, true)]
    public void TryGetUnitByHyperlinkIdTest(string? id, bool abilities, bool subAbilities)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_unitDataDocument.TryGetUnitByHyperlinkId(id, out _, abilities, subAbilities));

            return;
        }

        Assert.IsTrue(_unitDataDocument.TryGetUnitByHyperlinkId(id, out Unit? unit, abilities, subAbilities));
        BasicTomboftheSpiderQueenJungleGraveGolemLanerAsserts(unit!);
    }

    [TestMethod]
    public void GetMapUniqueUnitTest()
    {
        Unit unit = _unitDataDocument.GetUnitById("tombofthespiderqueen-JungleGraveGolemLaner", false, false);
        Assert.IsTrue(unit.IsMapUnique);
        Assert.AreEqual("tombofthespiderqueen", unit.MapName);
    }

    [TestMethod]
    public void GetUnitsTest()
    {
        List<Unit> units = _unitDataDocument.GetUnits(true, true).ToList();
        Assert.AreEqual("AbathurEvolvedMonstrosity", units[0].CUnitId);
        Assert.AreEqual("tombofthespiderqueen-JungleGraveGolemLaner", units[2].CUnitId);
    }

    [TestMethod]
    public void UpdateGameStringsTest()
    {
        Unit unit = new()
        {
            CUnitId = "AbathurEvolvedMonstrosity",
            Id = "AbathurEvolvedMonstrosity",
        };

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());
        gameStringDocument.UpdateGameStrings(unit);

        Assert.ThrowsException<ArgumentNullException>(() => gameStringDocument.UpdateGameStrings(unit: null!));

        Assert.AreEqual("A long description", unit.Description!.RawDescription);
        Assert.AreEqual("Shield", unit.Shield.ShieldType);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using UnitDataDocument unitDataDocument = UnitDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, unitDataDocument.Localization);
        Assert.IsTrue(unitDataDocument.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using UnitDataDocument unitDataDocument = UnitDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, unitDataDocument.Localization);
        Assert.IsTrue(unitDataDocument.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using UnitDataDocument unitDataDocument = UnitDataDocument.Parse(GetBytesForROM("AbathurEvolvedMonstrosity"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, unitDataDocument.Localization);
        Assert.IsTrue(unitDataDocument.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using UnitDataDocument unitDataDocument = UnitDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, unitDataDocument.Localization);
        Assert.IsTrue(unitDataDocument.TryGetUnitById("AbathurEvolvedMonstrosity", out Unit _, false, false));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using UnitDataDocument unitDataDocument = UnitDataDocument.Parse(GetBytesForROM("AbathurEvolvedMonstrosity"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, unitDataDocument.Localization);
        Assert.IsTrue(unitDataDocument.TryGetUnitById("AbathurEvolvedMonstrosity", out Unit _, false, false));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using UnitDataDocument document = UnitDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using UnitDataDocument document = UnitDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using UnitDataDocument document = UnitDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new(_dataFile, FileMode.Open);
        using UnitDataDocument document = await UnitDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using UnitDataDocument document = await UnitDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new(_dataFile, FileMode.Open);
        using UnitDataDocument document = await UnitDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("AbathurEvolvedMonstrosity", out JsonElement _));

        document.Dispose();
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new();
        using Utf8JsonWriter writer = new(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("AbathurEvolvedMonstrosity");
        writer.WriteString("name", "Evolved Monstrosity");
        writer.WriteString("hyperlinkId", "AbathurEvolvedMonstrosity2");
        writer.WriteNumber("innerRadius", 0.375);
        writer.WriteNumber("radius", 1.0);
        writer.WriteNumber("sight", 9.0);
        writer.WriteNumber("speed", 4.0);
        writer.WriteNumber("killXP", 100);
        writer.WriteString("damageType", "Summon");
        writer.WriteString("scalingLinkId", "linkId");
        writer.WriteString("description", "description");

        writer.WriteStartArray("descriptors");
        writer.WriteStringValue("PowerfulLaner");
        writer.WriteStringValue("Suicidal");
        writer.WriteEndArray();

        writer.WriteStartArray("attributes");
        writer.WriteStringValue("Heroic");
        writer.WriteEndArray();

        writer.WriteStartArray("units");
        writer.WriteStringValue("unit1");
        writer.WriteStringValue("unit2");
        writer.WriteEndArray();

        writer.WriteStartObject("portraits");
        writer.WriteString("targetInfo", "storm_ui_ingame_targetinfopanel_unit_abathur_monstrosity.png");
        writer.WriteString("minimap", "storm_ui_minimapicon_monstrosity.png");
        writer.WriteEndObject();

        writer.WriteStartObject("life");
        writer.WriteNumber("amount", 755);
        writer.WriteNumber("scale", 0.04);
        writer.WriteString("type", "Life");
        writer.WriteNumber("regenRate", 5.4256);
        writer.WriteNumber("regenScale", 0.04);
        writer.WriteEndObject();

        writer.WriteStartObject("shield");
        writer.WriteNumber("amount", 755);
        writer.WriteNumber("scale", 0.04);
        writer.WriteString("type", "Shield");
        writer.WriteNumber("regenDelay", 5);
        writer.WriteNumber("regenRate", 5.245);
        writer.WriteNumber("regenScale", 0.04);
        writer.WriteEndObject();

        writer.WriteStartObject("energy");
        writer.WriteNumber("amount", 755);
        writer.WriteString("type", "Ammo");
        writer.WriteNumber("regenRate", 5.4256);
        writer.WriteEndObject();

        writer.WriteStartObject("armor");
        writer.WriteStartObject("structure");
        writer.WriteNumber("basic", 30);
        writer.WriteNumber("ability", 20);
        writer.WriteNumber("splash", 30);
        writer.WriteEndObject();
        writer.WriteStartObject("hero");
        writer.WriteNumber("basic", 10);
        writer.WriteNumber("ability", 0);
        writer.WriteNumber("splash", 0);
        writer.WriteEndObject();
        writer.WriteEndObject();

        writer.WriteStartArray("weapons");
        writer.WriteStartObject();
        writer.WriteString("nameId", "AllianceSuperCavalryWeapon");
        writer.WriteNumber("range", 5);
        writer.WriteNumber("period", 3.9);
        writer.WriteNumber("damage", 454);
        writer.WriteNumber("damageScale", 0.65);
        writer.WriteStartObject("damageFactor");
        writer.WriteNumber("minion", 1.5);
        writer.WriteNumber("structure", 0.75);
        writer.WriteEndObject();
        writer.WriteEndObject();
        writer.WriteStartObject();
        writer.WriteString("nameId", "AlteracBossWeaponParent");
        writer.WriteNumber("range", 4);
        writer.WriteNumber("period", 40.1);
        writer.WriteNumber("damage", 124);
        writer.WriteNumber("damageScale", 0.65);
        writer.WriteStartObject("damageFactor");
        writer.WriteNumber("minion", 1.5);
        writer.WriteNumber("summoned", 1.0);
        writer.WriteEndObject();
        writer.WriteEndObject();
        writer.WriteEndArray();

        writer.WriteStartObject("abilities");
        writer.WriteStartArray("basic");
        writer.WriteStartObject();
        writer.WriteString("nameId", "AlteracBossWhirlwind");
        writer.WriteString("buttonId", "AlteracBossWhirlwind");
        writer.WriteString("name", "Whirlwind");
        writer.WriteString("icon", "storm_ui_icon_sonya_whirlwind.png");
        writer.WriteString("cooldownTooltip", "Cooldown: 12 seconds");
        writer.WriteString("shortTooltip", "Damage nearby enemies");
        writer.WriteString("abilityType", "Q");
        writer.WriteEndObject();
        writer.WriteStartObject();
        writer.WriteString("nameId", "AlteracBossCharge");
        writer.WriteString("buttonId", "AlteracBossCharge");
        writer.WriteString("name", "Charge");
        writer.WriteString("icon", "storm_ui_icon_varian_charge.png");
        writer.WriteString("cooldownTooltip", "Cooldown: 6 seconds");
        writer.WriteString("shortTooltip", "Charge to an enemy and damage them");
        writer.WriteString("abilityType", "W");
        writer.WriteEndObject();
        writer.WriteStartObject();
        writer.WriteString("nameId", "FakeAbility");
        writer.WriteString("buttonId", "FakeAbility");
        writer.WriteString("name", "Fake Ability");
        writer.WriteString("icon", "storm_ui_icon_sonya_whirlwind.png");
        writer.WriteString("cooldownTooltip", "Cooldown: 999 seconds");
        writer.WriteString("shortTooltip", "Enemies die in one hit.");
        writer.WriteString("abilityType", "ZZZ");
        writer.WriteEndObject();
        writer.WriteEndArray();
        writer.WriteStartArray("hidden");
        writer.WriteStartObject();
        writer.WriteString("nameId", "AlteracBossChargeApproach");
        writer.WriteString("buttonId", "AlteracBossCharge");
        writer.WriteString("name", "Charge");
        writer.WriteString("icon", "storm_ui_icon_varian_charge.png");
        writer.WriteString("shortTooltip", "Charge to an enemy and damage them");
        writer.WriteBoolean("isPassive", true);
        writer.WriteString("abilityType", "Hidden");
        writer.WriteEndObject();
        writer.WriteEndArray();
        writer.WriteEndObject();

        writer.WriteStartArray("subAbilities");
        writer.WriteStartObject();
        writer.WriteStartObject("AlteracBossWhirlwind|AlteracBossWhirlwind|Q");
        writer.WriteStartArray("interact");
        writer.WriteStartObject();
        writer.WriteString("nameId", "WitchDoctorGargantuanStomp");
        writer.WriteString("buttonId", "WitchDoctorGargantuanStomp");
        writer.WriteString("name", "Gargantuan Stomp");
        writer.WriteString("icon", "storm_ui_icon_nazeebo_gargantuanstomp.png");
        writer.WriteNumber("toggleCooldown", 0.125);
        writer.WriteString("cooldownTooltip", "Cooldown: 6 seconds");
        writer.WriteString("fullTooltip", "Order the Gargantuan to stomp, dealing <c val=\"bfd4fd\">240~~0.04~~</c> damage to nearby enemies and slowing them by <c val=\"bfd4fd\">30%</c> for <c val=\"bfd4fd\">2</c> seconds.");
        writer.WriteString("abilityType", "E");
        writer.WriteEndObject();
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.WriteStartObject("AlteracBossCharge|AlteracBossCharge|W");
        writer.WriteStartArray("mapMechanic");
        writer.WriteStartObject();
        writer.WriteString("nameId", "VoidPrisonCancel");
        writer.WriteString("buttonId", "ZeratulVoidPrisonCancel");
        writer.WriteString("name", "Void Prison Cancel");
        writer.WriteString("icon", "hud_btn_bg_ability_cancel.png");
        writer.WriteString("cooldownTooltip", "Cooldown: 1.5 seconds");
        writer.WriteString("fullTooltip", "<n/>Cancels the Void Prison ability.");
        writer.WriteString("abilityType", "W");
        writer.WriteEndObject();
        writer.WriteStartObject();
        writer.WriteString("nameId", "MapMechanicAbilityInstant");
        writer.WriteString("buttonId", "MapMechanicAbility");
        writer.WriteString("icon", "coreattackping.png");
        writer.WriteString("abilityType", "MapMechanic");
        writer.WriteEndObject();
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.WriteStartObject("AlteracBossChargeApproach|AlteracBossCharge|Hidden|True");
        writer.WriteStartArray("hidden");
        writer.WriteStartObject();
        writer.WriteString("nameId", "AbathurAssumingDirectControlCancel");
        writer.WriteString("buttonId", "AbathurSymbioteCancel");
        writer.WriteString("icon", "hud_btn_bg_ability_cancel.png");
        writer.WriteString("abilityType", "Heroic");
        writer.WriteEndObject();
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.WriteStartObject("FakeAbility|FakeAbility");
        writer.WriteStartArray("mapMechanic");
        writer.WriteStartObject();
        writer.WriteString("nameId", "Nonexists");
        writer.WriteString("buttonId", "Nonexists");
        writer.WriteString("name", "Nonexists");
        writer.WriteString("icon", "hud_btn_bg_ability_cancel.png");
        writer.WriteString("cooldownTooltip", "Cooldown: 0 seconds");
        writer.WriteString("abilityType", "ZZZZ");
        writer.WriteEndObject();
        writer.WriteEndArray();
        writer.WriteEndObject();

        writer.WriteEndObject();
        writer.WriteEndArray();

        writer.WriteEndObject();

        writer.WriteStartObject("kings-core");
        writer.WriteEndObject();

        writer.WriteStartObject("tombofthespiderqueen-JungleGraveGolemLaner");
        writer.WriteString("hyperlinkId", "tombofthespiderqueen-JungleGraveGolemLaner");
        writer.WriteString("name", "Sand Golem");
        writer.WriteNumber("radius", 1.25);
        writer.WriteNumber("sight", 8.0);
        writer.WriteNumber("speed", 3.75);
        writer.WriteNumber("killXP", 100);
        writer.WriteString("scalingLinkId", "GraveGolemLanerScaling");
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
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
        writer.WriteStartObject("unit");

        writer.WriteStartObject("damagetype");
        writer.WriteString("AbathurEvolvedMonstrosity", "Summon");
        writer.WriteEndObject();

        writer.WriteStartObject("description");
        writer.WriteString("AbathurEvolvedMonstrosity", "A long description");
        writer.WriteEndObject();

        writer.WriteStartObject("energytype");
        writer.WriteString("AbathurEvolvedMonstrosity", "Mana");
        writer.WriteEndObject();

        writer.WriteStartObject("lifetype");
        writer.WriteString("AbathurEvolvedMonstrosity", "Life");
        writer.WriteEndObject();

        writer.WriteStartObject("name");
        writer.WriteString("AbathurEvolvedMonstrosity", "Evolved Monstrosity");
        writer.WriteEndObject();

        writer.WriteStartObject("shieldtype");
        writer.WriteString("AbathurEvolvedMonstrosity", "Shield");
        writer.WriteEndObject();

        writer.WriteEndObject(); // unit
        writer.WriteEndObject(); // gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void BasicAbathurEvolvedMonstrosityAsserts(Unit unit)
    {
        Assert.AreEqual("AbathurEvolvedMonstrosity", unit.CUnitId);
        Assert.AreEqual("AbathurEvolvedMonstrosity", unit.Id);
        Assert.AreEqual("Evolved Monstrosity", unit.Name);
        Assert.IsFalse(unit.IsMapUnique);
        Assert.IsNull(unit.MapName);
        Assert.AreEqual(0.375, unit.InnerRadius);
        Assert.AreEqual(1.0, unit.Radius);
        Assert.AreEqual(9.0, unit.Sight);
        Assert.AreEqual(4.0, unit.Speed);
        Assert.AreEqual(100, unit.KillXP);
        Assert.AreEqual("Summon", unit.DamageType);
        Assert.AreEqual("linkId", unit.ScalingBehaviorLink);
        Assert.AreEqual("description", unit.Description?.RawDescription);
        Assert.AreEqual("Suicidal", unit.HeroDescriptors.ToList()[1]);
        Assert.AreEqual("Heroic", unit.Attributes.ToList()[0]);
        Assert.AreEqual("unit2", unit.UnitIds.ToList()[1]);
        Assert.AreEqual("storm_ui_ingame_targetinfopanel_unit_abathur_monstrosity.png", unit.UnitPortrait.TargetInfoPanelFileName);
        Assert.AreEqual("storm_ui_minimapicon_monstrosity.png", unit.UnitPortrait.MiniMapIconFileName);
    }

    private static void BasicTomboftheSpiderQueenJungleGraveGolemLanerAsserts(Unit unit)
    {
        Assert.AreEqual("tombofthespiderqueen-JungleGraveGolemLaner", unit.CUnitId);
        Assert.AreEqual("tombofthespiderqueen-JungleGraveGolemLaner", unit.Id);
        Assert.AreEqual("tombofthespiderqueen-JungleGraveGolemLaner", unit.HyperlinkId);
        Assert.AreEqual("Sand Golem", unit.Name);
        Assert.IsTrue(unit.IsMapUnique);
        Assert.AreEqual("tombofthespiderqueen", unit.MapName);
    }
}
