namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="VoiceLine"/> data as well as updating localized strings.
/// </summary>
public class VoiceLineDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected VoiceLineDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected VoiceLineDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected VoiceLineDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected VoiceLineDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
        : base(jsonDataFilePath, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected VoiceLineDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        : base(jsonData, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected VoiceLineDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected VoiceLineDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        : base(utf8Json, gameStringDocument, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceLineDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected VoiceLineDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        : base(utf8Json, utf8JsonGameStrings, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static VoiceLineDataDocument Parse(string jsonDataFilePath)
    {
        return new VoiceLineDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static VoiceLineDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new VoiceLineDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static VoiceLineDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new VoiceLineDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static VoiceLineDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
    {
        return new VoiceLineDataDocument(jsonDataFilePath, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static VoiceLineDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
    {
        return new VoiceLineDataDocument(jsonData, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static VoiceLineDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new VoiceLineDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static VoiceLineDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new VoiceLineDataDocument(utf8Json, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static VoiceLineDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new VoiceLineDataDocument(utf8Json, utf8JsonGameStrings);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<VoiceLineDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new VoiceLineDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<VoiceLineDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<VoiceLineDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new VoiceLineDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<VoiceLineDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="VoiceLine"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns> <see cref="VoiceLineDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static Task<VoiceLineDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new VoiceLineDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<VoiceLineDataDocument>();
    }

    /// <summary>
    /// Gets a <see cref="VoiceLine"/> from the voice line <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">A voice line id property value.</param>
    /// <returns>A <see cref="VoiceLine"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
    public VoiceLine GetVoiceLineById(string id)
    {
        if (id is null)
            throw new ArgumentNullException(nameof(id));

        if (TryGetVoiceLineById(id, out VoiceLine? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a voice line with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="id">A voice line id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="VoiceLine"/> associated with the <paramref name="id"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetVoiceLineById(string? id, [NotNullWhen(true)] out VoiceLine? value)
    {
        value = null;

        if (id is null)
            return false;

        if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
        {
            value = GetVoiceLineData(id, element);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets a <see cref="VoiceLine"/> from the voice line <paramref name="hyperlinkId"/> property value.
    /// </summary>
    /// <param name="hyperlinkId">A voice line hyperlinkId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
    /// <returns>A <see cref="VoiceLine"/> object.</returns>
    public VoiceLine GetVoiceLineByHyperlinkId(string hyperlinkId)
    {
        if (hyperlinkId is null)
            throw new ArgumentNullException(nameof(hyperlinkId));

        if (TryGetVoiceLineByHyperlinkId(hyperlinkId, out VoiceLine? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a voice line with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="hyperlinkId">A voice line hyperlinkId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="VoiceLine"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetVoiceLineByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out VoiceLine? value)
        => PropertyLookup("hyperlinkId", hyperlinkId, GetVoiceLineData, out value);

    /// <summary>
    /// Gets a <see cref="VoiceLine"/> from the voice line <paramref name="attributeId"/> property value.
    /// </summary>
    /// <param name="attributeId">A voice line attributeId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="attributeId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="attributeId"/> property value was not found.</exception>
    /// <returns>A <see cref="VoiceLine"/> object.</returns>
    public VoiceLine GetVoiceLineByAttributeId(string attributeId)
    {
        if (attributeId is null)
            throw new ArgumentNullException(nameof(attributeId));

        if (TryGetVoiceLineByAttributeId(attributeId, out VoiceLine? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a voice line with the <paramref name="attributeId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="attributeId">A voice line attributeId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="VoiceLine"/> associated with the <paramref name="attributeId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetVoiceLineByAttributeId(string? attributeId, [NotNullWhen(true)] out VoiceLine? value)
        => PropertyLookup("attributeId", attributeId, GetVoiceLineData, out value);

    private VoiceLine GetVoiceLineData(string voiceLineId, JsonElement voiceLineElement)
    {
        VoiceLine voiceLine = new()
        {
            Id = voiceLineId,
        };

        if (voiceLineElement.TryGetProperty("name", out JsonElement name))
            voiceLine.Name = name.GetString();

        if (voiceLineElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
            voiceLine.HyperlinkId = hyperlinkId.GetString();

        if (voiceLineElement.TryGetProperty("attributeId", out JsonElement attributeId))
            voiceLine.AttributeId = attributeId.GetString();

        if (voiceLineElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
            voiceLine.Rarity = rarity;

        if (voiceLineElement.TryGetProperty("releaseDate", out JsonElement releaseDateElement) && DateTime.TryParse(releaseDateElement.GetString(), out DateTime releaseDate))
            voiceLine.ReleaseDate = releaseDate;

        if (voiceLineElement.TryGetProperty("sortName", out JsonElement sortName))
            voiceLine.SortName = sortName.GetString();

        if (voiceLineElement.TryGetProperty("description", out JsonElement description))
            voiceLine.Description = SetTooltipDescription(description.GetString(), Localization);

        if (voiceLineElement.TryGetProperty("image", out JsonElement image))
            voiceLine.ImageFileName = image.GetString();

        GameStringDocument?.UpdateGameStrings(voiceLine);

        return voiceLine;
    }
}
