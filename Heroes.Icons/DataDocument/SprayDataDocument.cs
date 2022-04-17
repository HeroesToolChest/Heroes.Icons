namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="Spray"/> data as well as updating localized strings.
/// </summary>
public class SprayDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected SprayDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected SprayDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected SprayDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected SprayDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
        : base(jsonDataFilePath, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected SprayDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        : base(jsonData, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected SprayDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected SprayDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        : base(utf8Json, gameStringDocument, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SprayDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected SprayDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        : base(utf8Json, utf8JsonGameStrings, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static SprayDataDocument Parse(string jsonDataFilePath)
    {
        return new SprayDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static SprayDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new SprayDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static SprayDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new SprayDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static SprayDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
    {
        return new SprayDataDocument(jsonDataFilePath, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static SprayDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
    {
        return new SprayDataDocument(jsonData, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static SprayDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new SprayDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static SprayDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new SprayDataDocument(utf8Json, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static SprayDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new SprayDataDocument(utf8Json, utf8JsonGameStrings);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<SprayDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new SprayDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<SprayDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<SprayDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new SprayDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<SprayDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="Spray"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>A <see cref="SprayDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static Task<SprayDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new SprayDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<SprayDataDocument>();
    }

    /// <summary>
    /// Gets a <see cref="Spray"/> from the spray <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">A spray id property value.</param>
    /// <returns>A <see cref="Spray"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
    public Spray GetSprayById(string id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        if (TryGetSprayById(id, out Spray? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a spray with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="id">A spray id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="Spray"/> associated with the <paramref name="id"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetSprayById(string? id, [NotNullWhen(true)] out Spray? value)
    {
        value = null;

        if (id is null)
            return false;

        if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
        {
            value = GetSprayData(id, element);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets a <see cref="Spray"/> from the spray <paramref name="hyperlinkId"/> property value.
    /// </summary>
    /// <param name="hyperlinkId">A spray hyperlinkId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
    /// <returns>A <see cref="Spray"/> object.</returns>
    public Spray GetSprayByHyperlinkId(string hyperlinkId)
    {
        ArgumentNullException.ThrowIfNull(hyperlinkId, nameof(hyperlinkId));

        if (TryGetSprayByHyperlinkId(hyperlinkId, out Spray? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a spray with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="hyperlinkId">A spray hyperlinkId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="Spray"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetSprayByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out Spray? value)
        => PropertyLookup("hyperlinkId", hyperlinkId, GetSprayData, out value);

    /// <summary>
    /// Gets a <see cref="Spray"/> from the spray <paramref name="attributeId"/> property value.
    /// </summary>
    /// <param name="attributeId">A spray attributeId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="attributeId"/> property value was not found.</exception>
    /// <returns>A <see cref="Spray"/> object.</returns>
    public Spray GetSprayByAttributeId(string attributeId)
    {
        ArgumentNullException.ThrowIfNull(attributeId, nameof(attributeId));

        if (TryGetSprayByAttributeId(attributeId, out Spray? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a spray with the <paramref name="attributeId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="attributeId">A spray attributeId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="Spray"/> associated with the <paramref name="attributeId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetSprayByAttributeId(string? attributeId, [NotNullWhen(true)] out Spray? value)
        => PropertyLookup("attributeId", attributeId, GetSprayData, out value);

    private Spray GetSprayData(string sprayId, JsonElement sprayElement)
    {
        Spray spray = new()
        {
            Id = sprayId,
        };

        if (sprayElement.TryGetProperty("name", out JsonElement name))
            spray.Name = name.GetString();

        if (sprayElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
            spray.HyperlinkId = hyperlinkId.GetString();

        if (sprayElement.TryGetProperty("attributeId", out JsonElement attributeId))
            spray.AttributeId = attributeId.GetString();

        if (sprayElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
            spray.Rarity = rarity;

        if (sprayElement.TryGetProperty("category", out JsonElement category))
            spray.CollectionCategory = category.GetString();

        if (sprayElement.TryGetProperty("event", out JsonElement eventElement))
            spray.EventName = eventElement.GetString();

        if (sprayElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
            spray.ReleaseDate = releaseDate;

        if (sprayElement.TryGetProperty("sortName", out JsonElement sortName))
            spray.SortName = sortName.GetString();

        if (sprayElement.TryGetProperty("searchText", out JsonElement searchText))
            spray.SearchText = searchText.GetString();

        if (sprayElement.TryGetProperty("description", out JsonElement description))
            spray.Description = SetTooltipDescription(description.GetString(), Localization);

        if (sprayElement.TryGetProperty("image", out JsonElement image))
            spray.ImageFileName = image.GetString();

        if (sprayElement.TryGetProperty("animation", out JsonElement animationElement))
        {
            if (animationElement.TryGetProperty("texture", out JsonElement texture))
                spray.TextureSheet.Image = texture.GetString();

            if (animationElement.TryGetProperty("frames", out JsonElement frames))
                spray.AnimationCount = frames.GetInt32();

            if (animationElement.TryGetProperty("duration", out JsonElement duration))
                spray.AnimationDuration = duration.GetInt32();
        }

        GameStringDocument?.UpdateGameStrings(spray);

        return spray;
    }
}
