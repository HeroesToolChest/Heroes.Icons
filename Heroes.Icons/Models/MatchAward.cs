namespace Heroes.Icons.Models
{
    public class MatchAward
    {
        /// <summary>
        /// Gets or sets the unique id.
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
        /// Gets or sets the MVP screen image file name.
        /// </summary>
        public string MVPScreenImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the score screen image file name.
        /// </summary>
        public string ScoreScreenImageFileName { get; set; }

        /// <summary>
        /// Gets or sets the award description.
        /// </summary>
        public string Description { get; set; }
    }
}
