using Heroes.Models;
using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class HeroesDataXmlTests : HeroesIconsBase
    {
        private readonly IHeroesData HeroesData;

        public HeroesDataXmlTests()
        {
            HeroesData = HeroesIcons.HeroesData(67985);
        }

        [TestMethod]
        public void HeroExistsTest()
        {
            Assert.IsTrue(HeroesData.HeroExists("Mephisto"));

            IHeroesData heroData67621 = HeroesIcons.HeroesData(67621);
            Assert.IsFalse(HeroesData.HeroExists("Mephisto"));

            IHeroesData heroDataOldSplit = HeroesIcons.HeroesData(56705);
            Assert.IsTrue(heroDataOldSplit.HeroExists("Abathur"));

            IHeroesData heroDataLastest = HeroesIcons.HeroesData();
            Assert.IsTrue(heroDataLastest.HeroExists("Mephisto"));
        }

        [TestMethod]
        public void TotalCountOfHeroesTest()
        {
            Assert.AreEqual(82, HeroesData.GetTotalAmountOfHeroes());
        }

        [TestMethod]
        public void ListOfHeroNamesTest()
        {
            List<string> heroesList = HeroesData.HeroNames().ToList();

            Assert.AreEqual(82, heroesList.Count);
            Assert.IsTrue(heroesList.Contains("Anub'arak"));
            Assert.IsTrue(heroesList.Contains("Valeera"));
        }

        [TestMethod]
        public void HeroNameFromUnitIdTest()
        {
            Assert.AreEqual("Valeera", HeroesData.HeroNameFromUnitId("HeroValeera"));
            Assert.AreEqual("Anub'arak", HeroesData.HeroNameFromUnitId("HeroAnubarak"));
        }

        [TestMethod]
        public void HeroNameFromShortNameTest()
        {
            Assert.AreEqual("Valeera", HeroesData.HeroNameFromShortName("Valeera"));
            Assert.AreEqual("Anub'arak", HeroesData.HeroNameFromShortName("Anubarak"));
        }

        [TestMethod]
        public void HeroNameFromAttributeIdTest()
        {
            Assert.AreEqual("Valeera", HeroesData.HeroNameFromAttributeId("VALE"));
            Assert.AreEqual("Anub'arak", HeroesData.HeroNameFromAttributeId("Anub"));
        }

        [TestMethod]
        public void GetHeroDataAbathurTest()
        {
            Hero hero = HeroesData.HeroData("Abathur");

            Assert.AreEqual("Abathur", hero.ShortName);
            Assert.AreEqual("Abathur", hero.Name);
            Assert.AreEqual("Abathur", hero.CHeroId);
            Assert.AreEqual("HeroAbathur", hero.CUnitId);
            Assert.AreEqual("Abat", hero.AttributeId);
            Assert.AreEqual("Very Hard", hero.Difficulty);
            Assert.AreEqual(HeroFranchise.Starcraft, hero.Franchise);
            Assert.AreEqual(0.75, hero.InnerRadius);
            Assert.AreEqual(0.75, hero.Radius);
            Assert.AreEqual(new DateTime(2014, 3, 13), hero.ReleaseDate);
            Assert.AreEqual(12.0, hero.Sight);
            Assert.AreEqual(4.3984, hero.Speed);
            Assert.AreEqual("Melee", hero.Type);
            Assert.AreEqual(Rarity.Legendary, hero.Rarity);
            Assert.AreEqual("A unique Hero that can manipulate the battle from anywhere on the map.", hero.Description.RawDescription);

            // portraits
            Assert.AreEqual("storm_ui_ingame_heroselect_btn_infestor.png", hero.HeroPortrait.HeroSelectPortraitFileName);
            Assert.AreEqual("storm_ui_ingame_hero_leaderboard_abathur.png", hero.HeroPortrait.LeaderboardPortraitFileName);
            Assert.AreEqual("storm_ui_ingame_hero_loadingscreen_abathur.png", hero.HeroPortrait.LoadingScreenPortraitFileName);
            Assert.AreEqual("storm_ui_ingame_partypanel_btn_abathur.png", hero.HeroPortrait.PartyPanelPortraitFileName);
            Assert.AreEqual("ui_targetportrait_hero_abathur.png", hero.HeroPortrait.TargetPortraitFileName);

            // life
            Assert.AreEqual(685, hero.Life.LifeMax);
            Assert.AreEqual(0.04, hero.Life.LifeScaling);
            Assert.AreEqual(1.4257, hero.Life.LifeRegenerationRate);
            Assert.AreEqual(0.04, hero.Life.LifeRegenerationRateScaling);

            // energy
            Assert.AreEqual(0, hero.Energy.EnergyMax);
            Assert.AreEqual(0, hero.Energy.EnergyRegenerationRate);

            // roles
            Assert.AreEqual("Specialist", hero.Roles[0]);
            Assert.AreEqual(1, hero.Roles.Count);

            // ratings
            Assert.AreEqual(9, hero.Ratings.Complexity);
            Assert.AreEqual(3, hero.Ratings.Damage);
            Assert.AreEqual(1, hero.Ratings.Survivability);
            Assert.AreEqual(7, hero.Ratings.Utility);

            // weapons
            Assert.AreEqual("HeroAbathur", hero.Weapons[0].WeaponNameId);
            Assert.AreEqual(1, hero.Weapons[0].Range);
            Assert.AreEqual(0.7, hero.Weapons[0].Period);
            Assert.AreEqual(26, hero.Weapons[0].Damage);
            Assert.AreEqual(0.04, hero.Weapons[0].DamageScaling);

            // abilities
            Ability firstAbility = hero.Abilities["AbathurSymbiote|"];
            Assert.AreEqual("AbathurSymbiote", firstAbility.ReferenceNameId);
            Assert.AreEqual("Symbiote", firstAbility.Name);
            Assert.AreEqual("AbathurSymbiote", firstAbility.ShortTooltipNameId);
            Assert.AreEqual("AbathurSymbiote", firstAbility.FullTooltipNameId);
            Assert.AreEqual("storm_ui_icon_abathur_symbiote.png", firstAbility.IconFileName);
            Assert.AreEqual("Cooldown: 4 seconds", firstAbility.Tooltip.Cooldown.CooldownTooltip.RawDescription);
            Assert.AreEqual("Assist an ally and gain new abilities", firstAbility.Tooltip.ShortTooltip.RawDescription);
            Assert.AreEqual("Spawn and attach a Symbiote to a target ally or Structure. While active, Abathur controls the Symbiote, gaining access to new Abilities. The Symbiote is able to gain XP from nearby enemy deaths.", firstAbility.Tooltip.FullTooltip.RawDescription);
            Assert.AreEqual(AbilityType.Q, firstAbility.AbilityType);

            Ability secondAbility = hero.Abilities["AbathurToxicNest|"];
            Assert.AreEqual(3, secondAbility.Tooltip.Charges.CountMax);
            Assert.AreEqual(1, secondAbility.Tooltip.Charges.CountUse);
            Assert.AreEqual(3, secondAbility.Tooltip.Charges.CountStart);
            Assert.AreEqual(0.0625, secondAbility.Tooltip.Charges.RecastCooldown);
            Assert.IsNull(secondAbility.Tooltip.Charges.IsHideCount);
            Assert.AreEqual(AbilityType.W, secondAbility.AbilityType);

            // talents
            Talent talent = hero.Talents["AbathurHeroicAbilityUltimateEvolution"];
            Assert.AreEqual("AbathurHeroicAbilityUltimateEvolution", talent.ReferenceNameId);
            Assert.AreEqual("Ultimate Evolution", talent.Name);
            Assert.AreEqual("AbathurUltimateEvolution", talent.ShortTooltipNameId);
            Assert.AreEqual("AbathurUltimateEvolution", talent.FullTooltipNameId);
            Assert.AreEqual("storm_ui_icon_abathur_ultimateevolution.png", talent.IconFileName);
            Assert.AreEqual("Cooldown: 70 seconds", talent.Tooltip.Cooldown.CooldownTooltip.RawDescription);
            Assert.AreEqual("Clone target allied Hero and control it", talent.Tooltip.ShortTooltip.RawDescription);
            Assert.AreEqual("Clone target allied Hero and control it for <c val=\"#TooltipNumbers\">20</c> seconds. Abathur has perfected the clone, granting it <c val=\"#TooltipNumbers\">20%</c> Spell Power, <c val=\"#TooltipNumbers\">20%</c> bonus Attack Damage, and <c val=\"#TooltipNumbers\">10%</c> bonus Movement Speed. Cannot use their Heroic Ability.", talent.Tooltip.FullTooltip.RawDescription);
            Assert.AreEqual(AbilityType.Heroic, talent.AbilityType);
            Assert.IsTrue(talent.IsActive);
        }

        [TestMethod]
        public void GetHeroDataTychusTest()
        {
            Hero hero = HeroesData.HeroData("Tychus");

            // energy
            Assert.AreEqual(500, hero.Energy.EnergyMax);
            Assert.AreEqual(3, hero.Energy.EnergyRegenerationRate);
            Assert.AreEqual("Mana", hero.Energy.EnergyType);

            // roles
            Assert.AreEqual("Assassin", hero.Roles[0]);
            Assert.AreEqual(1, hero.Roles.Count);

            // abilities
            Ability ability = hero.Abilities["TychusRunAndGun|"];
            Assert.AreEqual(1, ability.Tooltip.Charges.CountMax);
            Assert.AreEqual(1, ability.Tooltip.Charges.CountUse);
            Assert.AreEqual(1, ability.Tooltip.Charges.CountStart);
            Assert.AreEqual(0.5, ability.Tooltip.Charges.RecastCooldown);
            Assert.IsTrue(ability.Tooltip.Charges.IsHideCount.Value);
            Assert.AreEqual(AbilityType.E, ability.AbilityType);

            ability = hero.GetAbility("TychusRunAndGun|");
            Assert.IsTrue(ability.Tooltip.Charges.IsHideCount.Value);
            Assert.AreEqual(AbilityType.E, ability.AbilityType);

            // talents
            Talent talent = hero.Talents["TychusMasteryRunandGunDash"];
            Assert.AreEqual("TychusMasteryRunandGunDash", talent.ReferenceNameId);
            Assert.AreEqual("Dash", talent.Name);
            Assert.AreEqual("TychusRunandGunDashTalent", talent.ShortTooltipNameId);
            Assert.AreEqual("TychusRunandGunDashTalent", talent.FullTooltipNameId);
            Assert.AreEqual("storm_ui_icon_tychus_runandgun_a.png", talent.IconFileName);
            Assert.IsTrue(string.IsNullOrEmpty(talent.Tooltip.Cooldown.CooldownTooltip.RawDescription));
            Assert.AreEqual(AbilityType.E, talent.AbilityType);
            Assert.IsFalse(talent.IsActive);
            Assert.IsTrue(talent.IsQuest);

            talent = hero.GetTalent("TychusMasteryRunandGunDash");
            Assert.IsTrue(string.IsNullOrEmpty(talent.Tooltip.Cooldown.CooldownTooltip.RawDescription));
            Assert.AreEqual(AbilityType.E, talent.AbilityType);

            talent = hero.GetTalent(string.Empty);
            Assert.AreEqual("No Pick", talent.Name);

            talent = hero.GetTalent("SomeTalent");
            Assert.AreEqual("SomeTalent", talent.Name);

            // subAbilities
            ability = hero.SubAbilities(AbilityTier.Basic).ToList().First();
            Assert.AreEqual("TychusOdinAnnihilate", ability.ReferenceNameId);
            Assert.AreEqual("Annihilate", ability.Name);
            Assert.AreEqual("TychusCommandeerOdinAnnihilate", ability.ShortTooltipNameId);
            Assert.AreEqual("TychusCommandeerOdinAnnihilate", ability.FullTooltipNameId);
            Assert.AreEqual("storm_ui_icon_tychus_annihilate.png", ability.IconFileName);
            Assert.AreEqual("Cooldown: 7 seconds", ability.Tooltip.Cooldown.CooldownTooltip.RawDescription);
            Assert.AreEqual(AbilityType.Q, ability.AbilityType);
        }

        [TestMethod]
        public void HeroDataExistsTests()
        {
            Assert.IsNotNull(HeroesData.HeroData("Kerrigan"));
            Assert.IsNotNull(HeroesData.HeroData("The Lost Vikings"));
        }

        [TestMethod]
        public void HeroDataLimitedDataTests()
        {
            Assert.IsTrue(HeroesData.HeroData("Ragnaros", includeAbilities: false).Abilities.Count == 0);
            Assert.IsTrue(HeroesData.HeroData("Ragnaros", includeTalents: false).Talents.Count == 0);
            Assert.IsTrue(HeroesData.HeroData("Ragnaros", additionalUnits: false).HeroUnits.Count == 0);
        }

        [TestMethod]
        public void MultipleHeroDataTests()
        {
            List<string> heroNames = new List<string>
            {
                "Ragnaros",
                "Valeera",
                "Chen",
            };

            List<Hero> heroes = HeroesData.HeroesData(heroNames).ToList();
            Assert.AreEqual(3, heroes.Count);
        }

        [TestMethod]
        public void HeroDataInMemoryDontLoadFilesTest()
        {
            Assert.IsNotNull(HeroesIcons.HeroesData(67985).HeroData("Abathur"));
        }

        [TestMethod]
        public void HeroDataLocalizationTest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

            Hero hero = HeroesData.HeroData("Abathur");
            Assert.AreEqual("0,75", hero.InnerRadius.ToString());
            Assert.AreEqual("0,75", hero.Radius.ToString());
            Assert.AreEqual(new DateTime(2014, 3, 13), hero.ReleaseDate);

            Assert.AreEqual(685, hero.Life.LifeMax);
            Assert.AreEqual("0,04", hero.Life.LifeScaling.ToString());
            Assert.AreEqual("1,4257", hero.Life.LifeRegenerationRate.ToString());
            Assert.AreEqual("0,04", hero.Life.LifeRegenerationRateScaling.ToString());

            // energy
            Assert.AreEqual(0, hero.Energy.EnergyMax);
            Assert.AreEqual(0, hero.Energy.EnergyRegenerationRate);

            // roles
            Assert.AreEqual("Specialist", hero.Roles[0]);
            Assert.AreEqual(1, hero.Roles.Count);

            // ratings
            Assert.AreEqual(9, hero.Ratings.Complexity);
            Assert.AreEqual(3, hero.Ratings.Damage);
            Assert.AreEqual(1, hero.Ratings.Survivability);
            Assert.AreEqual(7, hero.Ratings.Utility);

            // weapons
            Assert.AreEqual("HeroAbathur", hero.Weapons[0].WeaponNameId);
            Assert.AreEqual("0,7", hero.Weapons[0].Period.ToString());
            Assert.AreEqual("26", hero.Weapons[0].Damage.ToString());
        }

        [TestMethod]
        public void HeroDataAbilityTalentLinkIdsTests()
        {
            IHeroesData heroData = HeroesIcons.HeroesData(71138);
            Hero hero = HeroesData.HeroData("Abathur");

            Talent talent = hero.Talents["AbathurMasteryRegenerativeMicrobes"];
            Assert.IsTrue(talent.AbilityTalentLinkIds.Count == 2);
            Assert.IsTrue(talent.AbilityTalentLinkIds.Contains("AbathurSymbiote"));
            Assert.IsTrue(talent.AbilityTalentLinkIds.Contains("AbathurSymbioteCarapace"));
        }
    }
}
