using System.Collections.Generic;
using Heroes.Icons.Models;

namespace Heroes.Icons.Xml
{
    public interface IHomescreensXml
    {
        /// <summary>
        /// Returns a collection of all homescreens.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Homescreen> Homescreens();

        /// <summary>
        /// Returns the number of homescreens.
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}