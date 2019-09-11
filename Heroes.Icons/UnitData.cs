using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System;
using System.Text.Json;

namespace Heroes.Icons
{
    public abstract class UnitData : DataReader
    {
        public UnitData(ReadOnlyMemory<byte> jsonData)
            : base(jsonData)
        {
        }

        public UnitData(string dataFilePath)
            : base(dataFilePath)
        {
        }

        public UnitData(string dataFilePath, string gameStringFilePath)
            : base(dataFilePath, gameStringFilePath)
        {
        }

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

        protected virtual void AddAbilities(Unit unit, JsonElement abilitiesElement)
        {
            if (abilitiesElement.TryGetProperty("basic", out JsonElement tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Basic);
            if (abilitiesElement.TryGetProperty("heroic", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Heroic);
            if (abilitiesElement.TryGetProperty("trait", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Trait);
            if (abilitiesElement.TryGetProperty("mount", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Mount);
            if (abilitiesElement.TryGetProperty("activable", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Activable);
            if (abilitiesElement.TryGetProperty("hearth", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Hearth);
            if (abilitiesElement.TryGetProperty("taunt", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Taunt);
            if (abilitiesElement.TryGetProperty("dance", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Dance);
            if (abilitiesElement.TryGetProperty("spray", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Spray);
            if (abilitiesElement.TryGetProperty("voice", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Voice);
            if (abilitiesElement.TryGetProperty("mapMechanic", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.MapMechanic);
            if (abilitiesElement.TryGetProperty("interact", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Interact);
            if (abilitiesElement.TryGetProperty("action", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Activable);
            if (abilitiesElement.TryGetProperty("hidden", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Hidden);
            if (abilitiesElement.TryGetProperty("unknown", out tierElement))
                AddTierAbilities(unit, tierElement, AbilityTier.Unknown);
        }

        protected virtual void AddTierAbilities(Unit unit, JsonElement tierElement, AbilityTier abilityTier)
        {
            foreach (JsonElement element in tierElement.EnumerateArray())
            {
                Ability ability = new Ability
                {
                    Tier = abilityTier,
                };

                SetAbilityTalentBase(ability, element);

                unit.AddAbility(ability);
            }
        }

        protected virtual void SetAbilityTalentBase(AbilityTalentBase abilityTalentBase, JsonElement abilityTalentElement)
        {
            abilityTalentBase.AbilityTalentId = new AbilityTalentId(abilityTalentElement.GetProperty("nameId").GetString(), abilityTalentElement.GetProperty("buttonId").GetString());

            if (abilityTalentElement.TryGetProperty("name", out JsonElement name))
                abilityTalentBase.Name = name.GetString();

            if (abilityTalentElement.TryGetProperty("icon", out JsonElement icon))
                abilityTalentBase.IconFileName = icon.GetString();
            if (abilityTalentElement.TryGetProperty("toggleCooldown", out JsonElement toggleCooldown))
                abilityTalentBase.Tooltip.Cooldown.ToggleCooldown = toggleCooldown.GetDouble();
            if (abilityTalentElement.TryGetProperty("lifeTooltip", out JsonElement lifeTooltip))
                abilityTalentBase.Tooltip.Life.LifeCostTooltip = new TooltipDescription(lifeTooltip.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("energyTooltip", out JsonElement energyTooltip))
                abilityTalentBase.Tooltip.Energy.EnergyTooltip = new TooltipDescription(energyTooltip.GetString(), Localization);

            // charges
            if (abilityTalentElement.TryGetProperty("charges", out JsonElement charges))
            {
                abilityTalentBase.Tooltip.Charges.CountMax = charges.GetProperty("countMax").GetInt32();

                if (charges.TryGetProperty("countUse", out JsonElement countUse))
                    abilityTalentBase.Tooltip.Charges.CountUse = countUse.GetInt32();
                if (charges.TryGetProperty("countStart", out JsonElement countStart))
                    abilityTalentBase.Tooltip.Charges.CountStart = countStart.GetInt32();
                if (charges.TryGetProperty("hideCount", out JsonElement hideCount))
                    abilityTalentBase.Tooltip.Charges.IsHideCount = hideCount.GetBoolean();
                if (charges.TryGetProperty("recastCooldown", out JsonElement recastCooldown))
                    abilityTalentBase.Tooltip.Charges.RecastCooldown = recastCooldown.GetDouble();
            }

            if (abilityTalentElement.TryGetProperty("cooldownTooltip", out JsonElement cooldownTooltip))
                abilityTalentBase.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(cooldownTooltip.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("shortTooltip", out JsonElement shortTooltip))
                abilityTalentBase.Tooltip.ShortTooltip = new TooltipDescription(shortTooltip.GetString(), Localization);
            if (abilityTalentElement.TryGetProperty("fullTooltip", out JsonElement fullTooltip))
                abilityTalentBase.Tooltip.FullTooltip = new TooltipDescription(fullTooltip.GetString(), Localization);

            if (Enum.TryParse(abilityTalentElement.GetProperty("abilityType").GetString(), out AbilityType abilityType))
                abilityTalentBase.AbilityType = abilityType;
            else
                abilityTalentBase.AbilityType = AbilityType.Unknown;

            if (abilityTalentElement.TryGetProperty("isActive", out JsonElement isActive))
                abilityTalentBase.IsActive = isActive.GetBoolean();
            if (abilityTalentElement.TryGetProperty("isPassive", out JsonElement isPassive))
                abilityTalentBase.IsPassive = isPassive.GetBoolean();
            if (abilityTalentElement.TryGetProperty("isQuest", out JsonElement isQuest))
                abilityTalentBase.IsQuest = isQuest.GetBoolean();
        }

        protected virtual void SetLocalizedGameStrings(Unit unit)
        {
            if (JsonGameStringDocument != null)
            {
                JsonElement element = JsonGameStringDocument.RootElement;

                if (element.TryGetProperty($"unit/damagetype/{unit.CUnitId}", out JsonElement value))
                    unit.DamageType = value.ToString();
                if (element.TryGetProperty($"unit/description/{unit.CUnitId}", out value))
                    unit.Description = new TooltipDescription(value.ToString(), Localization);
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
                        ability.Tooltip.Cooldown.CooldownTooltip = new TooltipDescription(value.ToString(), Localization);
                    if (element.TryGetProperty($"abiltalent/energy/{ability.AbilityTalentId.Id}", out value))
                        ability.Tooltip.Energy.EnergyTooltip = new TooltipDescription(value.ToString(), Localization);
                    if (element.TryGetProperty($"abiltalent/full/{ability.AbilityTalentId.Id}", out value))
                        ability.Tooltip.FullTooltip = new TooltipDescription(value.ToString(), Localization);
                    if (element.TryGetProperty($"abiltalent/life/{ability.AbilityTalentId.Id}", out value))
                        ability.Tooltip.Life.LifeCostTooltip = new TooltipDescription(value.ToString(), Localization);
                    if (element.TryGetProperty($"abiltalent/name/{ability.AbilityTalentId.Id}", out value))
                        ability.Name = value.ToString();
                    if (element.TryGetProperty($"abiltalent/short/{ability.AbilityTalentId.Id}", out value))
                        ability.Tooltip.ShortTooltip = new TooltipDescription(value.ToString(), Localization);
                }
            }
        }
    }
}
