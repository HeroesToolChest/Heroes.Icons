namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="Announcer"/> data as well as updating localized strings.
/// </summary>
public class AnnouncerDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected AnnouncerDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected AnnouncerDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected AnnouncerDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected AnnouncerDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
        : base(jsonDataFilePath, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected AnnouncerDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        : base(jsonData, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected AnnouncerDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected AnnouncerDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        : base(utf8Json, gameStringDocument, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnnouncerDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected AnnouncerDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        : base(utf8Json, utf8JsonGameStrings, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static AnnouncerDataDocument Parse(string jsonDataFilePath)
    {
        return new AnnouncerDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static AnnouncerDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new AnnouncerDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static AnnouncerDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new AnnouncerDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static AnnouncerDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
    {
        return new AnnouncerDataDocument(jsonDataFilePath, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static AnnouncerDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
    {
        return new AnnouncerDataDocument(jsonData, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static AnnouncerDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new AnnouncerDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static AnnouncerDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new AnnouncerDataDocument(utf8Json, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static AnnouncerDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new AnnouncerDataDocument(utf8Json, utf8JsonGameStrings);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<AnnouncerDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new AnnouncerDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<AnnouncerDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<AnnouncerDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new AnnouncerDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<AnnouncerDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Announcer"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>An <see cref="AnnouncerDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static Task<AnnouncerDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new AnnouncerDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<AnnouncerDataDocument>();
    }

    /// <summary>
    /// Gets an <see cref="Announcer"/> from the announcer <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">An announcer id property value.</param>
    /// <returns>An <see cref="Announcer"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
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
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetAnnouncerById(string? id, [NotNullWhen(true)] out Announcer? value)
    {
        value = null;

        if (id is null)
            return false;

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
    /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
    /// <returns>An <see cref="Announcer"/> object.</returns>
    public Announcer GetAnnouncerByHyperlinkId(string hyperlinkId)
    {
        if (hyperlinkId is null)
            throw new ArgumentNullException(nameof(hyperlinkId));

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
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetAnnouncerByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out Announcer? value)
        => PropertyLookup("hyperlinkId", hyperlinkId, GetAnnouncerData, out value);

    /// <summary>
    /// Gets an <see cref="Announcer"/> from the announcer <paramref name="attributeId"/> property value.
    /// </summary>
    /// <param name="attributeId">An announcer attributeId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="attributeId"/> property value was not found.</exception>
    /// <returns>An <see cref="Announcer"/> object.</returns>
    public Announcer GetAnnouncerByAttributeId(string attributeId)
    {
        if (attributeId is null)
            throw new ArgumentNullException(nameof(attributeId));

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
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetAnnouncerByAttributeId(string? attributeId, [NotNullWhen(true)] out Announcer? value)
        => PropertyLookup("attributeId", attributeId, GetAnnouncerData, out value);

    /// <summary>
    /// Gets an <see cref="Announcer"/> from the announcer <paramref name="heroId"/> property value.
    /// </summary>
    /// <param name="heroId">An announcer heroId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="heroId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="heroId"/> property value was not found.</exception>
    /// <returns>An <see cref="Announcer"/> object.</returns>
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
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetAnnouncerByHeroId(string? heroId, [NotNullWhen(true)] out Announcer? value)
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
            announcer.Description = SetTooltipDescription(description.GetString(), Localization);

        if (announcerElement.TryGetProperty("image", out JsonElement image))
            announcer.ImageFileName = image.GetString();

        GameStringDocument?.UpdateGameStrings(announcer);

        return announcer;
    }
}
