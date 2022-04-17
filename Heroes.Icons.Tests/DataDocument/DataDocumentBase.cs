namespace Heroes.Icons.Tests.DataDocument;

public abstract class DataDocumentBase
{
    protected static byte[] GetBytesForROM(string objectId)
    {
        using MemoryStream memoryStream = new();
        using Utf8JsonWriter writer = new(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject(objectId);
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
