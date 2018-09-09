using Heroes.Models;
using System.Collections.Generic;

namespace Heroes.Icons.Xml
{
    public interface IHeroDataXml
    {
        /// <summary>
        /// Gets a Hero object.
        /// </summary>
        /// <param name="name">The hero real name or short name.</param>
        /// <returns></returns>
        Hero GetHeroData(string name);

        /// <summary>
        /// Gets the hero's name from the attribute id.
        /// </summary>
        /// <param name="attributeId">Four character hero id.</param>
        /// <returns></returns>
        string GetHeroNameFromAttributeId(string attributeId);

        /// <summary>
        /// Gets the hero's name from the short name.
        /// </summary>
        /// <param name="shortName">Short name of hero.</param>
        /// <returns></returns>
        string GetHeroNameFromShortName(string shortName);

        /// <summary>
        /// Gets the hero's name from the unit id.
        /// </summary>
        /// <param name="unitId">Unit id of hero. Starts with 'Hero'.</param>
        /// <returns></returns>
        string GetHeroNameFromUnitId(string unitId);

        /// <summary>
        /// Gets a list of real hero names.
        /// </summary>
        /// <returns></returns>
        List<string> GetListOfHeroNames();

        /// <summary>
        /// Gets the total count of heroes.
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