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
    /// Provides access to obtain <see cref="Mount"/> data as well as updating localized strings.
    /// </summary>
    public class MountDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected MountDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected MountDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected MountDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected MountDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected MountDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected MountDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected MountDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MountDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected MountDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(string jsonDataFilePath)
        {
            return new MountDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new MountDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new MountDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new MountDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new MountDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new MountDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new MountDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static MountDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new MountDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static Task<MountDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new MountDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<MountDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static Task<MountDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new MountDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<MountDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Mount"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>A <see cref="MountDataDocument"/> representation of the JSON value.</returns>
        public static Task<MountDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new MountDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<MountDataDocument>();
        }

        /// <summary>
        /// Gets a <see cref="Mount"/> from the mount <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">A mount id property value.</param>
        /// <returns>A <see cref="Mount"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public Mount GetMountById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetMountById(id, out Mount? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a mount with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">A mount id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Mount"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        public bool TryGetMountById(string id, [NotNullWhen(true)] out Mount? value)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            value = null;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetMountData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a <see cref="Mount"/> from the hero skin <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A mount hyperlinkId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>A <see cref="Mount"/> object.</returns>
        public Mount GetMountByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetMountByHyperlinkId(hyperlinkId, out Mount? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a mount with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">A mount hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Mount"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetMountByHyperlinkId(string hyperlinkId, [NotNullWhen(true)] out Mount? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetMountData, out value);

        /// <summary>
        /// Gets a <see cref="Mount"/> from the hero skin <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">A mount attributeId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="attributeId"/> property value was not found.</exception>
        /// <returns>A <see cref="Mount"/> object.</returns>
        public Mount GetMountByAttributeId(string attributeId)
        {
            if (attributeId is null)
                throw new ArgumentNullException(nameof(attributeId));

            if (TryGetMountByAttributeId(attributeId, out Mount? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a mount with the <paramref name="attributeId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="attributeId">A mount attributeId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Mount"/> associated with the <paramref name="attributeId"/> property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetMountByAttributeId(string attributeId, [NotNullWhen(true)] out Mount? value)
            => PropertyLookup("attributeId", attributeId, GetMountData, out value);

        private Mount GetMountData(string mountId, JsonElement mountElement)
        {
            Mount mount = new Mount()
            {
                Id = mountId,
            };

            if (mountElement.TryGetProperty("name", out JsonElement name))
                mount.Name = name.GetString();

            if (mountElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                mount.HyperlinkId = hyperlinkId.GetString();

            if (mountElement.TryGetProperty("attributeId", out JsonElement attributeId))
                mount.AttributeId = attributeId.GetString();

            if (mountElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
                mount.Rarity = rarity;

            if (mountElement.TryGetProperty("type", out JsonElement typeId))
                mount.MountCategory = typeId.GetString();

            if (mountElement.TryGetProperty("category", out JsonElement category))
                mount.CollectionCategory = category.GetString();

            if (mountElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
                mount.ReleaseDate = releaseDate;

            if (mountElement.TryGetProperty("sortName", out JsonElement sortName))
                mount.SortName = sortName.GetString();

            if (mountElement.TryGetProperty("searchText", out JsonElement searchText))
                mount.SearchText = searchText.GetString();

            if (mountElement.TryGetProperty("infoText", out JsonElement infoText))
                mount.InfoText = new TooltipDescription(infoText.GetString(), Localization);

            GameStringDocument?.UpdateGameStrings(mount);

            return mount;
        }
    }
}
