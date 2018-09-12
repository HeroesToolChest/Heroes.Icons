using System.Collections.Generic;
using Heroes.Icons.Models;

namespace Heroes.Icons.Xml
{
    public interface IMatchAwardsXml
    {
        /// <summary>
        /// Returns a MatchAward given the award reference id.
        /// </summary>
        /// <param name="awardId">The reference id.</param>
        /// <returns></returns>
        MatchAward GetMatchAward(string awardId);

        /// <summary>
        /// Returns a list of all awards.
        /// </summary>
        /// <returns></returns>
        List<MatchAward> ListOfAwards();

        /// <summary>
        /// Returns the total count of awards.
        /// </summary>
        /// <returns></returns>
        int TotalCountOfAwards();
    }
}