using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.DataDocument
{
    /// <summary>
    /// Provides access to obtain <see cref="Unit"/> data as well as updating localized strings.
    /// </summary>
    public class UnitDataDocument : UnitDataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected UnitDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected UnitDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected UnitDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected UnitDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected UnitDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected UnitDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected UnitDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected UnitDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(string jsonDataFilePath)
        {
            return new UnitDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new UnitDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new UnitDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new UnitDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new UnitDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new UnitDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new UnitDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static UnitDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new UnitDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static Task<UnitDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new UnitDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<UnitDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static Task<UnitDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new UnitDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<UnitDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Unit"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="UnitDataDocument"/> representation of the JSON value.</returns>
        public static Task<UnitDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new UnitDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<UnitDataDocument>();
        }

        /// <summary>
        /// Gets a <see cref="Unit"/> from the unit <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">A unit id property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <returns>A <see cref="Unit"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public Unit GetUnitById(string id, bool abilities, bool subAbilities)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetUnitById(id, out Unit? value, abilities, subAbilities))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a unit with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">A unit id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Unit"/> associated with the <paramref name="id"/> property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetUnitById(string? id, [NotNullWhen(true)] out Unit? value, bool abilities, bool subAbilities)
        {
            value = null;

            if (id is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetUnitData(id, element, abilities, subAbilities);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a <see cref="Unit"/> from the unit <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A unit hyperlinkId property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <returns>A <see cref="Unit"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="hyperlinkId"/> property value was not found.</exception>
        public Unit GetUnitByHyperlinkId(string hyperlinkId, bool abilities, bool subAbilities)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetUnitByHyperlinkId(hyperlinkId, out Unit? value, abilities, subAbilities))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a unit with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">A unit hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Unit"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetUnitByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out Unit? value, bool abilities, bool subAbilities)
            => PropertyLookup("hyperlinkId", hyperlinkId, out value, abilities, subAbilities);

        /// <summary>
        /// Gets a collection of all units.
        /// </summary>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <returns>A collection of <see cref="Unit"/>s.</returns>
        public IEnumerable<Unit> GetUnits(bool abilities, bool subAbilities)
        {
            foreach (JsonProperty unit in JsonDataDocument.RootElement.EnumerateObject())
            {
                yield return GetUnitById(unit.Name, abilities, subAbilities);
            }
        }

        private Unit GetUnitData(string unitId, JsonElement element, bool includeAbilities, bool includeSubAbilities)
        {
            Unit unit = new Unit
            {
                Id = unitId,
                CUnitId = unitId,
            };

            int indexOfMapSplit = unit.Id.IndexOf('-', StringComparison.OrdinalIgnoreCase);

            if (indexOfMapSplit > 0)
            {
                unit.MapName = unit.Id.Substring(0, indexOfMapSplit);
            }

            if (element.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                unit.HyperlinkId = hyperlinkId.GetString();

            int index = unitId.IndexOf('-', StringComparison.InvariantCultureIgnoreCase);
            if (index > -1)
            {
                unit.MapName = unitId.Substring(0, index);
            }

            if (element.TryGetProperty("name", out JsonElement name))
                unit.Name = name.GetString();
            if (element.TryGetProperty("innerRadius", out JsonElement innerRadius))
                unit.InnerRadius = innerRadius.GetDouble();
            if (element.TryGetProperty("radius", out JsonElement radius))
                unit.Radius = radius.GetDouble();
            if (element.TryGetProperty("sight", out JsonElement sight))
                unit.Sight = sight.GetDouble();
            if (element.TryGetProperty("speed", out JsonElement speed))
                unit.Speed = speed.GetDouble();
            if (element.TryGetProperty("killXP", out JsonElement killXP))
                unit.KillXP = killXP.GetInt32();
            if (element.TryGetProperty("damageType", out JsonElement damageType))
                unit.DamageType = damageType.GetString();
            if (element.TryGetProperty("scalingLinkId", out JsonElement scalingLinkId))
                unit.ScalingBehaviorLink = scalingLinkId.GetString();
            if (element.TryGetProperty("description", out JsonElement description))
                unit.Description = new TooltipDescription(description.GetString(), Localization);

            if (element.TryGetProperty("descriptors", out JsonElement descriptorElements))
            {
                foreach (JsonElement descriptorArrayElement in descriptorElements.EnumerateArray())
                    unit.HeroDescriptors.Add(descriptorArrayElement.GetString());
            }

            if (element.TryGetProperty("attributes", out JsonElement attributesElements))
            {
                foreach (JsonElement attributeArrayElement in attributesElements.EnumerateArray())
                    unit.Attributes.Add(attributeArrayElement.GetString());
            }

            if (element.TryGetProperty("units", out JsonElement unitsElements))
            {
                foreach (JsonElement unitArrayElement in unitsElements.EnumerateArray())
                    unit.UnitIds.Add(unitArrayElement.GetString());
            }

            // portraits
            if (element.TryGetProperty("portraits", out JsonElement portraitsElement))
            {
                if (portraitsElement.TryGetProperty("targetInfo", out JsonElement portraitValue))
                    unit.UnitPortrait.TargetInfoPanelFileName = portraitValue.GetString();
                if (portraitsElement.TryGetProperty("minimap", out portraitValue))
                    unit.UnitPortrait.MiniMapIconFileName = portraitValue.GetString();
            }

            // life
            SetUnitLife(element, unit);

            // shield
            SetUnitShield(element, unit);

            // energy
            SetUnitEnergy(element, unit);

            // armor
            SetUnitArmor(element, unit);

            // weapons
            SetUnitWeapons(element, unit);

            // abilities
            if (includeAbilities && element.TryGetProperty("abilities", out JsonElement abilities))
            {
                AddAbilities(unit, abilities);
            }

            if (includeSubAbilities && element.TryGetProperty("subAbilities", out JsonElement subAbilities))
            {
                foreach (JsonElement subAbilityArrayElement in subAbilities.EnumerateArray())
                {
                    foreach (JsonProperty subAbilityProperty in subAbilityArrayElement.EnumerateObject())
                    {
                        string parentLink = subAbilityProperty.Name;

                        AddAbilities(unit, subAbilityProperty.Value, parentLink);
                    }
                }
            }

            GameStringDocument?.UpdateGameStrings(unit);

            return unit;
        }

        private bool PropertyLookup(string propertyId, string? propertyValue, [NotNullWhen(true)] out Unit? value, bool abilities, bool subAbilities)
        {
            value = null;

            if (propertyValue is null)
                return false;

            foreach (JsonProperty unitProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (unitProperty.Value.TryGetProperty(propertyId, out JsonElement nameElement) && nameElement.ValueEquals(propertyValue))
                {
                    value = GetUnitData(unitProperty.Name, unitProperty.Value, abilities, subAbilities);

                    return true;
                }
            }

            return false;
        }
    }
}
