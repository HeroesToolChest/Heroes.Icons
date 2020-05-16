using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.DataReader
{
    /// <summary>
    /// Base class for the data reader classes.
    /// </summary>
    public abstract class DataDocumentBase : IDisposable
    {
        private bool _disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing the data.</param>
        protected DataDocumentBase(string jsonDataFilePath)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            string? file = Path.GetFileNameWithoutExtension(jsonDataFilePath);

            int index = file.LastIndexOf('_');
            if (index > -1)
            {
                if (Enum.TryParse(file.Substring(index + 1), true, out Localization localization))
                    Localization = localization;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing the data.</param>
        /// <param name="localization">The localization of the file.</param>
        protected DataDocumentBase(string jsonDataFilePath, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the data.</param>
        /// <param name="localization">The localization of the file.</param>
        protected DataDocumentBase(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);
            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing the data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringReader"/> cannot be null.</exception>
        protected DataDocumentBase(string jsonDataFilePath, GameStringReader gameStringReader)
            : this(jsonDataFilePath)
        {
            GameStringReader = gameStringReader ?? throw new ArgumentNullException(nameof(gameStringReader));
            Localization = GameStringReader.Localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDocumentBase"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringReader"/> cannot be null.</exception>
        protected DataDocumentBase(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : this(jsonData)
        {
            GameStringReader = gameStringReader ?? throw new ArgumentNullException(nameof(gameStringReader));
            Localization = GameStringReader.Localization;
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
        public Localization Localization { get; } = Localization.ENUS;

        /// <summary>
        /// Gets the <see cref="JsonDataDocument"/> to allow for manually parsing.
        /// </summary>
        public JsonDocument JsonDataDocument { get; }

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

                foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
                {
                    items.Add(heroProperty.Name);
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

                foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
                {
                    count++;
                }

                return count;
            }
        }

        /// <summary>
        /// Gets the current <see cref="GameStringReader"/> associated with this reader.
        /// </summary>
        protected GameStringReader? GameStringReader { get; } = null;

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets a collection of all the values of the selected property.
        /// </summary>
        /// <param name="property">A property name that is in the root element.</param>
        /// <returns>a collection of the <paramref name="property"/> values.</returns>
        protected IEnumerable<string> GetCollectionOfPropety(string property)
        {
            List<string> items = new List<string>();

            foreach (JsonProperty heroProperty in JsonDataDocument.RootElement.EnumerateObject())
            {
                if (heroProperty.Value.TryGetProperty(property, out JsonElement element))
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
        /// <returns>true if the value was found; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyId"/>, <paramref name="propertyValue"/>, or <paramref name="getData"/> is null.</exception>
        protected virtual bool PropertyLookup<T>(string propertyId, string propertyValue, Func<string, JsonElement, T> getData, [NotNullWhen(true)] out T? value)
            where T : class, IExtractable, new()
        {
            if (propertyId is null)
                throw new ArgumentNullException(nameof(propertyId));

            if (propertyValue is null)
                throw new ArgumentNullException(nameof(propertyValue));

            if (getData is null)
                throw new ArgumentNullException(nameof(getData));

            value = null;

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
                    GameStringReader?.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
