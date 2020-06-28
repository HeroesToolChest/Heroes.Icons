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
        private const string _heroFileTemplateName = "herodata_{0}_localized.json";

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

            VersionCheck(ref version);

            if (version is null)
                throw new ArgumentNullException(nameof(version));

            string versionString = version.ToString();

            string dataPath = string.Empty;
            string gamestringPath = string.Empty;

            bool dataDuplicate = false;
            bool gameStringDuplicate = false;

            // check .hdp.json file for duplicates
            JsonDocument hdpJsonDocument = JsonDocument.Parse(File.ReadAllBytes(Path.Join(_heroesDataDirectoryPath, versionString, _hdpJsonFile)));
            if (hdpJsonDocument.RootElement.TryGetProperty("duplicate", out JsonElement duplicateElement))
            {
                if (duplicateElement.TryGetProperty("data", out JsonElement dataElement) && HeroesDataVersion.TryParse(dataElement.GetString(), out HeroesDataVersion? dataVersion))
                {
                    dataPath = Path.Join(
                        _heroesDataDirectoryPath,
                        dataVersion.ToString(),
                        DataDirectoryName,
                        string.Format(CultureInfo.InvariantCulture, _heroFileTemplateName, dataVersion.Build));

                    dataDuplicate = true;
                }

                if (duplicateElement.TryGetProperty("gamestrings", out JsonElement gameStringsElement) && HeroesDataVersion.TryParse(gameStringsElement.GetString(), out HeroesDataVersion? gameStringsVersion))
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
                    string.Format(CultureInfo.InvariantCulture, _heroFileTemplateName, version.Build));
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

                return HeroDataDocument.Parse(dataPath, GameStringDocument.Parse(gamestringPath, localization));
            }

            return HeroDataDocument.Parse(dataPath, localization);
        }

        private void VersionCheck(ref HeroesDataVersion version)
        {
            if (OldestVersion is null || NewestVersion is null)
                return;

            if (version < OldestVersion)
                version = OldestVersion;
            else if (version > NewestVersion)
                version = NewestVersion;
        }
    }
}
