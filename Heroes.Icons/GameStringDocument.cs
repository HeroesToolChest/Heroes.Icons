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
        /// <see cref="Localization"/> will be inferred from <paramref name="jsonGameStringFilePath"/>.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The JSON file to parse.</param>
        protected GameStringDocument(string jsonGameStringFilePath)
        {
            JsonGameStringDocument = JsonDocument.Parse(File.ReadAllBytes(jsonGameStringFilePath));

            string? file = Path.GetFileNameWithoutExtension(jsonGameStringFilePath);

            int index = file.LastIndexOf('_');
            if (index > -1)
            {
                if (Enum.TryParse(file.Substring(index + 1), true, out Localization localization))
                    Localization = localization;
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
        /// <see cref="Localization"/> will be inferred from the meta property in the json data.
        /// </summary>
        /// <param name="jsonGameStrings">The JSON data to parse.</param>
        protected GameStringDocument(ReadOnlyMemory<byte> jsonGameStrings)
        {
            JsonGameStringDocument = JsonDocument.Parse(jsonGameStrings);

            if (JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement metaElement))
            {
                if (metaElement.TryGetProperty("locale", out JsonElement locale) && Enum.TryParse(locale.ToString(), true, out Localization localization))
                    Localization = localization;
            }
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
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as async.</param>
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        protected GameStringDocument(Stream utf8Json, Localization localization, bool isAsync = false)
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        {
            if (isAsync)
                _streamForAsync = utf8Json;
            else
                JsonGameStringDocument = JsonDocument.Parse(utf8Json);

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
        public Localization Localization { get; } = Localization.ENUS;

        /// <summary>
        /// Gets the <see cref="JsonDocument"/> to allow for manually parsing.
        /// </summary>
        public JsonDocument JsonGameStringDocument { get; private set; }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// <see cref="Localization"/> will be inferred from <paramref name="jsonGameStringFilePath"/>.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The JSON file to parse.</param>
        /// <returns>a <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(string jsonGameStringFilePath)
        {
            return new GameStringDocument(jsonGameStringFilePath);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="jsonGameStringFilePath">The JSON file to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>a <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(string jsonGameStringFilePath, Localization localization)
        {
            return new GameStringDocument(jsonGameStringFilePath, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// <see cref="Localization"/> will be inferred from the meta property in the json data.
        /// </summary>
        /// <param name="jsonGameStrings">The JSON data to parse.</param>
        /// <returns>a <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(ReadOnlyMemory<byte> jsonGameStrings)
        {
            return new GameStringDocument(jsonGameStrings);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="jsonGameStrings">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>a <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(ReadOnlyMemory<byte> jsonGameStrings, Localization localization)
        {
            return new GameStringDocument(jsonGameStrings, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>a <see cref="GameStringDocument"/> representation of the JSON value.</returns>
        public static GameStringDocument Parse(Stream utf8Json, Localization localization)
        {
            return new GameStringDocument(utf8Json, localization);
        }

        /// <summary>
        /// Parses a json file as UTF-8-encoded text to allow for gamestring data reading.
        /// </summary>
        /// <param name="utf8Json">The JSON data to parse.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <returns>a <see cref="GameStringDocument"/> representation of the JSON value.</returns>
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
        /// <exception cref="ArgumentNullException"><paramref name="hero"/> is null.</exception>
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
                    if (TryGetValueFromJsonElement(keyValue, "difficulty", hero.Id, out JsonElement value))
                        hero.Difficulty = value.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "expandedrole", hero.Id, out value))
                        hero.ExpandedRole = value.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "role", hero.Id, out value))
                    {
                        foreach (string roleValue in value.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries))
                        {
                            hero.Roles.Add(roleValue);
                        }
                    }

                    if (TryGetValueFromJsonElement(keyValue, "searchtext", hero.Id, out value))
                        hero.SearchText = value.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "title", hero.Id, out value))
                        hero.Title = value.ToString();

                    if (TryGetValueFromJsonElement(keyValue, "type", hero.Id, out value))
                        hero.Type = value.ToString();
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
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
        public void UpdateGameStrings(Unit unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("unit", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "damagetype", unit.Id, out JsonElement value))
                        unit.DamageType = value.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "description", unit.Id, out value))
                        unit.Description = new TooltipDescription(value.ToString(), Localization);
                    if (TryGetValueFromJsonElement(keyValue, "energytype", unit.Id, out value))
                        unit.Energy.EnergyType = value.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "lifetype", unit.Id, out value))
                        unit.Life.LifeType = value.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "name", unit.Id, out value))
                        unit.Name = value.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "shieldtype", unit.Id, out value))
                        unit.Shield.ShieldType = value.ToString();
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
        /// <exception cref="ArgumentNullException"><paramref name="talent"/> is null.</exception>
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
        /// <exception cref="ArgumentNullException"><paramref name="ability"/> is null.</exception>
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
        /// <exception cref="ArgumentNullException"><paramref name="announcer"/> is null.</exception>
        public void UpdateGameStrings(Announcer announcer)
        {
            if (announcer is null)
                throw new ArgumentNullException(nameof(announcer));

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                if (gameStringElement.TryGetProperty("announcer", out JsonElement keyValue))
                {
                    if (TryGetValueFromJsonElement(keyValue, "name", announcer.Id, out JsonElement value))
                        announcer.Name = value.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "sortName", announcer.Id, out value))
                        announcer.SortName = value.ToString();
                    if (TryGetValueFromJsonElement(keyValue, "description", announcer.Id, out value))
                        announcer.Description = new TooltipDescription(value.ToString());
                }
            }
        }

        /// <summary>
        /// Parses the Json stream as async.
        /// </summary>
        /// <typeparam name="T">A class that derives <see cref="GameStringDocument"/>.</typeparam>
        /// <returns>a class that derives <see cref="GameStringDocument"/>.</returns>
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

        private bool TryGetValueFromJsonElement(JsonElement element, string key, string id, out JsonElement value)
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
