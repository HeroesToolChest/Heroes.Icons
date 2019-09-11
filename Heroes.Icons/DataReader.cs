using Heroes.Models;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons
{
    public abstract class DataReader : IDisposable
    {
        public DataReader(string dataFilePath)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(dataFilePath));
        }

        public DataReader(ReadOnlyMemory<byte> jsonData)
        {
            JsonDataDocument = JsonDocument.Parse(jsonData);
        }

        public DataReader(string dataFilePath, string gameStringFilePath)
        {
            JsonDataDocument = JsonDocument.Parse(File.ReadAllBytes(dataFilePath));
            JsonGameStringDocument = JsonDocument.Parse(File.ReadAllBytes(gameStringFilePath));

            if (gameStringFilePath != null)
            {
                ReadOnlySpan<char> fileName = Path.GetFileNameWithoutExtension(gameStringFilePath.AsSpan());

                int index = fileName.LastIndexOf("_", StringComparison.OrdinalIgnoreCase);
                ReadOnlySpan<char> locale = fileName.Slice(index);

                Localization = Enum.Parse<Localization>(locale.ToString());
            }
        }

        protected JsonDocument JsonDataDocument { get; }
        protected JsonDocument? JsonGameStringDocument { get; } = null;
        protected Localization Localization { get; } = Localization.ENUS;

        public void Dispose()
        {
            JsonDataDocument?.Dispose();
            JsonGameStringDocument?.Dispose();
        }
    }
}
