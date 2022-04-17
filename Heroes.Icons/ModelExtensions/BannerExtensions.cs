namespace Heroes.Icons.ModelExtensions;

/// <summary>
/// Contains extensions for <see cref="Banner"/>.
/// </summary>
public static class BannerExtensions
{
    /// <summary>
    /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
    /// </summary>
    /// <param name="banner">The data to be updated.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is null.</exception>
    public static void UpdateGameStrings(this Banner banner, GameStringDocument gameStringDocument)
    {
        ArgumentNullException.ThrowIfNull(gameStringDocument, nameof(gameStringDocument));

        gameStringDocument.UpdateGameStrings(banner);
    }
}
