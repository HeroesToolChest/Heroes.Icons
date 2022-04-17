using Heroes.Icons.DataDocument;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons.Tests.DataDocument;

[TestClass]
public class BoostDataDocumentTests : DataDocumentBase, IDataDocument
{
    private readonly string _dataFile = Path.Combine("JsonData", "boostdata_76893_kokr.json");
    private readonly string _jsonGameStringFileKOKR = Path.Combine("JsonGameStrings", "gamestrings_76893_kokr.json");
    private readonly string _jsonGameStringFileFRFR = Path.Combine("JsonGameStrings", "gamestrings_76893_frfr.json");

    private readonly BoostDataDocument _boostDataDocument;

    public BoostDataDocumentTests()
    {
        _boostDataDocument = BoostDataDocument.Parse(LoadJsonTestData(), Localization.ENUS);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileFRFR);
        using BoostDataDocument document = BoostDataDocument.Parse(_dataFile, gameStringDocument);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.TryGetBoostById("30DayPromo", out Boost? boost));
        Assert.AreEqual("30 Day Boost", boost!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileLocaleTest()
    {
        using BoostDataDocument document = BoostDataDocument.Parse(_dataFile, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentFileTest()
    {
        using BoostDataDocument document = BoostDataDocument.Parse(_dataFile);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using BoostDataDocument document = BoostDataDocument.Parse(GetBytesForROM("30DayPromo"), gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.TryGetBoostById("30DayPromo", out Boost? boost));
        Assert.AreEqual("30 Day Boost", boost!.Name);
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentROMLocaleTest()
    {
        using BoostDataDocument document = BoostDataDocument.Parse(GetBytesForROM("30DayPromo"), Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BoostDataDocument document = BoostDataDocument.Parse(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGSDTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BoostDataDocument document = BoostDataDocument.Parse(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public void DataDocumentStreamWithGameStringStreamTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BoostDataDocument document = BoostDataDocument.Parse(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamAsyncTest()
    {
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BoostDataDocument document = await BoostDataDocument.ParseAsync(stream, Localization.FRFR);

        Assert.AreEqual(Localization.FRFR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringDocumentAsyncTest()
    {
        using GameStringDocument gameStringDocument = GameStringDocument.Parse(_jsonGameStringFileKOKR);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BoostDataDocument document = await BoostDataDocument.ParseAsync(stream, gameStringDocument);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [TestMethod]
    [TestCategory("DataDocument")]
    public async Task DataDocumentStreamWithGameStringStreamAsyncTest()
    {
        using FileStream streamGameString = new FileStream(_jsonGameStringFileKOKR, FileMode.Open);
        using FileStream stream = new FileStream(_dataFile, FileMode.Open);
        using BoostDataDocument document = await BoostDataDocument.ParseAsync(stream, streamGameString);

        Assert.AreEqual(Localization.KOKR, document.Localization);
        Assert.IsTrue(document.JsonDataDocument.RootElement.TryGetProperty("30DayPromo", out JsonElement _));
    }

    [DataTestMethod]
    [DataRow("30DayPromo")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetBoostByIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _boostDataDocument.GetBoostById(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _boostDataDocument.GetBoostById(id);
            });

            return;
        }

        Boost30DayPromoAsserts(_boostDataDocument.GetBoostById(id));
    }

    [DataTestMethod]
    [DataRow("30DayPromo")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetBoostByIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_boostDataDocument.TryGetBoostById(id, out _));

            return;
        }

        Assert.IsTrue(_boostDataDocument.TryGetBoostById(id, out Boost? _));
        if (_boostDataDocument.TryGetBoostById(id, out Boost? boost))
        {
            Boost30DayPromoAsserts(boost);
        }
    }

    [DataTestMethod]
    [DataRow("30DayStimpackPromo")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void GetBoostByHyperlinkIdTest(string id)
    {
        if (id is null)
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = _boostDataDocument.GetBoostByHyperlinkId(id!);
            });

            return;
        }
        else if (id == "asdf")
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                _ = _boostDataDocument.GetBoostByHyperlinkId(id);
            });

            return;
        }

        Boost30DayPromoAsserts(_boostDataDocument.GetBoostByHyperlinkId(id));
    }

    [DataTestMethod]
    [DataRow("30DayStimpackPromo")]
    [DataRow(null)]
    [DataRow("asdf")]
    public void TryGetBoostByIdHyperlinkIdTest(string? id)
    {
        if (id is null || id == "asdf")
        {
            Assert.IsFalse(_boostDataDocument.TryGetBoostByHyperlinkId(id, out _));

            return;
        }

        Assert.IsTrue(_boostDataDocument.TryGetBoostByHyperlinkId(id, out Boost? boost));
        Boost30DayPromoAsserts(boost!);
    }

    private static byte[] LoadJsonTestData()
    {
        using MemoryStream memoryStream = new MemoryStream();
        using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);
        writer.WriteStartObject();

        writer.WriteStartObject("30DayPromo");
        writer.WriteString("name", "30 Day Boost");
        writer.WriteString("hyperlinkId", "30DayStimpackPromo");
        writer.WriteString("sortName", "xcv30DayStimpackPromo");
        writer.WriteString("event", "LTO");
        writer.WriteString("releaseDate", "2014-03-13");
        writer.WriteEndObject();

        writer.WriteEndObject();

        writer.Flush();

        return memoryStream.ToArray();
    }

    private static void Boost30DayPromoAsserts(Boost boost)
    {
        Assert.AreEqual("30DayPromo", boost.Id);
        Assert.AreEqual("30 Day Boost", boost.Name);
        Assert.AreEqual("30DayStimpackPromo", boost.HyperlinkId);
        Assert.AreEqual("xcv30DayStimpackPromo", boost.SortName);
        Assert.AreEqual("LTO", boost.EventName);
    }
}
