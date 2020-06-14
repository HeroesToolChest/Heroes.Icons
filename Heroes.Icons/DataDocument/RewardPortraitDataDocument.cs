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
    /// Provides access to obtain <see cref="RewardPortrait"/> data as well as updating localized strings.
    /// </summary>
    public class RewardPortraitDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected RewardPortraitDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected RewardPortraitDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected RewardPortraitDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected RewardPortraitDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected RewardPortraitDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected RewardPortraitDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected RewardPortraitDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RewardPortraitDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected RewardPortraitDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(string jsonDataFilePath)
        {
            return new RewardPortraitDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new RewardPortraitDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new RewardPortraitDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new RewardPortraitDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new RewardPortraitDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new RewardPortraitDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new RewardPortraitDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static RewardPortraitDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new RewardPortraitDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static Task<RewardPortraitDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new RewardPortraitDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<RewardPortraitDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static Task<RewardPortraitDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new RewardPortraitDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<RewardPortraitDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="RewardPortrait"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="RewardPortraitDataDocument"/> representation of the JSON value.</returns>
        public static Task<RewardPortraitDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new RewardPortraitDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<RewardPortraitDataDocument>();
        }

        /// <summary>
        /// Gets a <see cref="RewardPortrait"/> from the reward portrait <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">A reward portrait id property value.</param>
        /// <returns>A <see cref="RewardPortrait"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public RewardPortrait GetRewardPortraitById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetRewardPortraitById(id, out RewardPortrait? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a reward portrait with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">A reward portrait id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="RewardPortrait"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetRewardPortraitById(string? id, [NotNullWhen(true)] out RewardPortrait? value)
        {
            value = null;

            if (id is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetRewardPortraitData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a <see cref="RewardPortrait"/> from the reward portrait <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A reward portrait hyperlinkId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>A <see cref="RewardPortrait"/> object.</returns>
        public RewardPortrait GetRewardPortraitByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetRewardPortraitByHyperlinkId(hyperlinkId, out RewardPortrait? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a reward portrait with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">A reward portrait hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="RewardPortrait"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetRewardPortraitByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out RewardPortrait? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetRewardPortraitData, out value);

        private RewardPortrait GetRewardPortraitData(string rewardPortraitId, JsonElement rewardPortraitElement)
        {
            RewardPortrait rewardPortrait = new RewardPortrait()
            {
                Id = rewardPortraitId,
            };

            if (rewardPortraitElement.TryGetProperty("name", out JsonElement name))
                rewardPortrait.Name = name.GetString();

            if (rewardPortraitElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                rewardPortrait.HyperlinkId = hyperlinkId.GetString();

            if (rewardPortraitElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
                rewardPortrait.Rarity = rarity;

            if (rewardPortraitElement.TryGetProperty("category", out JsonElement eventElement))
                rewardPortrait.CollectionCategory = eventElement.GetString();

            if (rewardPortraitElement.TryGetProperty("description", out JsonElement description))
                rewardPortrait.Description = new TooltipDescription(description.GetString(), Localization);

            if (rewardPortraitElement.TryGetProperty("descriptionUnearned", out JsonElement descriptionUnearned))
                rewardPortrait.DescriptionUnearned = new TooltipDescription(descriptionUnearned.GetString(), Localization);

            if (rewardPortraitElement.TryGetProperty("heroId", out JsonElement heroIdElement))
                rewardPortrait.HeroId = heroIdElement.GetString();

            if (rewardPortraitElement.TryGetProperty("portraitPackId", out JsonElement portraitPack))
                rewardPortrait.PortraitPackId = portraitPack.GetString();

            if (rewardPortraitElement.TryGetProperty("iconSlot", out JsonElement iconSlot))
                rewardPortrait.IconSlot = iconSlot.GetInt32();

            if (rewardPortraitElement.TryGetProperty("textureSheet", out JsonElement textureSheetElement))
            {
                if (textureSheetElement.TryGetProperty("image", out JsonElement image))
                    rewardPortrait.TextureSheet.Image = image.GetString();

                if (textureSheetElement.TryGetProperty("columns", out JsonElement columns))
                    rewardPortrait.TextureSheet.Columns = columns.GetInt32();

                if (textureSheetElement.TryGetProperty("rows", out JsonElement rows))
                    rewardPortrait.TextureSheet.Rows = rows.GetInt32();
            }

            GameStringDocument?.UpdateGameStrings(rewardPortrait);

            return rewardPortrait;
        }
    }
}
