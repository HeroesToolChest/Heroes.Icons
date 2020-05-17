using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Icons.DataReader
{
    /// <summary>
    /// Base class reader for unit and hero related data.
    /// </summary>
    public abstract class UnitBaseData : DataDocumentBase, IDataDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing the unit data.</param>
        protected UnitBaseData(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing the unit data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected UnitBaseData(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the unit data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        protected UnitBaseData(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">The JSON file containing the unit data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        protected UnitBaseData(string jsonDataFilePath, GameStringReader gameStringReader)
            : base(jsonDataFilePath, gameStringReader)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonData">The JSON data containing the unit data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        protected UnitBaseData(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : base(jsonData, gameStringReader)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="utf8Json">The JSON data containing the unit data.</param>
        /// <param name="localization">The <see cref="Localization"/> of the file.</param>
        /// <param name="isAsync">Value indicating whether to parse the <paramref name="utf8Json"/> as async.</param>
        protected UnitBaseData(Stream utf8Json, Localization localization, bool isAsync = false)
            : base(utf8Json, localization, isAsync)
        {
        }

        /// <summary>
        /// Sets the <see cref="Unit"/>'s life data.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to read from.</param>
        /// <param name="unit">The data to be set from <paramref name="element"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
        protected virtual void SetUnitLife(JsonElement element, Unit unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            if (element.TryGetProperty("life", out JsonElement lifeElement))
            {
                unit.Life.LifeMax = lifeElement.GetProperty("amount").GetDouble();
                unit.Life.LifeScaling = lifeElement.GetProperty("scale").GetDouble();

                if (lifeElement.TryGetProperty("type", out JsonElement lifeType))
                    unit.Life.LifeType = lifeType.GetString();

                unit.Life.LifeRegenerationRate = lifeElement.GetProperty("regenRate").GetDouble();
                unit.Life.LifeRegenerationRateScaling = lifeElement.GetProperty("regenScale").GetDouble();
            }
        }

        /// <summary>
        /// Sets the <see cref="Unit"/>'s shield data.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to read from.</param>
        /// <param name="unit">The data to be set from <paramref name="element"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
        protected virtual void SetUnitShield(JsonElement element, Unit unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            if (element.TryGetProperty("shield", out JsonElement shieldElement))
            {
                unit.Shield.ShieldMax = shieldElement.GetProperty("amount").GetDouble();
                unit.Shield.ShieldScaling = shieldElement.GetProperty("scale").GetDouble();

                if (shieldElement.TryGetProperty("type", out JsonElement shieldType))
                    unit.Shield.ShieldType = shieldType.GetString();

                unit.Shield.ShieldRegenerationDelay = shieldElement.GetProperty("regenDelay").GetDouble();
                unit.Shield.ShieldRegenerationRate = shieldElement.GetProperty("regenRate").GetDouble();
                unit.Shield.ShieldRegenerationRateScaling = shieldElement.GetProperty("regenScale").GetDouble();
            }
        }

        /// <summary>
        /// Sets the <see cref="Unit"/>'s energy data.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to read from.</param>
        /// <param name="unit">The data to be set from <paramref name="element"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
        protected virtual void SetUnitEnergy(JsonElement element, Unit unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            if (element.TryGetProperty("energy", out JsonElement energyElement))
            {
                unit.Energy.EnergyMax = energyElement.GetProperty("amount").GetDouble();

                if (energyElement.TryGetProperty("type", out JsonElement energyType))
                    unit.Energy.EnergyType = energyType.GetString();

                unit.Energy.EnergyRegenerationRate = energyElement.GetProperty("regenRate").GetDouble();
            }
        }

        /// <summary>
        /// Sets the <see cref="Unit"/>'s armor data.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to read from.</param>
        /// <param name="unit">The data to be set from <paramref name="element"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
        protected virtual void SetUnitArmor(JsonElement element, Unit unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            if (element.TryGetProperty("armor", out JsonElement armorElement))
            {
                foreach (JsonProperty armorProperty in armorElement.EnumerateObject())
                {
                    UnitArmor unitArmor = new UnitArmor
                    {
                        Type = armorProperty.Name,
                        BasicArmor = armorProperty.Value.GetProperty("basic").GetInt32(),
                        AbilityArmor = armorProperty.Value.GetProperty("ability").GetInt32(),
                        SplashArmor = armorProperty.Value.GetProperty("splash").GetInt32(),
                    };

                    unit.Armor.Add(unitArmor);
                }
            }
        }

        /// <summary>
        /// Sets the <see cref="Unit"/>'s weapon data.
        /// </summary>
        /// <param name="element">The <see cref="JsonElement"/> to read from.</param>
        /// <param name="unit">The data to be set from <paramref name="element"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
        protected virtual void SetUnitWeapons(JsonElement element, Unit unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            if (element.TryGetProperty("weapons", out JsonElement weapons))
            {
                foreach (JsonElement weaponArrayElement in weapons.EnumerateArray())
                {
                    UnitWeapon unitWeapon = new UnitWeapon
                    {
                        WeaponNameId = weaponArrayElement.GetProperty("nameId").GetString(),
                        Range = weaponArrayElement.GetProperty("range").GetDouble(),
                        Period = weaponArrayElement.GetProperty("period").GetDouble(),
                        Damage = weaponArrayElement.GetProperty("damage").GetDouble(),
                        DamageScaling = weaponArrayElement.GetProperty("damageScale").GetDouble(),
                    };

                    // attribute factors
                    if (weaponArrayElement.TryGetProperty("damageFactor", out JsonElement damageFactor))
                    {
                        foreach (JsonProperty attributeFactorProperty in damageFactor.EnumerateObject())
                        {
                            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor
                            {
                                Type = attributeFactorProperty.Name,
                                Value = attributeFactorProperty.Value.GetDouble(),
                            };

                            unitWeapon.AttributeFactors.Add(weaponAttributeFactor);
                        }
                    }

                    unit.Weapons.Add(unitWeapon);
                }
            }
        }

        /// <summary>
        /// Adds the <see cref="Unit"/>'s abilities.
        /// </summary>
        /// <param name="unit">The data to be set from <paramref name="abilitiesElement"/>.</param>
        /// <param name="abilitiesElement">The <see cref="JsonElement"/> to read from.</param>
        /// <param name="parentLink">Indicates if the ability is a sub-ability.</param>
        protected virtual void AddAbilities(Unit unit, JsonElement abilitiesElement, string? parentLink = null)
        {
            if (abilitiesElement.TryGetProperty("basic", out JsonElement basicElement))
                AddTierAbilities(unit, basicElement, AbilityTiers.Basic, parentLink);
            if (abilitiesElement.TryGetProperty("heroic", out JsonElement heroicElement))
                AddTierAbilities(unit, heroicElement, AbilityTiers.Heroic, parentLink);
            if (abilitiesElement.TryGetProperty("trait", out JsonElement traitElement))
                AddTierAbilities(unit, traitElement, AbilityTiers.Trait, parentLink);
            if (abilitiesElement.TryGetProperty("mount", out JsonElement mountElement))
                AddTierAbilities(unit, mountElement, AbilityTiers.Mount, parentLink);
            if (abilitiesElement.TryGetProperty("activable", out JsonElement activableElement))
                AddTierAbilities(unit, activableElement, AbilityTiers.Activable, parentLink);
            if (abilitiesElement.TryGetProperty("hearth", out JsonElement hearthElement))
                AddTierAbilities(unit, hearthElement, AbilityTiers.Hearth, parentLink);
            if (abilitiesElement.TryGetProperty("taunt", out JsonElement tauntElement))
                AddTierAbilities(unit, tauntElement, AbilityTiers.Taunt, parentLink);
            if (abilitiesElement.TryGetProperty("dance", out JsonElement danceElement))
                AddTierAbilities(unit, danceElement, AbilityTiers.Dance, parentLink);
            if (abilitiesElement.TryGetProperty("spray", out JsonElement sprayElement))
                AddTierAbilities(unit, sprayElement, AbilityTiers.Spray, parentLink);
            if (abilitiesElement.TryGetProperty("voice", out JsonElement voiceElement))
                AddTierAbilities(unit, voiceElement, AbilityTiers.Voice, parentLink);
            if (abilitiesElement.TryGetProperty("mapMechanic", out JsonElement mapElement))
                AddTierAbilities(unit, mapElement, AbilityTiers.MapMechanic, parentLink);
            if (abilitiesElement.TryGetProperty("interact", out JsonElement interactElement))
                AddTierAbilities(unit, interactElement, AbilityTiers.Interact, parentLink);
            if (abilitiesElement.TryGetProperty("action", out JsonElement actionElement))
                AddTierAbilities(unit, actionElement, AbilityTiers.Action, parentLink);
            if (abilitiesElement.TryGetProperty("hidden", out JsonElement hiddenElement))
                AddTierAbilities(unit, hiddenElement, AbilityTiers.Hidden, parentLink);
            if (abilitiesElement.TryGetProperty("unknown", out JsonElement unkownElement))
                AddTierAbilities(unit, unkownElement, AbilityTiers.Unknown, parentLink);
        }

        /// <summary>
        /// Adds the <see cref="Unit"/>'s ability data.
        /// </summary>
        /// <param name="unit">The data to be set from <paramref name="tierElement"/>.</param>
        /// <param name="tierElement">The <see cref="JsonElement"/> to read from.</param>
        /// <param name="abilityTier">The tier of the ability.</param>
        /// <param name="parentLink">Indicates if the ability is a sub-ability.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unit"/> is null.</exception>
        protected virtual void AddTierAbilities(Unit unit, JsonElement tierElement, AbilityTiers abilityTier, string? parentLink)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));

            foreach (JsonElement element in tierElement.EnumerateArray())
            {
                Ability ability = new Ability
                {
                    Tier = abilityTier,
                };

                if (parentLink != null)
                {
                    string[] ids = parentLink.Split('|', StringSplitOptions.RemoveEmptyEntries);

                    if (ids.Length >= 2)
                    {
                        ability.ParentLink = new AbilityTalentId(ids[0], ids[1]);

                        if (ids.Length >= 3 && Enum.TryParse(ids[2], true, out AbilityTypes abilityTypes))
                            ability.ParentLink.AbilityType = abilityTypes;

                        if (ids.Length == 4 && bool.TryParse(ids[3], out bool isPassive))
                            ability.ParentLink.IsPassive = isPassive;
                    }
                }

                SetAbilityTalentBase(ability, element);

                unit.AddAbility(ability);
            }
        }

        /// <summary>
        /// Sets the <see cref="AbilityTalentBase"/> data of the <see cref="Ability"/>.
        /// </summary>
        /// <param name="abilityTalentBase">The <see cref="AbilityTalentBase"/> data to be set.</param>
        /// <param name="abilityTalentElement">The <see cref="JsonElement"/> to read from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="abilityTalentBase"/> is null.</exception>
        protected virtual void SetAbilityTalentBase(AbilityTalentBase abilityTalentBase, JsonElement abilityTalentElement)
        {
            if (abilityTalentBase is null)
                throw new ArgumentNullException(nameof(abilityTalentBase));

            abilityTalentBase.AbilityTalentId.ReferenceId = abilityTalentElement.GetProperty("nameId").GetString();

            if (abilityTalentElement.TryGetProperty("buttonId", out JsonElement buttonElement))
                abilityTalentBase.AbilityTalentId.ButtonId = buttonElement.GetString();

            if (abilityTalentElement.TryGetProperty("name", out JsonElement nameElement))
                abilityTalentBase.Name = nameElement.GetString();

            if (abilityTalentElement.TryGetProperty("icon", out JsonElement iconElement))
                abilityTalentBase.IconFileName = iconElement.GetString();
            if (abilityTalentElement.TryGetProperty("toggleCooldown", out JsonElement toggleCooldownElement))
                abilityTalentBase.Tooltip.Cooldown.ToggleCooldown = toggleCooldownElement.GetDouble();
            if (abilityTalentElement.TryGetProperty("lifeTooltip", out JsonElement lifeTooltipElement))
                abilityTalentBase.Tooltip.Life.LifeCostTooltip = new TooltipDescription(lifeTooltipElement.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("energyTooltip", out JsonElement energyTooltipElement))
                abilityTalentBase.Tooltip.Energy.EnergyTooltip = new TooltipDescription(energyTooltipElement.GetString(), Localization);

            // charges
            if (abilityTalentElement.TryGetProperty("charges", out JsonElement chargeElement))
            {
                abilityTalentBase.Tooltip.Charges.CountMax = chargeElement.GetProperty("countMax").GetInt32();

                if (chargeElement.TryGetProperty("countUse", out JsonElement countUseElement))
                    abilityTalentBase.Tooltip.Charges.CountUse = countUseElement.GetInt32();
                if (chargeElement.TryGetProperty("countStart", out JsonElement countStartElement))
                    abilityTalentBase.Tooltip.Charges.CountStart = countStartElement.GetInt32();
                if (chargeElement.TryGetProperty("hideCount", out JsonElement hideCountElement))
                    abilityTalentBase.Tooltip.Charges.IsHideCount = hideCountElement.GetBoolean();
                if (chargeElement.TryGetProperty("recastCooldown", out JsonElement recastCooldownElement))
                    abilityTalentBase.Tooltip.Charges.RecastCooldown = recastCooldownElement.GetDouble();
            }

            if (abilityTalentElement.TryGetProperty("cooldownTooltip", out JsonElement cooldownTooltipElement))
                abilityTalentBase.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(cooldownTooltipElement.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("shortTooltip", out JsonElement shortTooltipElement))
                abilityTalentBase.Tooltip.ShortTooltip = new TooltipDescription(shortTooltipElement.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("fullTooltip", out JsonElement fullTooltipElement))
                abilityTalentBase.Tooltip.FullTooltip = new TooltipDescription(fullTooltipElement.GetString(), Localization);

            if (Enum.TryParse(abilityTalentElement.GetProperty("abilityType").GetString(), out AbilityTypes abilityTypes))
                abilityTalentBase.AbilityTalentId.AbilityType = abilityTypes;
            else
                abilityTalentBase.AbilityTalentId.AbilityType = AbilityTypes.Unknown;

            if (abilityTalentElement.TryGetProperty("isActive", out JsonElement isActiveElement))
                abilityTalentBase.IsActive = isActiveElement.GetBoolean();
            if (abilityTalentElement.TryGetProperty("isPassive", out JsonElement isPassiveElement))
                abilityTalentBase.AbilityTalentId.IsPassive = isPassiveElement.GetBoolean();
            if (abilityTalentElement.TryGetProperty("isQuest", out JsonElement isQuestElement))
                abilityTalentBase.IsQuest = isQuestElement.GetBoolean();
        }
    }
}
