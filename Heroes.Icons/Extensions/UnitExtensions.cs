using Heroes.Models;

namespace Heroes.Icons.Extensions
{
    /// <summary>
    /// Contains extensions for <see cref="Unit"/>.
    /// </summary>
    public static class UnitExtensions
    {
        /// <summary>
        /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="gameStringDocument"></param>
        public static void UpdateGameStrings(this Unit unit, GameStringDocument gameStringDocument)
        {
            gameStringDocument.UpdateGameStrings(unit);
        }
    }
}
