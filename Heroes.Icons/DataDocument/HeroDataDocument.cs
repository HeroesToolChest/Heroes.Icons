using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.DataDocument
{
    /// <summary>
    /// Provides access to obtain <see cref="Hero"/> data as well as updating localized strings.
    /// </summary>
    public class HeroDataDocument : UnitDataBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// <see cref="Localization"/> will be inferred from the <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected HeroDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected HeroDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected HeroDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected HeroDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected HeroDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected HeroDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected HeroDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected HeroDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Gets a collection of all hero unit ids.
        /// </summary>
        public IEnumerable<string> GetUnitIds => GetCollectionOfPropety("unitId");

        /// <summary>
        /// Gets a collection of all hero attribute ids.
        /// </summary>
        public IEnumerable<string> GetAttributeIds => GetCollectionOfPropety("attributeId");

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>A <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(string jsonDataFilePath)
        {
            return new HeroDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// <see cref="Localization"/> will be inferred from the <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new HeroDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new HeroDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new HeroDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new HeroDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new HeroDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new HeroDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static HeroDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new HeroDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static Task<HeroDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new HeroDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<HeroDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static Task<HeroDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new HeroDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<HeroDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Hero"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="HeroDataDocument"/> representation of the JSON value.</returns>
        public static Task<HeroDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new HeroDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<HeroDataDocument>();
        }

        /// <summary>
        /// Gets a <see cref="Hero"/> from the hero <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">A hero id property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <returns>A <see cref="Hero"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public Hero GetHeroById(string id, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetHeroById(id, out Hero? value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">A hero id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Unit"/> associated with the <paramref name="id"/> property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroById(string? id, [NotNullWhen(true)] out Hero? value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            value = null;

            if (id is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetHeroData(id, element, abilities, subAbilities, talents, heroUnits);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a <see cref="Hero"/> from the hero <paramref name="unitId"/> property value.
        /// </summary>
        /// <param name="unitId">A hero unitId property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unitId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="unitId"/> property value was not found.</exception>
        /// <returns>A <see cref="Hero"/> object.</returns>
        public Hero GetHeroByUnitId(string unitId, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (unitId is null)
                throw new ArgumentNullException(nameof(unitId));

            if (TryGetHeroByUnitId(unitId, out Hero? value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the given <paramref name="unitId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="unitId">A hero unitId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Unit"/> associated with the <paramref name="unitId"/> property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroByUnitId(string? unitId, [NotNullWhen(true)] out Hero? value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
            => PropertyLookup("unitId", unitId, out value, abilities, subAbilities, talents, heroUnits);

        /// <summary>
        /// Gets a <see cref="Hero"/> from the hero <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A hero hyperlinkId property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>A <see cref="Hero"/> object.</returns>
        public Hero GetHeroByHyperlinkId(string hyperlinkId, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetHeroByHyperlinkId(hyperlinkId, out Hero? value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">A hero hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Hero"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out Hero? value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
            => PropertyLookup("hyperlinkId", hyperlinkId, out value, abilities, subAbilities, talents, heroUnits);

        /// <summary>
        /// Gets a <see cref="Hero"/> from the hero <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">A hero attributeId property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is null.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="attributeId"/> property value was not found.</exception>
        /// <returns>A <see cref="Hero"/> object.</returns>
        public Hero GetHeroByAttributeId(string attributeId, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            if (attributeId is null)
                throw new ArgumentNullException(nameof(attributeId));

            if (TryGetHeroByAttributeId(attributeId, out Hero? value, abilities, subAbilities, talents, heroUnits))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero with the <paramref name="attributeId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="attributeId">A hero attributeId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Hero"/> associated with the <paramref name="attributeId"/> property value.</param>
        /// <param name="abilities">A value indicating whether to include ability parsing.</param>
        /// <param name="subAbilities">A value indicating whether to include sub-ability parsing.</param>
        /// <param name="talents">A value indicating whether to include talent parsing.</param>
        /// <param name="heroUnits">A value indicating whether to include hero unit parsing.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroByAttributeId(string? attributeId, [NotNullWhen(true)] out Hero? value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
            => PropertyLookup("attributeId", attributeId, out value, abilities, subAbilities, talents, heroUnits);

        /// <summary>
        /// Gets the hero's name from a <paramref name="heroId"/> property value.
        /// </summary>
        /// <param name="heroId">A hero heroId property value.</param>
        /// <returns>The hero's name.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="heroId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">No property was found with the requested property value.</exception>
        public string GetNameFromHeroId(string heroId)
        {
            if (heroId is null)
                throw new ArgumentNullException(nameof(heroId));

            if (TryGetNameFromHeroId(heroId, out string? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for the hero's name from a <paramref name="heroId"/> property value.
        /// </summary>
        /// <param name="heroId">A hero heroId property value.</param>
        /// <param name="value">When this method returns, contains the name of the hero.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetNameFromHeroId(string? heroId, [NotNullWhen(true)] out string? value)
        {
            value = null;

            if (heroId is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(heroId, out JsonElement element) && element.TryGetProperty("name", out JsonElement nameElement))
            {
                value = nameElement.GetString();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the hero's name from a <paramref name="unitId"/> property value.
        /// </summary>
        /// <param name="unitId">A hero unitId property value.</param>
        /// <returns>The hero's name.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unitId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">No property was found with the requested property value.</exception>
        public string GetNameFromUnitId(string unitId)
        {
            if (unitId is null)
                throw new ArgumentNullException(nameof(unitId));

            if (TryGetNameFromUnitId(unitId, out string? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for the hero's name from a <paramref name="unitId"/> property value.
        /// </summary>
        /// <param name="unitId">A hero unitId property value.</param>
        /// <param name="value">When this method returns, contains the name of the hero.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetNameFromUnitId(string? unitId, [NotNullWhen(true)] out string? value)
        {
            value = null;

            if (unitId is null)
                return false;

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("unitId", out JsonElement unitIdElement) && unitIdElement.ValueEquals(unitId) &&
                    heroProperty.Value.TryGetProperty("name", out JsonElement nameElement))
                {
                    value = nameElement.GetString();

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the hero's name from a <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A hero hyperlinkId property value.</param>
        /// <returns>The hero's name.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">No property was found with the requested property value.</exception>
        public string GetNameFromHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetNameFromHyperlinkId(hyperlinkId, out string? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for the hero's name from a <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A hero hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the name of the hero.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetNameFromHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out string? value)
        {
            value = null;

            if (hyperlinkId is null)
                return false;

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("hyperlinkId", out JsonElement unitIdElement) && unitIdElement.ValueEquals(hyperlinkId) &&
                    heroProperty.Value.TryGetProperty("name", out JsonElement nameElement))
                {
                    value = nameElement.GetString();

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the hero's name from a <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">A hero attributeId property value.</param>
        /// <returns>The hero's name.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">No property was found with the requested property value.</exception>
        public string GetNameFromAttributeId(string attributeId)
        {
            if (attributeId is null)
                throw new ArgumentNullException(nameof(attributeId));

            if (TryGetNameFromAttributeId(attributeId, out string? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for the hero's name from a <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">A hero attributeId property value.</param>
        /// <param name="value">When this method returns, contains the name of the hero.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetNameFromAttributeId(string? attributeId, [NotNullWhen(true)] out string? value)
        {
            value = null;

            if (attributeId is null)
                return false;

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("attributeId", out JsonElement unitIdElement) && unitIdElement.ValueEquals(attributeId) &&
                    heroProperty.Value.TryGetProperty("name", out JsonElement nameElement))
                {
                    value = nameElement.GetString();

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the hero's id from a <paramref name="unitId"/> property value.
        /// </summary>
        /// <param name="unitId">A hero unitId property value.</param>
        /// <returns>The hero's id.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unitId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">No property was found with the requested property value.</exception>
        public string GetHeroIdFromUnitId(string unitId)
        {
            if (unitId is null)
                throw new ArgumentNullException(nameof(unitId));

            if (TryGetHeroIdFromUnitId(unitId, out string? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for the hero's id from a <paramref name="unitId"/> property value.
        /// </summary>
        /// <param name="unitId">A hero unitId property value.</param>
        /// <param name="value">When this method returns, contains the id of the hero.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroIdFromUnitId(string? unitId, [NotNullWhen(true)] out string? value)
        {
            value = null;

            if (unitId is null)
                return false;

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("unitId", out JsonElement element) && element.ValueEquals(unitId))
                {
                    value = heroProperty.Name;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the hero's id from a <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A hero hyperlinkId property value.</param>
        /// <returns>The hero's id.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">No property was found with the requested property value.</exception>
        public string GetHeroIdFromHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetHeroIdFromHyperlinkId(hyperlinkId, out string? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for the hero's id from a <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A hero hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the id of the hero.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroIdFromHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out string? value)
        {
            value = null;

            if (hyperlinkId is null)
                return false;

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("hyperlinkId", out JsonElement element) && element.ValueEquals(hyperlinkId))
                {
                    value = heroProperty.Name;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the hero's id from a <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">A hero attributeId property value.</param>
        /// <returns>The hero's id.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">No property was found with the requested property value.</exception>
        public string GetHeroIdFromAttributeId(string attributeId)
        {
            if (attributeId is null)
                throw new ArgumentNullException(nameof(attributeId));

            if (TryGetHeroIdFromAttributeId(attributeId, out string? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for the hero's id from a <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">A hero attributeId property value.</param>
        /// <param name="value">When this method returns, contains the id of the hero.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroIdFromAttributeId(string? attributeId, [NotNullWhen(true)] out string? value)
        {
            value = null;

            if (attributeId is null)
                return false;

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("attributeId", out JsonElement element) && element.ValueEquals(attributeId))
                {
                    value = heroProperty.Name;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether a <paramref name="heroId"/> property value is found.
        /// </summary>
        /// <param name="heroId">A hero heroId property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="heroId"/> is <see langword="null"/>.</exception>
        public bool IsHeroExistsByHeroId(string heroId)
        {
            if (heroId is null)
                throw new ArgumentNullException(nameof(heroId));

            return JsonDataDocument.RootElement.TryGetProperty(heroId, out JsonElement _);
        }

        /// <summary>
        /// Returns a value indicating whether a <paramref name="unitId"/> property value was found.
        /// </summary>
        /// <param name="unitId">A hero unitId property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unitId"/> is <see langword="null"/>.</exception>
        public bool IsHeroExistsByUnitId(string unitId)
        {
            if (unitId is null)
                throw new ArgumentNullException(nameof(unitId));

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("unitId", out JsonElement element) && element.ValueEquals(unitId))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether a <paramref name="hyperlinkId"/> property value was found.
        /// </summary>
        /// <param name="hyperlinkId">A hero hyperlinkId property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        public bool IsHeroExistsByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty("hyperlinkId", out JsonElement element) && element.ValueEquals(hyperlinkId))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether the <paramref name="attributeId"/> property value was found.
        /// </summary>
        /// <param name="attributeId">A hero attributeId property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
        public bool IsHeroExistsByAttributeId(string attributeId)
        {
            if (attributeId is null)
                throw new ArgumentNullException(nameof(attributeId));

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

            if (heroElement.TryGetProperty("unitId", out JsonElement unitIdElement))
                hero.CUnitId = unitIdElement.GetString();

            if (heroElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkIdElement))
                hero.HyperlinkId = hyperlinkIdElement.GetString();

            if (heroElement.TryGetProperty("attributeId", out JsonElement attributeIdElement))
                hero.AttributeId = attributeIdElement.GetString();

            if (heroElement.TryGetProperty("name", out JsonElement nameElement))
                hero.Name = nameElement.GetString();

            if (heroElement.TryGetProperty("difficulty", out JsonElement difficultyElement))
                hero.Difficulty = difficultyElement.GetString();

            if (heroElement.TryGetProperty("franchise", out JsonElement franchiseElement) && Enum.TryParse(franchiseElement.GetString(), out HeroFranchise heroFranchise))
                hero.Franchise = heroFranchise;
            else
                hero.Franchise = HeroFranchise.Unknown;

            if (heroElement.TryGetProperty("gender", out JsonElement genderElement) && Enum.TryParse(genderElement.GetString(), out UnitGender unitGender))
                hero.Gender = unitGender;
            else
                hero.Gender = UnitGender.Neutral;

            if (heroElement.TryGetProperty("title", out JsonElement titleElement))
                hero.Title = titleElement.GetString();

            if (heroElement.TryGetProperty("innerRadius", out JsonElement innerRadiusElement))
                hero.InnerRadius = innerRadiusElement.GetDouble();

            if (heroElement.TryGetProperty("radius", out JsonElement radiusElement))
                hero.Radius = radiusElement.GetDouble();

            if (heroElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && releaseDateElement.TryGetDateTime(out DateTime releaseDate))
                hero.ReleaseDate = releaseDate;

            if (heroElement.TryGetProperty("sight", out JsonElement sightElement))
                hero.Sight = sightElement.GetDouble();

            if (heroElement.TryGetProperty("speed", out JsonElement speedElement))
                hero.Speed = speedElement.GetDouble();

            if (heroElement.TryGetProperty("type", out JsonElement typeElement))
                hero.Type = typeElement.GetString();

            if (heroElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
                hero.Rarity = rarity;
            else
                hero.Rarity = Rarity.Unknown;

            if (heroElement.TryGetProperty("scalingLinkId", out JsonElement scalingLinkIdElement))
                hero.ScalingBehaviorLink = scalingLinkIdElement.GetString();

            if (heroElement.TryGetProperty("searchText", out JsonElement searchTextElement))
                hero.SearchText = searchTextElement.GetString();

            if (heroElement.TryGetProperty("description", out JsonElement descriptionElement))
                hero.Description = new TooltipDescription(descriptionElement.GetString(), Localization);

            if (heroElement.TryGetProperty("infoText", out JsonElement infoTextElement))
                hero.InfoText = new TooltipDescription(infoTextElement.GetString(), Localization);

            if (heroElement.TryGetProperty("descriptors", out JsonElement descriptorsElement))
            {
                foreach (JsonElement descriptorArrayElement in descriptorsElement.EnumerateArray())
                    hero.HeroDescriptors.Add(descriptorArrayElement.GetString());
            }

            if (heroElement.TryGetProperty("units", out JsonElement units))
            {
                foreach (JsonElement unitArrayElement in units.EnumerateArray())
                    hero.UnitIds.Add(unitArrayElement.GetString());
            }

            // portraits
            if (heroElement.TryGetProperty("portraits", out JsonElement portraitsElement))
            {
                if (portraitsElement.TryGetProperty("heroSelect", out JsonElement heroSelectElement))
                    hero.HeroPortrait.HeroSelectPortraitFileName = heroSelectElement.GetString();
                if (portraitsElement.TryGetProperty("leaderboard", out JsonElement leaderboardElement))
                    hero.HeroPortrait.LeaderboardPortraitFileName = leaderboardElement.GetString();
                if (portraitsElement.TryGetProperty("loading", out JsonElement loadingElement))
                    hero.HeroPortrait.LoadingScreenPortraitFileName = loadingElement.GetString();
                if (portraitsElement.TryGetProperty("partyPanel", out JsonElement partyPanelElement))
                    hero.HeroPortrait.PartyPanelPortraitFileName = partyPanelElement.GetString();
                if (portraitsElement.TryGetProperty("target", out JsonElement targetElement))
                    hero.HeroPortrait.TargetPortraitFileName = targetElement.GetString();
                if (portraitsElement.TryGetProperty("draftScreen", out JsonElement draftScreenElement))
                    hero.HeroPortrait.DraftScreenFileName = draftScreenElement.GetString();
                if (portraitsElement.TryGetProperty("partyFrames", out JsonElement partyFramesElement))
                {
                    foreach (JsonElement partyFrameArrayElement in partyFramesElement.EnumerateArray())
                    {
                        hero.HeroPortrait.PartyFrameFileName.Add(partyFrameArrayElement.GetString());
                    }
                }

                if (portraitsElement.TryGetProperty("minimap", out JsonElement miniMapElement))
                    hero.UnitPortrait.MiniMapIconFileName = miniMapElement.GetString();
                if (portraitsElement.TryGetProperty("targetInfo", out JsonElement targetInfoElement))
                    hero.UnitPortrait.TargetInfoPanelFileName = targetInfoElement.GetString();
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
            if (heroElement.TryGetProperty("roles", out JsonElement rolesElement))
            {
                foreach (JsonElement roleArrayElement in rolesElement.EnumerateArray())
                    hero.Roles.Add(roleArrayElement.GetString());
            }

            // expandedRole
            if (heroElement.TryGetProperty("expandedRole", out JsonElement expandedRoleElement))
                hero.ExpandedRole = expandedRoleElement.GetString();

            // ratings
            if (heroElement.TryGetProperty("ratings", out JsonElement ratingsElement))
            {
                hero.Ratings.Complexity = ratingsElement.GetProperty("complexity").GetDouble();
                hero.Ratings.Damage = ratingsElement.GetProperty("damage").GetDouble();
                hero.Ratings.Survivability = ratingsElement.GetProperty("survivability").GetDouble();
                hero.Ratings.Utility = ratingsElement.GetProperty("utility").GetDouble();
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
                if (talents.TryGetProperty("level1", out JsonElement level1Element))
                    AddTierTalents(hero, level1Element, TalentTiers.Level1);
                if (talents.TryGetProperty("level4", out JsonElement level4Element))
                    AddTierTalents(hero, level4Element, TalentTiers.Level4);
                if (talents.TryGetProperty("level7", out JsonElement level7Element))
                    AddTierTalents(hero, level7Element, TalentTiers.Level7);
                if (talents.TryGetProperty("level10", out JsonElement level10Element))
                    AddTierTalents(hero, level10Element, TalentTiers.Level10);
                if (talents.TryGetProperty("level13", out JsonElement level13Element))
                    AddTierTalents(hero, level13Element, TalentTiers.Level13);
                if (talents.TryGetProperty("level16", out JsonElement level16Element))
                    AddTierTalents(hero, level16Element, TalentTiers.Level16);
                if (talents.TryGetProperty("level20", out JsonElement level20Element))
                    AddTierTalents(hero, level20Element, TalentTiers.Level20);
            }

            if (includeHeroUnits && heroElement.TryGetProperty("heroUnits", out JsonElement heroUnits))
            {
                foreach (JsonElement heroUnitArrayElement in heroUnits.EnumerateArray())
                {
                    foreach (JsonProperty heroUnitProperty in heroUnitArrayElement.EnumerateObject())
                    {
                        hero.HeroUnits.Add(GetHeroData(heroUnitProperty.Name, heroUnitProperty.Value, true, true, true, true));
                    }
                }
            }

            GameStringDocument?.UpdateGameStrings(hero);

            return hero;
        }

        private void AddTierTalents(Hero hero, JsonElement tierElement, TalentTiers talentTiers)
        {
            foreach (JsonElement element in tierElement.EnumerateArray())
            {
                Talent talent = new Talent
                {
                    Tier = talentTiers,
                };

                SetAbilityTalentBase(talent, element);

                if (element.TryGetProperty("sort", out JsonElement sort))
                    talent.Column = sort.GetInt32();

                if (element.TryGetProperty("abilityTalentLinkIds", out JsonElement abilityTalentLinkIds))
                {
                    foreach (JsonElement abilityTalentLinkIdElement in abilityTalentLinkIds.EnumerateArray())
                        talent.AbilityTalentLinkIds.Add(abilityTalentLinkIdElement.GetString());
                }

                if (element.TryGetProperty("prerequisiteTalentIds", out JsonElement prerequisiteTalentIds))
                {
                    foreach (JsonElement prerequisiteTalentIdElement in prerequisiteTalentIds.EnumerateArray())
                        talent.PrerequisiteTalentIds.Add(prerequisiteTalentIdElement.GetString());
                }

                hero.AddTalent(talent);
            }
        }

        private bool PropertyLookup(string propertyId, string? propertyValue, [NotNullWhen(true)] out Hero? value, bool abilities, bool subAbilities, bool talents, bool heroUnits)
        {
            value = null;

            if (propertyValue is null)
                return false;

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
