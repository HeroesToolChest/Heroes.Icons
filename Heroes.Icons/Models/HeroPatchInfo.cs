namespace Heroes.Icons.Models
{
    public class HeroPatchInfo
    {
        public HeroPatchInfo()
        { }

        /// <summary>
        /// Gets or sets the build number.
        /// </summary>
        public int Build { get; set; }

        /// <summary>
        /// Gets or sets the full version.
        /// </summary>
        public string FullVersion { get; set; }

        /// <summary>
        /// Gets or sets the type of patch.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the link to the official patch notes.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets if the patch is the same as the previous patch.
        /// </summary>
        public bool IsPrevious { get; set; }
    }
}
