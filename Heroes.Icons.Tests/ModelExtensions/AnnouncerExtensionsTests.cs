using Heroes.Icons.ModelExtensions;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.ModelExtensions
{
    [TestClass]
    public class AnnouncerExtensionsTests
    {
        [TestMethod]
        public void UpdateGameStringsTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

            Announcer announcer = new Announcer
            {
                Id = "AbathurA",
            };

            announcer.UpdateGameStrings(gameStringDocument);

            Assert.AreEqual("asdf", announcer.Description!.RawDescription);
        }

        [TestMethod]
        public void UpdateGameStringsThrowArgumentNullException()
        {
            Announcer announcer = new Announcer
            {
                Id = "AbathurA",
            };

            Assert.ThrowsException<ArgumentNullException>(() => announcer.UpdateGameStrings(null!));
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
            writer.WriteStartObject("announcer");

            writer.WriteStartObject("name");
            writer.WriteString("AbathurA", "Abathur Announcer");
            writer.WriteString("Adjutant", "Adjutant Announcer");
            writer.WriteEndObject();
            writer.WriteStartObject("description");
            writer.WriteString("AbathurA", "asdf");
            writer.WriteString("Adjutant", "qwer");
            writer.WriteEndObject();

            writer.WriteEndObject(); // end announcer

            writer.WriteEndObject(); // end gamestrings

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}