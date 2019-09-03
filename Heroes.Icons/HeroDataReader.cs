using Heroes.Models;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace Heroes.Icons
{
    public sealed class HeroDataReader : IDisposable
    {
        private readonly string _filePath;
        private readonly JsonDocument _jsonDocument;

        private HeroDataReader(string filePath)
        {
            _filePath = filePath;
            _jsonDocument = JsonDocument.Parse(File.ReadAllBytes(_filePath));
        }

        public static HeroDataReader Parse(string filePath)
        {
            return new HeroDataReader(filePath);
        }

        //public HeroData()
        //{
        //    Build = int.MaxValue;

        //    LoadData();
        //}

        //public HeroData(int build)
        //{
        //    if (build < 0)
        //        Build = 0;

        //    Build = build;

        //    LoadData();
        //}

        public Hero GetHero(string heroId)
        {
            Hero hero = new Hero();

            JsonElement jsonElement = _jsonDocument.RootElement;

            if (jsonElement.TryGetProperty(heroId, out JsonElement heroIdElement))
            {
                hero.Id = heroId;
                hero.Name = heroIdElement.GetProperty("name").GetString();
                hero.CUnitId = heroIdElement.GetProperty("unitId").GetString();
                hero.HyperlinkId = heroIdElement.GetProperty("hyperlinkId").GetString();
                hero.AttributeId = heroIdElement.GetProperty("attributeId").GetString();
                hero.Difficulty = heroIdElement.GetProperty("difficulty").GetString();

                if (Enum.TryParse(heroIdElement.GetProperty("franchise").GetString(), out HeroFranchise heroFranchise))
                    hero.Franchise = heroFranchise;
                else
                    hero.Franchise = HeroFranchise.Unknown;

                if (Enum.TryParse(heroIdElement.GetProperty("gender").GetString(), out UnitGender unitGender))
                    hero.Gender = unitGender;
                else
                    hero.Gender = UnitGender.Neutral;

                if (heroIdElement.TryGetProperty("title", out JsonElement title))
                    hero.Title = title.GetString();

                hero.InnerRadius = heroIdElement.GetProperty("innerRadius").GetDouble();
                hero.Radius = heroIdElement.GetProperty("radius").GetDouble();

                if (heroIdElement.GetProperty("releaseDate").TryGetDateTime(out DateTime releaseDate))
                    hero.ReleaseDate = releaseDate;

                hero.Sight = heroIdElement.GetProperty("sight").GetDouble();
                hero.Speed = heroIdElement.GetProperty("speed").GetDouble();
                hero.Type = heroIdElement.GetProperty("type").GetString();

                if (Enum.TryParse(heroIdElement.GetProperty("rarity").GetString(), out Rarity rarity))
                    hero.Rarity = rarity;
                else
                    hero.Rarity = Rarity.Unknown;

                if (heroIdElement.TryGetProperty("scalingLinkId", out JsonElement scalingLinkId))
                    hero.ScalingBehaviorLink = scalingLinkId.GetString();

                if (heroIdElement.TryGetProperty("searchText", out JsonElement searchText))
                    hero.SearchText = searchText.GetString();

                if (heroIdElement.TryGetProperty("description", out JsonElement description))
                    hero.Description = new TooltipDescription(description.GetString());

                if (heroIdElement.TryGetProperty("descriptors", out JsonElement descriptors))
                {
                    foreach (JsonElement descriptorArrayElement in descriptors.EnumerateArray())
                        hero.AddHeroDescriptor(descriptorArrayElement.GetString());
                }

                if (heroIdElement.TryGetProperty("units", out JsonElement units))
                {
                    foreach (JsonElement unitArrayElement in units.EnumerateArray())
                        hero.AddUnitId(unitArrayElement.GetString());
                }

                // portraits
                if (heroIdElement.TryGetProperty("portraits", out JsonElement portraits))
                {
                    if (portraits.TryGetProperty("heroSelect", out JsonElement heroSelect))
                        hero.HeroPortrait.HeroSelectPortraitFileName = heroSelect.GetString();
                    if (portraits.TryGetProperty("leaderboard", out JsonElement leaderboard))
                        hero.HeroPortrait.LeaderboardPortraitFileName = leaderboard.GetString();
                    if (portraits.TryGetProperty("loading", out JsonElement loading))
                        hero.HeroPortrait.LoadingScreenPortraitFileName = loading.GetString();
                    if (portraits.TryGetProperty("partyPanel", out JsonElement partyPanel))
                        hero.HeroPortrait.PartyPanelPortraitFileName = partyPanel.GetString();
                    if (portraits.TryGetProperty("target", out JsonElement target))
                        hero.HeroPortrait.TargetPortraitFileName = target.GetString();
                    if (portraits.TryGetProperty("draftScreen", out JsonElement draftScreen))
                        hero.HeroPortrait.DraftScreenFileName = draftScreen.GetString();
                    if (portraits.TryGetProperty("partyFrames", out JsonElement partyFrames))
                    {
                        foreach (JsonElement partyFrameArrayElement in partyFrames.EnumerateArray())
                        {
                            hero.HeroPortrait.PartyFrameFileName.Add(partyFrameArrayElement.GetString());
                        }
                    }
                }

                // life
                if (heroIdElement.TryGetProperty("life", out JsonElement life))
                {
                    hero.Life.LifeMax = life.GetProperty("amount").GetDouble();
                    hero.Life.LifeScaling = life.GetProperty("scale").GetDouble();

                    if (life.TryGetProperty("type", out JsonElement type))
                        hero.Life.LifeType = type.GetString();

                    hero.Life.LifeRegenerationRate = life.GetProperty("regenRate").GetDouble();
                    hero.Life.LifeRegenerationRateScaling = life.GetProperty("regenScale").GetDouble();
                }

                // shields
                if (heroIdElement.TryGetProperty("shield", out JsonElement shield))
                {
                    hero.Shield.ShieldMax = shield.GetProperty("amount").GetDouble();
                    hero.Shield.ShieldScaling = shield.GetProperty("scale").GetDouble();

                    if (shield.TryGetProperty("type", out JsonElement type))
                        hero.Shield.ShieldType = type.GetString();

                    hero.Shield.ShieldRegenerationDelay = shield.GetProperty("regenDelay").GetDouble();
                    hero.Shield.ShieldRegenerationRate = shield.GetProperty("regenRate").GetDouble();
                    hero.Shield.ShieldRegenerationRateScaling = shield.GetProperty("regenScale").GetDouble();
                }

                // energy
                if (heroIdElement.TryGetProperty("energy", out JsonElement energy))
                {
                    hero.Energy.EnergyMax = energy.GetProperty("amount").GetDouble();

                    if (energy.TryGetProperty("type", out JsonElement type))
                        hero.Energy.EnergyType = type.GetString();

                    hero.Energy.EnergyRegenerationRate = energy.GetProperty("regenRate").GetDouble();
                }

                // armor
                if (heroIdElement.TryGetProperty("armor", out JsonElement armor))
                {
                    foreach (JsonProperty armorProperty in armor.EnumerateObject())
                    {
                        UnitArmor unitArmor = new UnitArmor
                        {
                            Type = armorProperty.Name,
                            BasicArmor = armorProperty.Value.GetProperty("basic").GetInt32(),
                            AbilityArmor = armorProperty.Value.GetProperty("ability").GetInt32(),
                            SplashArmor = armorProperty.Value.GetProperty("splash").GetInt32(),
                        };

                        hero.AddUnitArmor(unitArmor);
                    }
                }

                // roles
                foreach (JsonElement roleArrayElement in heroIdElement.GetProperty("roles").EnumerateArray())
                    hero.AddRole(roleArrayElement.GetString());

                // expandedRole
                if (heroIdElement.TryGetProperty("expandedRole", out JsonElement expandedRole))
                    hero.ExpandedRole = expandedRole.GetString();

                // ratings
                if (heroIdElement.TryGetProperty("ratings", out JsonElement ratings))
                {
                    hero.Ratings.Complexity = ratings.GetProperty("complexity").GetDouble();
                    hero.Ratings.Damage = ratings.GetProperty("damage").GetDouble();
                    hero.Ratings.Survivability = ratings.GetProperty("survivability").GetDouble();
                    hero.Ratings.Utility = ratings.GetProperty("utility").GetDouble();
                }

                // weapons
                if (heroIdElement.TryGetProperty("weapons", out JsonElement weapons))
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

                        hero.AddUnitWeapon(unitWeapon);
                    }
                }
            }

            return hero;
        }

        public void Dispose()
        {
            _jsonDocument.Dispose();
        }

        /// <summary>
        /// Returns the hero's name from the attribute id.
        /// </summary>
        /// <param name="attributeId">Four character hero id.</param>
        /// <returns></returns>
        //string HeroNameFromAttributeId(string attributeId);

        /// <summary>
        /// Returns the hero's name from the short name.
        /// </summary>
        /// <param name="shortName">Short name of hero.</param>
        /// <returns></returns>
        //string HeroNameFromShortName(string shortName);
    }
}
