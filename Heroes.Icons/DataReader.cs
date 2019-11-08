using Heroes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons
{
    /// <summary>
    /// Abstract data reader class.
    /// </summary>
    public abstract class DataReader : IDisposable
    {
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

        public DataReader(string jsonDataFilePath, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            Localization = localization;
        }

        public DataReader(ReadOnlyMemory<byte> jsonData)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);

            if (JsonDataDocument is null)
                throw new NullReferenceException(nameof(JsonDataDocument));
        }

        public DataReader(ReadOnlyMemory<byte> jsonData, Localization localization)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);
            Localization = localization;
        }

        public DataReader(string jsonDataFilePath, GameStringReader gameStringReader)
            : this(jsonDataFilePath)
        {
            GameStringReader = gameStringReader;
            Localization = GameStringReader.Localization;
        }

        public DataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : this(jsonData)
        {
            GameStringReader = gameStringReader;
            Localization = GameStringReader.Localization;
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

        protected GameStringReader? GameStringReader { get; } = null;

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
    }
}
