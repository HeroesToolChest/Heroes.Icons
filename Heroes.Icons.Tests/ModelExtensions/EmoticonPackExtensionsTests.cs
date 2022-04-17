using Heroes.Icons.ModelExtensions;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class EmoticonPackExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        EmoticonPack emoticonPack = new EmoticonPack
        {
            Id = "AbathurEmoticonPack2",
        };

        emoticonPack.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Abathur emojis that can be used to express emotions or ideas in chat. Hover over an emoji below to view its text command.", emoticonPack.Description!.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        EmoticonPack emoticonPack = new EmoticonPack
        {
            Id = "AbathurEmoticonPack2",
        };

        Assert.ThrowsException<ArgumentNullException>(() => emoticonPack.UpdateGameStrings(null!));
    }

    private static byte[] LoadEnusLocalizedStringData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);

        writer.WriteStartObject();

        writer.WriteStartObject("meta");
        writer.WriteString("locale", "enus");
        writer.WriteEndObject(); // meta

        writer.WriteStartObject("gamestrings");
        writer.WriteStartObject("emoticonpack");

        writer.WriteStartObject("description");
        writer.WriteString("AbathurEmoticonPack2", "Abathur emojis that can be used to express emotions or ideas in chat. Hover over an emoji below to view its text command.");
        writer.WriteEndObject();
        writer.WriteStartObject("name");
        writer.WriteString("AbathurEmoticonPack", "Abathur Pack 2");
        writer.WriteEndObject();

        writer.WriteEndObject(); // end emoticon pack

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
