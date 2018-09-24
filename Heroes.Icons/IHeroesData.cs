using Heroes.Models;
using System.Collections.Generic;

namespace Heroes.Icons
{
    public interface IHeroesData
    {
        /// <summary>
        /// Returns a collection of Hero data.
        /// </summary>
        /// <param name="heroNames">The list of hero names to provide.  Names can be real or short names.</param>
        /// <param name="name">The hero real name or short name.</param>
        /// <param name="includeAbilities">Include the ability data.</param>
        /// <param name="includeTalents">Include the talent data.</param>
        /// <param name="additionalUnits">Include the additional hero units.</param>
        /// <returns></returns>
        IEnumerable<Hero> HeroesData(IEnumerable<string> heroNames, bool includeAbilities = true, bool includeTalents = true, bool additionalUnits = true);

        /// <summary>
        /// Returns a Hero object.
        /// </summary>
        /// <param name="name">The hero real name or short name.</param>
        /// <param name="includeAbilities">Include the ability data.</param>
        /// <param name="includeTalents">Include the talent data.</param>
        /// <param name="additionalUnits">Include the additional hero units.</param>
        /// <returns></returns>
        Hero HeroData(string name, bool includeAbilities = true, bool includeTalents = true, bool additionalUnits = true);

        /// <summary>
        /// Returns the hero's name from the attribute id.
        /// </summary>
        /// <param name="attributeId">Four character hero id.</param>
        /// <returns></returns>
        string HeroNameFromAttributeId(string attributeId);

        /// <summary>
        /// Returns the hero's name from the short name.
        /// </summary>
        /// <param name="shortName">Short name of hero.</param>
        /// <returns></returns>
        string HeroNameFromShortName(string shortName);

        /// <summary>
        /// Returns the hero's name from the unit id.
        /// </summary>
        /// <param name="unitId">Unit id of hero. Starts with 'Hero'.</param>
        /// <returns></returns>
        string HeroNameFromUnitId(string unitId);

        /// <summary>
        /// Returns a collection of real hero names.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> HeroNames();

        /// <summary>
        /// Returns the number of heroes.
        /// </summary>
        /// <returns></returns>
        int GetTotalAmountOfHeroes();

        /// <summary>
        /// Checks if the given hero name exists.
        /// </summary>
        /// <param name="name">The hero real name or short name.</param>
        /// <returns></returns>
        bool HeroExists(string name);
    }
}