using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Heroes.Icons
{
    /// <summary>
    /// Provides the methods to update gamestrings for game data objects.
    /// </summary>
    public class GameStringDocument : IDisposable
    {
        private readonly Stream? _streamForAsync = null;

        private bool _disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStringDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from the meta property in the json data, otherwise it will be
        /// inferred from <paramref name="jsonGameStringFilePath"/>.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The JSON file to parse.</param>
        protected GameStringDocument(string jsonGameStringFilePath)
        {
            JsonGameStringDocument = JsonDocument.Parse(File.ReadAllBytes(jsonGameStringFilePath));

            if (!SetLocalizationFromMeta())
            {
                SetLocalizationFromFileName(jsonGameStringFilePath);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStringDocument"/> class.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The JSON file to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected GameStringDocument(string jsonGameStringFilePath, Localization localization)
        {
            JsonGameStringDocument = JsonDocument.Parse(File.ReadAllBytes(jsonGameStringFilePath));
            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStringDocument"/> class.
        /// The <see cref="Localization"/> will be inferred from the meta property in the json data.
        /// </summary>
        /// <param name="jsonGameStrings">The JSON data to parse.</param>
        protected GameStringDocument(ReadOnlyMemory<byte> jsonGameStrings)
        {
            JsonGameStringDocument = JsonDocument.Parse(jsonGameStrings);

            SetLocalizationFromMeta();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStringDocument"/> class.
        /// </summary>
        /// <param name="jsonGameStrings">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected GameStringDocument(ReadOnlyMemory<byte> jsonGameStrings, Localization localization)
        {
            JsonGameStringDocument = JsonDocument.Parse(jsonGameStrings);
            Localization = localization;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStringDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected GameStringDocument(Stream utf8Json, bool isAsync = false)
        {
            if (isAsync)
            {
                JsonGameStringDocument = null!;
                _streamForAsync = utf8Json;
            }
            else
            {
                JsonGameStringDocument = JsonDocument.Parse(utf8Json);
                SetLocalizationFromMeta();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStringDocument"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as <see langword="async"/>.</param>
        protected GameStringDocument(Stream utf8Json, Localization localization, bool isAsync = false)
        {
            if (isAsync)
            {
                JsonGameStringDocument = null!;
                _streamForAsync = utf8Json;
            }
            else
            {
                JsonGameStringDocument = JsonDocument.Parse(utf8Json);
            }

            Localization = localization;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="GameStringDocument"/> class.
        /// </summary>
        ~GameStringDocument()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the current selected localization.
        /// </summary>
        public Localization Localization { get; private set; } = Localization.ENUS;

        /// <summary>
        /// Gets the <see cref="JsonDocument"/> to allow for manually parsing.
        /// </summary>
        public JsonDocument JsonGameStringDocument { get; private set; }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the json data, otherwise it will be
        /// inferred from <paramref name="jsonGameStringFilePath"/>.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The JSON file to parse.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(string jsonGameStringFilePath)
        {
            return new GameStringDocument(jsonGameStringFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The JSON file to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(string jsonGameStringFilePath, Localization localization)
        {
            return new GameStringDocument(jsonGameStringFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the json data.
        /// </summary>
        /// <param name="jsonGameStrings">The JSON data to parse.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(ReadOnlyMemory<byte> jsonGameStrings)
        {
            return new GameStringDocument(jsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="jsonGameStrings">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(ReadOnlyMemory<byte> jsonGameStrings, Localization localization)
        {
            return new GameStringDocument(jsonGameStrings, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the json data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(Stream utf8Json)
        {
            return new GameStringDocument(utf8Json);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(Stream utf8Json, Localization localization)
        {
            return new GameStringDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// The <see cref="Localization"/> will be inferred from the meta property in the json data.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static async Task<GameStringDocument> ParseAsync(Stream utf8Json)
        {
            GameStringDocument document = new GameStringDocument(utf8Json, true);
            await document.InitializeParseAsync<GameStringDocument>().ConfigureAwait(false);
            document.SetLocalizationFromMeta();

            return document;
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>A <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static Task<GameStringDocument> ParseAsync(Stream utf8Json, Localization localization)
        {
            return new GameStringDocument(utf8Json, localization, true).InitializeParseAsync<GameStringDocument>();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Updates the <paramref name="hero"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="hero">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="hero"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Hero hero)
        {
            if (hero is null)
                throw new ArgumentNullException(nameof(hero));

            JsonElement element = JsonGameStringDocument.RootElement;

            UpdateGameStrings(unit: hero);

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("unit", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "difficulty", hero.Id, out JsonElement difficultyElement))
                        hero.Difficulty = difficultyElement.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "expandedrole", hero.Id, out JsonElement expandedRoleElement))
                        hero.ExpandedRole = expandedRoleElement.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "role", hero.Id, out JsonElement roleElement))
                    {
                        foreach (string roleValue in roleElement.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries))
                        {
                            hero.Roles.Add(roleValue);
                        }
                    }

                    if (TryGetValueFromJsonElement(keyValue, "searchtext", hero.Id, out JsonElement searchTextElement))
                        hero.SearchText = searchTextElement.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "title", hero.Id, out JsonElement titleElement))
                        hero.Title = titleElement.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "type", hero.Id, out JsonElement typeElement))
                        hero.Type = typeElement.ToString();
                }

                foreach (Talent talent in hero.Talents)
                {
                    SetAbilityTalentData(gameStringElement, talent);
                }

                foreach (Hero heroUnit in hero.HeroUnits)
                {
                    UpdateGameStrings(heroUnit);
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="unit"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="unit">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Unit unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("unit", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "damagetype", unit.Id, out JsonElement damageTypeElement))
                        unit.DamageType = damageTypeElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "description", unit.Id, out JsonElement descriptionElement))
                        unit.Description = new TooltipDescription(descriptionElement.ToString(), Localization);
                    if (TryGetValueFromJsonElement(keyValue, "energytype", unit.Id, out JsonElement energyTypeElement))
                        unit.Energy.EnergyType = energyTypeElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "lifetype", unit.Id, out JsonElement lifeTypeElement))
                        unit.Life.LifeType = lifeTypeElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "name", unit.Id, out JsonElement nameElement))
                        unit.Name = nameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "shieldtype", unit.Id, out JsonElement shieldTypeElement))
                        unit.Shield.ShieldType = shieldTypeElement.ToString();
                }

                foreach (Ability ability in unit.Abilities)
                {
                    SetAbilityTalentData(gameStringElement, ability);
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="talent"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="talent">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="talent"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Talent talent)
        {
            if (talent is null)
                throw new ArgumentNullException(nameof(talent));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                SetAbilityTalentData(gameStringElement, talent);
            }
        }

        /// <summary>
        /// Updates the <paramref name="ability"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="ability">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ability"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Ability ability)
        {
            if (ability is null)
                throw new ArgumentNullException(nameof(ability));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                SetAbilityTalentData(gameStringElement, ability);
            }
        }

        /// <summary>
        /// Updates the <paramref name="announcer"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="announcer">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="announcer"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Announcer announcer)
        {
            if (announcer is null)
                throw new ArgumentNullException(nameof(announcer));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("announcer", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "name", announcer.Id, out JsonElement nameElement))
                        announcer.Name = nameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "sortName", announcer.Id, out JsonElement sortNameElement))
                        announcer.SortName = sortNameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "description", announcer.Id, out JsonElement descriptionElement))
                        announcer.Description = new TooltipDescription(descriptionElement.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="matchAward"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="matchAward">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="matchAward"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(MatchAward matchAward)
        {
            if (matchAward is null)
                throw new ArgumentNullException(nameof(matchAward));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("award", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "name", matchAward.Id, out JsonElement nameElement))
                        matchAward.Name = nameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "description", matchAward.Id, out JsonElement descriptionElement))
                        matchAward.Description = new TooltipDescription(descriptionElement.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="heroSkin"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="heroSkin">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="heroSkin"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(HeroSkin heroSkin)
        {
            if (heroSkin is null)
                throw new ArgumentNullException(nameof(heroSkin));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("heroskin", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "name", heroSkin.Id, out JsonElement nameElement))
                        heroSkin.Name = nameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "searchtext", heroSkin.Id, out JsonElement searchTextElement))
                        heroSkin.SearchText = searchTextElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "sortname", heroSkin.Id, out JsonElement sortNameElement))
                        heroSkin.SortName = sortNameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "info", heroSkin.Id, out JsonElement infoElement))
                        heroSkin.Description = new TooltipDescription(infoElement.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="mount"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="mount">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="mount"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Mount mount)
        {
            if (mount is null)
                throw new ArgumentNullException(nameof(mount));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("mount", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "name", mount.Id, out JsonElement nameElement))
                        mount.Name = nameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "searchtext", mount.Id, out JsonElement searchTextElement))
                        mount.SearchText = searchTextElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "sortname", mount.Id, out JsonElement sortNameElement))
                        mount.SortName = sortNameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "info", mount.Id, out JsonElement infoElement))
                        mount.Description = new TooltipDescription(infoElement.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="banner"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="banner">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="banner"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Banner banner)
        {
            if (banner is null)
                throw new ArgumentNullException(nameof(banner));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("banner", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "name", banner.Id, out JsonElement nameElement))
                        banner.Name = nameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "sortname", banner.Id, out JsonElement sortNameElement))
                        banner.SortName = sortNameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "description", banner.Id, out JsonElement descriptionElement))
                        banner.Description = new TooltipDescription(descriptionElement.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="spray"/>'s localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="spray">The data to be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="spray"/> is <see langword="null"/>.</exception>
        public void UpdateGameStrings(Spray spray)
        {
            if (spray is null)
                throw new ArgumentNullException(nameof(spray));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("spray", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "name", spray.Id, out JsonElement nameElement))
                        spray.Name = nameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "searchtext", spray.Id, out JsonElement searchTextElement))
                        spray.SearchText = searchTextElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "sortname", spray.Id, out JsonElement sortNameElement))
                        spray.SortName = sortNameElement.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "description", spray.Id, out JsonElement descriptionElement))
                        spray.Description = new TooltipDescription(descriptionElement.ToString());
                }
            }
        }

        /// <summary>
        /// Parses the Json stream as <see langword="async"/>.
        /// </summary>
        /// <typeparam name="T">A class that derives <see cref="GameStringDocument"/>.</typeparam>
        /// <returns><typeparamref name="T"/>.</returns>
        protected async Task<T> InitializeParseAsync<T>()
            where T : GameStringDocument
        {
            JsonGameStringDocument = await JsonDocument.ParseAsync(_streamForAsync).ConfigureAwait(false);

            return (T)this;
        }

        /// <summary>
        /// Disposes the resources.
        /// </summary>
        /// <param name="disposing">True to include releasing managed resource.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    JsonGameStringDocument.Dispose();
                    _streamForAsync?.Dispose();
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Sets the <see cref="Localization"/> from the meta property in the json data.
        /// </summary>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        protected bool SetLocalizationFromMeta()
        {
            if (JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement metaElement))
            {
                if (metaElement.TryGetProperty("locale", out JsonElement locale) && Enum.TryParse(locale.ToString(), true, out Localization localization))
                {
                    Localization = localization;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets the <see cref="Localization"/> from <paramref name="jsonGameStringFilePath"/>.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The json file path.</param>
        /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
        protected bool SetLocalizationFromFileName(string jsonGameStringFilePath)
        {
            string? file = Path.GetFileNameWithoutExtension(jsonGameStringFilePath);

            int index = file.LastIndexOf('_');
            if (index > -1)
            {
                if (Enum.TryParse(file.Substring(index + 1), true, out Localization localization))
                {
                    Localization = localization;

                    return true;
                }
            }

            return false;
        }

        private static bool TryGetValueFromJsonElement(JsonElement element, string key, string id, out JsonElement value)
        {
            value = default;

            return element.TryGetProperty(key, out JsonElement keyInnerValue) && keyInnerValue.TryGetProperty(id, out value);
        }

        private void SetAbilityTalentData(JsonElement gameStringElement, AbilityTalentBase abilityTalentBase)
        {
            if (gameStringElement.TryGetProperty("abiltalent", out JsonElement keyValue))
            {
                if (TryGetValueFromJsonElement(keyValue, "cooldown", abilityTalentBase.AbilityTalentId.Id, out JsonElement value))
                    abilityTalentBase.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(value.ToString(), Localization);
                if (TryGetValueFromJsonElement(keyValue, "energy", abilityTalentBase.AbilityTalentId.Id, out value))
                    abilityTalentBase.Tooltip.Energy.EnergyTooltip = new TooltipDescription(value.ToString(), Localization);
                if (TryGetValueFromJsonElement(keyValue, "full", abilityTalentBase.AbilityTalentId.Id, out value))
                    abilityTalentBase.Tooltip.FullTooltip = new TooltipDescription(value.ToString(), Localization);
                if (TryGetValueFromJsonElement(keyValue, "life", abilityTalentBase.AbilityTalentId.Id, out value))
                    abilityTalentBase.Tooltip.Life.LifeCostTooltip = new TooltipDescription(value.ToString(), Localization);
                if (TryGetValueFromJsonElement(keyValue, "name", abilityTalentBase.AbilityTalentId.Id, out value))
                    abilityTalentBase.Name = value.ToString();
                if (TryGetValueFromJsonElement(keyValue, "short", abilityTalentBase.AbilityTalentId.Id, out value))
                    abilityTalentBase.Tooltip.ShortTooltip = new TooltipDescription(value.ToString(), Localization);
            }
        }
    }
}
