using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.DataReader
{
    /// <summary>
    /// Provides access to obtain announcer data as well as updating localized strings.
    /// </summary>
    public class AnnouncerDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
        /// <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing announcer data.</param>
        protected AnnouncerDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing announcer data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected AnnouncerDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the announcer data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected AnnouncerDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing announcer data.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected AnnouncerDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the announcer data.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected AnnouncerDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data containing the data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as async.</param>
        protected AnnouncerDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing announcer data.</param>
        /// <returns>an <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
        public static AnnouncerDataDocument Parse(string jsonDataFilePath)
        {
            return new AnnouncerDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing announcer data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>an <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
        public static AnnouncerDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new AnnouncerDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the announcer data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>an <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
        public static AnnouncerDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new AnnouncerDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing announcer data.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>an <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
        public static AnnouncerDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new AnnouncerDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the announcer data.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>an <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
        public static AnnouncerDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new AnnouncerDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data containing the data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>an <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
        public static AnnouncerDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new AnnouncerDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data containing the data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>an <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
        public static Task<AnnouncerDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new AnnouncerDataDocument(utf8Json, localization, true).InitializeParseAsync<AnnouncerDataDocument>();
        }

        /// <summary>
        /// Gets an <see cref="Announcer"/> from the announcer <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">An announcer id property value.</param>
        /// <returns>an <see cref="Announcer"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public Announcer GetAnnouncerById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetAnnouncerById(id, out Announcer? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an announcer with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">An announcer id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Announcer"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns>true if the value was found; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        public bool TryGetAnnouncerById(string id, [NotNullWhen(true)] out Announcer? value)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            value = null;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetAnnouncerData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets an <see cref="Announcer"/> from the announcer <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">An announcer hyperlinkId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is null.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>an <see cref="Announcer"/> object.</returns>
        public Announcer GetAnnouncerByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
            {
                throw new ArgumentNullException(nameof(hyperlinkId));
            }

            if (TryGetAnnouncerByHyperlinkId(hyperlinkId, out Announcer? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an announcer with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">An announcer hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Announcer"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is null.</exception>
        /// <returns>true if the value was found; otherwise false.</returns>
        public bool TryGetAnnouncerByHyperlinkId(string hyperlinkId, [NotNullWhen(true)] out Announcer? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetAnnouncerData, out value);

        /// <summary>
        /// Gets an <see cref="Announcer"/> from the announcer <paramref name="attributeId"/> property value.
        /// </summary>
        /// <param name="attributeId">An announcer attributeId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is null.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="attributeId"/> property value was not found.</exception>
        /// <returns>an <see cref="Announcer"/> object.</returns>
        public Announcer GetAnnouncerByAttributeId(string attributeId)
        {
            if (attributeId is null)
            {
                throw new ArgumentNullException(nameof(attributeId));
            }

            if (TryGetAnnouncerByAttributeId(attributeId, out Announcer? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an announcer with the <paramref name="attributeId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="attributeId">An announcer attributeId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Announcer"/> associated with the <paramref name="attributeId"/> property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is null.</exception>
        /// <returns>true if the value was found; otherwise false.</returns>
        public bool TryGetAnnouncerByAttributeId(string attributeId, [NotNullWhen(true)] out Announcer? value)
            => PropertyLookup("attributeId", attributeId, GetAnnouncerData, out value);

        /// <summary>
        /// Gets an <see cref="Announcer"/> from the announcer <paramref name="heroId"/> property value.
        /// </summary>
        /// <param name="heroId">An announcer heroId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="heroId"/> is null.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="heroId"/> property value was not found.</exception>
        /// <returns>an <see cref="Announcer"/> object.</returns>
        public Announcer GetAnnouncerByHeroId(string heroId)
        {
            if (heroId is null)
            {
                throw new ArgumentNullException(nameof(heroId));
            }

            if (TryGetAnnouncerByHeroId(heroId, out Announcer? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an announcer with the <paramref name="heroId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="heroId">An announcer heroId property value to find.</param>
        /// <param name="value">When this method returns, contains the <see cref="Announcer"/> associated with the <paramref name="heroId"/> property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="heroId"/> is null.</exception>
        /// <returns>true if the value was found; otherwise false.</returns>
        public bool TryGetAnnouncerByHeroId(string heroId, [NotNullWhen(true)] out Announcer? value)
            => PropertyLookup("heroId", heroId, GetAnnouncerData, out value);

        private Announcer GetAnnouncerData(string announcerId, JsonElement announcerElement)
        {
            Announcer announcer = new Announcer()
            {
                Id = announcerId,
            };

            if (announcerElement.TryGetProperty("name", out JsonElement name))
                announcer.Name = name.GetString();

            if (announcerElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                announcer.HyperlinkId = hyperlinkId.GetString();

            if (announcerElement.TryGetProperty("attributeId", out JsonElement attributeId))
                announcer.AttributeId = attributeId.GetString();

            if (announcerElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
                announcer.Rarity = rarity;

            if (announcerElement.TryGetProperty("category", out JsonElement category))
                announcer.CollectionCategory = category.GetString();

            if (announcerElement.TryGetProperty("gender", out JsonElement gender))
                announcer.Gender = gender.GetString();

            if (announcerElement.TryGetProperty("heroId", out JsonElement heroId))
                announcer.HeroId = heroId.GetString();

            if (announcerElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
                announcer.ReleaseDate = releaseDate;

            if (announcerElement.TryGetProperty("sortName", out JsonElement sortName))
                announcer.SortName = sortName.GetString();

            if (announcerElement.TryGetProperty("description", out JsonElement description))
                announcer.Description = new TooltipDescription(description.GetString(), Localization);

            if (announcerElement.TryGetProperty("image", out JsonElement image))
                announcer.ImageFileName = image.GetString();

            GameStringDocument?.UpdateGameStrings(announcer);

            return announcer;
        }
    }
}
