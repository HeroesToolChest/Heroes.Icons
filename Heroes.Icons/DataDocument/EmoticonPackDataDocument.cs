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
    /// Provides access to obtain <see cref="EmoticonPack"/> data as well as updating localized strings.
    /// </summary>
    public class EmoticonPackDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected EmoticonPackDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected EmoticonPackDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected EmoticonPackDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected EmoticonPackDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected EmoticonPackDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected EmoticonPackDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected EmoticonPackDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonPackDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected EmoticonPackDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static EmoticonPackDataDocument Parse(string jsonDataFilePath)
        {
            return new EmoticonPackDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static EmoticonPackDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new EmoticonPackDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
        public static EmoticonPackDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new EmoticonPackDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static EmoticonPackDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new EmoticonPackDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
        public static EmoticonPackDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new EmoticonPackDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static EmoticonPackDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new EmoticonPackDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static EmoticonPackDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new EmoticonPackDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
        public static EmoticonPackDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new EmoticonPackDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static Task<EmoticonPackDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new EmoticonPackDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<EmoticonPackDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static Task<EmoticonPackDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new EmoticonPackDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<EmoticonPackDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="EmoticonPack"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="EmoticonPackDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
        public static Task<EmoticonPackDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new EmoticonPackDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<EmoticonPackDataDocument>();
        }

        /// <summary>
        /// Gets an <see cref="EmoticonPack"/> from the emoticon pack <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">An emoticon pack id property value.</param>
        /// <returns>An <see cref="EmoticonPack"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public EmoticonPack GetEmoticonPackById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetEmoticonPackById(id, out EmoticonPack? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an emoticon pack with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">An emoticon pack id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="EmoticonPack"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetEmoticonPackById(string? id, [NotNullWhen(true)] out EmoticonPack? value)
        {
            value = null;

            if (id is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetEmoticonPackData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets an <see cref="EmoticonPack"/> from the emoticon pack <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">An emoticon pack hyperlinkId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>An <see cref="EmoticonPack"/> object.</returns>
        public EmoticonPack GetEmoticonPackByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetEmoticonPackByHyperlinkId(hyperlinkId, out EmoticonPack? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an emoticon pack with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">An emoticon pack hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="EmoticonPack"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetEmoticonPackByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out EmoticonPack? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetEmoticonPackData, out value);

        private EmoticonPack GetEmoticonPackData(string emoticonPackId, JsonElement emoticonPackElement)
        {
            EmoticonPack emoticonPack = new EmoticonPack()
            {
                Id = emoticonPackId,
            };

            if (emoticonPackElement.TryGetProperty("name", out JsonElement expression))
                emoticonPack.Name = expression.GetString();

            if (emoticonPackElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                emoticonPack.HyperlinkId = hyperlinkId.GetString();

            if (emoticonPackElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
                emoticonPack.Rarity = rarity;

            if (emoticonPackElement.TryGetProperty("category", out JsonElement category))
                emoticonPack.CollectionCategory = category.GetString();

            if (emoticonPackElement.TryGetProperty("event", out JsonElement eventElement))
                emoticonPack.EventName = eventElement.GetString();

            if (emoticonPackElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
                emoticonPack.ReleaseDate = releaseDate;

            if (emoticonPackElement.TryGetProperty("sortName", out JsonElement sortName))
                emoticonPack.SortName = sortName.GetString();

            if (emoticonPackElement.TryGetProperty("description", out JsonElement description))
                emoticonPack.Description = SetTooltipDescription(description.GetString(), Localization);

            if (emoticonPackElement.TryGetProperty("emoticons", out JsonElement emoticons))
            {
                foreach (JsonElement emoticon in emoticons.EnumerateArray())
                {
                    string? emoticonValue = emoticon.GetString();
                    if (emoticonValue is not null)
                        emoticonPack.EmoticonIds.Add(emoticonValue);
                }
            }

            GameStringDocument?.UpdateGameStrings(emoticonPack);

            return emoticonPack;
        }
    }
}
