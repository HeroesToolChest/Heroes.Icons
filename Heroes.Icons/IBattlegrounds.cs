using System.Collections.Generic;
using Heroes.Icons.Models;

namespace Heroes.Icons
{
    public interface IBattlegrounds
    {
        /// <summary>
        /// Returns a Battleground given the map id.
        /// </summary>
        /// <param name="name">The unique map id or name.</param>
        /// <returns></returns>
        Battleground Battleground(string name);

        /// <summary>
        /// Returns a collection of all battlegrounds.
        /// </summary>
        /// <param name="includeBrawl">Include brawls.</param>
        /// <returns></returns>
        IEnumerable<Battleground> Battlegrounds(bool includeBrawl = false);

        /// <summary>
        /// Returns a collection of all brawl maps.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Battleground> BrawlBattlegrounds();

        /// <summary>
        /// Returns the number of battlegrounds.
        /// </summary>
        /// <param name="includeBrawl">Include brawls.</param>
        /// <returns></returns>
        int Count(bool includeBrawl = false);
    }
}