using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Heroes.Icons.Xml
{
    internal class HeroesDataXml : XmlBase, IInitializable, ISettableBuild, IHeroesData
    {
        private readonly string StormHeroShortName = "_stormhero";
        private readonly string HeroesDataZipFileFormat = "heroesdata_{0}_{1}.zip";
        private readonly string HeroesDataXmlFileFormat = "heroesdata_{0}_{1}.xml";
        private readonly string HeroesDataXmlFilePrefix = "heroesdata_";
        private readonly Dictionary<string, Hero> HeroDataByHeroShortName = new Dictionary<string, Hero>();
        private readonly int OldestHeroesDataBuild = 47479;

        private readonly string HeroBuildsAssemblyPath;
        private readonly HeroBuildsXml HeroBuildsXml;

        private int SelectedBuild;

        private XDocument HeroesDataXmlDocument;
        private Hero StormHero;

        public HeroesDataXml(HeroBuildsXml heroBuildsXml)
        {
            HeroBuildsAssemblyPath = XmlAssemblyPath + ".HeroBuilds";
            HeroBuildsXml = heroBuildsXml;
        }

        public void Initialize()
        {
        }

        public void SetSelectedBuild(int build)
        {
            bool alreadyLoaded = false;
            int loadedBuild = SelectedBuild;

            // check if already loaded
            if (HeroesDataXmlDocument != null && build == SelectedBuild)
                alreadyLoaded = true;

            if (build < OldestHeroesDataBuild)
                SelectedBuild = OldestHeroesDataBuild;
            else if (build > HeroBuildsXml.NewestBuild)
                SelectedBuild = HeroBuildsXml.NewestBuild;
            else
                SelectedBuild = build;

            // check again
            if (alreadyLoaded && loadedBuild == SelectedBuild)
                return;

            // zip file we want to load
            string zipFile = string.Format(HeroesDataZipFileFormat, SelectedBuild, Localization);
            Stream zipFileStream = HeroesIconsAssembly.GetManifestResourceStream($"{HeroBuildsAssemblyPath}.{zipFile}");

            if (zipFileStream == null)
            {
                IEnumerable<string> resourceNames = HeroesIconsAssembly.GetManifestResourceNames().Where(x => x.StartsWith($"{HeroBuildsAssemblyPath}.{HeroesDataXmlFilePrefix}"));
                foreach (string assemblyPath in resourceNames)
                {
                    string fileName = GetAssemblyZipFileName(assemblyPath);

                    string[] buildNumbers = fileName.Split('_')[1].Split('-');
                    if (buildNumbers.Length == 2)
                    {
                        int beginning = int.Parse(buildNumbers[0]);
                        int end = int.Parse(buildNumbers[1]);

                        if (SelectedBuild >= beginning && SelectedBuild <= end)
                        {
                            zipFile = fileName;
                            zipFileStream = HeroesIconsAssembly.GetManifestResourceStream($"{HeroBuildsAssemblyPath}.{zipFile}");
                            break;
                        }
                    }
                }
            }

            // file in the zip we want to load
            string xmlFile = string.Format(HeroesDataXmlFileFormat, SelectedBuild, Localization);

            HeroesDataXmlDocument = LoadZipFileFromManifestStream(zipFileStream, Path.ChangeExtension(xmlFile, ".min.xml"));

            StormHero = HeroData(StormHeroShortName);
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

            if (!string.IsNullOrEmpty(realName) || name == StormHeroShortName) // is a short name
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
            XElement heroElement = HeroesDataXmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("unitId")?.Value == unitId);
            if (heroElement == null)
                heroElement = HeroesDataXmlDocument.Root.Elements().FirstOrDefault(x => x.Attribute("cUnitId")?.Value == unitId);

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
                string heroName = heroElement.Attribute("name")?.Value;

                if (!string.IsNullOrEmpty(heroName))
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

            bool isNewFormat = false;

            Hero hero = new Hero();

            if (!string.IsNullOrEmpty(heroElement.Attribute("hyperlinkId")?.Value))
            {
                hero.ShortName = heroElement.Attribute("hyperlinkId")?.Value;
                hero.CUnitId = heroElement.Attribute("unitId")?.Value;
                hero.CHeroId = XmlConvert.DecodeName(heroElement.Name.LocalName);
                isNewFormat = true;
            }
            else
            {
                hero.ShortName = XmlConvert.DecodeName(heroElement.Name.LocalName);

                hero.CHeroId = heroElement.Attribute("cHeroId")?.Value;
                hero.CUnitId = heroElement.Attribute("cUnitId")?.Value;
            }

            hero.Name = heroElement.Attribute("name")?.Value;
            hero.AttributeId = heroElement.Attribute("attributeId")?.Value;
            hero.Difficulty = heroElement.Attribute("difficulty")?.Value;
            hero.Type = heroElement.Attribute("type")?.Value;

            if (Enum.TryParse(heroElement.Attribute("franchise")?.Value, out HeroFranchise franchise))
                hero.Franchise = franchise;

            if (Enum.TryParse(heroElement.Attribute("gender")?.Value, out HeroGender gender))
                hero.Gender = gender;

            if (double.TryParse(heroElement.Attribute("innerRadius")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double innerRadius))
                hero.InnerRadius = innerRadius;

            if (double.TryParse(heroElement.Attribute("radius")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double radius))
                hero.Radius = radius;

            if (DateTime.TryParse(heroElement.Attribute("releaseDate")?.Value, out DateTime releaseDate))
                hero.ReleaseDate = releaseDate;

            if (double.TryParse(heroElement.Attribute("sight")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double sight))
                hero.Sight = sight;

            if (double.TryParse(heroElement.Attribute("speed")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double speed))
                hero.Speed = speed;

            if (Enum.TryParse(heroElement.Attribute("rarity")?.Value, out Rarity rarity))
                hero.Rarity = rarity;

            hero.MountLinkId = heroElement.Element("MountLinkId")?.Value;
            hero.HearthLinkId = heroElement.Element("HearthLinkId")?.Value;

            hero.Description = new TooltipDescription(heroElement.Element("Description")?.Value);

            // portraits
            XElement portraitElement = heroElement.Element("Portraits");
            if (portraitElement != null)
            {
                hero.HeroPortrait.HeroSelectPortraitFileName = portraitElement.Element("HeroSelect")?.Value;
                hero.HeroPortrait.LeaderboardPortraitFileName = portraitElement.Element("Leaderboard")?.Value;
                hero.HeroPortrait.LoadingScreenPortraitFileName = portraitElement.Element("Loading")?.Value;
                hero.HeroPortrait.TargetPortraitFileName = portraitElement.Element("Target")?.Value;

                if (isNewFormat)
                {
                    // blank out
                }
                else
                {
                    hero.HeroPortrait.PartyPanelPortraitFileName = portraitElement.Element("PartyFrame")?.Value;
                }
            }

            // life
            XElement lifeElement = heroElement.Element("Life");
            if (lifeElement != null)
            {
                hero.Life.LifeMax = double.Parse(lifeElement.Element("Amount")?.Value, CultureInfo.InvariantCulture);
                hero.Life.LifeScaling = double.Parse(lifeElement.Element("Amount")?.Attribute("scale")?.Value, CultureInfo.InvariantCulture);
                hero.Life.LifeRegenerationRate = double.Parse(lifeElement.Element("RegenRate")?.Value, CultureInfo.InvariantCulture);
                hero.Life.LifeRegenerationRateScaling = double.Parse(lifeElement.Element("RegenRate")?.Attribute("scale")?.Value, CultureInfo.InvariantCulture);
            }

            // energy
            XElement energyElement = heroElement.Element("Energy");
            if (energyElement != null)
            {
                hero.Energy.EnergyMax = double.Parse(energyElement.Element("Amount")?.Value, CultureInfo.InvariantCulture);
                hero.Energy.EnergyType = energyElement.Element("Amount")?.Attribute("type")?.Value;
                hero.Energy.EnergyRegenerationRate = double.Parse(energyElement.Element("RegenRate")?.Value, CultureInfo.InvariantCulture);
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

            // expanded roles
            hero.ExpandedRole = heroElement.Element("ExpandedRole")?.Value;

            // ratings
            XElement ratingsElement = heroElement.Element("Ratings");
            if (ratingsElement != null)
            {
                hero.Ratings.Complexity = double.Parse(ratingsElement.Attribute("complexity")?.Value, CultureInfo.InvariantCulture);
                hero.Ratings.Damage = double.Parse(ratingsElement.Attribute("damage")?.Value, CultureInfo.InvariantCulture);
                hero.Ratings.Survivability = double.Parse(ratingsElement.Attribute("survivability")?.Value, CultureInfo.InvariantCulture);
                hero.Ratings.Utility = double.Parse(ratingsElement.Attribute("utility")?.Value, CultureInfo.InvariantCulture);
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
                        WeaponNameId = XmlConvert.DecodeName(weapon.Name.LocalName),
                        Range = double.Parse(weapon.Attribute("range")?.Value, CultureInfo.InvariantCulture),
                        Period = double.Parse(weapon.Attribute("period")?.Value, CultureInfo.InvariantCulture),
                    };

                    XElement damageElement = weapon.Element("Damage");
                    if (damageElement != null)
                    {
                        unitWeapon.Damage = double.Parse(damageElement.Value, CultureInfo.InvariantCulture);
                        unitWeapon.DamageScaling = double.Parse(damageElement.Attribute("scale")?.Value, CultureInfo.InvariantCulture);
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
                    SetAbilities(abilitiesElement, hero, isNewFormat);
                }

                // sub abilities
                XElement subAbilitiesElement = heroElement.Element("SubAbilities");
                if (subAbilitiesElement != null)
                {
                    XElement parentLinkAbility = subAbilitiesElement.Elements().FirstOrDefault();
                    string parentLink = parentLinkAbility.Name.LocalName;

                    SetAbilities(parentLinkAbility, hero, isNewFormat, parentLink);
                }
            }

            // talents
            if (includeTalents)
            {
                XElement talentsElement = heroElement.Element("Talents");
                if (talentsElement != null)
                {
                    SetTalents(talentsElement, hero, isNewFormat);
                }
            }

            return hero;
        }

        private void SetAbilities(XElement abilityElements, Hero hero, bool isNewFormat, string parentLink = "")
        {
            if (abilityElements == null)
                return;

            foreach (XElement abilityTierElement in abilityElements.Elements())
            {
                if (!Enum.TryParse(XmlConvert.DecodeName(abilityTierElement.Name.LocalName), out AbilityTier abilityTier))
                    continue;

                // loop though elements in tier
                foreach (XElement abilityElement in abilityTierElement.Elements())
                {
                    Ability ability = new Ability
                    {
                        Tier = abilityTier,
                    };

                    SetAbilityTalentData(abilityElement, ability, isNewFormat);

                    if (!string.IsNullOrEmpty(parentLink))
                        ability.ParentLink = parentLink;

                    string abilityKey = $"{ability.ReferenceNameId}|{ability.ButtonName}";

                    if (!hero.Abilities.ContainsKey(abilityKey))
                    {
                        hero.Abilities.Add(abilityKey, ability);
                    }
                }
            }
        }

        private void SetTalents(XElement talentElements, Hero hero, bool isNewFormat)
        {
            if (talentElements == null)
                return;

            foreach (XElement talentTierElement in talentElements.Elements())
            {
                if (!Enum.TryParse(XmlConvert.DecodeName(talentTierElement.Name.LocalName), out TalentTier talentTier))
                    continue;

                foreach (XElement talentElement in talentTierElement.Elements())
                {
                    Talent talent = new Talent
                    {
                        Tier = talentTier,
                        Column = int.TryParse(talentElement.Attribute("sort")?.Value, out int column) ? column : 0,
                    };

                    XElement abilityTalentLinkIdsElement = talentElement.Element("AbilityTalentLinkIds");
                    if (abilityTalentLinkIdsElement != null)
                    {
                        foreach (XElement abilityTalentLinkIdElement in abilityTalentLinkIdsElement.Elements())
                        {
                            talent.AbilityTalentLinkIds.Add(abilityTalentLinkIdElement?.Value);
                        }
                    }

                    SetAbilityTalentData(talentElement, talent, false);

                    hero.Talents.Add(talent.ReferenceNameId, talent);
                }
            }
        }

        private void SetAbilityTalentData(XElement abilityTalentElement, AbilityTalentBase abilityTalent, bool isNewFormat)
        {
            if (isNewFormat)
            {
                string abilityId = XmlConvert.DecodeName(abilityTalentElement.Name.LocalName);
                string buttonId = abilityTalentElement.Attribute("buttonId")?.Value;
                abilityTalent.ReferenceNameId = $"{abilityId}|{buttonId}";
            }
            else
            {
                abilityTalent.ReferenceNameId = XmlConvert.DecodeName(abilityTalentElement.Name.LocalName);
            }

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

            if (double.TryParse(abilityTalentElement.Element("ToggleCooldown")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double toggleCooldown))
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

                if (double.TryParse(chargesElement.Attribute("recastCooldown")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double chargesRecastCooldown))
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
