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
    /// Provides access to obtain <see cref="MatchAward"/> data as well as updating localized strings.
    /// </summary>
    public class MatchAwardDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected MatchAwardDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected MatchAwardDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected MatchAwardDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected MatchAwardDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected MatchAwardDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected MatchAwardDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected MatchAwardDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAwardDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected MatchAwardDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static MatchAwardDataDocument Parse(string jsonDataFilePath)
        {
            return new MatchAwardDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static MatchAwardDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new MatchAwardDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
        public static MatchAwardDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new MatchAwardDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static MatchAwardDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new MatchAwardDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
        public static MatchAwardDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new MatchAwardDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static MatchAwardDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new MatchAwardDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static MatchAwardDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new MatchAwardDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
        public static MatchAwardDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new MatchAwardDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static Task<MatchAwardDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new MatchAwardDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<MatchAwardDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static Task<MatchAwardDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new MatchAwardDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<MatchAwardDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="MatchAward"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="MatchAwardDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
        public static Task<MatchAwardDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new MatchAwardDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<MatchAwardDataDocument>();
        }

        /// <summary>
        /// Gets a <see cref="MatchAward"/> from the match award <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">A match award id property value.</param>
        /// <returns>A <see cref="MatchAward"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public MatchAward GetMatchAwardById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetMatchAwardById(id, out MatchAward? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a match award with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">A match award id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="MatchAward"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetMatchAwardById(string? id, [NotNullWhen(true)] out MatchAward? value)
        {
            value = null;

            if (id is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetMatchAwardData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a <see cref="MatchAward"/> from the match award <paramref name="gameLink"/> property value.
        /// The <paramref name="gameLink"/> is also known as the hyperlinkId.
        /// </summary>
        /// <param name="gameLink">A match award gameLink property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameLink"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="gameLink"/> property value was not found.</exception>
        /// <returns>A <see cref="MatchAward"/> object.</returns>
        public MatchAward GetMatchAwardByGameLinkId(string gameLink)
        {
            if (gameLink is null)
                throw new ArgumentNullException(nameof(gameLink));

            if (TryGetMatchAwardByGameLinkId(gameLink, out MatchAward? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a match award with the <paramref name="gameLink"/> property value, returning a value that indicates whether such value exists.
        /// The <paramref name="gameLink"/> is also known as the hyperlinkId.
        /// </summary>
        /// <param name="gameLink">A match award gameLink property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="MatchAward"/> associated with the <paramref name="gameLink"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetMatchAwardByGameLinkId(string? gameLink, [NotNullWhen(true)] out MatchAward? value)
            => PropertyLookup("gameLink", gameLink, GetMatchAwardData, out value);

        /// <summary>
        /// Gets a <see cref="MatchAward"/> from the match award <paramref name="tag"/> property value.
        /// </summary>
        /// <param name="tag">A match award tag property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="tag"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="tag"/> property value was not found.</exception>
        /// <returns>A <see cref="MatchAward"/> object.</returns>
        public MatchAward GetMatchAwardByTag(string tag)
        {
            if (tag is null)
                throw new ArgumentNullException(nameof(tag));

            if (TryGetMatchAwardByTag(tag, out MatchAward? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a match award with the <paramref name="tag"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="tag">A match award tag property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="MatchAward"/> associated with the <paramref name="tag"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetMatchAwardByTag(string? tag, [NotNullWhen(true)] out MatchAward? value)
            => PropertyLookup("tag", tag, GetMatchAwardData, out value);

        private MatchAward GetMatchAwardData(string matchAwardId, JsonElement matchAwardElement)
        {
            MatchAward matchAward = new MatchAward()
            {
                Id = matchAwardId,
            };

            if (matchAwardElement.TryGetProperty("name", out JsonElement name))
                matchAward.Name = name.GetString();

            if (matchAwardElement.TryGetProperty("gameLink", out JsonElement gameLink))
                matchAward.HyperlinkId = gameLink.GetString();

            if (matchAwardElement.TryGetProperty("tag", out JsonElement tag))
                matchAward.Tag = tag.GetString();

            if (matchAwardElement.TryGetProperty("mvpScreenIcon", out JsonElement mvpScreenIcon))
                matchAward.MVPScreenImageFileName = mvpScreenIcon.GetString();

            if (matchAwardElement.TryGetProperty("scoreScreenIcon", out JsonElement scoreScreenIcon))
                matchAward.ScoreScreenImageFileName = scoreScreenIcon.GetString();

            if (matchAwardElement.TryGetProperty("description", out JsonElement description))
                matchAward.Description = SetTooltipDescription(description.GetString(), Localization);

            GameStringDocument?.UpdateGameStrings(matchAward);

            return matchAward;
        }
    }
}
