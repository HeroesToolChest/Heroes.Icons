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
    /// Provides access to obtain <see cref="Emoticon"/> data as well as updating localized strings.
    /// </summary>
    public class EmoticonDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected EmoticonDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected EmoticonDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected EmoticonDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected EmoticonDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected EmoticonDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected EmoticonDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected EmoticonDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmoticonDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected EmoticonDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(string jsonDataFilePath)
        {
            return new EmoticonDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new EmoticonDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new EmoticonDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new EmoticonDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new EmoticonDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new EmoticonDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new EmoticonDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static EmoticonDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new EmoticonDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static Task<EmoticonDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new EmoticonDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<EmoticonDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static Task<EmoticonDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new EmoticonDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<EmoticonDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Emoticon"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="EmoticonDataDocument"/> representation of the JSON value.</returns>
        public static Task<EmoticonDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new EmoticonDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<EmoticonDataDocument>();
        }

        /// <summary>
        /// Gets an <see cref="Emoticon"/> from the emoticon <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">An emoticon id property value.</param>
        /// <returns>An <see cref="Emoticon"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public Emoticon GetEmoticonById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetEmoticonById(id, out Emoticon? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an emoticon with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">An emoticon id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Emoticon"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        public bool TryGetEmoticonById(string id, [NotNullWhen(true)] out Emoticon? value)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            value = null;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetEmoticonData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets an <see cref="Emoticon"/> from the emoticon <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">An emoticon hyperlinkId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>An <see cref="Emoticon"/> object.</returns>
        public Emoticon GetEmoticonByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetEmoticonByHyperlinkId(hyperlinkId, out Emoticon? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an emoticon with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">An emoticon hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Emoticon"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetEmoticonByHyperlinkId(string hyperlinkId, [NotNullWhen(true)] out Emoticon? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetEmoticonData, out value);

        private Emoticon GetEmoticonData(string emoticonId, JsonElement emoticonElement)
        {
            Emoticon emoticon = new Emoticon()
            {
                Id = emoticonId,
            };

            if (emoticonElement.TryGetProperty("expression", out JsonElement expression))
                emoticon.Name = expression.GetString();

            if (emoticonElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                emoticon.HyperlinkId = hyperlinkId.GetString();

            if (emoticonElement.TryGetProperty("caseSensitive", out JsonElement caseSensitive))
                emoticon.IsAliasCaseSensitive = caseSensitive.GetBoolean();

            if (emoticonElement.TryGetProperty("isHidden", out JsonElement isHidden))
                emoticon.IsHidden = isHidden.GetBoolean();

            if (emoticonElement.TryGetProperty("searchText", out JsonElement searchText))
            {
                string[] values = searchText.GetString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string value in values)
                {
                    emoticon.SearchTexts.Add(value);
                }
            }

            if (emoticonElement.TryGetProperty("description", out JsonElement description))
                emoticon.Description = new TooltipDescription(description.GetString(), Localization);

            if (emoticonElement.TryGetProperty("localizedAliases", out JsonElement localizedAliasesElement))
            {
                foreach (JsonElement localizedAlias in localizedAliasesElement.EnumerateArray())
                {
                    emoticon.LocalizedAliases.Add(localizedAlias.GetString());
                }
            }

            if (emoticonElement.TryGetProperty("aliases", out JsonElement aliasesElement))
            {
                foreach (JsonElement alias in aliasesElement.EnumerateArray())
                {
                    emoticon.UniversalAliases.Add(alias.GetString());
                }
            }

            if (emoticonElement.TryGetProperty("heroId", out JsonElement heroId))
                emoticon.HeroId = heroId.GetString();

            if (emoticonElement.TryGetProperty("heroSkinId", out JsonElement heroSkinId))
                emoticon.HeroSkinId = heroSkinId.GetString();

            if (emoticonElement.TryGetProperty("image", out JsonElement image))
                emoticon.Image.FileName = image.GetString();

            if (emoticonElement.TryGetProperty("animation", out JsonElement animationElement))
            {
                if (animationElement.TryGetProperty("texture", out JsonElement texture))
                    emoticon.TextureSheet.Image = texture.GetString();

                if (animationElement.TryGetProperty("frames", out JsonElement frames))
                    emoticon.Image.Count = frames.GetInt32();

                if (animationElement.TryGetProperty("duration", out JsonElement duration))
                    emoticon.Image.DurationPerFrame = duration.GetInt32();

                if (animationElement.TryGetProperty("width", out JsonElement width))
                    emoticon.Image.Width = width.GetInt32();
            }

            GameStringDocument?.UpdateGameStrings(emoticon);

            return emoticon;
        }
    }
}
