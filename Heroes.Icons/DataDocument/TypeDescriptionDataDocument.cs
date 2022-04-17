using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.DataDocument;

/// <summary>
/// Provides access to obtain <see cref="TypeDescription"/> data as well as updating localized strings.
/// </summary>
public class TypeDescriptionDataDocument : DataDocumentBase, IDataDocument
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    protected TypeDescriptionDataDocument(string jsonDataFilePath)
        : base(jsonDataFilePath)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected TypeDescriptionDataDocument(string jsonDataFilePath, Localization localization)
        : base(jsonDataFilePath, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    protected TypeDescriptionDataDocument(ReadOnlyMemory<byte> jsonData, Localization localization)
        : base(jsonData, localization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected TypeDescriptionDataDocument(string jsonDataFilePath, GameStringDocument gameStringDocument)
        : base(jsonDataFilePath, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    protected TypeDescriptionDataDocument(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
        : base(jsonData, gameStringDocument)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected TypeDescriptionDataDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        : base(utf8Json, localization, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected TypeDescriptionDataDocument(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        : base(utf8Json, gameStringDocument, isAsync)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeDescriptionDataDocument"/> class.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
    protected TypeDescriptionDataDocument(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        : base(utf8Json, utf8JsonGameStrings, isAsync)
    {
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static TypeDescriptionDataDocument Parse(string jsonDataFilePath)
    {
        return new TypeDescriptionDataDocument(jsonDataFilePath);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static TypeDescriptionDataDocument Parse(string jsonDataFilePath, Localization localization)
    {
        return new TypeDescriptionDataDocument(jsonDataFilePath, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static TypeDescriptionDataDocument Parse(ReadOnlyMemory<byte> jsonData, Localization localization)
    {
        return new TypeDescriptionDataDocument(jsonData, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
    /// </summary>
    /// <param name="jsonDataFilePath">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="jsonDataFilePath"/> was not found.</exception>
    /// <exception cref="JsonException">The json data in <paramref name="jsonDataFilePath"/> is not valid.</exception>
    public static TypeDescriptionDataDocument Parse(string jsonDataFilePath, GameStringDocument gameStringDocument)
    {
        return new TypeDescriptionDataDocument(jsonDataFilePath, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// </summary>
    /// <param name="jsonData">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="jsonData"/> does not represent a valid single JSON value.</exception>
    public static TypeDescriptionDataDocument Parse(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
    {
        return new TypeDescriptionDataDocument(jsonData, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static TypeDescriptionDataDocument Parse(Stream utf8Json, Localization localization)
    {
        return new TypeDescriptionDataDocument(utf8Json, localization);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static TypeDescriptionDataDocument Parse(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new TypeDescriptionDataDocument(utf8Json, gameStringDocument);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static TypeDescriptionDataDocument Parse(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new TypeDescriptionDataDocument(utf8Json, utf8JsonGameStrings);
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="localization">The <see cref="Localization"/> of the file.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<TypeDescriptionDataDocument> ParseAsync(Stream utf8Json, Localization localization)
    {
        return new TypeDescriptionDataDocument(utf8Json, localization, true).InitializeParseDataStreamAsync<TypeDescriptionDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static Task<TypeDescriptionDataDocument> ParseAsync(Stream utf8Json, GameStringDocument gameStringDocument)
    {
        return new TypeDescriptionDataDocument(utf8Json, gameStringDocument, true).InitializeParseDataStreamAsync<TypeDescriptionDataDocument>();
    }

    /// <summary>
    /// Parses a json file as UTF-8-encoded text to allow for <see cref="TypeDescription"/> data reading.
    /// The <see cref="Localization"/> will be inferred from the meta property in the <paramref name="utf8JsonGameStrings"/> data.
    /// </summary>
    /// <param name="utf8Json">The JSON data to parse.</param>
    /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
    /// <returns>An <see cref="TypeDescriptionDataDocument"/> representation of the JSON value.</returns>
    /// <exception cref="JsonException"><paramref name="utf8Json"/> or <paramref name="utf8JsonGameStrings"/> does not represent a valid single JSON value.</exception>
    public static Task<TypeDescriptionDataDocument> ParseAsync(Stream utf8Json, Stream utf8JsonGameStrings)
    {
        return new TypeDescriptionDataDocument(utf8Json, utf8JsonGameStrings, true).InitializeParseDataWithGameStringStreamAsync<TypeDescriptionDataDocument>();
    }

    /// <summary>
    /// Gets a <see cref="TypeDescription"/> from the type description <paramref name="id"/> property value.
    /// </summary>
    /// <param name="id">An type description id property value.</param>
    /// <returns>An <see cref="TypeDescription"/> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException">The <paramref name="id"/> property value was not found.</exception>
    public TypeDescription GetTypeDescriptionById(string id)
    {
        if (id is null)
            throw new ArgumentNullException(nameof(id));

        if (TryGetTypeDescriptionById(id, out TypeDescription? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a type description with the <paramref name="id"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="id">A type description id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="TypeDescription"/> associated with the <paramref name="id"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetTypeDescriptionById(string? id, [NotNullWhen(true)] out TypeDescription? value)
    {
        value = null;

        if (id is null)
            return false;

        if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
        {
            value = GetTypeDescriptionData(id, element);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets an <see cref="TypeDescription"/> from the type description <paramref name="hyperlinkId"/> property value.
    /// </summary>
    /// <param name="hyperlinkId">A type description id property value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hyperlinkId"/> is <see langword="null"/>.</exception>
    /// <exception cref="KeyNotFoundException"><paramref name="hyperlinkId"/> property value was not found.</exception>
    /// <returns>A <see cref="TypeDescription"/> object.</returns>
    public TypeDescription GetTypeDescriptionByHyperlinkId(string hyperlinkId)
    {
        if (hyperlinkId is null)
            throw new ArgumentNullException(nameof(hyperlinkId));

        if (TryGetTypeDescriptionByHyperlinkId(hyperlinkId, out TypeDescription? value))
            return value;
        else
            throw new KeyNotFoundException();
    }

    /// <summary>
    /// Looks for a type description with the <paramref name="hyperlinkId"/> property value, returning a value that indicates whether such value exists.
    /// </summary>
    /// <param name="hyperlinkId">A type description id property value.</param>
    /// <param name="value">When this method returns, contains the <see cref="TypeDescription"/> associated with the <paramref name="hyperlinkId"/> property value.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    public bool TryGetTypeDescriptionByHyperlinkId(string? hyperlinkId, [NotNullWhen(true)] out TypeDescription? value)
        => PropertyLookup("hyperlinkId", hyperlinkId, GetTypeDescriptionData, out value);

    private TypeDescription GetTypeDescriptionData(string typeDescriptionId, JsonElement typeDescriptionElement)
    {
        TypeDescription typeDescription = new TypeDescription()
        {
            Id = typeDescriptionId,
        };

        if (typeDescriptionElement.TryGetProperty("name", out JsonElement name))
            typeDescription.Name = name.GetString();

        if (typeDescriptionElement.TryGetProperty("hyperlinkId", out JsonElement hyperlinkId))
            typeDescription.HyperlinkId = hyperlinkId.GetString();

        if (typeDescriptionElement.TryGetProperty("iconSlot", out JsonElement iconSlot))
            typeDescription.IconSlot = iconSlot.GetInt32();

        if (typeDescriptionElement.TryGetProperty("textureSheet", out JsonElement textureSheetElement))
        {
            if (textureSheetElement.TryGetProperty("image", out JsonElement image))
                typeDescription.TextureSheet.Image = image.GetString();

            if (textureSheetElement.TryGetProperty("columns", out JsonElement columns))
                typeDescription.TextureSheet.Columns = columns.GetInt32();

            if (textureSheetElement.TryGetProperty("rows", out JsonElement rows))
                typeDescription.TextureSheet.Rows = rows.GetInt32();
        }

        if (typeDescriptionElement.TryGetProperty("image", out JsonElement imageFileName))
            typeDescription.ImageFileName = imageFileName.GetString();

        GameStringDocument?.UpdateGameStrings(typeDescription);

        return typeDescription;
    }
}
