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
    public abstract class DataReader : IDisposable
    {
        private bool _disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing the data.</param>
        public DataReader(string jsonDataFilePath)
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
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing the data.</param>
        /// <param name="localization">The localization of the file.</param>
        public DataReader(string jsonDataFilePath, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="jsonData">JSON data containing the data.</param>
        /// <param name="localization">The localization of the file.</param>
        public DataReader(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);
            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing the data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringReader"/> cannot be null.</exception>
        public DataReader(string jsonDataFilePath, GameStringReader gameStringReader)
            : this(jsonDataFilePath)
        {
            GameStringReader = gameStringReader ?? throw new ArgumentNullException(nameof(gameStringReader));
            Localization = GameStringReader.Localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="jsonData">JSON data containing the data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringReader"/> cannot be null.</exception>
        public DataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : this(jsonData)
        {
            GameStringReader = gameStringReader ?? throw new ArgumentNullException(nameof(gameStringReader));
            Localization = GameStringReader.Localization;
        }

        private DataReader(ReadOnlyMemory<byte> jsonData)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);
            if (JsonDataDocument is null)
                throw new NullReferenceException(nameof(JsonDataDocument));
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DataReader"/> class.
        /// </summary>
        ~DataReader()
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
        /// Gets a collection of all names.
        /// </summary>
        public IEnumerable<string> GetNames => GetCollectionOfPropety("name");

        /// <summary>
        /// Gets a collection of all hyperlink ids.
        /// </summary>
        public IEnumerable<string> GetHyperlinkIds => GetCollectionOfPropety("hyperlinkId");

        /// <summary>
        /// Gets a collection of all ids.
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
        /// <returns>Collection of values.</returns>
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
        /// <returns>True if the value was found, otherwise false.</returns>
        /// <exception cref="ArgumentException"><paramref name="propertyId"/> cannot be null or empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyValue"/> or <paramref name="getData"/> cannot be null.</exception>
        protected virtual bool PropertyLookup<T>(string propertyId, string propertyValue, Func<string, JsonElement, T> getData, [NotNullWhen(true)] out T? value)
            where T : class, IExtractable, new()
        {
            if (string.IsNullOrWhiteSpace(propertyId))
                throw new ArgumentException("Cannot be null or empty.", nameof(propertyId));

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
