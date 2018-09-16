using Heroes.Models;
using System.Collections.Generic;

namespace Heroes.Icons.Xml
{
    public interface IHeroDataXml
    {
        /// <summary>
        /// Returns a Hero object.
        /// </summary>
        /// <param name="name">The hero real name or short name.</param>
        /// <returns></returns>
        Hero HeroData(string name);

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