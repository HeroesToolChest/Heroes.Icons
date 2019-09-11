using Heroes.Models;
using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class UnitDataReaderTests
    {
        private readonly UnitDataReader _unitDataReader;

        public UnitDataReaderTests()
        {
            _unitDataReader = new UnitDataReader(LoadJsonTestData());
        }

        [DataTestMethod]
        [DataRow("AbathurEvolvedMonstrosity", false, false)]
        [DataRow("AbathurEvolvedMonstrosity", true, false)]
        [DataRow("AbathurEvolvedMonstrosity", false, true)]
        [DataRow("AbathurEvolvedMonstrosity", true, true)]
        [DataRow(null, true, true)]
        [DataRow("asdf", true, true)]
        public void GetUnitByIdTests(string id, bool abilities, bool subAbilities)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _ = _unitDataReader.GetUnitById(id, abilities, subAbilities);
#pragma warning restore CS8604 // Possible null reference argument.
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _unitDataReader.GetUnitById(id, abilities, subAbilities);
                });

                return;
            }

            Unit unit = _unitDataReader.GetUnitById(id, abilities, subAbilities);

            Assert.AreEqual("AbathurEvolvedMonstrosity", unit.CUnitId);
            Assert.AreEqual("AbathurEvolvedMonstrosity", unit.Id);
            Assert.AreEqual("Evolved Monstrosity", unit.Name);
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
                Assert.AreEqual(AbilityTier.Basic, abilitiesList[0].Tier);
                Assert.AreEqual("AlteracBossWhirlwind", abilitiesList[0].AbilityTalentId?.ReferenceId);
                Assert.AreEqual("AlteracBossWhirlwind", abilitiesList[0].AbilityTalentId?.ButtonId);
                Assert.AreEqual("Whirlwind", abilitiesList[0].Name);
                Assert.AreEqual("storm_ui_icon_sonya_whirlwind.png", abilitiesList[0].IconFileName);
                Assert.AreEqual("Cooldown: 12 seconds", abilitiesList[0].Tooltip.Cooldown.CooldownTooltip?.RawDescription);
                Assert.AreEqual("Damage nearby enemies", abilitiesList[0].Tooltip.ShortTooltip?.RawDescription);
                Assert.AreEqual(AbilityType.Q, abilitiesList[0].AbilityType);

                Assert.AreEqual(AbilityTier.Hidden, abilitiesList[2].Tier);
                Assert.AreEqual("AlteracBossChargeApproach", abilitiesList[2].AbilityTalentId?.ReferenceId);
                Assert.AreEqual("AlteracBossCharge", abilitiesList[2].AbilityTalentId?.ButtonId);
                Assert.AreEqual("Charge", abilitiesList[2].Name);
            }
        }

        private byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("AbathurEvolvedMonstrosity");
            writer.WriteString("name", "Evolved Monstrosity");
            writer.WriteString("hyperlinkId", "AbathurEvolvedMonstrosity");
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
            writer.WriteEndArray();
            writer.WriteStartArray("hidden");
            writer.WriteStartObject();
            writer.WriteString("nameId", "AlteracBossChargeApproach");
            writer.WriteString("buttonId", "AlteracBossCharge");
            writer.WriteString("name", "Charge");
            writer.WriteString("icon", "storm_ui_icon_varian_charge.png");
            writer.WriteString("shortTooltip", "Charge to an enemy and damage them");
            writer.WriteString("abilityType", "Hidden");
            writer.WriteEndObject();
            writer.WriteEndArray();
            writer.WriteEndObject();

            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}
