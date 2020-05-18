using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.DataDocument
{
    public abstract class DataDocumentBase
    {
        protected static byte[] GetBytesForROM(string objectId)
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject(objectId);
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}
