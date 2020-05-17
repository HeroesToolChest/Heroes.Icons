using Heroes.Models;
using Heroes.Models.AbilityTalents;

namespace Heroes.Icons.Extensions
{
    /// <summary>
    /// Contains extensions for <see cref="Talent"/>.
    /// </summary>
    public static class TalentExtension
    {
        /// <summary>
        /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="talent"></param>
        /// <param name="gameStringDocument"></param>
        public static void UpdateGameStrings(this Talent talent, GameStringDocument gameStringDocument)
        {
            gameStringDocument.UpdateGameStrings(talent);
        }
    }
}
