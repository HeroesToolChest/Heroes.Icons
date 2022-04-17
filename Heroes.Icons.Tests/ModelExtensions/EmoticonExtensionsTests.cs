using Heroes.Icons.ModelExtensions;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Heroes.Icons.Tests.ModelExtensions;

[TestClass]
public class EmoticonExtensionsTests
{
    [TestMethod]
    public void UpdateGameStringsTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

        Emoticon emoticon = new Emoticon
        {
            Id = "abathur_silly",
        };

        emoticon.UpdateGameStrings(gameStringDocument);

        Assert.AreEqual("Silly", emoticon.Description!.RawDescription);
        Assert.AreEqual("(Locked) Abathur Silly", emoticon.DescriptionLocked!.RawDescription);
        Assert.AreEqual(1, emoticon.UniversalAliases.Count);
        Assert.AreEqual(":silly:", emoticon.UniversalAliases.ToList()[0]);
    }

    [TestMethod]
    public void UpdateGameStringsThrowArgumentNullException()
    {
        Emoticon emoticon = new Emoticon
        {
            Id = "abathur_silly",
        };

        Assert.ThrowsException<ArgumentNullException>(() => emoticon.UpdateGameStrings(null!));
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
        writer.WriteStartObject("emoticon");

        writer.WriteStartObject("localizedaliases");
        writer.WriteString("abathur_silly", ":P");
        writer.WriteEndObject();
        writer.WriteStartObject("aliases");
        writer.WriteString("abathur_silly", ":silly:");
        writer.WriteEndObject();
        writer.WriteStartObject("description");
        writer.WriteString("abathur_silly", "Silly");
        writer.WriteEndObject();
        writer.WriteStartObject("descriptionlocked");
        writer.WriteString("abathur_silly", "(Locked) Abathur Silly");
        writer.WriteEndObject();
        writer.WriteStartObject("expression");
        writer.WriteString("abathur_silly", "Silly");
        writer.WriteEndObject();
        writer.WriteStartObject("searchtext");
        writer.WriteString("abathur_silly", string.Empty);
        writer.WriteEndObject();

        writer.WriteEndObject(); // end emoticon

        writer.WriteEndObject(); // end gamestrings

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }
}
