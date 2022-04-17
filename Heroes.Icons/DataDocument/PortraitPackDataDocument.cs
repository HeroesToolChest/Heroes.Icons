namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="PortraitPack"/> data as well as updating localized strings.
/// </summary>
public class PortraitPackDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected PortraitPackDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected PortraitPackDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected PortraitPackDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected PortraitPackDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
        : base(jsonDataFilePath, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected PortraitPackDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        : base(jsonData, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected PortraitPackDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected PortraitPackDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        : base(utf8Json, gameStringDocument, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortraitPackDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected PortraitPackDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        : base(utf8Json, utf8JsonGameStrings, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static PortraitPackDataDocument Parse(string jsonDataFilePath)
    {
        return new PortraitPackDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static PortraitPackDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new PortraitPackDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static PortraitPackDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new PortraitPackDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static PortraitPackDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
    {
        return new PortraitPackDataDocument(jsonDataFilePath, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static PortraitPackDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
    {
        return new PortraitPackDataDocument(jsonData, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static PortraitPackDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new PortraitPackDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static PortraitPackDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new PortraitPackDataDocument(utf8Json, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static PortraitPackDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new PortraitPackDataDocument(utf8Json, utf8JsonGameStrings);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<PortraitPackDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new PortraitPackDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<PortraitPackDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<PortraitPackDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new PortraitPackDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<PortraitPackDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="PortraitPack"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>A <see cref="PortraitPackDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static Task<PortraitPackDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new PortraitPackDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<PortraitPackDataDocument>();
    }

    /// <summary>
    /// Gets a <see cref="PortraitPack"/> from the portrait pack <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">A portrait pack id property value.</param>
    /// <returns>A <see cref="PortraitPack"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
    public PortraitPack GetPortraitPackById(string id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        if (TryGetPortraitPackById(id, out PortraitPack? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a portrait pack with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="id">A portrait pack id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="PortraitPack"/> associated with the <paramref name="id"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetPortraitPackById(string? id, [NotNullWhen(true)] out PortraitPack? value)
    {
        value = null;

        if (id is null)
            return false;

        if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
        {
            value = GetPortraitPackData(id, element);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets a <see cref="PortraitPack"/> from the portrait pack <paramref name="hyperlinkId"/> property value.
    /// </summary>
    /// <param name="hyperlinkId">A portrait pack hyperlinkId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
    /// <returns>A <see cref="PortraitPack"/> object.</returns>
    public PortraitPack GetPortraitPackByHyperlinkId(string hyperlinkId)
    {
        ArgumentNullException.ThrowIfNull(hyperlinkId, nameof(hyperlinkId));

        if (TryGetPortraitPackByHyperlinkId(hyperlinkId, out PortraitPack? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a portrait pack with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="hyperlinkId">A portrait pack hyperlinkId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="PortraitPack"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetPortraitPackByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out PortraitPack? value)
        => PropertyLookup("hyperlinkId", hyperlinkId, GetPortraitPackData, out value);

    private PortraitPack GetPortraitPackData(string portraitPackId, JsonElement portraitPackElement)
    {
        PortraitPack portraitPack = new()
        {
            Id = portraitPackId,
        };

        if (portraitPackElement.TryGetProperty("name", out JsonElement name))
            portraitPack.Name = name.GetString();

        if (portraitPackElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
            portraitPack.HyperlinkId = hyperlinkId.GetString();

        if (portraitPackElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
            portraitPack.Rarity = rarity;

        if (portraitPackElement.TryGetProperty("event", out JsonElement eventElement))
            portraitPack.EventName = eventElement.GetString();

        if (portraitPackElement.TryGetProperty("sortName", out JsonElement sortName))
            portraitPack.SortName = sortName.GetString();

        if (portraitPackElement.TryGetProperty("rewardPortraitIds", out JsonElement rewardPortraitIdsElements))
        {
            foreach (JsonElement rewardPortraitIdElement in rewardPortraitIdsElements.EnumerateArray())
            {
                string? rewardPortraitValue = rewardPortraitIdElement.GetString();
                if (rewardPortraitValue is not null)
                    portraitPack.RewardPortraitIds.Add(rewardPortraitValue);
            }
        }

        GameStringDocument?.UpdateGameStrings(portraitPack);

        return portraitPack;
    }
}
