using Heroes.Icons.DataReader;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.DataReader
{
    [TestClass]
    public class AnnouncerDataReaderTests : IDataReader
    {
        private readonly string _dataFile = Path.Combine("JsonData", "announcerdata_76893_kokr.json");
        private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
        private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

        private readonly AnnouncerDataReader _announcerDataReader;

        public AnnouncerDataReaderTests()
        {
            _announcerDataReader = new AnnouncerDataReader(LoadJsonTestData(), Localization.ENUS);
        }

        [TestMethod]
        [TestCategory("DataReader")]
        public void DataReaderFileGSRTest()
        {
            using GameStringReader gameStringReader = new GameStringReader(_jsonGameStringFileFRFR);
            using AnnouncerDataReader reader = new AnnouncerDataReader(_dataFile, gameStringReader);

            Assert.AreEqual(Localization.FRFR, reader.Localization);
            Assert.IsTrue(reader.TryGetAnnouncerById("AbathurA", out Announcer _));
        }

        [TestMethod]
        [TestCategory("DataReader")]
        public void DataReaderFileLocaleTest()
        {
            using AnnouncerDataReader announcerDataReader = new AnnouncerDataReader(_dataFile, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, announcerDataReader.Localization);
            Assert.IsTrue(announcerDataReader.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataReader")]
        public void DataReaderFileTest()
        {
            using AnnouncerDataReader announcerDataReader = new AnnouncerDataReader(_dataFile);

            Assert.AreEqual(Localization.KOKR, announcerDataReader.Localization);
            Assert.IsTrue(announcerDataReader.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
        }

        [TestMethod]
        [TestCategory("DataReader")]
        public void DataReaderROMGSRTest()
        {
            using GameStringReader gameStringReader = new GameStringReader(_jsonGameStringFileKOKR);
            using AnnouncerDataReader announcerDataReader = new AnnouncerDataReader(_dataFile, gameStringReader);

            Assert.AreEqual(Localization.KOKR, announcerDataReader.Localization);
            Assert.IsTrue(announcerDataReader.TryGetAnnouncerById("AbathurA", out Announcer _));
        }

        [TestMethod]
        [TestCategory("DataReader")]
        public void DataReaderRomLocaleTest()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("AbathurA");
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            byte[] bytes = memoryStream.ToArray();

            using AnnouncerDataReader announcerDataReader = new AnnouncerDataReader(bytes, Localization.FRFR);

            Assert.AreEqual(Localization.FRFR, announcerDataReader.Localization);
            Assert.IsTrue(announcerDataReader.JsonDataDocument.RootElement.TryGetProperty("AbathurA", out JsonElement _));
        }

        [DataTestMethod]
        [DataRow("Adjutant")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetAnnouncerByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerById(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerById(id);
                });

                return;
            }

            BasicAdjutantAsserts(_announcerDataReader.GetAnnouncerById(id));
        }

        [DataTestMethod]
        [DataRow("Adjutant")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetAnnouncerByIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.TryGetAnnouncerById(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_announcerDataReader.TryGetAnnouncerById(id, out _));

                return;
            }

            Assert.IsTrue(_announcerDataReader.TryGetAnnouncerById(id, out Announcer? _));
            if (_announcerDataReader.TryGetAnnouncerById(id, out Announcer? announcer))
            {
                BasicAdjutantAsserts(announcer);
            }
        }

        [DataTestMethod]
        [DataRow("AdjutantAnnouncer")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetAnnouncerByHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerByHyperlinkId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerByHyperlinkId(id);
                });

                return;
            }

            BasicAdjutantAsserts(_announcerDataReader.GetAnnouncerByHyperlinkId(id));
        }

        [DataTestMethod]
        [DataRow("AdjutantAnnouncer")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetAnnouncerByIdHyperlinkIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.TryGetAnnouncerByHyperlinkId(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_announcerDataReader.TryGetAnnouncerByHyperlinkId(id, out _));

                return;
            }

            Assert.IsTrue(_announcerDataReader.TryGetAnnouncerByHyperlinkId(id, out Announcer? announcer));
            BasicAdjutantAsserts(announcer!);
        }

        [DataTestMethod]
        [DataRow("AADJ")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetAnnouncerByAttributeIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerByAttributeId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerByAttributeId(id);
                });

                return;
            }

            BasicAdjutantAsserts(_announcerDataReader.GetAnnouncerByAttributeId(id));
        }

        [DataTestMethod]
        [DataRow("AADJ")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetAnnouncerByAttributeIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.TryGetAnnouncerByAttributeId(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_announcerDataReader.TryGetAnnouncerByAttributeId(id, out _));

                return;
            }

            Assert.IsTrue(_announcerDataReader.TryGetAnnouncerByAttributeId(id, out Announcer? announcer));
            BasicAdjutantAsserts(announcer!);
        }

        [DataTestMethod]
        [DataRow("AI")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void GetAnnouncerByHeroIdTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerByHeroId(id!);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.ThrowsException<KeyNotFoundException>(() =>
                {
                    _ = _announcerDataReader.GetAnnouncerByHeroId(id);
                });

                return;
            }

            BasicAdjutantAsserts(_announcerDataReader.GetAnnouncerByHeroId(id));
        }

        [DataTestMethod]
        [DataRow("AI")]
        [DataRow(null)]
        [DataRow("asdf")]
        public void TryGetAnnouncerByHeroTest(string id)
        {
            if (id is null)
            {
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    _ = _announcerDataReader.TryGetAnnouncerByHeroId(id!, out _);
                });

                return;
            }
            else if (id == "asdf")
            {
                Assert.IsFalse(_announcerDataReader.TryGetAnnouncerByHeroId(id, out _));

                return;
            }

            Assert.IsTrue(_announcerDataReader.TryGetAnnouncerByHeroId(id, out Announcer? announcer));
            BasicAdjutantAsserts(announcer!);
        }

        [TestMethod]
        public void UpdateGameStringsTest()
        {
            Announcer announcer = new Announcer
            {
                Id = "AbathurA",
            };

            using GameStringReader gameStringReader = new GameStringReader(LoadEnusLocalizedStringData());
            gameStringReader.UpdateGameStrings(announcer);

            Assert.ThrowsException<ArgumentNullException>(() => gameStringReader.UpdateGameStrings(announcer: null!));

            Assert.AreEqual("Abathur Announcer", announcer.Name);
            Assert.AreEqual("asdf", announcer.Description?.RawDescription);
            Assert.AreEqual("asdfsn", announcer.SortName);
        }

        private byte[] LoadJsonTestData()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
            writer.WriteStartObject();

            writer.WriteStartObject("AbathurA");
            writer.WriteString("name", "Abathur Announcer");
            writer.WriteString("hyperlinkId", "AbathurAnnouncer");
            writer.WriteString("attributeId", "AB01");
            writer.WriteString("rarity", "Legendary");
            writer.WriteString("category", "Starcraft");
            writer.WriteString("gender", "Unknown");
            writer.WriteString("heroId", "Abathur");
            writer.WriteString("releaseDate", "2014-03-13");
            writer.WriteString("image", "storm_ui_announcer_abathur.png");
            writer.WriteEndObject();

            writer.WriteStartObject("Adjutant");
            writer.WriteString("name", "Adjutant Announcer");
            writer.WriteString("hyperlinkId", "AdjutantAnnouncer");
            writer.WriteString("attributeId", "AADJ");
            writer.WriteString("rarity", "Legendary");
            writer.WriteString("category", "Starcraft");
            writer.WriteString("gender", "Female");
            writer.WriteString("heroId", "AI");
            writer.WriteString("releaseDate", "2018-03-27");
            writer.WriteString("image", "storm_ui_announcer_adjutant.png");
            writer.WriteString("description", "Ann");
            writer.WriteString("sortName", "adj");
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
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
            writer.WriteStartObject("announcer");

            writer.WriteStartObject("name");
            writer.WriteString("AbathurA", "Abathur Announcer");
            writer.WriteString("Adjutant", "Adjutant Announcer");
            writer.WriteEndObject();
            writer.WriteStartObject("description");
            writer.WriteString("AbathurA", "asdf");
            writer.WriteString("Adjutant", "qwer");
            writer.WriteEndObject();
            writer.WriteStartObject("sortName");
            writer.WriteString("AbathurA", "asdfsn");
            writer.WriteString("Adjutant", "qwersn");
            writer.WriteEndObject();

            writer.WriteEndObject(); // end announcer

            writer.WriteEndObject(); // end gamestrings

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }

        private void BasicAdjutantAsserts(Announcer announcer)
        {
            Assert.AreEqual("Adjutant", announcer.Id);
            Assert.AreEqual("Adjutant Announcer", announcer.Name);
            Assert.AreEqual("AdjutantAnnouncer", announcer.HyperlinkId);
            Assert.AreEqual("AADJ", announcer.AttributeId);
            Assert.AreEqual(Rarity.Legendary, announcer.Rarity);
            Assert.AreEqual("Starcraft", announcer.CollectionCategory);
            Assert.AreEqual("Female", announcer.Gender);
            Assert.AreEqual("AI", announcer.HeroId);
            Assert.AreEqual(new DateTime(2018, 3, 27), announcer.ReleaseDate);
            Assert.AreEqual("storm_ui_announcer_adjutant.png", announcer.ImageFileName);
            Assert.AreEqual("Ann", announcer.Description?.RawDescription);
            Assert.AreEqual("adj", announcer.SortName);
        }
    }
}
