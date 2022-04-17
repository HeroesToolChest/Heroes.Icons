namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="LootChest"/> data as well as updating localized strings.
/// </summary>
public class LootChestDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected LootChestDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected LootChestDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected LootChestDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected LootChestDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
        : base(jsonDataFilePath, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected LootChestDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        : base(jsonData, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected LootChestDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected LootChestDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        : base(utf8Json, gameStringDocument, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LootChestDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected LootChestDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        : base(utf8Json, utf8JsonGameStrings, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static LootChestDataDocument Parse(string jsonDataFilePath)
    {
        return new LootChestDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static LootChestDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new LootChestDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static LootChestDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new LootChestDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static LootChestDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
    {
        return new LootChestDataDocument(jsonDataFilePath, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static LootChestDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
    {
        return new LootChestDataDocument(jsonData, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static LootChestDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new LootChestDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static LootChestDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new LootChestDataDocument(utf8Json, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static LootChestDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new LootChestDataDocument(utf8Json, utf8JsonGameStrings);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<LootChestDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new LootChestDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<LootChestDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<LootChestDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new LootChestDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<LootChestDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="LootChest"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>An <see cref="LootChestDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static Task<LootChestDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new LootChestDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<LootChestDataDocument>();
    }

    /// <summary>
    /// Gets a <see cref="LootChest"/> from the loot chest <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">An loot chest id property value.</param>
    /// <returns>An <see cref="LootChest"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
    public LootChest GetLootChestById(string id)
    {
        if (id is null)
            throw new ArgumentNullException(nameof(id));

        if (TryGetLootChestById(id, out LootChest? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a loot chest with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="id">A loot chest id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="LootChest"/> associated with the <paramref name="id"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetLootChestById(string? id, [NotNullWhen(true)] out LootChest? value)
    {
        value = null;

        if (id is null)
            return false;

        if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
        {
            value = GetLootChestData(id, element);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets an <see cref="LootChest"/> from the loot chest <paramref name="hyperlinkId"/> property value.
    /// </summary>
    /// <param name="hyperlinkId">A loot chest hyperlinkId property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
    /// <returns>A <see cref="LootChest"/> object.</returns>
    public LootChest GetLootChestByHyperlinkId(string hyperlinkId)
    {
        if (hyperlinkId is null)
            throw new ArgumentNullException(nameof(hyperlinkId));

        if (TryGetLootChestByHyperlinkId(hyperlinkId, out LootChest? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a loot chest with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="hyperlinkId">A loot chest hyperlinkId property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="LootChest"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetLootChestByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out LootChest? value)
        => PropertyLookup("hyperlinkId", hyperlinkId, GetLootChestData, out value);

    /// <summary>
    /// Gets an <see cref="LootChest"/> from the loot chest <paramref name="typeDescription"/> property value.
    /// </summary>
    /// <param name="typeDescription">A loot chest type description id property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="typeDescription"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="typeDescription"/> property value was not found.</exception>
    /// <returns>A <see cref="LootChest"/> object.</returns>
    public LootChest GetLootChestByTypeDescription(string typeDescription)
    {
        if (typeDescription is null)
            throw new ArgumentNullException(nameof(typeDescription));

        if (TryGetLootChestByTypeDescription(typeDescription, out LootChest? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a loot chest with the <paramref name="typeDescription"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="typeDescription">A loot chest type description id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="LootChest"/> associated with the <paramref name="typeDescription"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetLootChestByTypeDescription(string? typeDescription, [NotNullWhen(true)] out LootChest? value)
        => PropertyLookup("typeDescription", typeDescription, GetLootChestData, out value);

    private LootChest GetLootChestData(string lootChestId, JsonElement lootChestElement)
    {
        LootChest lootChest = new()
        {
            Id = lootChestId,
        };

        if (lootChestElement.TryGetProperty("name", out JsonElement name))
            lootChest.Name = name.GetString();

        if (lootChestElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
            lootChest.HyperlinkId = hyperlinkId.GetString();

        if (lootChestElement.TryGetProperty("rarity", out JsonElement rarityElement) && Enum.TryParse(rarityElement.GetString(), out Rarity rarity))
            lootChest.Rarity = rarity;

        if (lootChestElement.TryGetProperty("maxRerolls", out JsonElement maxRerolls))
            lootChest.MaxRerolls = maxRerolls.GetInt32();

        if (lootChestElement.TryGetProperty("typeDescription", out JsonElement typeDescription))
            lootChest.TypeDescription = typeDescription.GetString();

        if (lootChestElement.TryGetProperty("event", out JsonElement eventName))
            lootChest.EventName = eventName.GetString();

        if (lootChestElement.TryGetProperty("description", out JsonElement description))
            lootChest.Description = SetTooltipDescription(description.GetString(), Localization);

        GameStringDocument?.UpdateGameStrings(lootChest);

        return lootChest;
    }
}
