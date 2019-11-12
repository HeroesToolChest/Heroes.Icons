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
        public DataReader(string jsonDataFilePath, GameStringReader gameStringReader)
            : this(jsonDataFilePath)
        {
            GameStringReader = gameStringReader;
            Localization = GameStringReader.Localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="jsonData">JSON data containing the data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public DataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : this(jsonData)
        {
            GameStringReader = gameStringReader;
            Localization = GameStringReader.Localization;
        }

        private DataReader(ReadOnlyMemory<byte> jsonData)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);

            if (JsonDataDocument is null)
                throw new NullReferenceException(nameof(JsonDataDocument));
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
        /// Get the amount of total items.
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
            JsonDataDocument.Dispose();
            GameStringReader?.Dispose();
        }

        /// <summary>
        /// Gets a collection of all the values of the selected property.
        /// </summary>
        /// <param name="property"></param>
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
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyId">Json property name.</param>
        /// <param name="propertyValue">The value of the property.</param>
        /// <param name="getData"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual bool PropertyLookup<T>(string propertyId, string propertyValue, Func<string, JsonElement, T> getData, [NotNullWhen(true)] out T? value)
            where T : class, IExtractable, new()
        {
            if (propertyValue is null)
                throw new ArgumentNullException(nameof(propertyValue));

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
    }
}
