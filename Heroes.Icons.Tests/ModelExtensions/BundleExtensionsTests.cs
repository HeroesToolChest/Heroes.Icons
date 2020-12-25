using Heroes.Icons.ModelExtensions;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.Tests.ModelExtensions
{
    [TestClass]
    public class BundleExtensionsTests
    {
        [TestMethod]
        public void UpdateGameStringsTest()
        {
            using GameStringDocument gameStringDocument = GameStringDocument.Parse(LoadEnusLocalizedStringData());

            Bundle bundle = new Bundle
            {
                Id = "RaiderRexxarBundle",
            };

            bundle.UpdateGameStrings(gameStringDocument);

            Assert.AreEqual("특공대원 렉사르 묶음 상품", bundle.Name);
            Assert.AreEqual("xyzRaiderRexxarBundle", bundle.SortName);
        }

        [TestMethod]
        public void UpdateGameStringsThrowArgumentNullException()
        {
            Bundle bundle = new Bundle
            {
                Id = "RaiderRexxarBundle",
            };

            Assert.ThrowsException<ArgumentNullException>(() => bundle.UpdateGameStrings(null!));
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
            writer.WriteStartObject("bundle");

            writer.WriteStartObject("name");
            writer.WriteString("RaiderRexxarBundle", "특공대원 렉사르 묶음 상품");
            writer.WriteEndObject();
            writer.WriteStartObject("sortname");
            writer.WriteString("RaiderRexxarBundle", "xyzRaiderRexxarBundle");
            writer.WriteEndObject();

            writer.WriteEndObject(); // end

            writer.WriteEndObject(); // end gamestrings

            writer.WriteEndObject();

            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}
