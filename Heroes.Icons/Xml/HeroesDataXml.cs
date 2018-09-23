using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class HeroesDataXml : XmlBase, IXml, IXmlMultipleBuild, IHeroesDataXml
    {
        private readonly string HeroesDataZipFileFormat = "heroesdata_{0}_{1}.min.zip";
        private readonly string HeroesDataXmlFileFormat = "heroesdata_{0}_{1}.min.xml";
        private readonly Dictionary<string, Hero> HeroDataByHeroShortName = new Dictionary<string, Hero>();
        private readonly int OldestHeroesDataBuild = 47479;

        private readonly string HeroBuildsXmlDirectory;
        private readonly HeroBuildsXml HeroBuildsXml;

        private int SelectedBuild;

        private XDocument HeroesDataXmlDocument;

        public HeroesDataXml(HeroBuildsXml heroBuildsXml)
        {
            HeroBuildsXmlDirectory = Path.Combine(XmlFolderPath, "HeroBuilds");
            HeroBuildsXml = heroBuildsXml;
        }

        public void Initialize()
        {
        }

        public void SetSelectedBuild(int build)
        {
            if (HeroesDataXmlDocument != null && SelectedBuild == build)
                return;

            if (build < OldestHeroesDataBuild)
                SelectedBuild = OldestHeroesDataBuild;
            else if (build > HeroBuildsXml.NewestBuild)
                SelectedBuild = HeroBuildsXml.NewestBuild;
            else
                SelectedBuild = build;

            // zip file we want to load
            string zipFile = string.Format(HeroesDataZipFileFormat, SelectedBuild, Localization);

            if (!File.Exists(Path.Combine(HeroBuildsXmlDirectory, zipFile)))
            {
                foreach (string filePath in Directory.EnumerateFiles(HeroBuildsXmlDirectory, string.Format(HeroesDataZipFileFormat, "*", Localization)))
                {
                    string[] buildNumbers = Path.GetFileName(filePath).Split('_')[1].Split('-');
                    if (buildNumbers.Length == 2)
                    {
                        int beginning = int.Parse(buildNumbers[0]);
                        int end = int.Parse(buildNumbers[1]);

                        if (build >= beginning && build <= end)
                        {
                            zipFile = Path.GetFileName(filePath);
                            break;
                        }
                    }
                }
            }

            // file in the zip we want to load
            string xmlFile = string.Format(HeroesDataXmlFileFormat, SelectedBuild, "enus");

            HeroesDataXmlDocument = LoadZipFile(Path.Combine(HeroBuildsXmlDirectory, zipFile), xmlFile);
        }

        public IEnumerable<Hero> HeroesData(IEnumerable<string> heroNames, bool includeAbilities = true, bool includeTalents = true, bool additionalUnits = true)
        {
            if (heroNames == null)
                return null;

            List<Hero> heroes = new List<Hero>();

            foreach (string heroName in heroNames)
            {
                heroes.Add(HeroData(heroName, includeAbilities, includeTalents, additionalUnits));
            }

            return heroes;
        }

        public Hero HeroData(string name, bool includeAbilities = true, bool includeTalents = true, bool additionalUnits = true)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            string realName = HeroNameFromShortName(name); // check if it's a short name

            if (!string.IsNullOrEmpty(realName)) // is a short name
                return GetHeroDataFromDataXml(HeroesDataXmlDocument.Root.Element(name), includeAbilities, includeTalents, additionalUnits);
            else // full real name
                return GetHeroDataFromDataXml(HeroesDataXmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("name")?.Value == name), includeAbilities, includeTalents, additionalUnits);
        }

        public string HeroNameFromShortName(string shortName)
        {
            XElement heroElement = HeroesDataXmlDocument.Root.Elements().FirstOrDefault(x => x.Name.LocalName == shortName);

            return heroElement?.Attribute("name")?.Value;
        }

        public string HeroNameFromAttributeId(string attributeId)
        {
            XElement heroElement = HeroesDataXmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("attributeId")?.Value == attributeId);

            return heroElement?.Attribute("name")?.Value;
        }

        public string HeroNameFromUnitId(string unitId)
        {
            XElement heroElement = HeroesDataXmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("cUnitId")?.Value == unitId);

            return heroElement?.Attribute("name")?.Value;
        }

        public bool HeroExists(string name)
        {
            if (!string.IsNullOrEmpty(HeroNameFromShortName(name)))
                return true;
            else
                return HeroesDataXmlDocument.Root.Elements().Any(x => x.Attribute("name")?.Value == name);
        }

        public IEnumerable<string> HeroNames()
        {
            List<string> heroNames = new List<string>();
            foreach (XElement heroElement in HeroesDataXmlDocument.Root.Elements())
            {
                heroNames.Add(heroElement.Attribute("name").Value);
            }

            return heroNames;
        }

        public int GetTotalAmountOfHeroes()
        {
            return HeroesDataXmlDocument.Root.Elements().Count();
        }

        private Hero GetHeroDataFromDataXml(XElement heroElement, bool includeAbilities, bool includeTalents, bool additionalUnits)
        {
            if (heroElement == null)
                return null;

            Hero hero = new Hero
            {
                ShortName = heroElement.Name.LocalName,
                Name = heroElement.Attribute("name")?.Value,
                CHeroId = heroElement.Attribute("cHeroId")?.Value,
                CUnitId = heroElement.Attribute("cUnitId")?.Value,
                AttributeId = heroElement.Attribute("attributeId")?.Value,
                Difficulty = heroElement.Attribute("difficulty")?.Value,
                Type = heroElement.Attribute("type")?.Value,
            };

            if (Enum.TryParse(heroElement.Attribute("franchise")?.Value, out HeroFranchise franchise))
                hero.Franchise = franchise;

            if (Enum.TryParse(heroElement.Attribute("gender")?.Value, out HeroGender gender))
                hero.Gender = gender;

            if (double.TryParse(heroElement.Attribute("innerRadius")?.Value, out double innerRadius))
                hero.InnerRadius = innerRadius;

            if (double.TryParse(heroElement.Attribute("radius")?.Value, out double radius))
                hero.Radius = radius;

            if (DateTime.TryParse(heroElement.Attribute("releaseDate")?.Value, out DateTime releaseDate))
                hero.ReleaseDate = releaseDate;

            if (double.TryParse(heroElement.Attribute("sight")?.Value, out double sight))
                hero.Sight = sight;

            if (double.TryParse(heroElement.Attribute("speed")?.Value, out double speed))
                hero.Speed = speed;

            if (Enum.TryParse(heroElement.Attribute("rarity")?.Value, out HeroRarity rarity))
                hero.Rarity = rarity;

            hero.Description = new TooltipDescription(heroElement.Element("Description")?.Value);

            // portraits
            XElement portraitElement = heroElement.Element("Portraits");
            if (portraitElement != null)
            {
                hero.HeroPortrait.HeroSelectPortraitFileName = portraitElement.Element("HeroSelect")?.Value;
                hero.HeroPortrait.LeaderboardPortraitFileName = portraitElement.Element("Leaderboard")?.Value;
                hero.HeroPortrait.LoadingScreenPortraitFileName = portraitElement.Element("Loading")?.Value;
                hero.HeroPortrait.PartyPanelPortraitFileName = portraitElement.Element("PartyFrame")?.Value;
                hero.HeroPortrait.TargetPortraitFileName = portraitElement.Element("Target")?.Value;
            }

            // life
            XElement lifeElement = heroElement.Element("Life");
            if (lifeElement != null)
            {
                hero.Life.LifeMax = double.Parse(lifeElement.Element("Amount")?.Value);
                hero.Life.LifeScaling = double.Parse(lifeElement.Element("Amount")?.Attribute("scale")?.Value);
                hero.Life.LifeRegenerationRate = double.Parse(lifeElement.Element("RegenRate")?.Value);
                hero.Life.LifeRegenerationRateScaling = double.Parse(lifeElement.Element("RegenRate")?.Attribute("scale")?.Value);
            }

            // energy
            XElement energyElement = heroElement.Element("Energy");
            if (energyElement != null)
            {
                hero.Energy.EnergyMax = double.Parse(energyElement.Element("Amount")?.Value);
                hero.Energy.EnergyType = energyElement.Element("Amount")?.Attribute("type")?.Value;
                hero.Energy.EnergyRegenerationRate = double.Parse(energyElement.Element("RegenRate")?.Value);
            }

            // armor
            XElement armorElement = heroElement.Element("Armor");
            if (armorElement != null)
            {
                hero.Armor.PhysicalArmor = int.Parse(armorElement.Element("Physical")?.Value);
                hero.Armor.SpellArmor = int.Parse(armorElement.Element("Spell")?.Value);
            }

            // roles
            XElement rolesElement = heroElement.Element("Roles");
            if (rolesElement != null)
            {
                HashSet<string> roles = new HashSet<string>();
                foreach (XElement role in rolesElement.Elements("Role"))
                {
                    roles.Add(role.Value);
                }

                hero.Roles = roles.ToList();
            }

            // ratings
            XElement ratingsElement = heroElement.Element("Ratings");
            if (ratingsElement != null)
            {
                hero.Ratings.Complexity = double.Parse(ratingsElement.Attribute("complexity")?.Value);
                hero.Ratings.Damage = double.Parse(ratingsElement.Attribute("damage")?.Value);
                hero.Ratings.Survivability = double.Parse(ratingsElement.Attribute("survivability")?.Value);
                hero.Ratings.Utility = double.Parse(ratingsElement.Attribute("utility")?.Value);
            }

            // weapons
            XElement weaponsElement = heroElement.Element("Weapons");
            if (weaponsElement != null)
            {
                List<UnitWeapon> weapons = new List<UnitWeapon>();

                foreach (XElement weapon in weaponsElement.Elements())
                {
                    UnitWeapon unitWeapon = new UnitWeapon()
                    {
                        WeaponNameId = weapon.Name.LocalName,
                        Range = double.Parse(weapon.Attribute("range")?.Value),
                        Period = double.Parse(weapon.Attribute("period")?.Value),
                    };

                    XElement damageElement = weapon.Element("Damage");
                    if (damageElement != null)
                    {
                        unitWeapon.Damage = double.Parse(damageElement.Value);
                        unitWeapon.DamageScaling = double.Parse(damageElement.Attribute("scale")?.Value);
                    }

                    weapons.Add(unitWeapon);
                }

                hero.Weapons = weapons;
            }

            // abilities
            if (includeAbilities)
            {
                XElement abilitiesElement = heroElement.Element("Abilities");
                if (abilitiesElement != null)
                {
                    SetAbilities(abilitiesElement, hero);
                }

                // sub abilities
                XElement subAbilitiesElement = heroElement.Element("SubAbilities");
                if (subAbilitiesElement != null)
                {
                    XElement parentLinkAbility = subAbilitiesElement.Elements().FirstOrDefault();
                    string parentLink = parentLinkAbility.Name.LocalName;

                    SetAbilities(parentLinkAbility, hero, parentLink);
                }
            }

            // talents
            if (includeTalents)
            {
                XElement talentsElement = heroElement.Element("Talents");
                if (talentsElement != null)
                {
                    SetTalents(talentsElement, hero);
                }
            }

            // hero units
            if (additionalUnits)
            {
                XElement heroUnitsElement = heroElement.Element("HeroUnits");
                if (heroUnitsElement != null)
                {
                    XElement heroNameElement = heroUnitsElement.Elements().FirstOrDefault();

                    List<Unit> heroUnits = new List<Unit>();

                    foreach (XElement heroUnitElement in heroNameElement.Elements())
                    {
                        Hero heroUnit = GetHeroDataFromDataXml(heroUnitElement, includeAbilities, includeTalents, additionalUnits);
                        heroUnit.ParentLink = heroNameElement.Name.LocalName;
                        heroUnits.Add(heroUnit);
                    }

                    hero.HeroUnits = heroUnits;
                }
            }

            return hero;
        }

        private void SetAbilities(XElement abilityElements, Hero hero, string parentLink = "")
        {
            if (abilityElements == null)
                return;

            foreach (XElement abilityTierElement in abilityElements.Elements())
            {
                if (!Enum.TryParse(abilityTierElement.Name.LocalName, out AbilityTier abilityTier))
                    continue;

                // loop though elements in tier
                foreach (XElement abilityElement in abilityTierElement.Elements())
                {
                    Ability ability = new Ability
                    {
                        Tier = abilityTier,
                    };

                    SetAbilityTalentData(abilityElement, hero, ability);

                    if (!string.IsNullOrEmpty(parentLink))
                        ability.ParentLink = parentLink;

                    hero.Abilities.Add(ability.ReferenceNameId, ability);
                }
            }
        }

        private void SetTalents(XElement talentElements, Hero hero)
        {
            if (talentElements == null)
                return;

            foreach (XElement talentTierElement in talentElements.Elements())
            {
                if (!Enum.TryParse(talentTierElement.Name.LocalName, out TalentTier talentTier))
                    continue;

                foreach (XElement talentElement in talentTierElement.Elements())
                {
                    Talent talent = new Talent
                    {
                        Tier = talentTier,
                        Column = int.TryParse(talentElement.Attribute("sort")?.Value, out int column) ? column : 0,
                    };

                    SetAbilityTalentData(talentElement, hero, talent);

                    hero.Talents.Add(talent.ReferenceNameId, talent);
                }
            }
        }

        private void SetAbilityTalentData(XElement abilityTalentElement, Hero hero, AbilityTalentBase abilityTalent)
        {
            abilityTalent.ReferenceNameId = abilityTalentElement.Name.LocalName;
            abilityTalent.Name = abilityTalentElement.Attribute("name")?.Value;
            abilityTalent.ShortTooltipNameId = abilityTalentElement.Attribute("shortTooltipId")?.Value;
            abilityTalent.FullTooltipNameId = abilityTalentElement.Attribute("fullTooltipId")?.Value;

            if (bool.TryParse(abilityTalentElement.Attribute("isActive")?.Value, out bool isActive))
                abilityTalent.IsActive = isActive;

            if (bool.TryParse(abilityTalentElement.Attribute("isQuest")?.Value, out bool isQuest))
                abilityTalent.IsQuest = isQuest;

            if (Enum.TryParse(abilityTalentElement.Attribute("abilityType")?.Value, out AbilityType abilityType))
                abilityTalent.AbilityType = abilityType;

            abilityTalent.IconFileName = abilityTalentElement.Element("Icon")?.Value;

            if (double.TryParse(abilityTalentElement.Element("ToggleCooldown")?.Value, out double toggleCooldown))
                abilityTalent.Tooltip.Cooldown.ToggleCooldown = toggleCooldown;

            abilityTalent.Tooltip.Life.LifeCostTooltip = new TooltipDescription(abilityTalentElement.Element("LifeTooltip")?.Value);
            abilityTalent.Tooltip.Energy.EnergyTooltip = new TooltipDescription(abilityTalentElement.Element("EnergyTooltip")?.Value);

            XElement chargesElement = abilityTalentElement.Element("Charges");
            if (chargesElement != null)
            {
                if (int.TryParse(chargesElement.Attribute("consume")?.Value, out int chargesCountUse))
                    abilityTalent.Tooltip.Charges.CountUse = chargesCountUse;

                if (int.TryParse(chargesElement.Attribute("initial")?.Value, out int chargesCountStart))
                    abilityTalent.Tooltip.Charges.CountStart = chargesCountStart;

                if (double.TryParse(chargesElement.Attribute("recastCooldown")?.Value, out double chargesRecastCooldown))
                    abilityTalent.Tooltip.Charges.RecastCooldown = chargesRecastCooldown;

                abilityTalent.Tooltip.Charges.CountMax = int.Parse(chargesElement.Value);

                if (bool.TryParse(chargesElement.Attribute("isHidden")?.Value, out bool isHidden))
                    abilityTalent.Tooltip.Charges.IsHideCount = isHidden;
            }

            abilityTalent.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(abilityTalentElement.Element("CooldownTooltip")?.Value);
            abilityTalent.Tooltip.ShortTooltip = new TooltipDescription(abilityTalentElement.Element("ShortTooltip")?.Value);
            abilityTalent.Tooltip.FullTooltip = new TooltipDescription(abilityTalentElement.Element("FullTooltip")?.Value);
        }
    }
}
