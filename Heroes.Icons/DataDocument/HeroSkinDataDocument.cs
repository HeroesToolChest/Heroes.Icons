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
    /// Provides access to obtain <see cref="HeroSkin"/> data as well as updating localized strings.
    /// </summary>
    public class HeroSkinDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected HeroSkinDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected HeroSkinDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected HeroSkinDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected HeroSkinDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected HeroSkinDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected HeroSkinDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected HeroSkinDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroSkinDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected HeroSkinDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(string jsonDataFilePath)
        {
            return new HeroSkinDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new HeroSkinDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new HeroSkinDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new HeroSkinDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new HeroSkinDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new HeroSkinDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new HeroSkinDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static HeroSkinDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new HeroSkinDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static Task<HeroSkinDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new HeroSkinDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<HeroSkinDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static Task<HeroSkinDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new HeroSkinDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<HeroSkinDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="HeroSkin"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="HeroSkinDataDocument"/> representation of the JSON value.</returns>
        public static Task<HeroSkinDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new HeroSkinDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<HeroSkinDataDocument>();
        }

        /// <summary>
        /// Gets a <see cref="HeroSkin"/> from the hero skin <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">A hero skin id property value.</param>
        /// <returns>An <see cref="HeroSkin"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public HeroSkin GetHeroSkinById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetHeroSkinById(id, out HeroSkin? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero skin with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">A hero skin id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="HeroSkin"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroSkinById(string? id, [NotNullWhen(true)] out HeroSkin? value)
        {
            value = null;

            if (id is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetHeroSkinData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a <see cref="HeroSkin"/> from the hero skin <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A hero skin hyperlinkId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>A <see cref="HeroSkin"/> object.</returns>
        public HeroSkin GetHeroSkinByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetHeroSkinByHyperlinkId(hyperlinkId, out HeroSkin? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero skin with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">A hero skin hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="HeroSkin"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroSkinByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out HeroSkin? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetHeroSkinData, out value);

        /// <summary>
        /// Gets a <see cref="HeroSkin"/> from the hero skin <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">A hero skin attributeId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="attributeId"/> property value was not found.</exception>
        /// <returns>A <see cref="HeroSkin"/> object.</returns>
        public HeroSkin GetHeroSkinByAttributeId(string attributeId)
        {
            if (attributeId is null)
                throw new ArgumentNullException(nameof(attributeId));

            if (TryGetHeroSkinByAttributeId(attributeId, out HeroSkin? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a hero skin with the <paramref name="attributeId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="attributeId">A hero skin attributeId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="HeroSkin"/> associated with the <paramref name="attributeId"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetHeroSkinByAttributeId(string? attributeId, [NotNullWhen(true)] out HeroSkin? value)
            => PropertyLookup("attributeId", attributeId, GetHeroSkinData, out value);

        private HeroSkin GetHeroSkinData(string heroSkinId, JsonElement heroSkinElement)
        {
            HeroSkin heroSkin = new HeroSkin()
            {
                Id = heroSkinId,
            };

            if (heroSkinElement.TryGetProperty("name", out JsonElement name))
                heroSkin.Name = name.GetString();

            if (heroSkinElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                heroSkin.HyperlinkId = hyperlinkId.GetString();

            if (heroSkinElement.TryGetProperty("attributeId", out JsonElement attributeId))
                heroSkin.AttributeId = attributeId.GetString();

            if (heroSkinElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
                heroSkin.Rarity = rarity;

            if (heroSkinElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
                heroSkin.ReleaseDate = releaseDate;

            if (heroSkinElement.TryGetProperty("sortName", out JsonElement sortName))
                heroSkin.SortName = sortName.GetString();

            if (heroSkinElement.TryGetProperty("searchText", out JsonElement searchText))
                heroSkin.SearchText = searchText.GetString();

            if (heroSkinElement.TryGetProperty("infoText", out JsonElement infoText))
                heroSkin.InfoText = SetTooltipDescription(infoText.GetString(), Localization);

            if (heroSkinElement.TryGetProperty("features", out JsonElement featuresElement))
            {
                foreach (JsonElement featureElement in featuresElement.EnumerateArray())
                {
                    string? featureValue = featureElement.GetString();
                    if (featureValue is not null)
                        heroSkin.Features.Add(featureValue);
                }
            }

            GameStringDocument?.UpdateGameStrings(heroSkin);

            return heroSkin;
        }
    }
}
