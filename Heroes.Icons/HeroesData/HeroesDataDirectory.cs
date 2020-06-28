using Heroes.Icons.DataDocument;
using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Heroes.Icons.HeroesData
{
    /// <summary>
    /// Contains the information for the heroes-data directory.
    /// </summary>
    [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "need lower")]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "will be disposed by caller.")]
    public class HeroesDataDirectory
    {
        private const string _hdpJsonFile = ".hdp.json";
        private const string _announcerFileTemplateName = "announcerdata_{0}_localized.json";
        private const string _bannerFileTemplateName = "bannerdata_{0}_localized.json";
        private const string _behaviorVeterancyFileTemplateName = "behaviorveterancydata_{0}_localized.json";
        private const string _emoticonFileTemplateName = "emoticondata_{0}_localized.json";
        private const string _emoticonPackFileTemplateName = "emoticonpackdata_{0}_localized.json";
        private const string _heroFileTemplateName = "herodata_{0}_localized.json";
        private const string _heroSkinFileTemplateName = "heroskindata_{0}_localized.json";
        private const string _matchAwardFileTemplateName = "matchawarddata_{0}_localized.json";
        private const string _mountFileTemplateName = "mountdata_{0}_localized.json";
        private const string _portraitPackFileTemplateName = "portraitpackdata_{0}_localized.json";
        private const string _rewardPortraitFileTemplateName = "rewardportraitdata_{0}_localized.json";
        private const string _sprayFileTemplateName = "spraydata_{0}_localized.json";
        private const string _unitFileTemplateName = "unitdata_{0}_localized.json";
        private const string _voiceLineFileTemplateName = "voicelinedata_{0}_localized.json";

        private const string _gameStringTemplateName = "gamestrings_{0}_{1}.json";

        private readonly string _heroesDataDirectoryPath;
        private readonly SortedSet<HeroesDataVersion> _versions;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroesDataDirectory"/> class. Loads all the version directories.
        /// </summary>
        /// <param name="heroesDataPath">The path of the heroes-data directory.</param>
        public HeroesDataDirectory(string heroesDataPath = "heroesdata")
        {
            if (string.IsNullOrWhiteSpace(heroesDataPath))
                throw new ArgumentException("Cannot be null or whitespace", nameof(heroesDataPath));

            if (!Directory.Exists(heroesDataPath))
                throw new DirectoryNotFoundException("Path does not exist as a directory");

            _heroesDataDirectoryPath = heroesDataPath;

            _versions = new SortedSet<HeroesDataVersion>(GetVersions(_heroesDataDirectoryPath, true));
        }

        /// <summary>
        /// Gets the newest (latest) version.
        /// </summary>
        public HeroesDataVersion? NewestVersion => _versions.Max;

        /// <summary>
        /// Gets the oldest (earliest) version.
        /// </summary>
        public HeroesDataVersion? OldestVersion => _versions.Min;

        /// <summary>
        /// Gets a collection of versions.
        /// </summary>
        public IEnumerable<HeroesDataVersion> Versions => _versions;

        /// <summary>
        /// Gets or sets the name of the data directory.
        /// </summary>
        public string DataDirectoryName { get; set; } = "data";

        /// <summary>
        /// Gets or sets the name of the gamestring directory.
        /// </summary>
        public string GameStringsDirectoryName { get; set; } = "gamestrings";

        /// <summary>
        /// Gets a collection of <see cref="HeroesDataVersion"/>s from the <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path that contains the version directories.</param>
        /// <param name="includePtr"><see langword="true"/> to include the ptr versions.</param>
        /// <returns>A collection of <see cref="HeroesDataVersion"/>s.</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/> is <see langword="null"/> or whitespace.</exception>
        public static IEnumerable<HeroesDataVersion> GetVersions(string path, bool includePtr = false)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Cannot be null or whitespace", nameof(path));

            IEnumerable<string> pathDirectories = Directory.EnumerateDirectories(path, "*.*.*.*");

            foreach (string directoryPath in pathDirectories)
            {
                ReadOnlySpan<char> pathSpan = Path.TrimEndingDirectorySeparator(directoryPath.AsSpan());
                ReadOnlySpan<char> name = pathSpan.Slice(pathSpan.LastIndexOf(Path.DirectorySeparatorChar) + 1);

                if (!name.IsEmpty)
                {
                    if (HeroesDataVersion.TryParse(name, out HeroesDataVersion? result))
                    {
                        if (result.IsPtr && !includePtr)
                            continue;

                        yield return result;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the version exists as a directory in the <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The directory to check.</param>
        /// <param name="heroesVersion">The version to find.</param>
        /// <returns><see langword="true"/> if the <paramref name="heroesVersion"/> directory was found at the <paramref name="path"/>; otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/> is <see langword="null"/> or whitespace.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="heroesVersion"/> is <see langword="null"/>.</exception>
        public static bool VersionExists(string path, HeroesDataVersion heroesVersion)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Cannot be null or whitespace", nameof(path));

            if (heroesVersion is null)
                throw new ArgumentNullException(nameof(heroesVersion));

            return Directory.Exists(Path.Combine(path, heroesVersion.ToString()!));
        }

        /// <summary>
        /// Checks if the version exists.
        /// </summary>
        /// <param name="heroesVersion">The version to find.</param>
        /// <returns><see langword="true"/> if the <paramref name="heroesVersion"/> exists, otherwise <see langword="false"/>.</returns>
        public bool VersionExists(HeroesDataVersion heroesVersion) => _versions.Contains(heroesVersion);

        /// <summary>
        /// Checks if the build exists.
        /// </summary>
        /// <param name="build">The build to find.</param>
        /// <returns><see langword="true"/> if the <paramref name="build"/> exists, otherwise <see langword="false"/>.</returns>
        public bool BuildExists(int build) => _versions.Any(x => x.Build == build);

        /// <summary>
        /// Loads the <see cref="AnnouncerDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="AnnouncerDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public AnnouncerDataDocument AnnouncerData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _announcerFileTemplateName);

            if (includeGameStrings)
                return AnnouncerDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return AnnouncerDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="BannerDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="BannerDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public BannerDataDocument BannerData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _bannerFileTemplateName);

            if (includeGameStrings)
                return BannerDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return BannerDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="BehaviorVeterancyDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <returns>The <see cref="BehaviorVeterancyDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public BehaviorVeterancyDataDocument BehaviorVeterancyData(HeroesDataVersion version)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, _) = GetDataAndGameStringPaths(version, false, Localization.ENUS, _behaviorVeterancyFileTemplateName);

            return BehaviorVeterancyDataDocument.Parse(dataPath);
        }

        /// <summary>
        /// Loads the <see cref="EmoticonDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="EmoticonDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public EmoticonDataDocument EmoticonData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _emoticonFileTemplateName);

            if (includeGameStrings)
                return EmoticonDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return EmoticonDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="EmoticonPackDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="EmoticonPackDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public EmoticonPackDataDocument EmoticonPackData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _emoticonPackFileTemplateName);

            if (includeGameStrings)
                return EmoticonPackDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return EmoticonPackDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="HeroDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="HeroDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public HeroDataDocument HeroData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _heroFileTemplateName);

            if (includeGameStrings)
                return HeroDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return HeroDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="HeroSkinDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="HeroSkinDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public HeroSkinDataDocument HeroSkinData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _heroSkinFileTemplateName);

            if (includeGameStrings)
                return HeroSkinDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return HeroSkinDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="MatchAwardDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="MatchAwardDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public MatchAwardDataDocument MatchAwardData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _matchAwardFileTemplateName);

            if (includeGameStrings)
                return MatchAwardDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return MatchAwardDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="MountDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="MountDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public MountDataDocument MountData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _mountFileTemplateName);

            if (includeGameStrings)
                return MountDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return MountDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="PortraitPackDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="PortraitPackDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public PortraitPackDataDocument PortraitPackData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _portraitPackFileTemplateName);

            if (includeGameStrings)
                return PortraitPackDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return PortraitPackDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="RewardPortraitDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="RewardPortraitDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public RewardPortraitDataDocument RewardPortraitData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _rewardPortraitFileTemplateName);

            if (includeGameStrings)
                return RewardPortraitDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return RewardPortraitDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="SprayDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="SprayDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public SprayDataDocument SprayData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _sprayFileTemplateName);

            if (includeGameStrings)
                return SprayDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return SprayDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="UnitDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="UnitDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public UnitDataDocument UnitData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _unitFileTemplateName);

            if (includeGameStrings)
                return UnitDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return UnitDataDocument.Parse(dataPath, localization);
        }

        /// <summary>
        /// Loads the <see cref="VoiceLineDataDocument"/> from the <paramref name="version"/> directory.
        /// </summary>
        /// <param name="version">The version directory to load the data from.</param>
        /// <param name="includeGameStrings">If <see langword="true"/>, loads the gamestrings from the gamestrings directory.</param>
        /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
        /// <returns>The <see cref="VoiceLineDataDocument"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="version"/> is <see langword="null"/>.</exception>
        public VoiceLineDataDocument VoiceLineData(HeroesDataVersion version, bool includeGameStrings = true, Localization localization = Localization.ENUS)
        {
            if (version is null)
                throw new ArgumentNullException(nameof(version));

            (string dataPath, string gameStringPath) = GetDataAndGameStringPaths(version, includeGameStrings, localization, _voiceLineFileTemplateName);

            if (includeGameStrings)
                return VoiceLineDataDocument.Parse(dataPath, GameStringDocument.Parse(gameStringPath, localization));
            else
                return VoiceLineDataDocument.Parse(dataPath, localization);
        }

        private (string DataPath, string GameStringPath) GetDataAndGameStringPaths(HeroesDataVersion version, bool includeGameStrings, Localization localization, string dataTemplateName)
        {
            if (_versions.Count > 0)
            {
                if (version < OldestVersion)
                    version = OldestVersion;
                else if (version > NewestVersion)
                    version = NewestVersion;
            }

            string versionString = version.ToString();

            string dataPath = string.Empty;
            string gamestringPath = string.Empty;

            bool dataDuplicate = false;
            bool gameStringDuplicate = false;

            // check .hdp.json file for duplicates
            JsonDocument hdpJsonDocument = JsonDocument.Parse(File.ReadAllBytes(Path.Join(_heroesDataDirectoryPath, versionString, _hdpJsonFile)));
            if (hdpJsonDocument.RootElement.TryGetProperty("duplicate", out JsonElement duplicateElement))
            {
                if (duplicateElement.TryGetProperty(DataDirectoryName, out JsonElement dataElement) && HeroesDataVersion.TryParse(dataElement.GetString(), out HeroesDataVersion? dataVersion))
                {
                    dataPath = Path.Join(
                        _heroesDataDirectoryPath,
                        dataVersion.ToString(),
                        DataDirectoryName,
                        string.Format(CultureInfo.InvariantCulture, dataTemplateName, dataVersion.Build));

                    dataDuplicate = true;
                }

                if (duplicateElement.TryGetProperty(GameStringsDirectoryName, out JsonElement gameStringsElement) && HeroesDataVersion.TryParse(gameStringsElement.GetString(), out HeroesDataVersion? gameStringsVersion))
                {
                    gamestringPath = Path.Join(
                        _heroesDataDirectoryPath,
                        gameStringsVersion.ToString(),
                        GameStringsDirectoryName,
                        string.Format(CultureInfo.InvariantCulture, _gameStringTemplateName, gameStringsVersion.Build, localization.ToString().ToLowerInvariant()));

                    gameStringDuplicate = true;
                }
            }

            if (!dataDuplicate)
            {
                dataPath = Path.Join(
                    _heroesDataDirectoryPath,
                    versionString,
                    DataDirectoryName,
                    string.Format(CultureInfo.InvariantCulture, dataTemplateName, version.Build));
            }

            if (includeGameStrings)
            {
                if (!gameStringDuplicate)
                {
                    gamestringPath = Path.Join(
                        _heroesDataDirectoryPath,
                        versionString,
                        GameStringsDirectoryName,
                        string.Format(CultureInfo.InvariantCulture, _gameStringTemplateName, version.Build, localization.ToString().ToLowerInvariant()));
                }
            }

            return (dataPath, gamestringPath);
        }
    }
}
