﻿namespace Heroes.Icons.ModelExtensions;

/// <summary>
/// Contains extensions for <see cref="LootChest"/>.
/// </summary>
public static class LootChestExtensions
{
    /// <summary>
    /// Updates the localized gamestrings to the selected <see cref="Localization"/>.
    /// </summary>
    /// <param name="lootChest">The data to be updated.</param>
    /// <param name="gameStringDocument">Instance of a <see cref="GameStringDocument"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="gameStringDocument"/> is null.</exception>
    public static void UpdateGameStrings(this LootChest lootChest, GameStringDocument gameStringDocument)
    {
        if (gameStringDocument is null)
            throw new ArgumentNullException(nameof(gameStringDocument));

        gameStringDocument.UpdateGameStrings(lootChest);
    }
}
