using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Heroes.Icons.DataReader
{
    /// <summary>
    /// Provides access to obtain announcer data as well as updating localized strings.
    /// </summary>
    public class AnnouncerDataReader : DataReader, IDataReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataReader"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing announcer data.</param>
        public AnnouncerDataReader(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataReader"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing announcer data.</param>
        /// <param name="localization">The localization of the file.</param>
        public AnnouncerDataReader(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataReader"/> class.
        /// </summary>
        /// <param name="jsonData">JSON data containing the announcer data.</param>
        /// <param name="localization">The localization of the file.</param>
        public AnnouncerDataReader(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataReader"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing announcer data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public AnnouncerDataReader(string jsonDataFilePath, GameStringReader gameStringReader)
            : base(jsonDataFilePath, gameStringReader)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncerDataReader"/> class.
        /// </summary>
        /// <param name="jsonData">JSON data containing the announcer data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public AnnouncerDataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : base(jsonData, gameStringReader)
        {
        }

        /// <summary>
        /// Gets an <see cref="Announcer"/> from the given announcer <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Announcer id to find.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        public Announcer GetAnnouncerById(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (TryGetAnnouncerById(id, out Announcer? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for an announcer with the given <paramref name="id"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">Announcer id to find.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException" />
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
        /// Gets an <see cref="Announcer"/> from the given announcer <paramref name="hyperlinkId"/>.
        /// </summary>
        /// <param name="hyperlinkId">Announcer hyperlinkId to find.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
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
        /// Looks for an announcer with the given <paramref name="hyperlinkId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">Announcer hyperlinkId to find.</param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
        public bool TryGetAnnouncerByHyperlinkId(string hyperlinkId, [NotNullWhen(true)] out Announcer? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetAnnouncerData, out value);

        /// <summary>
        /// Gets an <see cref="Announcer"/> from the given announcer <paramref name="attributeId"/>.
        /// </summary>
        /// <param name="attributeId">Announcer attributeId to find.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
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
        /// Looks for an announcer with the given <paramref name="attributeId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="attributeId">Announcer attributeId to find.</param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
        public bool TryGetAnnouncerByAttributeId(string attributeId, [NotNullWhen(true)] out Announcer? value)
            => PropertyLookup("attributeId", attributeId, GetAnnouncerData, out value);

        /// <summary>
        /// Gets an <see cref="Announcer"/> from the given announcer <paramref name="heroId"/>.
        /// </summary>
        /// <param name="heroId">Announcer heroId to find.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
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
        /// Looks for an announcer with the given <paramref name="heroId"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="heroId">Announcer heroId to find.</param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException" />
        /// <returns></returns>
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

            return announcer;
        }
    }
}
