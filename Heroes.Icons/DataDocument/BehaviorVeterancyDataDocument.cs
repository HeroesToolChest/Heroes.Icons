namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="BehaviorVeterancy"/> data as well as updating localized strings.
/// </summary>
public class BehaviorVeterancyDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BehaviorVeterancyDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected BehaviorVeterancyDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BehaviorVeterancyDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected BehaviorVeterancyDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BehaviorVeterancyDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected BehaviorVeterancyDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BehaviorVeterancyDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected BehaviorVeterancyDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="BehaviorVeterancy"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>A <see cref="BehaviorVeterancyDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static BehaviorVeterancyDataDocument Parse(string jsonDataFilePath)
    {
        return new BehaviorVeterancyDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="BehaviorVeterancy"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BehaviorVeterancyDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static BehaviorVeterancyDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new BehaviorVeterancyDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="BehaviorVeterancy"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BehaviorVeterancyDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static BehaviorVeterancyDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new BehaviorVeterancyDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="BehaviorVeterancy"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BehaviorVeterancyDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static BehaviorVeterancyDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new BehaviorVeterancyDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="BehaviorVeterancy"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>A <see cref="BehaviorVeterancyDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<BehaviorVeterancyDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new BehaviorVeterancyDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<BehaviorVeterancyDataDocument>();
    }

    /// <summary>
    /// Gets a <see cref="BehaviorVeterancy"/> from the behavior veterancy <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">A behavior veterancy id property value.</param>
    /// <returns>A <see cref="BehaviorVeterancy"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
    public BehaviorVeterancy GetBehaviorVeterancyById(string id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        if (TryGetBehaviorVeterancyById(id, out BehaviorVeterancy? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a behavior veterancy with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="id">A behavior veterancy id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="BehaviorVeterancy"/> associated with the <paramref name="id"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetBehaviorVeterancyById(string? id, [NotNullWhen(true)] out BehaviorVeterancy? value)
    {
        value = null;

        if (id is null)
            return false;

        if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
        {
            value = GetBehaviorVeterancyData(id, element);

            return true;
        }

        return false;
    }

    private static BehaviorVeterancy GetBehaviorVeterancyData(string behaviorVeterancyId, JsonElement behaviorVeterancyElement)
    {
        BehaviorVeterancy behaviorVeterancy = new()
        {
            Id = behaviorVeterancyId,
        };

        int indexOfMapSplit = behaviorVeterancy.Id.IndexOf('-', StringComparison.OrdinalIgnoreCase);

        if (indexOfMapSplit > 0)
        {
            behaviorVeterancy.MapName = behaviorVeterancy.Id[..indexOfMapSplit];
        }

        if (behaviorVeterancyElement.TryGetProperty("combineModifications", out JsonElement combineModifications))
            behaviorVeterancy.CombineModifications = combineModifications.GetBoolean();

        if (behaviorVeterancyElement.TryGetProperty("combineXP", out JsonElement combineXP))
            behaviorVeterancy.CombineXP = combineXP.GetBoolean();

        if (behaviorVeterancyElement.TryGetProperty("veterancyLevels", out JsonElement veterancyLevelsElement))
        {
            foreach (JsonElement veterancyLevelElement in veterancyLevelsElement.EnumerateArray())
            {
                VeterancyLevel veterancyLevel = new();

                if (veterancyLevelElement.TryGetProperty("minVeterancyXP", out JsonElement minVeterancyXP))
                {
                    veterancyLevel.MinimumVeterancyXP = minVeterancyXP.GetInt32();
                }

                if (veterancyLevelElement.TryGetProperty("modifications", out JsonElement modificationsElement))
                {
                    if (modificationsElement.TryGetProperty("killXPBonus", out JsonElement killXPBonus))
                        veterancyLevel.VeterancyModification.KillXpBonus = killXPBonus.GetDouble();

                    if (modificationsElement.TryGetProperty("damageDealtScaled", out JsonElement damageDealtScaledElement))
                    {
                        foreach (JsonProperty property in damageDealtScaledElement.EnumerateObject())
                        {
                            veterancyLevel.VeterancyModification.DamageDealtScaledCollection.Add(new VeterancyDamageDealtScaled()
                            {
                                Type = property.Name,
                                Value = property.Value.GetDouble(),
                            });
                        }
                    }

                    if (modificationsElement.TryGetProperty("damageDealtFraction", out JsonElement damageDealtFractionElement))
                    {
                        foreach (JsonProperty property in damageDealtFractionElement.EnumerateObject())
                        {
                            veterancyLevel.VeterancyModification.DamageDealtFractionCollection.Add(new VeterancyDamageDealtFraction()
                            {
                                Type = property.Name,
                                Value = property.Value.GetDouble(),
                            });
                        }
                    }

                    if (modificationsElement.TryGetProperty("vitalMax", out JsonElement vitalMaxElement))
                    {
                        foreach (JsonProperty property in vitalMaxElement.EnumerateObject())
                        {
                            veterancyLevel.VeterancyModification.VitalMaxCollection.Add(new VeterancyVitalMax()
                            {
                                Type = property.Name,
                                Value = property.Value.GetDouble(),
                            });
                        }
                    }

                    if (modificationsElement.TryGetProperty("vitalMaxFraction", out JsonElement vitalMaxFractionElement))
                    {
                        foreach (JsonProperty property in vitalMaxFractionElement.EnumerateObject())
                        {
                            veterancyLevel.VeterancyModification.VitalMaxFractionCollection.Add(new VeterancyVitalMaxFraction()
                            {
                                Type = property.Name,
                                Value = property.Value.GetDouble(),
                            });
                        }
                    }

                    if (modificationsElement.TryGetProperty("vitalRegen", out JsonElement vitalRegenElement))
                    {
                        foreach (JsonProperty property in vitalRegenElement.EnumerateObject())
                        {
                            veterancyLevel.VeterancyModification.VitalRegenCollection.Add(new VeterancyVitalRegen()
                            {
                                Type = property.Name,
                                Value = property.Value.GetDouble(),
                            });
                        }
                    }

                    if (modificationsElement.TryGetProperty("vitalRegenFraction", out JsonElement vitalRegenFractionElement))
                    {
                        foreach (JsonProperty property in vitalRegenFractionElement.EnumerateObject())
                        {
                            veterancyLevel.VeterancyModification.VitalRegenFractionCollection.Add(new VeterancyVitalRegenFraction()
                            {
                                Type = property.Name,
                                Value = property.Value.GetDouble(),
                            });
                        }
                    }
                }

                behaviorVeterancy.VeterancyLevels.Add(veterancyLevel);
            }
        }

        return behaviorVeterancy;
    }
}
