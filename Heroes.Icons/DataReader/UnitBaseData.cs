using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.Text.Json;

namespace Heroes.Icons.DataReader
{
    /// <summary>
    /// Base class reader for unit and hero related data.
    /// </summary>
    public abstract class UnitBaseData : DataReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing the data.</param>
        public UnitBaseData(string jsonDataFilePath)
            : base(jsonDataFilePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing the data.</param>
        /// <param name="localization">The localization of the file.</param>
        public UnitBaseData(string jsonDataFilePath, Localization localization)
            : base(jsonDataFilePath, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonData">JSON data containing the data.</param>
        /// <param name="localization">The localization of the file.</param>
        public UnitBaseData(ReadOnlyMemory<byte> jsonData, Localization localization)
            : base(jsonData, localization)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonDataFilePath">JSON file containing the data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public UnitBaseData(string jsonDataFilePath, GameStringReader gameStringReader)
            : base(jsonDataFilePath, gameStringReader)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitBaseData"/> class.
        /// </summary>
        /// <param name="jsonData">JSON data containing the data.</param>
        /// <param name="gameStringReader">Instance of a <see cref="GameStringReader"/>.</param>
        public UnitBaseData(ReadOnlyMemory<byte> jsonData, GameStringReader gameStringReader)
            : base(jsonData, gameStringReader)
        {
        }

        /// <summary>
        /// Sets the unit's life data.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="unit"></param>
        protected virtual void SetUnitLife(JsonElement element, Unit unit)
        {
            if (element.TryGetProperty("life", out JsonElement value))
            {
                unit.Life.LifeMax = value.GetProperty("amount").GetDouble();
                unit.Life.LifeScaling = value.GetProperty("scale").GetDouble();

                if (value.TryGetProperty("type", out JsonElement lifeType))
                    unit.Life.LifeType = lifeType.GetString();

                unit.Life.LifeRegenerationRate = value.GetProperty("regenRate").GetDouble();
                unit.Life.LifeRegenerationRateScaling = value.GetProperty("regenScale").GetDouble();
            }
        }

        /// <summary>
        /// Sets the unit's shield data.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="unit"></param>
        protected virtual void SetUnitShield(JsonElement element, Unit unit)
        {
            if (element.TryGetProperty("shield", out JsonElement value))
            {
                unit.Shield.ShieldMax = value.GetProperty("amount").GetDouble();
                unit.Shield.ShieldScaling = value.GetProperty("scale").GetDouble();

                if (value.TryGetProperty("type", out JsonElement shieldType))
                    unit.Shield.ShieldType = shieldType.GetString();

                unit.Shield.ShieldRegenerationDelay = value.GetProperty("regenDelay").GetDouble();
                unit.Shield.ShieldRegenerationRate = value.GetProperty("regenRate").GetDouble();
                unit.Shield.ShieldRegenerationRateScaling = value.GetProperty("regenScale").GetDouble();
            }
        }

        /// <summary>
        /// Sets the unit's energy data.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="unit"></param>
        protected virtual void SetUnitEnergy(JsonElement element, Unit unit)
        {
            if (element.TryGetProperty("energy", out JsonElement value))
            {
                unit.Energy.EnergyMax = value.GetProperty("amount").GetDouble();

                if (value.TryGetProperty("type", out JsonElement energyType))
                    unit.Energy.EnergyType = energyType.GetString();

                unit.Energy.EnergyRegenerationRate = value.GetProperty("regenRate").GetDouble();
            }
        }

        /// <summary>
        /// Sets the unit's armor data.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="unit"></param>
        protected virtual void SetUnitArmor(JsonElement element, Unit unit)
        {
            if (element.TryGetProperty("armor", out JsonElement value))
            {
                foreach (JsonProperty armorProperty in value.EnumerateObject())
                {
                    UnitArmor unitArmor = new UnitArmor
                    {
                        Type = armorProperty.Name,
                        BasicArmor = armorProperty.Value.GetProperty("basic").GetInt32(),
                        AbilityArmor = armorProperty.Value.GetProperty("ability").GetInt32(),
                        SplashArmor = armorProperty.Value.GetProperty("splash").GetInt32(),
                    };

                    unit.AddUnitArmor(unitArmor);
                }
            }
        }

        /// <summary>
        /// Sets the unit's weapon data.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="unit"></param>
        protected virtual void SetUnitWeapons(JsonElement element, Unit unit)
        {
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

                            unitWeapon.AddAttributeFactor(weaponAttributeFactor);
                        }
                    }

                    unit.AddUnitWeapon(unitWeapon);
                }
            }
        }

        /// <summary>
        /// Adds the unit's abilities.
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="abilitiesElement"></param>
        /// <param name="parentLink">Indicates if the ability is a sub-ability.</param>
        protected virtual void AddAbilities(Unit unit, JsonElement abilitiesElement, string? parentLink = null)
        {
            if (abilitiesElement.TryGetProperty("basic", out JsonElement tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Basic, parentLink);
            if (abilitiesElement.TryGetProperty("heroic", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Heroic, parentLink);
            if (abilitiesElement.TryGetProperty("trait", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Trait, parentLink);
            if (abilitiesElement.TryGetProperty("mount", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Mount, parentLink);
            if (abilitiesElement.TryGetProperty("activable", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Activable, parentLink);
            if (abilitiesElement.TryGetProperty("hearth", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Hearth, parentLink);
            if (abilitiesElement.TryGetProperty("taunt", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Taunt, parentLink);
            if (abilitiesElement.TryGetProperty("dance", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Dance, parentLink);
            if (abilitiesElement.TryGetProperty("spray", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Spray, parentLink);
            if (abilitiesElement.TryGetProperty("voice", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Voice, parentLink);
            if (abilitiesElement.TryGetProperty("mapMechanic", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.MapMechanic, parentLink);
            if (abilitiesElement.TryGetProperty("interact", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Interact, parentLink);
            if (abilitiesElement.TryGetProperty("action", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Action, parentLink);
            if (abilitiesElement.TryGetProperty("hidden", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Hidden, parentLink);
            if (abilitiesElement.TryGetProperty("unknown", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Unknown, parentLink);
        }

        /// <summary>
        /// Adds the ability data.
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="tierElement"></param>
        /// <param name="abilityTier">The tier of the ability.</param>
        /// <param name="parentLink">Indicates if the ability is a sub-ability.</param>
        protected virtual void AddTierAbilities(Unit unit, JsonElement tierElement, AbilityTier abilityTier, string? parentLink)
        {
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

                        if (ids.Length >= 3 && Enum.TryParse(ids[2], true, out AbilityType abilityType))
                            ability.ParentLink.AbilityType = abilityType;

                        if (ids.Length == 4 && bool.TryParse(ids[3], out bool isPassive))
                            ability.ParentLink.IsPassive = isPassive;
                    }
                }

                SetAbilityTalentBase(ability, element);

                unit.AddAbility(ability);
            }
        }

        /// <summary>
        /// Sets the base data of the abilityTalent.
        /// </summary>
        /// <param name="abilityTalentBase"></param>
        /// <param name="abilityTalentElement"></param>
        protected virtual void SetAbilityTalentBase(AbilityTalentBase abilityTalentBase, JsonElement abilityTalentElement)
        {
            abilityTalentBase.AbilityTalentId.ReferenceId = abilityTalentElement.GetProperty("nameId").GetString();

            if (abilityTalentElement.TryGetProperty("buttonId", out JsonElement value))
                abilityTalentBase.AbilityTalentId.ButtonId = value.GetString();

            if (abilityTalentElement.TryGetProperty("name", out value))
                abilityTalentBase.Name = value.GetString();

            if (abilityTalentElement.TryGetProperty("icon", out value))
                abilityTalentBase.IconFileName = value.GetString();
            if (abilityTalentElement.TryGetProperty("toggleCooldown", out value))
                abilityTalentBase.Tooltip.Cooldown.ToggleCooldown = value.GetDouble();
            if (abilityTalentElement.TryGetProperty("lifeTooltip", out value))
                abilityTalentBase.Tooltip.Life.LifeCostTooltip = new TooltipDescription(value.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("energyTooltip", out value))
                abilityTalentBase.Tooltip.Energy.EnergyTooltip = new TooltipDescription(value.GetString(), Localization);

            // charges
            if (abilityTalentElement.TryGetProperty("charges", out JsonElement chargeElement))
            {
                abilityTalentBase.Tooltip.Charges.CountMax = chargeElement.GetProperty("countMax").GetInt32();

                if (chargeElement.TryGetProperty("countUse", out value))
                    abilityTalentBase.Tooltip.Charges.CountUse = value.GetInt32();
                if (chargeElement.TryGetProperty("countStart", out value))
                    abilityTalentBase.Tooltip.Charges.CountStart = value.GetInt32();
                if (chargeElement.TryGetProperty("hideCount", out value))
                    abilityTalentBase.Tooltip.Charges.IsHideCount = value.GetBoolean();
                if (chargeElement.TryGetProperty("recastCooldown", out value))
                    abilityTalentBase.Tooltip.Charges.RecastCooldown = value.GetDouble();
            }

            if (abilityTalentElement.TryGetProperty("cooldownTooltip", out value))
                abilityTalentBase.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(value.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("shortTooltip", out value))
                abilityTalentBase.Tooltip.ShortTooltip = new TooltipDescription(value.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("fullTooltip", out value))
                abilityTalentBase.Tooltip.FullTooltip = new TooltipDescription(value.GetString(), Localization);

            if (Enum.TryParse(abilityTalentElement.GetProperty("abilityType").GetString(), out AbilityType abilityType))
                abilityTalentBase.AbilityTalentId.AbilityType = abilityType;
            else
                abilityTalentBase.AbilityTalentId.AbilityType = AbilityType.Unknown;

            if (abilityTalentElement.TryGetProperty("isActive", out value))
                abilityTalentBase.IsActive = value.GetBoolean();
            if (abilityTalentElement.TryGetProperty("isPassive", out value))
                abilityTalentBase.AbilityTalentId.IsPassive = value.GetBoolean();
            if (abilityTalentElement.TryGetProperty("isQuest", out value))
                abilityTalentBase.IsQuest = value.GetBoolean();
        }
    }
}
