using System.Collections.Generic;

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
        public string TextHexColor { get; set; }

        /// <summary>
        /// Gets or sets the text glow color.
        /// </summary>
        public string TextHexGlowColor { get; set; }

        /// <summary>
        /// Gets or sets the map image file name.
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        /// Add a map name alias.
        /// </summary>
        /// <param name="name">The alias.</param>
        public void AddAlias(string name)
        {
            Aliases.Add(name);
        }

        /// <summary>
        /// Returns a collection of map name aliases.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetsListOfAliases()
        {
            return Aliases;
        }
    }
}
