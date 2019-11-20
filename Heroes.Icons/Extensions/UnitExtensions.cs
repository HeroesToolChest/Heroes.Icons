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
        /// <param name="gameStringReader"></param>
        public static void UpdateGameStrings(this Unit unit, GameStringReader gameStringReader)
        {
            gameStringReader.UpdateGameStrings(unit);
        }
    }
}
