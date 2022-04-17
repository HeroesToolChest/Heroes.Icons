namespace Heroes.Icons.ModelExtensions;

/// <summary>
/// Contains extensions for <see cref="Ability"/>.
/// </summary>
public static class AbilityExtensions
{
    /// <summary>
    /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
    /// </summary>
    /// <param name="ability">The data to be updated.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is null.</exception>
    public static void UpdateGameStrings(this Ability ability, GameStringDocument gameStringDocument)
    {
        ArgumentNullException.ThrowIfNull(gameStringDocument, nameof(gameStringDocument));

        gameStringDocument.UpdateGameStrings(ability);
    }
}
