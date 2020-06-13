using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Heroes.Icons.HeroesData
{
    /// <summary>
    /// Contains the information for the heroes-data directory.
    /// </summary>
    public static class HeroesDataDirectory
    {
        /// <summary>
        /// Gets a collection of <see cref="HeroesDataVersion"/>s in the heroes-data directory ordered by newest to oldest (descending).
        /// </summary>
        /// <param name="path">The directory that contains the heroes-data version directories.</param>
        /// <returns>A collection of <see cref="HeroesDataVersion"/>s.</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/> is <see langword="null"/> or whitespace.</exception>
        public static IEnumerable<HeroesDataVersion> GetVersions(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Cannot be null or whitespace", nameof(path));
            }

            List<HeroesDataVersion> heroesDataVersions = new List<HeroesDataVersion>();

            IEnumerable<string> pathDirectories = Directory.EnumerateDirectories(path, "*.*.*.*");

            foreach (string directoryPath in pathDirectories)
            {
                string name = new DirectoryInfo(directoryPath).Name;

                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (HeroesDataVersion.TryParse(name, out HeroesDataVersion? result))
                    {
                        heroesDataVersions.Add(result);
                    }
                }
            }

            return heroesDataVersions.OrderByDescending(x => x);
        }

        /// <summary>
        /// Checks if the version exists as a directory in the <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The directory to check.</param>
        /// <param name="heroesVersion">The version to find.</param>
        /// <returns><see langword="true"/> if the version was found; otherwise <see langword="false"/>.</returns>
        public static bool VersionExists(string path, HeroesDataVersion heroesVersion)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Cannot be null or whitespace", nameof(path));

            if (heroesVersion is null)
                throw new ArgumentNullException(nameof(heroesVersion));

            return Directory.Exists(Path.Combine(path, heroesVersion.ToString()!));
        }
    }
}
