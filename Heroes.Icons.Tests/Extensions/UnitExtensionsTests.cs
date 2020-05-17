using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Extensions.Tests
{
    [TestClass]
    public class UnitExtensionsTests
    {
        [TestMethod]
        public void UpdateGameStringsTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

            Unit unit = new Unit
            {
                CUnitId = "AbathurEvolvedMonstrosity",
                Id = "AbathurEvolvedMonstrosity",
            };

            unit.UpdateGameStrings(gameStringDocument);

            Assert.AreEqual("A long description", unit.Description!.RawDescription);
        }

        private byte[] LoadEnusLocalizedStringData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);

            writer.WriteStartObject();

            writer.WriteStartObject("meta");
            writer.WriteString("locale", "enus");
            writer.WriteEndObject(); // meta

            writer.WriteStartObject("gamestrings");
            writer.WriteStartObject("unit");

            writer.WriteStartObject("damagetype");
            writer.WriteString("AbathurEvolvedMonstrosity", "Summon");
            writer.WriteEndObject();

            writer.WriteStartObject("description");
            writer.WriteString("AbathurEvolvedMonstrosity", "A long description");
            writer.WriteEndObject();

            writer.WriteStartObject("energytype");
            writer.WriteString("AbathurEvolvedMonstrosity", "Mana");
            writer.WriteEndObject();

            writer.WriteStartObject("lifetype");
            writer.WriteString("AbathurEvolvedMonstrosity", "Life");
            writer.WriteEndObject();

            writer.WriteStartObject("name");
            writer.WriteString("AbathurEvolvedMonstrosity", "Evolved Monstrosity");
            writer.WriteEndObject();

            writer.WriteStartObject("shieldtype");
            writer.WriteString("AbathurEvolvedMonstrosity", "Shield");
            writer.WriteEndObject();

            writer.WriteEndObject(); // unit
            writer.WriteEndObject(); // gamestrings

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}