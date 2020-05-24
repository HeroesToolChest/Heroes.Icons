using Heroes.Icons.ModelExtensions;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.ModelExtensions
{
    [TestClass]
    public class HeroSkinExtensionsTests
    {
        [TestMethod]
        public void UpdateGameStringsTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

            HeroSkin heroSkin = new HeroSkin
            {
                Id = "AbathurBaseVar3",
            };

            heroSkin.UpdateGameStrings(gameStringDocument);

            Assert.AreEqual("Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.", heroSkin.Description!.RawDescription);
        }

        [TestMethod]
        public void UpdateGameStringsThrowArgumentNullException()
        {
            HeroSkin heroSkin = new HeroSkin
            {
                Id = "AbathurBaseVar3",
            };

            Assert.ThrowsException<ArgumentNullException>(() => heroSkin.UpdateGameStrings(null!));
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
            writer.WriteStartObject("heroskin");

            writer.WriteStartObject("info");
            writer.WriteString("AbathurBaseVar3", "Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.");
            writer.WriteString("AbathurBone", "Abathur, the Evolution Master of Kerrigan's Swarm, works ceaselessly to improve the zerg from the genetic level up. His hate for chaos and imperfection almost rivals his hatred of pronouns.");
            writer.WriteEndObject();
            writer.WriteStartObject("name");
            writer.WriteString("AbathurBaseVar3", "Kaldir Abathur");
            writer.WriteString("AbathurBone", "Bone Abathur");
            writer.WriteEndObject();
            writer.WriteStartObject("searchtext");
            writer.WriteString("AbathurBaseVar3", "Blue");
            writer.WriteString("AbathurBone", "White Pink");
            writer.WriteEndObject();
            writer.WriteStartObject("sortname");
            writer.WriteString("AbathurBaseVar3", "zxAbathurVar1");
            writer.WriteString("AbathurBone", "zxAbathurVar0");
            writer.WriteEndObject();

            writer.WriteEndObject(); // end announcer

            writer.WriteEndObject(); // end gamestrings

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}
