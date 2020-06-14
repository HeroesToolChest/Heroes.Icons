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
    /// Base class for the data reader classes.
    /// </summary>
    public abstract class DataDocumentBase : IDisposable
    {
        private readonly Stream? _streamForDataAsync = null;
        private readonly Stream? _streamForGameStringAsync = null;

        private bool _disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// The <see cref="Localization"/> will be inferred from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file to parse.</param>
        protected DataDocumentBase(string jsonDataFilePath)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            SetLocalizationFromFileName(jsonDataFilePath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected DataDocumentBase(string jsonDataFilePath, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected DataDocumentBase(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);
            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// The <paramref name="gameStringDocument"/> overrides the <paramref name="jsonDataFilePath"/> <see cref="Localization"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is <see langword="null"/>.</exception>
        protected DataDocumentBase(string jsonDataFilePath, GameStringDocument gameStringDocument)
            : this(jsonDataFilePath)
        {
            GameStringDocument = gameStringDocument ?? throw new ArgumentNullException(nameof(gameStringDocument));
            Localization = GameStringDocument.Localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is <see langword="null"/>.</exception>
        protected DataDocumentBase(ReadOnlyMemory<byte> jsonData, GameStringDocument gameStringDocument)
            : this(jsonData)
        {
            GameStringDocument = gameStringDocument ?? throw new ArgumentNullException(nameof(gameStringDocument));
            Localization = GameStringDocument.Localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected DataDocumentBase(Stream utf8Json, Localization localization, bool isAsync = false)
        {
            if (isAsync)
            {
                JsonDataDocument = null!;
                _streamForDataAsync = utf8Json;
            }
            else
            {
                JsonDataDocument = JsonDocument.Parse(utf8Json);
            }

            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is <see langword="null"/>.</exception>
        protected DataDocumentBase(Stream utf8Json, GameStringDocument gameStringDocument, bool isAsync = false)
        {
            if (isAsync)
            {
                JsonDataDocument = null!;
                _streamForDataAsync = utf8Json;
            }
            else
            {
                JsonDataDocument = JsonDocument.Parse(utf8Json);
            }

            GameStringDocument = gameStringDocument ?? throw new ArgumentNullException(nameof(gameStringDocument));
            Localization = gameStringDocument.Localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="utf8JsonGameStrings">The JSON gamestring data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected DataDocumentBase(Stream utf8Json, Stream utf8JsonGameStrings, bool isAsync = false)
        {
            if (isAsync)
            {
                JsonDataDocument = null!;
                _streamForDataAsync = utf8Json;
                _streamForGameStringAsync = utf8JsonGameStrings;
            }
            else
            {
                JsonDataDocument = JsonDocument.Parse(utf8Json);
                GameStringDocument = GameStringDocument.Parse(utf8JsonGameStrings);
                Localization = GameStringDocument.Localization;
            }
        }

        private DataDocumentBase(ReadOnlyMemory<byte> jsonData)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);
            if (JsonDataDocument is null)
                throw new NullReferenceException(nameof(JsonDataDocument));
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        ~DataDocumentBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the current selected localization.
        /// </summary>
        public Localization Localization { get; private set; } = Localization.ENUS;

        /// <summary>
        /// Gets the <see cref="JsonDataDocument"/> to allow for manually parsing.
        /// </summary>
        public JsonDocument JsonDataDocument { get; private set; }

        /// <summary>
        /// Gets a collection of all name property values.
        /// </summary>
        public IEnumerable<string> GetNames => GetCollectionOfPropety("name");

        /// <summary>
        /// Gets a collection of all hyperlinkId property values.
        /// </summary>
        public IEnumerable<string> GetHyperlinkIds => GetCollectionOfPropety("hyperlinkId");

        /// <summary>
        /// Gets a collection of all ids (the root element property values).
        /// </summary>
        public IEnumerable<string> GetIds
        {
            get
            {
                List<string> items = new List<string>();

                foreach (JsonProperty property in JsonDataDocument.RootElement.EnumerateObject())
                {
                    items.Add(property.Name);
                }

                return items;
            }
        }

        /// <summary>
        /// Gets the amount of total items.
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;

                foreach (JsonProperty property in JsonDataDocument.RootElement.EnumerateObject())
                {
                    count++;
                }

                return count;
            }
        }

        /// <summary>
        /// Gets the current <see cref="GameStringDocument"/> associated with this reader.
        /// </summary>
        protected GameStringDocument? GameStringDocument { get; private set; } = null;

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Sets the <see cref="Localization"/> from <paramref name="jsonDataFilePath"/>.
        /// </summary>
        /// <param name="jsonDataFilePath">The json file path.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        protected bool SetLocalizationFromFileName(string jsonDataFilePath)
        {
            string? file = Path.GetFileNameWithoutExtension(jsonDataFilePath);

            int index = file.LastIndexOf('_');
            if (index > -1)
            {
                if (Enum.TryParse(file.Substring(index + 1), true, out Localization localization))
                {
                    Localization = localization;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Parses the JSON data stream as async.
        /// </summary>
        /// <typeparam name="T">A class that derives <see cref="DataDocumentBase"/>.</typeparam>
        /// <returns>a class that derives <see cref="DataDocumentBase"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="_streamForDataAsync"/> is <see langword="null"/>.</exception>
        protected async Task<T> InitializeParseDataStreamAsync<T>()
            where T : DataDocumentBase
        {
            if (_streamForDataAsync is null)
                throw new InvalidOperationException($"{nameof(_streamForDataAsync)} is null.");

            JsonDataDocument = await JsonDocument.ParseAsync(_streamForDataAsync).ConfigureAwait(false);

            return (T)this;
        }

        /// <summary>
        /// Parses the JSON data and gamestring stream as async.
        /// </summary>
        /// <typeparam name="T">A class that derives <see cref="DataDocumentBase"/>.</typeparam>
        /// <returns>a class that derives <see cref="DataDocumentBase"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="_streamForDataAsync"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><see cref="_streamForGameStringAsync"/> is <see langword="null"/>.</exception>
        protected async Task<T> InitializeParseDataWithGameStringStreamAsync<T>()
            where T : DataDocumentBase
        {
            if (_streamForDataAsync is null)
                throw new InvalidOperationException($"{nameof(_streamForDataAsync)} is null.");

            if (_streamForGameStringAsync is null)
                throw new InvalidOperationException($"{nameof(_streamForGameStringAsync)} is null.");

            Task<JsonDocument> dataDocumentTask = JsonDocument.ParseAsync(_streamForDataAsync);
            Task<GameStringDocument> gameStringDocumentTask = GameStringDocument.ParseAsync(_streamForGameStringAsync);

            JsonDataDocument = await dataDocumentTask.ConfigureAwait(false);
            GameStringDocument = await gameStringDocumentTask.ConfigureAwait(false);

            Localization = GameStringDocument.Localization;

            return (T)this;
        }

        /// <summary>
        /// Gets a collection of all the values of the selected property.
        /// </summary>
        /// <param name="property">A property name that is in the root element.</param>
        /// <returns>a collection of the <paramref name="property"/> values.</returns>
        protected IEnumerable<string> GetCollectionOfPropety(string property)
        {
            List<string> items = new List<string>();

            foreach (JsonProperty jsonProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (jsonProperty.Value.TryGetProperty(property, out JsonElement element))
                    items.Add(element.GetString());
            }

            return items;
        }

        /// <summary>
        /// Finds the value to a given <paramref name="propertyId"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="IExtractable"/> type.</typeparam>
        /// <param name="propertyId">Json property name.</param>
        /// <param name="propertyValue">The value of the property.</param>
        /// <param name="getData">The method to execute the lookup for the value.</param>
        /// <param name="value">An <see cref="IExtractable"/> object with the given <paramref name="propertyId"/>.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyId"/>, <paramref name="propertyValue"/>, or <paramref name="getData"/> is <see langword="null"/>.</exception>
        protected virtual bool PropertyLookup<T>(string propertyId, string? propertyValue, Func<string, JsonElement, T> getData, [NotNullWhen(true)] out T? value)
            where T : class, IExtractable, new()
        {
            if (propertyId is null)
                throw new ArgumentNullException(nameof(propertyId));

            if (getData is null)
                throw new ArgumentNullException(nameof(getData));

            value = null;

            if (propertyValue is null)
                return false;

            foreach (JsonProperty property in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (property.Value.TryGetProperty(propertyId, out JsonElement nameElement) && nameElement.ValueEquals(propertyValue))
                {
                    value = getData(property.Name, property.Value);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Disposes the resources.
        /// </summary>
        /// <param name="disposing">True to include releasing managed resource.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    JsonDataDocument.Dispose();
                    GameStringDocument?.Dispose();
                    _streamForDataAsync?.Dispose();
                    _streamForGameStringAsync?.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
