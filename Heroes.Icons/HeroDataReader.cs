using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Heroes.Icons
{
    /// <summary>
    /// Provides access to obtain hero data as well as updating localized strings.
    /// </summary>
    public class HeroDataReader : UnitBaseData
    {
        /// <summary>
        /// Initializes a new reader for the json data file.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing hero data.</param>
        public HeroDataReader(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data file.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing hero data.</param>
        /// <param name="localization">Localization of data.</param>
        public HeroDataReader(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data.
        /// </summary>
        /// <param name="jsonData">JSON data containing hero data.</param>
        public HeroDataReader(ReadOnlyMemory<byte> jsonData)
            : base(jsonData)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data.
        /// </summary>
        /// <param name="jsonData">JSON data containing hero data.</param>
        /// <param name="localization">Localization of data.</param>
        public HeroDataReader(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data file.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing hero data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public HeroDataReader(string jsonDataFilePath, GameStringReader gameStringReader)
            : base(jsonDataFilePath, gameStringReader)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data file.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing hero data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        /// <param name="localization">Localization of data.</param>
        public HeroDataReader(string jsonDataFilePath, GameStringReader gameStringReader, Localization localization)
            : base(jsonDataFilePath, gameStringReader, localization)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data.
        /// </summary>
        /// <param name="jsonData">JSON data containing hero data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public HeroDataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : base(jsonData, gameStringReader)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data.
        /// </summary>
        /// <param name="jsonData">JSON data containing hero data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        /// <param name="localization">Localization of data.</param>
        public HeroDataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader, Localization localization)
            : base(jsonData, gameStringReader, localization)
        {
        }

        public Hero GetHeroById(string heroId, bool abilities = false, bool subAbilities = false, bool talents = false, bool heroUnits = false)
        {
            if (JsonDataDocument.RootElement.TryGetProperty(heroId, out JsonElement heroElement))
            {
                Hero hero = GetHeroData(heroElement, abilities, subAbilities, talents, heroUnits);
                hero.Id = heroId;
                hero.CHeroId = heroId;

                return hero;
            }

            throw new KeyNotFoundException();
        }

        public Hero GetHeroByName(string name, bool abilities = false, bool subAbilities = false, bool talents = false, bool heroUnits = false)
        {
            JsonElement jsonElement = JsonDataDocument.RootElement;

            foreach (JsonProperty heroElement in jsonElement.EnumerateObject())
            {
                if (heroElement.Value.TryGetProperty("name", out JsonElement nameElement) && nameElement.ValueEquals(name))
                {
                    Hero hero = GetHeroData(heroElement.Value, abilities, subAbilities, talents, heroUnits);
                    hero.Id = heroElement.Name;
                    hero.CHeroId = heroElement.Name;

                    return hero;
                }
            }

            throw new KeyNotFoundException();
        }

        private Hero GetHeroData(JsonElement heroElement, bool includeAbilities, bool includeSubAbilities, bool includeTalents, bool includeHeroUnits)
        {
            Hero hero = new Hero
            {
                CUnitId = heroElement.GetProperty("unitId").GetString(),
                HyperlinkId = heroElement.GetProperty("hyperlinkId").GetString(),
                AttributeId = heroElement.GetProperty("attributeId").GetString(),
            };

            if (heroElement.TryGetProperty("name", out JsonElement name))
                hero.Name = name.GetString();

            if (heroElement.TryGetProperty("difficulty", out JsonElement difficulty))
                hero.Difficulty = difficulty.GetString();

            if (Enum.TryParse(heroElement.GetProperty("franchise").GetString(), out HeroFranchise heroFranchise))
                hero.Franchise = heroFranchise;
            else
                hero.Franchise = HeroFranchise.Unknown;

            if (Enum.TryParse(heroElement.GetProperty("gender").GetString(), out UnitGender unitGender))
                hero.Gender = unitGender;
            else
                hero.Gender = UnitGender.Neutral;

            if (heroElement.TryGetProperty("title", out JsonElement title))
                hero.Title = title.GetString();

            hero.InnerRadius = heroElement.GetProperty("innerRadius").GetDouble();
            hero.Radius = heroElement.GetProperty("radius").GetDouble();

            if (heroElement.GetProperty("releaseDate").TryGetDateTime(out DateTime releaseDate))
                hero.ReleaseDate = releaseDate;

            hero.Sight = heroElement.GetProperty("sight").GetDouble();
            hero.Speed = heroElement.GetProperty("speed").GetDouble();

            if (heroElement.TryGetProperty("type", out JsonElement type))
                hero.Type = type.GetString();

            if (Enum.TryParse(heroElement.GetProperty("rarity").GetString(), out Rarity rarity))
                hero.Rarity = rarity;
            else
                hero.Rarity = Rarity.Unknown;

            if (heroElement.TryGetProperty("scalingLinkId", out JsonElement scalingLinkId))
                hero.ScalingBehaviorLink = scalingLinkId.GetString();

            if (heroElement.TryGetProperty("searchText", out JsonElement searchText))
                hero.SearchText = searchText.GetString();

            if (heroElement.TryGetProperty("description", out JsonElement description))
                hero.Description = new TooltipDescription(description.GetString());

            if (heroElement.TryGetProperty("descriptors", out JsonElement descriptors))
            {
                foreach (JsonElement descriptorArrayElement in descriptors.EnumerateArray())
                    hero.AddHeroDescriptor(descriptorArrayElement.GetString());
            }

            if (heroElement.TryGetProperty("units", out JsonElement units))
            {
                foreach (JsonElement unitArrayElement in units.EnumerateArray())
                    hero.AddUnitId(unitArrayElement.GetString());
            }

            // portraits
            if (heroElement.TryGetProperty("portraits", out JsonElement portraits))
            {
                if (portraits.TryGetProperty("heroSelect", out JsonElement heroSelect))
                    hero.HeroPortrait.HeroSelectPortraitFileName = heroSelect.GetString();
                if (portraits.TryGetProperty("leaderboard", out JsonElement leaderboard))
                    hero.HeroPortrait.LeaderboardPortraitFileName = leaderboard.GetString();
                if (portraits.TryGetProperty("loading", out JsonElement loading))
                    hero.HeroPortrait.LoadingScreenPortraitFileName = loading.GetString();
                if (portraits.TryGetProperty("partyPanel", out JsonElement partyPanel))
                    hero.HeroPortrait.PartyPanelPortraitFileName = partyPanel.GetString();
                if (portraits.TryGetProperty("target", out JsonElement target))
                    hero.HeroPortrait.TargetPortraitFileName = target.GetString();
                if (portraits.TryGetProperty("draftScreen", out JsonElement draftScreen))
                    hero.HeroPortrait.DraftScreenFileName = draftScreen.GetString();
                if (portraits.TryGetProperty("partyFrames", out JsonElement partyFrames))
                {
                    foreach (JsonElement partyFrameArrayElement in partyFrames.EnumerateArray())
                    {
                        hero.HeroPortrait.PartyFrameFileName.Add(partyFrameArrayElement.GetString());
                    }
                }
            }

            // life
            SetUnitLife(heroElement, hero);

            // shield
            SetUnitShield(heroElement, hero);

            // energy
            SetUnitEnergy(heroElement, hero);

            // armor
            SetUnitArmor(heroElement, hero);

            // roles
            if (heroElement.TryGetProperty("roles", out JsonElement roles))
            {
                foreach (JsonElement roleArrayElement in roles.EnumerateArray())
                    hero.AddRole(roleArrayElement.GetString());
            }

            // expandedRole
            if (heroElement.TryGetProperty("expandedRole", out JsonElement expandedRole))
                hero.ExpandedRole = expandedRole.GetString();

            // ratings
            if (heroElement.TryGetProperty("ratings", out JsonElement ratings))
            {
                hero.Ratings.Complexity = ratings.GetProperty("complexity").GetDouble();
                hero.Ratings.Damage = ratings.GetProperty("damage").GetDouble();
                hero.Ratings.Survivability = ratings.GetProperty("survivability").GetDouble();
                hero.Ratings.Utility = ratings.GetProperty("utility").GetDouble();
            }

            // weapons
            SetUnitWeapons(heroElement, hero);

            // abilities
            if (includeAbilities && heroElement.TryGetProperty("abilities", out JsonElement abilities))
            {
                AddAbilities(hero, abilities);
            }

            // TODO: subAbilities
            /*if (includeSubAbilities && heroElement.TryGetProperty("subAbilities", out JsonElement subAbilities))
            //{
            //    foreach (JsonElement subAbilityArrayElement in subAbilities.EnumerateArray())
            //    {
            //        foreach (JsonProperty subAbilityProperty in subAbilityArrayElement.EnumerateObject())
            //        {
            //            string parentLink = subAbilityProperty.Name;
            //            subAbilityProperty.Value
            //        }
            //    }
            }*/

            // talents
            if (includeTalents && heroElement.TryGetProperty("talents", out JsonElement talents))
            {
                if (talents.TryGetProperty("level1", out JsonElement tierElement))
                    AddTierTalents(hero, tierElement, TalentTier.Level1);
                if (talents.TryGetProperty("level4", out tierElement))
                    AddTierTalents(hero, tierElement, TalentTier.Level4);
                if (talents.TryGetProperty("level7", out tierElement))
                    AddTierTalents(hero, tierElement, TalentTier.Level7);
                if (talents.TryGetProperty("level10", out tierElement))
                    AddTierTalents(hero, tierElement, TalentTier.Level10);
                if (talents.TryGetProperty("level13", out tierElement))
                    AddTierTalents(hero, tierElement, TalentTier.Level13);
                if (talents.TryGetProperty("level16", out tierElement))
                    AddTierTalents(hero, tierElement, TalentTier.Level16);
                if (talents.TryGetProperty("level20", out tierElement))
                    AddTierTalents(hero, tierElement, TalentTier.Level20);
            }

           // SetLocalizedGameStrings(hero);
            SetLocalizedHeroGameStrings(hero);

            return hero;
        }

        private void AddTierTalents(Hero hero, JsonElement tierElement, TalentTier talentTier)
        {
            foreach (JsonElement element in tierElement.EnumerateArray())
            {
                Talent talent = new Talent
                {
                    Tier = talentTier,
                };

                SetAbilityTalentBase(talent, element);

                if (element.TryGetProperty("sort", out JsonElement sort))
                    talent.Column = sort.GetInt32();

                if (element.TryGetProperty("abilityTalentLinkIds", out JsonElement abilityTalentLinkIds))
                {
                    foreach (JsonElement abilityTalentLinkIdElement in abilityTalentLinkIds.EnumerateArray())
                        talent.AddAbilityTalentLinkId(abilityTalentLinkIdElement.GetString());
                }

                if (element.TryGetProperty("prerequisiteTalentIds", out JsonElement prerequisiteTalentIds))
                {
                    foreach (JsonElement prerequisiteTalentIdElement in prerequisiteTalentIds.EnumerateArray())
                        talent.AddPrerequisiteTalentId(prerequisiteTalentIdElement.GetString());
                }

                hero.AddTalent(talent);
            }
        }

        private void SetLocalizedHeroGameStrings(Hero hero)
        {
            //if (JsonGameStringDocument != null)
            //{
            //    JsonElement element = JsonGameStringDocument.RootElement;

            //    if (element.TryGetProperty($"unit/difficulty/{hero.CHeroId}", out JsonElement value))
            //        hero.Difficulty = value.ToString();
            //    if (element.TryGetProperty($"unit/expandedrole/{hero.CHeroId}", out value))
            //        hero.ExpandedRole = value.ToString();

            //    if (element.TryGetProperty($"unit/role/{hero.CHeroId}", out value))
            //    {
            //        string[] roles = value.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries);

            //        foreach (string role in roles)
            //        {
            //            hero.AddRole(role);
            //        }
            //    }

            //    if (element.TryGetProperty($"unit/searchtext/{hero.CHeroId}", out value))
            //        hero.SearchText = value.ToString();
            //    if (element.TryGetProperty($"unit/title/{hero.CHeroId}", out value))
            //        hero.Title = value.ToString();
            //    if (element.TryGetProperty($"unit/type/{hero.CHeroId}", out value))
            //        hero.Type = value.ToString();
            //}
        }

        /// <summary>
        /// Returns the hero's name from the attribute id.
        /// </summary>
        /// <param name="attributeId">Four character hero id.</param>
        /// <returns></returns>
        //string HeroNameFromAttributeId(string attributeId);

        /// <summary>
        /// Returns the hero's name from the short name.
        /// </summary>
        /// <param name="shortName">Short name of hero.</param>
        /// <returns></returns>
        //string HeroNameFromShortName(string shortName);
    }
}
