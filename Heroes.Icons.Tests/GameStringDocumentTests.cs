using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.Tests
{
    [TestClass]
    public class GameStringDocumentTests
    {
        private readonly string _jsonGameStringFileENUS = Path.Combine("JsonGameStrings", "gamestrings_76893_enus.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringNoMetaFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_no_meta_kokr.json");
        private readonly string _jsonGameStringMetaNoLocaleFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_meta_no_locale_kokr.json");
        private readonly string _jsonGameStringUnknownLocale = Path.Combine("JsonGameStrings", "gamestrings_76893_unknown.json");

        [TestMethod]
        public void GameStringDocumentWithFileTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);

            Assert.AreEqual(Localization.KOKR, gameStringDocument.Localization);
            Assert.IsTrue(gameStringDocument.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentWithFileNoMetaTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringNoMetaFileKOKR);

            Assert.AreEqual(Localization.KOKR, gameStringDocument.Localization);
            Assert.IsFalse(gameStringDocument.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentWithFileMetaNoLocaleTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringMetaNoLocaleFileKOKR);

            Assert.AreEqual(Localization.KOKR, gameStringDocument.Localization);
            Assert.IsTrue(gameStringDocument.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
            Assert.IsFalse(gameStringDocument.JsonGameStringDocument.RootElement.GetProperty("meta").TryGetProperty("locale", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentWithFileUnknownLocaleTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringUnknownLocale);

            Assert.AreEqual(Localization.ENUS, gameStringDocument.Localization);
            Assert.IsFalse(gameStringDocument.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentWithFileLocaleTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileENUS, Localization.PLPL);

            Assert.AreEqual(Localization.PLPL, gameStringDocument.Localization);
            Assert.IsTrue(gameStringDocument.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentWithROMTest()
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

            using GameStringDocument gameStringDocument = GameStringDocument.Parse(bytes);

            Assert.AreEqual(Localization.FRFR, gameStringDocument.Localization);
            Assert.IsTrue(gameStringDocument.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentWithROMLocaleTest()
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

            using GameStringDocument gameStringDocument = GameStringDocument.Parse(bytes, Localization.ITIT);

            Assert.AreEqual(Localization.ITIT, gameStringDocument.Localization);
            Assert.IsTrue(gameStringDocument.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentStreamTest()
        {
            using FileStream stream = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using GameStringDocument document = GameStringDocument.Parse(stream);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public void GameStringDocumentWithStreamLocaleTest()
        {
            using FileStream stream = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using GameStringDocument document = GameStringDocument.Parse(stream, Localization.KOKR);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public async Task GameStringDocumentWithStreamAsyncTest()
        {
            using FileStream stream = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using GameStringDocument document = await GameStringDocument.ParseAsync(stream);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }

        [TestMethod]
        public async Task GameStringDocumentWithStreamAsyncLocaleTest()
        {
            using FileStream stream = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
            using GameStringDocument document = await GameStringDocument.ParseAsync(stream, Localization.KOKR);

            Assert.AreEqual(Localization.KOKR, document.Localization);
            Assert.IsTrue(document.JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement _));
        }
    }
}
