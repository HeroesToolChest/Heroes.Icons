using Heroes.Models;

namespace Heroes.Icons.Extensions
{
    /// <summary>
    /// Contains extensions for <see cref="Unit"/>.
    /// </summary>
    public static class HeroExtensions
    {
        /// <summary>
        /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="gameStringDocument"></param>
        public static void UpdateGameStrings(this Hero hero, GameStringDocument gameStringDocument)
        {
            gameStringDocument.UpdateGameStrings(hero);
        }
    }
}
