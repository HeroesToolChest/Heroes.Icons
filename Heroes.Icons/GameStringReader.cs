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
        public void UpdateGameStrings(Hero hero)
        {
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
            }
        }

        /// <summary>
        /// Updates the object's localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="unit"></param>
        public void UpdateGameStrings(Unit unit)
        {
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
                    if (ability.AbilityTalentId is null)
                        continue;

                    if (gameStringElement.TryGetProperty("abiltalent", out keyValue))
                    {
                        if (TryGetValueFromJsonElement(keyValue, "cooldown", ability.AbilityTalentId.Id, out JsonElement value))
                            ability.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(value.ToString(), Localization);
                        if (TryGetValueFromJsonElement(keyValue, "energy", ability.AbilityTalentId.Id, out value))
                            ability.Tooltip.Energy.EnergyTooltip = new TooltipDescription(value.ToString(), Localization);
                        if (TryGetValueFromJsonElement(keyValue, "full", ability.AbilityTalentId.Id, out value))
                            ability.Tooltip.FullTooltip = new TooltipDescription(value.ToString(), Localization);
                        if (TryGetValueFromJsonElement(keyValue, "life", ability.AbilityTalentId.Id, out value))
                            ability.Tooltip.Life.LifeCostTooltip = new TooltipDescription(value.ToString(), Localization);
                        if (TryGetValueFromJsonElement(keyValue, "name", ability.AbilityTalentId.Id, out value))
                            ability.Name = value.ToString();
                        if (TryGetValueFromJsonElement(keyValue, "short", ability.AbilityTalentId.Id, out value))
                            ability.Tooltip.ShortTooltip = new TooltipDescription(value.ToString(), Localization);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the object's localized gamestrings to the currently selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="announcer"></param>
        public void UpdateGameStrings(Announcer announcer)
        {
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
    }
}
