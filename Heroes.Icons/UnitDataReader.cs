using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Heroes.Icons
{
    public class UnitDataReader : UnitData
    {
        /// <summary>
        /// Loads the JSON file containing the unit data.
        /// </summary>
        /// <param name="jsonData">JSON file containing unit data.</param>
        public UnitDataReader(ReadOnlyMemory<byte> jsonData)
            : base(jsonData)
        {
        }

        /// <summary>
        /// Loads the JSON file containing the unit data.
        /// </summary>
        /// <param name="jsonData">JSON file containing unit data.</param>
        public UnitDataReader(string jsonData)
            : base(jsonData)
        {
        }

        /// <summary>
        /// Loads the JSON file containing the unit data along with the gamestring data.
        /// </summary>
        /// <param name="jsonData">JSON file containing unit data.</param>
        /// <param name="gameStringData">JSON file containing gamestrings.</param>
        public UnitDataReader(string jsonData, string jsonGameStringData)
            : base(jsonData, jsonGameStringData)
        {
        }

        /// <summary>
        /// Parses the JSON file containing the unit data.
        /// </summary>
        /// <param name="jsonHeroData">JSON file containing unit data.</param>
        /// <returns></returns>
        public static UnitDataReader Parse(ReadOnlyMemory<byte> jsonData)
        {
            return new UnitDataReader(jsonData);
        }

        /// <summary>
        /// Parses the JSON file containing the unit data.
        /// </summary>
        /// <param name="jsonHeroData">JSON file containing unit data.</param>
        /// <returns></returns>
        public static UnitDataReader Parse(string jsonData)
        {
            return new UnitDataReader(jsonData);
        }

        /// <summary>
        /// Parses the JSON file containing the unit data along with the locale gamestrings file.
        /// </summary>
        /// <param name="jsonData">JSON file containing unit data.</param>
        /// <param name="jsonGameStrings">JSON file containing gamestrings.</param>
        /// <returns></returns>
        public static UnitDataReader Parse(string jsonData, string jsonGameStrings)
        {
            return new UnitDataReader(jsonData, jsonGameStrings);
        }

        /// <summary>
        /// Updates the localized gamestrings for the given <see cref="Unit"/>.
        /// </summary>
        /// <param name="unit">Unit id to update.</param>
        /// <param name="jsonGameStrings">Gamestrings json file with localized text.</param>
        public static void UpdateGameStrings(Unit unit, string jsonGameStrings)
        {
            using UnitDataReader unitDataReader = new UnitDataReader(string.Empty, jsonGameStrings);

            unitDataReader.SetLocalizedGameStrings(unit);
        }

        /// <summary>
        /// Gets a <see cref="Unit"/> from the given unit <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Unit id to find.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <exception cref="KeyNotFoundException" />
        /// <returns></returns>
        public Unit GetUnitById(string id, bool abilities = false, bool subAbilities = false)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (TryGetUnitById(id, out Unit value, abilities, subAbilities))
                return value;
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Looks for a unit with the given <paramref name="id"/>, returning a value that indicates whether such value exists.
        /// </summary>
        /// <param name="id">Unit id to find.</param>
        /// <param name="value">When this method returns, a <see cref="Unit"/> object.</param>
        /// <param name="abilities">Value indicating to include abilities.</param>
        /// <param name="subAbilities">Value indicating to include sub-abilities.</param>
        /// <returns></returns>
        public bool TryGetUnitById(string id, out Unit value, bool abilities = false, bool subAbilities = false)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            value = new Unit();

            if (JsonDataDocument.RootElement.TryGetProperty(id, out JsonElement element))
            {
                value = GetUnitData(element, abilities, subAbilities);
                value.Id = id;
                value.CUnitId = id;

                return true;
            }

            return false;
        }

        private Unit GetUnitData(JsonElement element, bool includeAbilities, bool includeSubAbilities)
        {
            Unit unit = new Unit
            {
                HyperlinkId = element.GetProperty("hyperlinkId").GetString(),
            };

            if (element.TryGetProperty("name", out JsonElement value))
                unit.Name = value.GetString();
            if (element.TryGetProperty("innerRadius", out value))
                unit.InnerRadius = value.GetDouble();
            if (element.TryGetProperty("radius", out value))
                unit.Radius = value.GetDouble();
            if (element.TryGetProperty("sight", out value))
                unit.Sight = value.GetDouble();
            if (element.TryGetProperty("speed", out value))
                unit.Speed = value.GetDouble();
            if (element.TryGetProperty("killXP", out value))
                unit.KillXP = value.GetInt32();
            if (element.TryGetProperty("damageType", out value))
                unit.DamageType = value.GetString();
            if (element.TryGetProperty("scalingLinkId", out value))
                unit.ScalingBehaviorLink = value.GetString();
            if (element.TryGetProperty("description", out value))
                unit.Description = new TooltipDescription(value.GetString());

            if (element.TryGetProperty("descriptors", out value))
            {
                foreach (JsonElement descriptorArrayElement in value.EnumerateArray())
                    unit.AddHeroDescriptor(descriptorArrayElement.GetString());
            }

            if (element.TryGetProperty("attributes", out value))
            {
                foreach (JsonElement attributeArrayElement in value.EnumerateArray())
                    unit.AddAttribute(attributeArrayElement.GetString());
            }

            if (element.TryGetProperty("units", out value))
            {
                foreach (JsonElement unitArrayElement in value.EnumerateArray())
                    unit.AddUnitId(unitArrayElement.GetString());
            }

            // portraits
            if (element.TryGetProperty("portraits", out value))
            {
                if (value.TryGetProperty("targetInfo", out JsonElement portraitValue))
                    unit.UnitPortrait.TargetInfoPanelFileName = portraitValue.GetString();
                if (value.TryGetProperty("minimap", out portraitValue))
                    unit.UnitPortrait.MiniMapIconFileName = portraitValue.GetString();
            }

            // life
            SetUnitLife(element, unit);

            // shield
            SetUnitShield(element, unit);

            // energy
            SetUnitEnergy(element, unit);

            // armor
            SetUnitArmor(element, unit);

            // weapons
            SetUnitWeapons(element, unit);

            // abilities
            if (includeAbilities && element.TryGetProperty("abilities", out JsonElement abilities))
            {
                AddAbilities(unit, abilities);
            }

            // TODO: subAbilities
            /*if (includeSubAbilities && heroElement.TryGetProperty("subAbilities", out JsonElement subAbilities))
            //{
            //    foreach (JsonElement subAbilityArrayElement in subAbilities.EnumerateArray())
            //    {
            //        foreach (JsonProperty subAbilityProperty in subAbilityArrayElement.EnumerateObject())
            //        {
            //            string parentLink = subAbilityProperty.Name;
            //            subAbilityProperty.Value
            //        }
            //    }
            }*/

            SetLocalizedGameStrings(unit);

            return unit;
        }
    }
}
