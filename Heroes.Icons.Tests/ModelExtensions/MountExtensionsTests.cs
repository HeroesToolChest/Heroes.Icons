using Heroes.Icons.ModelExtensions;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.ModelExtensions
{
    [TestClass]
    public class MountExtensionsTests
    {
        [TestMethod]
        public void UpdateGameStringsTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

            Mount mount = new Mount
            {
                Id = "AlarakTaldarimMarch",
            };

            mount.UpdateGameStrings(gameStringDocument);

            Assert.AreEqual("Should he choose to float only an inch off the ground, you would still be beneath the Highlord.", mount.InfoText!.RawDescription);
        }

        [TestMethod]
        public void UpdateGameStringsThrowArgumentNullException()
        {
            Mount mount = new Mount
            {
                Id = "AlarakTaldarimMarch",
            };

            Assert.ThrowsException<ArgumentNullException>(() => mount.UpdateGameStrings(null!));
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
            writer.WriteStartObject("mount");

            writer.WriteStartObject("infotext");
            writer.WriteString("AlarakTaldarimMarch", "Should he choose to float only an inch off the ground, you would still be beneath the Highlord.");
            writer.WriteString("AnubarakWings", "In the years following the Third War, Azerothian scholars hypothesized that the wings of spiderlords were vestigal, incapable of flight. They were very wrong.");
            writer.WriteEndObject();
            writer.WriteStartObject("name");
            writer.WriteString("AlarakTaldarimMarch", "Highlord's Ascent");
            writer.WriteString("AnubarakWings", "Crypt Lord Wings");
            writer.WriteEndObject();
            writer.WriteStartObject("searchtext");
            writer.WriteString("AlarakTaldarimMarch", "Highlord's Ascent");
            writer.WriteString("AnubarakWings", "Crypt Lord Wings");
            writer.WriteEndObject();
            writer.WriteStartObject("sortname");
            writer.WriteString("AlarakTaldarimMarch", "1HeroAlarak");
            writer.WriteString("AnubarakWings", "1HeroAnubarak");
            writer.WriteEndObject();

            writer.WriteEndObject(); // end mount

            writer.WriteEndObject(); // end gamestrings

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}
