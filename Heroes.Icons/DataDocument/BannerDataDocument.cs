namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="Banner"/> data as well as updating localized strings.
/// </summary>
public class BannerDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected BannerDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected BannerDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected BannerDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected BannerDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
        : base(jsonDataFilePath, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected BannerDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        : base(jsonData, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected BannerDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected BannerDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        : base(utf8Json, gameStringDocument, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BannerDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected BannerDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        : base(utf8Json, utf8JsonGameStrings, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static BannerDataDocument Parse(string jsonDataFilePath)
    {
        return new BannerDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static BannerDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new BannerDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static BannerDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new BannerDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static BannerDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
    {
        return new BannerDataDocument(jsonDataFilePath, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static BannerDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
    {
        return new BannerDataDocument(jsonData, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static BannerDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new BannerDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static BannerDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new BannerDataDocument(utf8Json, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static BannerDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new BannerDataDocument(utf8Json, utf8JsonGameStrings);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<BannerDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new BannerDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<BannerDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<BannerDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new BannerDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<BannerDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Banner"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>A <see cref="BannerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static Task<BannerDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new BannerDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<BannerDataDocument>();
    }

    /// <summary>
    /// Gets a <see cref="Banner"/> from the banner <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">A banner id property value.</param>
    /// <returns>A <see cref="Banner"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
    public Banner GetBannerById(string id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        if (TryGetBannerById(id, out Banner? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a banner with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="id">A banner id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="Banner"/> associated with the <paramref name="id"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetBannerById(string? id, [NotNullWhen(true)] out Banner? value)
    {
        value = null;

        if (id is null)
            return false;

        if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
        {
            value = GetBannerData(id, element);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets a <see cref="Banner"/> from the banner <paramref name="hyperlinkId"/> property value.
    /// </summary>
    /// <param name="hyperlinkId">A banner hyperlinkId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
    /// <returns>A <see cref="Banner"/> object.</returns>
    public Banner GetBannerByHyperlinkId(string hyperlinkId)
    {
        ArgumentNullException.ThrowIfNull(hyperlinkId, nameof(hyperlinkId));

        if (TryGetBannerByHyperlinkId(hyperlinkId, out Banner? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a banner with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="hyperlinkId">A banner hyperlinkId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="Banner"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetBannerByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out Banner? value)
        => PropertyLookup("hyperlinkId", hyperlinkId, GetBannerData, out value);

    /// <summary>
    /// Gets a <see cref="Banner"/> from the banner <paramref name="attributeId"/> property value.
    /// </summary>
    /// <param name="attributeId">A banner attributeId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="attributeId"/> property value was not found.</exception>
    /// <returns>A <see cref="Banner"/> object.</returns>
    public Banner GetBannerByAttributeId(string attributeId)
    {
        ArgumentNullException.ThrowIfNull(attributeId, nameof(attributeId));

        if (TryGetBannerByAttributeId(attributeId, out Banner? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a banner with the <paramref name="attributeId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="attributeId">A banner attributeId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="Banner"/> associated with the <paramref name="attributeId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetBannerByAttributeId(string? attributeId, [NotNullWhen(true)] out Banner? value)
        => PropertyLookup("attributeId", attributeId, GetBannerData, out value);

    private Banner GetBannerData(string bannerId, JsonElement bannerElement)
    {
        Banner banner = new()
        {
            Id = bannerId,
        };

        if (bannerElement.TryGetProperty("name", out JsonElement name))
            banner.Name = name.GetString();

        if (bannerElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
            banner.HyperlinkId = hyperlinkId.GetString();

        if (bannerElement.TryGetProperty("attributeId", out JsonElement attributeId))
            banner.AttributeId = attributeId.GetString();

        if (bannerElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
            banner.Rarity = rarity;

        if (bannerElement.TryGetProperty("category", out JsonElement category))
            banner.CollectionCategory = category.GetString();

        if (bannerElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
            banner.ReleaseDate = releaseDate;

        if (bannerElement.TryGetProperty("sortName", out JsonElement sortName))
            banner.SortName = sortName.GetString();

        if (bannerElement.TryGetProperty("description", out JsonElement description))
            banner.Description = SetTooltipDescription(description.GetString(), Localization);

        GameStringDocument?.UpdateGameStrings(banner);

        return banner;
    }
}
