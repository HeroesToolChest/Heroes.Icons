using Heroes.Models;
using System;
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
            if (jsonDataFilePath is null)
            {
                throw new ArgumentNullException(nameof(jsonDataFilePath));
            }

            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            int index = jsonDataFilePath.LastIndexOf('_');
            if (index > -1)
            {
                if (Enum.TryParse(jsonDataFilePath.Substring(index), true, out Localization localization))
                    Localization = localization;
            }
        }

        public DataReader(string jsonDataFilePath, Localization localization)
        {
            if (jsonDataFilePath is null)
            {
                throw new ArgumentNullException(nameof(jsonDataFilePath));
            }

            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(jsonDataFilePath));

            Localization = localization;
        }

        public DataReader(ReadOnlyMemory<byte> jsonData)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);

            if (JsonDataDocument is null)
                throw new NullReferenceException(nameof(JsonDataDocument));

            if (JsonDataDocument.RootElement.TryGetProperty("locale", out JsonElement locale) && Enum.TryParse(locale.ToString(), true, out Localization localization))
                Localization = localization;
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
        }

        public DataReader(string jsonDataFilePath, GameStringReader gameStringReader, Localization localization)
         : this(jsonDataFilePath, localization)
        {
            GameStringReader = gameStringReader;
        }

        public DataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : this(jsonData)
        {
            GameStringReader = gameStringReader;
        }

        public DataReader(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader, Localization localization)
            : this(jsonData, localization)
        {
            GameStringReader = gameStringReader;
        }

        /// <summary>
        /// Gets the current selected localization.
        /// </summary>
        public Localization Localization { get; } = Localization.ENUS;

        /// <summary>
        /// Gets the <see cref="JsonDataDocument"/> to allow for manually parsing.
        /// </summary>
        public JsonDocument JsonDataDocument { get; }

        protected GameStringReader? GameStringReader { get; } = null;

        public void Dispose()
        {
            JsonDataDocument.Dispose();
            GameStringReader?.Dispose();
        }
    }
}
