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
    public class HeroDataReader : UnitBaseData, IDataReader
    {
        /// <summary>
        /// Initializes a new reader for the json data file. <see cref="Localization"/> will be
        /// inferred from the <paramref name="jsonDataFilePath"/>.
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
        /// <param name="localization">Localization of data.</param>
        public HeroDataReader(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new reader for the json data file. The <paramref name="gameStringReader"/>
        /// overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing hero data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public HeroDataReader(string jsonDataFilePath, GameStringReader gameStringReader)
            : base(jsonDataFilePath, gameStringReader)
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
        /// Gets a collection of all hero names.
        /// </summary>
        public IEnumerable<string> GetNames => GetCollectionOfPropety("name");

        /// <summary>
        /// Gets a collectin of all hyperlink ids.
        /// </summary>
        public IEnumerable<string> GetHyperlinkIds => GetCollectionOfPropety("hyperlinkId");

        /// <summary>
        /// Gets a collectin of all hero unit ids.
        /// </summary>
        public IEnumerable<string> GetUnitIds => GetCollectionOfPropety("unitId");

        /// <summary>
        /// Gets a collectin of all hero attribute ids.
        /// </summary>
        public IEnumerable<string> GetAttributeIds => GetCollectionOfPropety("attributeId");

        /// <summary>
        /// Gets a <see cref="Hero"/> from the given hero <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Hero id to find.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
        public Hero GetHeroById(string id, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (TryGetHeroById(id, out Hero value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the given <paramref name="id"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">Hero id to find.</param>
        /// <param name="value">When this method returns, a <see cref="Hero"/> object.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
        public bool TryGetHeroById(string id, out Hero value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            value = new Hero();

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetHeroData(id, element, abilities, subAbilities, talents, heroUnits);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a <see cref="Hero"/> from the given hero <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Hero name to find.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
        public Hero GetHeroByName(string name, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (TryGetHeroByName(name, out Hero value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the given <paramref name="name"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="name">Hero name to find.</param>
        /// <param name="value">When this method returns, a <see cref="Hero"/> object.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
        public bool TryGetHeroByName(string name, out Hero value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
            => PropertyLookup("name", name, out value, abilities, subAbilities, talents, heroUnits);

        /// <summary>
        /// Gets a <see cref="Hero"/> from the given hero <paramref name="hyperlinkId"/>.
        /// </summary>
        /// <param name="unitId">Hero unitId to find.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
        public Hero GetHeroByUnitId(string unitId, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (unitId is null)
            {
                throw new ArgumentNullException(nameof(unitId));
            }

            if (TryGetHeroByUnitId(unitId, out Hero value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the given <paramref name="unitId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="unitId">Hero unitId to find.</param>
        /// <param name="value">When this method returns, a <see cref="Hero"/> object.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
        public bool TryGetHeroByUnitId(string unitId, out Hero value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
            => PropertyLookup("unitId", unitId, out value, abilities, subAbilities, talents, heroUnits);

        /// <summary>
        /// Gets a <see cref="Hero"/> from the given hero <paramref name="hyperlinkId"/>.
        /// </summary>
        /// <param name="hyperlinkId">Hero hyperlinkId to find.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
        public Hero GetHeroByHyperlinkId(string hyperlinkId, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (hyperlinkId is null)
            {
                throw new ArgumentNullException(nameof(hyperlinkId));
            }

            if (TryGetHeroByHyperlinkId(hyperlinkId, out Hero value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the given <paramref name="hyperlinkId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">Hero hyperlinkId to find.</param>
        /// <param name="value">When this method returns, a <see cref="Hero"/> object.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
        public bool TryGetHeroByHyperlinkId(string hyperlinkId, out Hero value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
            => PropertyLookup("hyperlinkId", hyperlinkId, out value, abilities, subAbilities, talents, heroUnits);

        /// <summary>
        /// Gets a <see cref="Hero"/> from the given hero <paramref name="attributeId"/>.
        /// </summary>
        /// <param name="attributeId">Hero attributeId to find.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
        public Hero GetHeroByAttributeId(string attributeId, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (attributeId is null)
            {
                throw new ArgumentNullException(nameof(attributeId));
            }

            if (TryGetHeroByAttributeId(attributeId, out Hero value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the given <paramref name="attributeId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="attributeId">Hero attributeId to find.</param>
        /// <param name="value">When this method returns, a <see cref="Hero"/> object.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <param name="talents">Value indicating to include talents.</param>
        /// <param name="heroUnits">Value indicating to include hero units.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
        public bool TryGetHeroByAttributeId(string attributeId, out Hero value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
            => PropertyLookup("attributeId", attributeId, out value, abilities, subAbilities, talents, heroUnits);

        /// <summary>
        /// Gets the hero's name from the <paramref name="heroId"/>. If not found returns null.
        /// </summary>
        /// <param name="heroId">The hero's heroId.</param>
        /// <returns>The hero's name.</returns>
        public string? GetNameFromHeroId(string heroId)
        {
            if (heroId is null)
            {
                throw new ArgumentNullException(nameof(heroId));
            }

            if (JsonDataDocument.RootElement.TryGetProperty(heroId, out JsonElement element) && element.TryGetProperty("name", out JsonElement nameElement))
                return nameElement.GetString();

            return null;
        }

        /// <summary>
        /// Gets the hero's name from the <paramref name="unitId"/>. If not found returns null.
        /// </summary>
        /// <param name="unitId">The hero's unitId.</param>
        /// <returns>The hero's name.</returns>
        public string? GetNameFromUnitId(string unitId)
        {
            if (unitId is null)
            {
                throw new ArgumentNullException(nameof(unitId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("unitId", out JsonElement element) && element.ValueEquals(unitId) &&
                    heroProperty.Value.TryGetProperty("name", out JsonElement nameElement))
                {
                    return nameElement.GetString();
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the hero's name from the <paramref name="hyperlinkId"/>. If not found returns null.
        /// </summary>
        /// <param name="hyperlinkId">The hero's hyperlinkId.</param>
        /// <returns>The hero's name.</returns>
        public string? GetNameFromHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
            {
                throw new ArgumentNullException(nameof(hyperlinkId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("hyperlinkId", out JsonElement element) && element.ValueEquals(hyperlinkId) &&
                    heroProperty.Value.TryGetProperty("name", out JsonElement nameElement))
                {
                    return nameElement.GetString();
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the hero's name from the <paramref name="attributeId"/>. If not found returns null.
        /// </summary>
        /// <param name="attributeId">The hero's attributeId.</param>
        /// <returns>The hero's name.</returns>
        public string? GetNameFromAttributeId(string attributeId)
        {
            if (attributeId is null)
            {
                throw new ArgumentNullException(nameof(attributeId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("attributeId", out JsonElement element) && element.ValueEquals(attributeId) &&
                    heroProperty.Value.TryGetProperty("name", out JsonElement nameElement))
                {
                    return nameElement.GetString();
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the hero's id from the <paramref name="name"/>. If not found returns null.
        /// </summary>
        /// <param name="name">The hero's name.</param>
        /// <returns>The hero's id.</returns>
        public string? GetHeroIdFromName(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("name", out JsonElement element) && element.ValueEquals(name))
                    return heroProperty.Name;
            }

            return null;
        }

        /// <summary>
        /// Gets the hero's id from the <paramref name="unitId"/>. If not found returns null.
        /// </summary>
        /// <param name="unitId">The hero's unitId.</param>
        /// <returns>The hero's id.</returns>
        public string? GetHeroIdFromUnitId(string unitId)
        {
            if (unitId is null)
            {
                throw new ArgumentNullException(nameof(unitId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("unitId", out JsonElement element) && element.ValueEquals(unitId))
                    return heroProperty.Name;
            }

            return null;
        }

        /// <summary>
        /// Gets the hero's id from the <paramref name="hyperlinkId"/>. If not found returns null.
        /// </summary>
        /// <param name="hyperlinkId">The hero's hyperlinkId.</param>
        /// <returns>The hero's id.</returns>
        public string? GetHeroIdFromHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
            {
                throw new ArgumentNullException(nameof(hyperlinkId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("hyperlinkId", out JsonElement element) && element.ValueEquals(hyperlinkId))
                    return heroProperty.Name;
            }

            return null;
        }

        /// <summary>
        /// Gets the hero's id from the <paramref name="attributeId"/>. If not found returns null.
        /// </summary>
        /// <param name="hyperlinkId">The hero's hyperlinkId.</param>
        /// <returns>The hero's id.</returns>
        public string? GetHeroIdFromAttributeId(string attributeId)
        {
            if (attributeId is null)
            {
                throw new ArgumentNullException(nameof(attributeId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("attributeId", out JsonElement element) && element.ValueEquals(attributeId))
                    return heroProperty.Name;
            }

            return null;
        }

        /// <summary>
        /// Returns the value indicating if the <paramref name="heroId"/> was found.
        /// </summary>
        /// <param name="heroId">The hero's id.</param>
        /// <returns>Value indicating if found.</returns>
        public bool IsHeroExistsByHeroId(string heroId)
        {
            if (heroId is null)
            {
                throw new ArgumentNullException(nameof(heroId));
            }

            return JsonDataDocument.RootElement.TryGetProperty(heroId, out JsonElement _);
        }

        /// <summary>
        /// Returns the value indicating if the <paramref name="name"/> was found.
        /// </summary>
        /// <param name="name">The hero's name.</param>
        /// <returns>Value indicating if found.</returns>
        public bool IsHeroExistsByName(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("name", out JsonElement element) && element.ValueEquals(name))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the value indicating if the <paramref name="unitId"/> was found.
        /// </summary>
        /// <param name="unitId">The hero's unitId.</param>
        /// <returns>Value indicating if found.</returns>
        public bool IsHeroExistsByUnitId(string unitId)
        {
            if (unitId is null)
            {
                throw new ArgumentNullException(nameof(unitId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("unitId", out JsonElement element) && element.ValueEquals(unitId))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the value indicating if the <paramref name="hyperlinkId"/> was found.
        /// </summary>
        /// <param name="hyperlinkId">The hero's hyperlinkId.</param>
        /// <returns>Value indicating if found.</returns>
        public bool IsHeroExistsByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
            {
                throw new ArgumentNullException(nameof(hyperlinkId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("hyperlinkId", out JsonElement element) && element.ValueEquals(hyperlinkId))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the value indicating if the <paramref name="attributeId"/> was found.
        /// </summary>
        /// <param name="attributeId">The hero's attributeId.</param>
        /// <returns>Value indicating if found.</returns>
        public bool IsHeroExistsByAttributeId(string attributeId)
        {
            if (attributeId is null)
            {
                throw new ArgumentNullException(nameof(attributeId));
            }

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("attributeId", out JsonElement element) && element.ValueEquals(attributeId))
                    return true;
            }

            return false;
        }

        private Hero GetHeroData(string heroId, JsonElement heroElement, bool includeAbilities, bool includeSubAbilities, bool includeTalents, bool includeHeroUnits)
        {
            Hero hero = new Hero
            {
                CHeroId = heroId,
            };

            if (heroElement.TryGetProperty("unitId", out JsonElement unitId))
                hero.CUnitId = unitId.GetString();

            if (heroElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                hero.HyperlinkId = hyperlinkId.GetString();

            if (heroElement.TryGetProperty("attributeId", out JsonElement attributeId))
                hero.AttributeId = attributeId.GetString();

            if (heroElement.TryGetProperty("name", out JsonElement name))
                hero.Name = name.GetString();

            if (heroElement.TryGetProperty("difficulty", out JsonElement difficulty))
                hero.Difficulty = difficulty.GetString();

            if (heroElement.TryGetProperty("franchise", out JsonElement franchise) && Enum.TryParse(franchise.GetString(), out HeroFranchise heroFranchise))
                hero.Franchise = heroFranchise;
            else
                hero.Franchise = HeroFranchise.Unknown;

            if (heroElement.TryGetProperty("gender", out JsonElement gender) && Enum.TryParse(gender.GetString(), out UnitGender unitGender))
                hero.Gender = unitGender;
            else
                hero.Gender = UnitGender.Neutral;

            if (heroElement.TryGetProperty("title", out JsonElement title))
                hero.Title = title.GetString();

            if (heroElement.TryGetProperty("innerRadius", out JsonElement innerRadius))
                hero.InnerRadius = innerRadius.GetDouble();

            if (heroElement.TryGetProperty("radius", out JsonElement radius))
                hero.Radius = radius.GetDouble();

            if (heroElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && releaseDateElement.TryGetDateTime(out DateTime releaseDate))
                hero.ReleaseDate = releaseDate;

            if (heroElement.TryGetProperty("sight", out JsonElement sight))
                hero.Sight = sight.GetDouble();

            if (heroElement.TryGetProperty("speed", out JsonElement speed))
                hero.Speed = speed.GetDouble();

            if (heroElement.TryGetProperty("type", out JsonElement type))
                hero.Type = type.GetString();

            if (heroElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
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

                if (portraits.TryGetProperty("minimap", out JsonElement miniMap))
                    hero.UnitPortrait.MiniMapIconFileName = miniMap.GetString();
                if (portraits.TryGetProperty("targetInfo", out JsonElement targetInfo))
                    hero.UnitPortrait.TargetInfoPanelFileName = targetInfo.GetString();
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

            if (includeSubAbilities && heroElement.TryGetProperty("subAbilities", out JsonElement subAbilities))
            {
                foreach (JsonElement subAbilityArrayElement in subAbilities.EnumerateArray())
                {
                    foreach (JsonProperty subAbilityProperty in subAbilityArrayElement.EnumerateObject())
                    {
                        string parentLink = subAbilityProperty.Name;

                        AddAbilities(hero, subAbilityProperty.Value, parentLink);
                    }
                }
            }

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

            if (includeHeroUnits && heroElement.TryGetProperty("heroUnits", out JsonElement heroUnits))
            {
                foreach (JsonElement heroUnitArrayElement in heroUnits.EnumerateArray())
                {
                    foreach (JsonProperty heroUnitProperty in heroUnitArrayElement.EnumerateObject())
                    {
                        hero.AddHeroUnit(GetHeroData(heroUnitProperty.Name, heroUnitProperty.Value, true, true, true, true));
                    }
                }
            }

            GameStringReader?.UpdateGameStrings(hero);

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

        private bool PropertyLookup(string propertyId, string propertyValue, out Hero value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (propertyValue is null)
                throw new ArgumentNullException(nameof(propertyValue));

            value = new Hero();

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty(propertyId, out JsonElement nameElement) && nameElement.ValueEquals(propertyValue))
                {
                    value = GetHeroData(heroProperty.Name, heroProperty.Value, abilities, subAbilities, talents, heroUnits);

                    return true;
                }
            }

            return false;
        }
    }
}
