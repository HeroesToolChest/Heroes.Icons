using Heroes.Models;
using System;

namespace Heroes.Icons.ModelExtensions
{
    /// <summary>
    /// Contains extensions for <see cref="Announcer"/>.
    /// </summary>
    public static class AnnouncerExtensions
    {
        /// <summary>
        /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="announcer">The data to be updated.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is null.</exception>
        public static void UpdateGameStrings(this Announcer announcer, GameStringDocument gameStringDocument)
        {
            if (gameStringDocument is null)
                throw new ArgumentNullException(nameof(gameStringDocument));

            gameStringDocument.UpdateGameStrings(announcer);
        }
    }
}
