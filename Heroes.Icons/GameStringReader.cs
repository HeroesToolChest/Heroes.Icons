using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons
{
    /// <summary>
    /// Provides the methods to update gamestrings for game data objects.
    /// </summary>
    public class GameStringReader : IDisposable
    {
        /// <summary>
        /// Initializes a new reader for the gamestrings file.
        /// </summary>
        /// <param name="jsonGameStringFilePath">JSON file containing gamestrings.</param>
        public GameStringReader(string jsonGameStringFilePath)
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
        /// Initializes a new reader for the gamestrings file.
        /// </summary>
        /// <param name="jsonGameStringFilePath">JSON file containing gamestrings.</param>
        /// <param name="localization">Localization of data.</param>
        public GameStringReader(string jsonGameStringFilePath, Localization localization)
        {
            JsonGameStringDocument = JsonDocument.Parse(File.ReadAllBytes(jsonGameStringFilePath));
            Localization = localization;
        }

        /// <summary>
        /// Initializes a new reader for the gamestrings file.
        /// </summary>
        /// <param name="jsonGameStrings">JSON data containing gamestrings.</param>
        public GameStringReader(ReadOnlyMemory<byte> jsonGameStrings)
        {
            JsonGameStringDocument = JsonDocument.Parse(jsonGameStrings);

            if (JsonGameStringDocument.RootElement.TryGetProperty("meta", out JsonElement metaElement))
            {
                if (metaElement.TryGetProperty("locale", out JsonElement locale) && Enum.TryParse(locale.ToString(), true, out Localization localization))
                    Localization = localization;
            }
        }

        /// <summary>
        /// Initializes a new reader for the gamestrings file.
        /// </summary>
        /// <param name="jsonGameStrings">JSON data containing gamestrings.</param>
        /// <param name="localization">Localization of data.</param>
        public GameStringReader(ReadOnlyMemory<byte> jsonGameStrings, Localization localization)
        {
            JsonGameStringDocument = JsonDocument.Parse(jsonGameStrings);
            Localization = localization;
        }

        /// <summary>
        /// Gets the current selected localization.
        /// </summary>
        public Localization Localization { get; } = Localization.ENUS;

        /// <summary>
        /// Gets the <see cref="JsonDocument"/> to allow for manually parsing.
        /// </summary>
        public JsonDocument JsonGameStringDocument { get; }

        /// <inheritdoc/>
        public void Dispose()
        {
            JsonGameStringDocument.Dispose();
        }

        /// <summary>
        /// Updates the object's localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="hero"></param>
        /// <exception cref="ArgumentNullException" />
        public void UpdateGameStrings(Hero hero)
        {
            if (hero is null)
            {
                throw new ArgumentNullException(nameof(hero));
            }

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
                            hero.AddRole(roleValue);
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
        /// Updates the object's localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="unit"></param>
        /// <exception cref="ArgumentNullException" />
        public void UpdateGameStrings(Unit unit)
        {
            if (unit is null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

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
        /// Updates the object's localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="talent"></param>
        /// <exception cref="ArgumentNullException" />
        public void UpdateGameStrings(Talent talent)
        {
            if (talent is null)
            {
                throw new ArgumentNullException(nameof(talent));
            }

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                SetAbilityTalentData(gameStringElement, talent);
            }
        }

        /// <summary>
        /// Updates the object's localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="ability"></param>
        /// <exception cref="ArgumentNullException" />
        public void UpdateGameStrings(Ability ability)
        {
            if (ability is null)
            {
                throw new ArgumentNullException(nameof(ability));
            }

            JsonElement element = JsonGameStringDocument.RootElement;

            if (element.TryGetProperty("gamestrings", out JsonElement gameStringElement))
            {
                SetAbilityTalentData(gameStringElement, ability);
            }
        }

        /// <summary>
        /// Updates the object's localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="announcer"></param>
        /// <exception cref="ArgumentNullException" />
        public void UpdateGameStrings(Announcer announcer)
        {
            if (announcer is null)
            {
                throw new ArgumentNullException(nameof(announcer));
            }

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
