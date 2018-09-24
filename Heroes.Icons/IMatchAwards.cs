using System.Collections.Generic;
using Heroes.Icons.Models;

namespace Heroes.Icons
{
    public interface IMatchAwards
    {
        /// <summary>
        /// Returns a MatchAward given the award reference id.
        /// </summary>
        /// <param name="awardId">The reference id.</param>
        /// <returns></returns>
        MatchAward MatchAward(string awardId);

        /// <summary>
        /// Returns a collection of all awards.
        /// </summary>
        /// <returns></returns>
        IEnumerable<MatchAward> Awards();

        /// <summary>
        /// Returns the number of awards.
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}