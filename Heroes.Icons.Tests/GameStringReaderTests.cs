using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class GameStringReaderTests
    {
        private readonly string _jsonGameStringFileENUS = Path.Combine("JsonGameStrings", "gamestrings_76893_enus.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");

        [TestMethod]
        public void GameStringReaderWithFileTest()
        {
            using GameStringReader gameStringReader = new GameStringReader(_jsonGameStringFileKOKR);

            Assert.AreEqual(Localization.KOKR, gameStringReader.Localization);
            Assert.IsTrue(gameStringReader.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringReaderWithFileLocaleTest()
        {
            using GameStringReader gameStringReader = new GameStringReader(_jsonGameStringFileENUS, Localization.PLPL);

            Assert.AreEqual(Localization.PLPL, gameStringReader.Localization);
            Assert.IsTrue(gameStringReader.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringReaderWithROMTest()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("meta");
            writer.WriteString("locale", "frfr");
            writer.WriteEndObject(); // meta

            writer.WriteEndObject();

            writer.Flush();

            byte[] bytes = memoryStream.ToArray();

            using GameStringReader gameStringReader = new GameStringReader(bytes);

            Assert.AreEqual(Localization.FRFR, gameStringReader.Localization);
            Assert.IsTrue(gameStringReader.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringReaderWithROMLocaleTest()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("meta");
            writer.WriteString("locale", "frfr");
            writer.WriteEndObject(); // meta

            writer.WriteEndObject();

            writer.Flush();

            byte[] bytes = memoryStream.ToArray();

            using GameStringReader gameStringReader = new GameStringReader(bytes, Localization.ITIT);

            Assert.AreEqual(Localization.ITIT, gameStringReader.Localization);
            Assert.IsTrue(gameStringReader.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }
    }
}
