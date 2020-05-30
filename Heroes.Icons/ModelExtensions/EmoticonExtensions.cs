using Heroes.Models;
using System;

namespace Heroes.Icons.ModelExtensions
{
    /// <summary>
    /// Contains extensions for <see cref="Emoticon"/>.
    /// </summary>
    public static class EmoticonExtensions
    {
        /// <summary>
        /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="emoticon">The data to be updated.</param>
        /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is null.</exception>
        public static void UpdateGameStrings(this Emoticon emoticon, GameStringDocument gameStringDocument)
        {
            if (gameStringDocument is null)
                throw new ArgumentNullException(nameof(gameStringDocument));

            gameStringDocument.UpdateGameStrings(emoticon);
        }
    }
}
