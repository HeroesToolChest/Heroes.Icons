﻿using Heroes.Icons.DataDocument;
using Heroes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Heroes.Icons.HeroesData.Tests;

[TestClass]
public class HeroesDataDirectoryTests
{
    private readonly string _testFolder = "heroesdataTestFolders";
    private readonly HeroesDataDirectory _heroesDataDirectory;

    public HeroesDataDirectoryTests()
    {
        _heroesDataDirectory = new HeroesDataDirectory("heroesdataTestFolders");
    }

    [TestMethod]
    public void HeroesDataDirectoryContructorThrowExceptionsTest()
    {
        Assert.ThrowsException<ArgumentException>(() => new HeroesDataDirectory(null!));
        Assert.ThrowsException<ArgumentException>(() => new HeroesDataDirectory(string.Empty));
        Assert.ThrowsException<DirectoryNotFoundException>(() => new HeroesDataDirectory("someDirectory"));
    }

    [TestMethod]
    public void NoVersionsLoadedTest()
    {
        HeroesDataDirectory heroesDataDirectory = new HeroesDataDirectory(Path.Join("heroesdataTestFolders", "someOther"));
        Assert.IsNull(heroesDataDirectory.NewestVersion);
        Assert.IsNull(heroesDataDirectory.OldestVersion);
    }

    [TestMethod]
    public void GetVersionsStaticMethodTest()
    {
        List<HeroesDataVersion> list = HeroesDataDirectory.GetVersions(_testFolder).OrderByDescending(x => x).ToList();
        Assert.AreEqual(0, list.Where(x => x.IsPtr).Count());
        Assert.AreEqual(6, list.Count);

        List<HeroesDataVersion> listWithPtr = HeroesDataDirectory.GetVersions(_testFolder, true).OrderByDescending(x => x).ToList();
        Assert.IsTrue(listWithPtr.Where(x => x.IsPtr).Any());
        Assert.AreEqual(8, listWithPtr.Count);
    }

    [TestMethod]
    public void GetVersionsStaticMethodExceptionsTest()
    {
        Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(null!).ToList());
        Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(string.Empty).ToList());
        Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.GetVersions(" ").ToList());
    }

    [TestMethod]
    public void VersionExistsStaticMethodTest()
    {
        Assert.IsTrue(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(2, 47, 3, 76124)));
        Assert.IsTrue(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(2, 48, 0, 76268, true)));
        Assert.IsFalse(HeroesDataDirectory.VersionExists(_testFolder, new HeroesDataVersion(77, 23, 1, 76268, true)));
    }

    [TestMethod]
    public void VersionExistsStaticMethodExceptionsTest()
    {
        Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(null!, new HeroesDataVersion(1, 1, 1, 1)));
        Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(string.Empty, new HeroesDataVersion(1, 1, 1, 1)));
        Assert.ThrowsException<ArgumentException>(() => HeroesDataDirectory.VersionExists(" ", new HeroesDataVersion(1, 1, 1, 1)));
        Assert.ThrowsException<ArgumentNullException>(() => HeroesDataDirectory.VersionExists("path", null!));
    }

    [TestMethod]
    public void VersionsTest()
    {
        List<HeroesDataVersion> list = _heroesDataDirectory.Versions.ToList();
        Assert.AreEqual(8, list.Count);
    }

    [TestMethod]
    public void VersionExistsTest()
    {
        Assert.IsFalse(_heroesDataDirectory.VersionExists(new HeroesDataVersion(-1, 234, 234, 34234234)));
        Assert.IsTrue(_heroesDataDirectory.VersionExists(new HeroesDataVersion(2, 47, 3, 76124)));
    }

    [TestMethod]
    public void BuildExistsTest()
    {
        Assert.IsFalse(_heroesDataDirectory.BuildExists(34234234));
        Assert.IsTrue(_heroesDataDirectory.BuildExists(76124));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    [DataRow(2, 40, 3, 70000, false, false, Localization.KOKR)]
    [DataRow(2, 48, 3, 77205, false, false, Localization.KOKR)]
    [DataRow(2, 48, 3, 77205, false, true, Localization.KOKR)]
    [DataRow(2, 48, 4, 77406, false, true, Localization.KOKR)]
    [DataRow(2, 48, 4, 77407, false, true, Localization.ENUS)]
    [DataRow(8, 50, 3, 9999999, false, false, Localization.KOKR)]
    public void HeroDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        HeroDataDocument dataDocument = _heroesDataDirectory.HeroData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetHeroById("Abathur", out Hero? hero, false, false, false, false));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
    }

    [DataTestMethod]
    [DataRow(2, 48, 3, 77205, false, true, Localization.KOKR)]
    public void HeroDataLoadDuplicateDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        HeroDataDocument heroDataDocument = _heroesDataDirectory.HeroData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(heroDataDocument.TryGetHeroById("Abathur", out Hero? hero, false, false, false, false));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty("this is some text."));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(hero!.Description?.RawDescription));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void AnnouncerDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        AnnouncerDataDocument dataDocument = _heroesDataDirectory.AnnouncerData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetAnnouncerById("AbathurA", out Announcer? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false)]
    public void BehaviorVeterancyDataTest(int major, int minor, int revision, int build, bool isPtr)
    {
        BehaviorVeterancyDataDocument dataDocument = _heroesDataDirectory.BehaviorVeterancyData(new HeroesDataVersion(major, minor, revision, build, isPtr));
        Assert.IsTrue(dataDocument.TryGetBehaviorVeterancyById("alteracpass-CoreScaling", out BehaviorVeterancy? value));

        Assert.IsTrue(value!.CombineModifications);
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void EmoticonDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        EmoticonDataDocument dataDocument = _heroesDataDirectory.EmoticonData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetEmoticonById("cat_blink_anim", out Emoticon? value));

        if (gamestrings)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Description?.RawDescription));
        }
        else
        {
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Description?.RawDescription));
        }
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void EmoticonPackDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        EmoticonPackDataDocument dataDocument = _heroesDataDirectory.EmoticonPackData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetEmoticonPackById("CassiaEmoticonPack2", out EmoticonPack? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void HeroSkinDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        HeroSkinDataDocument dataDocument = _heroesDataDirectory.HeroSkinData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetHeroSkinById("AbathurBaseVar3", out HeroSkin? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void MatchAwardDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        MatchAwardDataDocument dataDocument = _heroesDataDirectory.MatchAwardData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetMatchAwardById("HatTrick", out MatchAward? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void MountDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        MountDataDocument dataDocument = _heroesDataDirectory.MountData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetMountById("AlarakTaldarimMarch", out Mount? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void PortraitPackDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        PortraitPackDataDocument dataDocument = _heroesDataDirectory.PortraitPackData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetPortraitPackById("AbathurToys18Portrait", out PortraitPack? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void RewardPortraitDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        RewardPortraitDataDocument dataDocument = _heroesDataDirectory.RewardPortraitData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetRewardPortraitById("1YearAnniversaryPortrait", out RewardPortrait? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void SprayDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        SprayDataDocument dataDocument = _heroesDataDirectory.SprayData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetSprayById("SprayAnimatedCookieAbathur", out Spray? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void UnitDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        UnitDataDocument dataDocument = _heroesDataDirectory.UnitData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetUnitById("AbathurEvolvedMonstrosity", out Unit? value, false, false));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Description?.RawDescription));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Description?.RawDescription));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void VoiceLineDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        VoiceLineDataDocument dataDocument = _heroesDataDirectory.VoiceLineData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetVoiceLineById("AbathurBase_VoiceLine01", out VoiceLine? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [DataTestMethod]
    [DataRow(2, 47, 3, 76124, false, true, Localization.KOKR)]
    [DataRow(2, 47, 3, 76124, false, false, Localization.KOKR)]
    public void BannerDataTest(int major, int minor, int revision, int build, bool isPtr, bool gamestrings, Localization localization)
    {
        BannerDataDocument dataDocument = _heroesDataDirectory.BannerData(new HeroesDataVersion(major, minor, revision, build, isPtr), gamestrings, localization);
        Assert.IsTrue(dataDocument.TryGetBannerById("BannerD3DemonHunter", out Banner? value));

        if (gamestrings)
            Assert.IsTrue(!string.IsNullOrEmpty(value!.Name));
        else
            Assert.IsFalse(!string.IsNullOrEmpty(value!.Name));
    }

    [TestMethod]
    public void DataExceptionsTest()
    {
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.HeroData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.AnnouncerData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.BannerData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.BehaviorVeterancyData(null!));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.EmoticonData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.EmoticonPackData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.HeroSkinData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.MatchAwardData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.MountData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.PortraitPackData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.RewardPortraitData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.SprayData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UnitData(null!, true, Localization.KOKR));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.VoiceLineData(null!, true, Localization.KOKR));
    }

    [TestMethod]
    public void UpdateGameStringAnnouncerTest()
    {
        using AnnouncerDataDocument dataDocument = _heroesDataDirectory.AnnouncerData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        Announcer data = dataDocument.GetAnnouncerById("AbathurA");
        Assert.AreEqual("아바투르 아나운서", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("annNane", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringBannerTest()
    {
        using BannerDataDocument dataDocument = _heroesDataDirectory.BannerData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        Banner data = dataDocument.GetBannerById("BannerD3DemonHunter");
        Assert.AreEqual("악마사냥꾼 깃발", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("bannerName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringEmoticonTest()
    {
        using EmoticonDataDocument dataDocument = _heroesDataDirectory.EmoticonData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        Emoticon data = dataDocument.GetEmoticonById("cat_blink_anim");
        Assert.AreEqual("Unknown", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("blinky blink", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringEmoticonPackTest()
    {
        using EmoticonPackDataDocument dataDocument = _heroesDataDirectory.EmoticonPackData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        EmoticonPack data = dataDocument.GetEmoticonPackById("CassiaEmoticonPack2");
        Assert.AreEqual("카시아 팩 2", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("emotPackName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringHeroTest()
    {
        using HeroDataDocument dataDocument = _heroesDataDirectory.HeroData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        Hero data = dataDocument.GetHeroById("Abathur", false, false, false, false);
        Assert.AreEqual("전장 어디에서나 전투에 영향을 줄 수 있는 독특한 영웅입니다.", data.Description?.RawDescription);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("heroDescription", data.Description?.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringHeroSkinTest()
    {
        using HeroSkinDataDocument dataDocument = _heroesDataDirectory.HeroSkinData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        HeroSkin data = dataDocument.GetHeroSkinById("AbathurBaseVar3");
        Assert.AreEqual("칼디르 아바투르", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("heroskinName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringMatchAwardTest()
    {
        using MatchAwardDataDocument dataDocument = _heroesDataDirectory.MatchAwardData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        MatchAward data = dataDocument.GetMatchAwardById("HatTrick");
        Assert.AreEqual("기선 제압자", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("awardName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringMountTest()
    {
        using MountDataDocument dataDocument = _heroesDataDirectory.MountData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        Mount data = dataDocument.GetMountById("AlarakTaldarimMarch");
        Assert.AreEqual("군주의 승천", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("mountName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringPortraitPackTest()
    {
        using PortraitPackDataDocument dataDocument = _heroesDataDirectory.PortraitPackData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        PortraitPack data = dataDocument.GetPortraitPackById("AbathurToys18Portrait");
        Assert.AreEqual("애벌레투르 초상화", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("portraitName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringRewardPortraitTest()
    {
        using RewardPortraitDataDocument dataDocument = _heroesDataDirectory.RewardPortraitData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        RewardPortrait data = dataDocument.GetRewardPortraitById("1YearAnniversaryPortrait");
        Assert.AreEqual("1주년 기념 초상화", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("rewardportraitName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringSprayTest()
    {
        using SprayDataDocument dataDocument = _heroesDataDirectory.SprayData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        Spray data = dataDocument.GetSprayById("SprayAnimatedCookieAbathur");
        Assert.AreEqual("과자 아바투르", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("sprayName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringUnitTest()
    {
        using UnitDataDocument dataDocument = _heroesDataDirectory.UnitData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        Unit data = dataDocument.GetUnitById("AbathurEvolvedMonstrosity", false, false);
        Assert.AreEqual("some description", data.Description?.RawDescription);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("unitDescription", data.Description?.RawDescription);
    }

    [TestMethod]
    public void UpdateGameStringVoiceLineTest()
    {
        using VoiceLineDataDocument dataDocument = _heroesDataDirectory.VoiceLineData(new HeroesDataVersion(2, 47, 3, 76124), true, Localization.KOKR);
        VoiceLine data = dataDocument.GetVoiceLineById("AbathurBase_VoiceLine01");
        Assert.AreEqual("군단을 위하여", data.Name);

        _heroesDataDirectory.UpdateGameString(data, new HeroesDataVersion(2, 48, 4, 77407), Localization.ENUS);
        Assert.AreEqual("voiceName", data.Name);
    }

    [TestMethod]
    public void UpdateGameStringsExceptionTest()
    {
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(announcer: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new Announcer(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(banner: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new Banner(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(emoticon: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new Emoticon(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(emoticonPack: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new EmoticonPack(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(hero: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new Hero(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(heroSkin: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new HeroSkin(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(matchAward: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new MatchAward(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(mount: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new Mount(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(portraitPack: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new PortraitPack(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(rewardPortrait: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new RewardPortrait(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(spray: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new Spray(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(unit: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new Unit(), null!, Localization.ENUS));

        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(voiceLine: null!, new HeroesDataVersion(0, 0, 0, 0), Localization.ENUS));
        Assert.ThrowsException<ArgumentNullException>(() => _heroesDataDirectory.UpdateGameString(new VoiceLine(), null!, Localization.ENUS));
    }

    [TestMethod]
    public void ReloadVersionsTest()
    {
        int count = _heroesDataDirectory.Versions.Count;
        Assert.AreEqual(count, _heroesDataDirectory.ReloadVersions());
    }
}
