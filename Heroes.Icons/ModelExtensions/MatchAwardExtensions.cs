using Heroes.Models;
using System;

namespace Heroes.Icons.ModelExtensions;

/// <summary>
/// Contains extensions for <see cref="MatchAward"/>.
/// </summary>
public static class MatchAwardExtensions
{
    /// <summary>
    /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
    /// </summary>
    /// <param name="matchAward">The data to be updated.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is null.</exception>
    public static void UpdateGameStrings(this MatchAward matchAward, GameStringDocument gameStringDocument)
    {
        if (gameStringDocument is null)
            throw new ArgumentNullException(nameof(gameStringDocument));

        gameStringDocument.UpdateGameStrings(matchAward);
    }
}
