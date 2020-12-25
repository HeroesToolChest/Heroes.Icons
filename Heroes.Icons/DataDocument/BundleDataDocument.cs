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
    /// Provides access to obtain <see cref="Bundle"/> data as well as updating localized strings.
    /// </summary>
    public class BundleDataDocument : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        protected BundleDataDocument(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected BundleDataDocument(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected BundleDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected BundleDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : base(jsonDataFilePath, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        protected BundleDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : base(jsonData, gameStringDocument)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected BundleDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected BundleDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
            : base(utf8Json, gameStringDocument, isAsync)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleDataDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected BundleDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
            : base(utf8Json, utf8JsonGameStrings, isAsync)
        {
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static BundleDataDocument Parse(string jsonDataFilePath)
        {
            return new BundleDataDocument(jsonDataFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static BundleDataDocument Parse(string jsonDataFilePath, Localization localization)
        {
            return new BundleDataDocument(jsonDataFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
        public static BundleDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            return new BundleDataDocument(jsonData, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
        /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
        public static BundleDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
        {
            return new BundleDataDocument(jsonDataFilePath, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
        public static BundleDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        {
            return new BundleDataDocument(jsonData, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static BundleDataDocument Parse(Stream utf8Json, Localization localization)
        {
            return new BundleDataDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static BundleDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new BundleDataDocument(utf8Json, gameStringDocument);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
        public static BundleDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new BundleDataDocument(utf8Json, utf8JsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static Task<BundleDataDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new BundleDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<BundleDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
        public static Task<BundleDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
        {
            return new BundleDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<BundleDataDocument>();
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for <see cref="Bundle"/> data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <returns>An <see cref="BundleDataDocument"/> representation of the JSON value.</returns>
        /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
        public static Task<BundleDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
        {
            return new BundleDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<BundleDataDocument>();
        }

        /// <summary>
        /// Gets a <see cref="Bundle"/> from the bundle <paramref name="id"/> property value.
        /// </summary>
        /// <param name="id">An bundle id property value.</param>
        /// <returns>An <see cref="Bundle"/> object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
        public Bundle GetBundleById(string id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            if (TryGetBundleById(id, out Bundle? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a bundle with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">A bundle id property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Bundle"/> associated with the <paramref name="id"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetBundleById(string? id, [NotNullWhen(true)] out Bundle? value)
        {
            value = null;

            if (id is null)
                return false;

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetBundleData(id, element);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets an <see cref="Bundle"/> from the bundle <paramref name="hyperlinkId"/> property value.
        /// </summary>
        /// <param name="hyperlinkId">A bundle hyperlinkId property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
        /// <returns>A <see cref="Bundle"/> object.</returns>
        public Bundle GetBundleByHyperlinkId(string hyperlinkId)
        {
            if (hyperlinkId is null)
                throw new ArgumentNullException(nameof(hyperlinkId));

            if (TryGetBundleByHyperlinkId(hyperlinkId, out Bundle? value))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a bundle with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="hyperlinkId">A bundle hyperlinkId property value.</param>
        /// <param name="value">When this method returns, contains the <see cref="Bundle"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        public bool TryGetBundleByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out Bundle? value)
            => PropertyLookup("hyperlinkId", hyperlinkId, GetBundleData, out value);

        private Bundle GetBundleData(string bundleId, JsonElement bundleElement)
        {
            Bundle bundle = new Bundle()
            {
                Id = bundleId,
            };

            if (bundleElement.TryGetProperty("name", out JsonElement name))
                bundle.Name = name.GetString();

            if (bundleElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
                bundle.HyperlinkId = hyperlinkId.GetString();

            if (bundleElement.TryGetProperty("sortName", out JsonElement sortName))
                bundle.SortName = sortName.GetString();

            if (bundleElement.TryGetProperty("franchise", out JsonElement franchiseElement) && Enum.TryParse(franchiseElement.GetString(), out Franchise franchise))
                bundle.Franchise = franchise;
            else
                bundle.Franchise = Franchise.Unknown;

            if (bundleElement.TryGetProperty("event", out JsonElement eventName))
                bundle.EventName = eventName.GetString();

            if (bundleElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
                bundle.ReleaseDate = releaseDate;

            if (bundleElement.TryGetProperty("isDynamicContent", out JsonElement isDynamicContent))
                bundle.IsDynamicContent = isDynamicContent.GetBoolean();

            if (bundleElement.TryGetProperty("heroes", out JsonElement heroesElement))
            {
                foreach (JsonElement heroElement in heroesElement.EnumerateArray())
                {
                    string? heroValue = heroElement.GetString();
                    if (heroValue is not null)
                        bundle.HeroIds.Add(heroValue);
                }
            }

            if (bundleElement.TryGetProperty("skins", out JsonElement skinsElement))
            {
                foreach (JsonElement skinElement in skinsElement.EnumerateArray())
                {
                    foreach (JsonProperty skinProperties in skinElement.EnumerateObject())
                    {
                        string heroId = skinProperties.Name;

                        foreach (JsonElement heroSkinId in skinProperties.Value.EnumerateArray())
                        {
                            string? heroSkinIdValue = heroSkinId.GetString();
                            if (heroSkinIdValue is not null)
                                bundle.AddHeroSkin(skinProperties.Name, heroSkinIdValue);
                        }
                    }
                }
            }

            if (bundleElement.TryGetProperty("mounts", out JsonElement mountsElement))
            {
                foreach (JsonElement element in mountsElement.EnumerateArray())
                {
                    string? value = element.GetString();
                    if (value is not null)
                        bundle.MountIds.Add(value);
                }
            }

            if (bundleElement.TryGetProperty("image", out JsonElement image))
                bundle.ImageFileName = image.GetString();

            if (bundleElement.TryGetProperty("boostId", out JsonElement boostId))
                bundle.BoostBonusId = boostId.GetString();

            if (bundleElement.TryGetProperty("goldBonus", out JsonElement goldBonus))
                bundle.GoldBonus = goldBonus.GetInt32();

            if (bundleElement.TryGetProperty("gemsBonus", out JsonElement gemsBonus))
                bundle.GemsBonus = gemsBonus.GetInt32();

            if (bundleElement.TryGetProperty("lootChestBonus", out JsonElement lootChestBonus))
                bundle.LootChestBonus = lootChestBonus.GetString();

            GameStringDocument?.UpdateGameStrings(bundle);

            return bundle;
        }
    }
}
