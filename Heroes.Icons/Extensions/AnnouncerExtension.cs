using Heroes.Models;

namespace Heroes.Icons.Extensions
{
    /// <summary>
    /// Contains extensions for <see cref="Announcer"/>.
    /// </summary>
    public static class AnnouncerExtension
    {
        /// <summary>
        /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="announcer"></param>
        /// <param name="gameStringReader"></param>
        public static void UpdateGameStrings(this Announcer announcer, GameStringReader gameStringReader)
        {
            gameStringReader.UpdateGameStrings(announcer);
        }
    }
}
