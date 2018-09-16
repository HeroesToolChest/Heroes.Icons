using System.Collections.Generic;
using Heroes.Icons.Models;

namespace Heroes.Icons.Xml
{
    public interface IBattlegroundsXml
    {
        /// <summary>
        /// Returns a Battleground given the map id.
        /// </summary>
        /// <param name="mapId">Unique map id.</param>
        /// <returns></returns>
        Battleground GetBattleground(string mapId);

        /// <summary>
        /// Returns a list of all battlegrounds.
        /// </summary>
        /// <param name="includeBrawl">Include brawls.</param>
        /// <returns></returns>
        List<Battleground> ListOfBattlegrounds(bool includeBrawl = false);

        /// <summary>
        /// Returns a list of all brawl maps.
        /// </summary>
        /// <returns></returns>
        List<Battleground> ListOfBrawlBattlegrounds();

        /// <summary>
        /// Returns the count of all battlegrounds.
        /// </summary>
        /// <param name="includeBrawl">Include brawls.</param>
        /// <returns></returns>
        int TotalCountOfBattlegrounds(bool includeBrawl = false);
    }
}