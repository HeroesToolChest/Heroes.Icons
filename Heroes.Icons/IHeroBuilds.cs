using System.Collections.Generic;
using Heroes.Icons.Models;

namespace Heroes.Icons
{
    public interface IHeroBuilds
    {
        /// <summary>
        /// Gets a list of all builds numbers.
        /// </summary>
        List<string> Builds { get; }

        /// <summary>
        /// Gets the newest (highest) build number.
        /// </summary>
        int NewestBuild { get; }

        /// <summary>
        /// Gets the oldest (lowest) build number.
        /// </summary>
        int OldestBuild { get; }

        /// <summary>
        /// Returns data about a specific build.
        /// </summary>
        /// <param name="build">The build number.</param>
        /// <returns></returns>
        HeroPatchInfo GetPatchInfo(int build);

        /// <summary>
        /// Returns data about a specific build.
        /// </summary>
        /// <param name="fullVersion">The full build version.</param>
        /// <returns></returns>
        HeroPatchInfo GetPatchInfo(string fullVersion);
    }
}