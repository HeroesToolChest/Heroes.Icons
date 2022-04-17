﻿namespace Heroes.Icons.ModelExtensions;

/// <summary>
/// Contains extensions for <see cref="Boost"/>.
/// </summary>
public static class BoostExtensions
{
    /// <summary>
    /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
    /// </summary>
    /// <param name="boost">The data to be updated.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is null.</exception>
    public static void UpdateGameStrings(this Boost boost, GameStringDocument gameStringDocument)
    {
        if (gameStringDocument is null)
            throw new ArgumentNullException(nameof(gameStringDocument));

        gameStringDocument.UpdateGameStrings(boost);
    }
}
