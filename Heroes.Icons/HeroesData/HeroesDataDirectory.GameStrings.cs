namespace Heroes.Icons.HeroesData;

/// <summary>
/// Contains the information for the heroes-data directory.
/// </summary>
public partial class HeroesDataDirectory
{
    /// <summary>
    /// Updates the gamestrings of <paramref name="announcer"/>.
    /// </summary>
    /// <param name="announcer">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="announcer"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(Announcer announcer, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(announcer, nameof(announcer));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _announcerFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        announcer.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="banner"/>.
    /// </summary>
    /// <param name="banner">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="banner"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(Banner banner, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(banner, nameof(banner));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _bannerFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        banner.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="emoticon"/>.
    /// </summary>
    /// <param name="emoticon">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="emoticon"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(Emoticon emoticon, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(emoticon, nameof(emoticon));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _emoticonFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        emoticon.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="emoticonPack"/>.
    /// </summary>
    /// <param name="emoticonPack">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="emoticonPack"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(EmoticonPack emoticonPack, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(emoticonPack, nameof(emoticonPack));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _emoticonPackFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        emoticonPack.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="hero"/>.
    /// </summary>
    /// <param name="hero">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hero"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(Hero hero, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(hero, nameof(hero));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _heroFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        hero.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="heroSkin"/>.
    /// </summary>
    /// <param name="heroSkin">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="heroSkin"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(HeroSkin heroSkin, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(heroSkin, nameof(heroSkin));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _heroSkinFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        heroSkin.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="matchAward"/>.
    /// </summary>
    /// <param name="matchAward">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="matchAward"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(MatchAward matchAward, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(matchAward, nameof(matchAward));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _matchAwardFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        matchAward.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="mount"/>.
    /// </summary>
    /// <param name="mount">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="mount"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(Mount mount, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(mount, nameof(mount));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _mountFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        mount.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="portraitPack"/>.
    /// </summary>
    /// <param name="portraitPack">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="portraitPack"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(PortraitPack portraitPack, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(portraitPack, nameof(portraitPack));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _portraitPackFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        portraitPack.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="rewardPortrait"/>.
    /// </summary>
    /// <param name="rewardPortrait">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="rewardPortrait"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(RewardPortrait rewardPortrait, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(rewardPortrait, nameof(rewardPortrait));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _rewardPortraitFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        rewardPortrait.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="spray"/>.
    /// </summary>
    /// <param name="spray">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="spray"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(Spray spray, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(spray, nameof(spray));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _sprayFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        spray.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="unit"/>.
    /// </summary>
    /// <param name="unit">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(Unit unit, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(unit, nameof(unit));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _unitFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        unit.UpdateGameStrings(gameStringDocument);
    }

    /// <summary>
    /// Updates the gamestrings of <paramref name="voiceLine"/>.
    /// </summary>
    /// <param name="voiceLine">The data who's gamestrings will be updated.</param>
    /// <param name="version">The version directory to load the gamestrings from.</param>
    /// <param name="localization">The <see cref="Localization"/> of the gamestrings.</param>
    /// <exception cref="ArgumentNullException"><paramref name="voiceLine"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="version"/> is null.</exception>
    public void UpdateGameString(VoiceLine voiceLine, HeroesDataVersion version, Localization localization)
    {
        ArgumentNullException.ThrowIfNull(voiceLine, nameof(voiceLine));
        ArgumentNullException.ThrowIfNull(version, nameof(version));

        (_, string gameStringPath) = GetDataAndGameStringPaths(version, true, localization, _voiceLineFileTemplateName, false, true);

        using GameStringDocument gameStringDocument = GameStringDocument.Parse(gameStringPath);

        voiceLine.UpdateGameStrings(gameStringDocument);
    }
}
