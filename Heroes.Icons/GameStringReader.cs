using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons
{
    public class GameStringReader : IDisposable
    {
        private readonly JsonDocument _jsonGameStringDocument;
        private readonly Localization _localization;

        /// <summary>
        /// Initializes a new reader for the gamestrings file.
        /// </summary>
        /// <param name="jsonGameStringFilePath">JSON file containing gamestrings.</param>
        public GameStringReader(string jsonGameStringFilePath)
        {
            _jsonGameStringDocument = JsonDocument.Parse(File.ReadAllBytes(jsonGameStringFilePath));

            int index = jsonGameStringFilePath.LastIndexOf('_');
            if (index > -1)
            {
                if (Enum.TryParse(jsonGameStringFilePath.Substring(index), true, out Localization localization))
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
            _jsonGameStringDocument = JsonDocument.Parse(File.ReadAllBytes(jsonGameStringFilePath));
            _localization = localization;
        }

        /// <summary>
        /// Initializes a new reader for the gamestrings file.
        /// </summary>
        /// <param name="jsonGameStrings">JSON data containing gamestrings.</param>
        public GameStringReader(ReadOnlyMemory<byte> jsonGameStrings)
        {
            _jsonGameStringDocument = JsonDocument.Parse(jsonGameStrings);

            if (_jsonGameStringDocument.RootElement.TryGetProperty("locale", out JsonElement locale) && Enum.TryParse(locale.ToString(), true, out Localization localization))
                Localization = localization;
        }

        /// <summary>
        /// Initializes a new reader for the gamestrings file.
        /// </summary>
        /// <param name="jsonGameStrings">JSON data containing gamestrings.</param>
        /// <param name="localization">Localization of data.</param>
        public GameStringReader(ReadOnlyMemory<byte> jsonGameStrings, Localization localization)
        {
            _jsonGameStringDocument = JsonDocument.Parse(jsonGameStrings);
            _localization = localization;
        }

        /// <summary>
        /// Gets the current selected localization.
        /// </summary>
        public Localization Localization { get; } = Localization.ENUS;

        public void Dispose()
        {
            _jsonGameStringDocument.Dispose();
        }

        /// <summary>
        /// Updates the object's localized gamestrings to the current selected <see cref="Localization"/>.
        /// </summary>
        /// <param name="unit"></param>
        public void UpdateGameStrings(Unit unit)
        {
            JsonElement element = _jsonGameStringDocument.RootElement;

            if (element.TryGetProperty($"unit/damagetype/{unit.CUnitId}", out JsonElement value))
                unit.DamageType = value.ToString();
            if (element.TryGetProperty($"unit/description/{unit.CUnitId}", out value))
                unit.Description = new TooltipDescription(value.ToString(), _localization);
            if (element.TryGetProperty($"unit/energytype/{unit.CUnitId}", out value))
                unit.Energy.EnergyType = value.ToString();
            if (element.TryGetProperty($"unit/lifetype/{unit.CUnitId}", out value))
                unit.Life.LifeType = value.ToString();
            if (element.TryGetProperty($"unit/name/{unit.CUnitId}", out value))
                unit.Name = value.ToString();
            if (element.TryGetProperty($"unit/shieldtype/{unit.CUnitId}", out value))
                unit.Shield.ShieldType = value.ToString();

            foreach (Ability ability in unit.Abilities)
            {
                if (ability.AbilityTalentId is null)
                    continue;

                if (element.TryGetProperty($"abiltalent/cooldown/{ability.AbilityTalentId.Id}", out value))
                    ability.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(value.ToString(), _localization);
                if (element.TryGetProperty($"abiltalent/energy/{ability.AbilityTalentId.Id}", out value))
                    ability.Tooltip.Energy.EnergyTooltip = new TooltipDescription(value.ToString(), _localization);
                if (element.TryGetProperty($"abiltalent/full/{ability.AbilityTalentId.Id}", out value))
                    ability.Tooltip.FullTooltip = new TooltipDescription(value.ToString(), _localization);
                if (element.TryGetProperty($"abiltalent/life/{ability.AbilityTalentId.Id}", out value))
                    ability.Tooltip.Life.LifeCostTooltip = new TooltipDescription(value.ToString(), _localization);
                if (element.TryGetProperty($"abiltalent/name/{ability.AbilityTalentId.Id}", out value))
                    ability.Name = value.ToString();
                if (element.TryGetProperty($"abiltalent/short/{ability.AbilityTalentId.Id}", out value))
                    ability.Tooltip.ShortTooltip = new TooltipDescription(value.ToString(), _localization);
            }
        }
    }
}
