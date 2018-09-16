using System.Collections.Generic;
using System.Linq;

namespace Heroes.Icons.Models
{
    public class Battleground
    {
        private HashSet<string> Aliases = new HashSet<string>();

        /// <summary>
        /// Gets or sets the unique mad id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets if the map is a brawl map.
        /// </summary>
        public bool IsBrawl { get; set; }

        /// <summary>
        /// Gets or sets the text color.
        /// </summary>
        public string TextColor { get; set; }

        /// <summary>
        /// Gets or sets the text glow color.
        /// </summary>
        public string TextGlowColor { get; set; }

        /// <summary>
        /// Gets or sets the map image file name.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Add a map name alias.
        /// </summary>
        /// <param name="name">The alias.</param>
        public void AddAlias(string name)
        {
            Aliases.Add(name);
        }

        /// <summary>
        /// Returns a list of map name aliases.
        /// </summary>
        /// <returns></returns>
        public List<string> GetsListOfAliases()
        {
            return Aliases.ToList();
        }
    }
}
