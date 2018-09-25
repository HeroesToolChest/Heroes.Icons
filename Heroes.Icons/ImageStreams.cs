using Heroes.Icons.Models;
using Heroes.Models;
using Heroes.Models.AbilityTalents;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Heroes.Icons
{
    public static class ImageStreams
    {
        private static readonly Assembly HeroesIconsAssembly = Assembly.GetExecutingAssembly();
        private static readonly string StreamFilePath = "Heroes.Icons.Images";

        /// <summary>
        /// Returns the image stream for the abilityTalant.
        /// </summary>
        /// <param name="abilityTalentBase"></param>
        /// <returns></returns>
        public static Stream AbilityTalentImage(this AbilityTalentBase abilityTalentBase)
        {
            if (string.IsNullOrEmpty(abilityTalentBase.IconFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.AbilityTalents.{abilityTalentBase.IconFileName.ToLower()}");
        }

        /// <summary>
        /// Returns the MVP match award image stream.
        /// </summary>
        /// <param name="matchAward"></param>
        /// <param name="awardColor">The MVP award color.</param>
        /// <returns></returns>
        public static Stream MatchAwardMVPScreenImage(this MatchAward matchAward, MVPAwardColor awardColor)
        {
            if (string.IsNullOrEmpty(matchAward.MVPScreenImageFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Awards.{matchAward.MVPScreenImageFileName.Replace("{mvpColor}", awardColor.ToString().ToLower())}");
        }

        /// <summary>
        /// Returns the score screen match award image stream.
        /// </summary>
        /// <param name="matchAward"></param>
        /// <param name="awardColor">The score screen award color.</param>
        /// <returns></returns>
        public static Stream MatchAwardScoreScreenImage(this MatchAward matchAward, ScoreScreenAwardColor awardColor)
        {
            if (string.IsNullOrEmpty(matchAward.ScoreScreenImageFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Awards.{matchAward.ScoreScreenImageFileName.Replace("{mvpColor}", awardColor.ToString().ToLower())}");
        }

        /// <summary>
        /// Returns the battleground image stream.
        /// </summary>
        /// <param name="battleground"></param>
        /// <returns></returns>
        public static Stream BattlegroundImage(this Battleground battleground)
        {
            if (string.IsNullOrEmpty(battleground.ImageFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Battlegrounds.{battleground.ImageFileName.ToLower()}");
        }

        /// <summary>
        /// Returns the homescreen image stream.
        /// </summary>
        /// <param name="homescreen"></param>
        /// <returns></returns>
        public static Stream HomescreenImage(this Homescreen homescreen)
        {
            if (string.IsNullOrEmpty(homescreen.ImageFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Homescreens.{homescreen.ImageFileName.ToLower()}");
        }

        /// <summary>
        /// Returns the hero select image stream.
        /// </summary>
        /// <param name="heroPortrait"></param>
        /// <returns></returns>
        public static Stream HeroSelectImage(this HeroPortrait heroPortrait)
        {
            if (string.IsNullOrEmpty(heroPortrait.HeroSelectPortraitFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.HeroSelectPortraits.{heroPortrait.HeroSelectPortraitFileName.ToLower()}");
        }

        /// <summary>
        /// Returns the leaderboard image stream.
        /// </summary>
        /// <param name="heroPortrait"></param>
        /// <returns></returns>
        public static Stream LeaderboardImage(this HeroPortrait heroPortrait)
        {
            if (string.IsNullOrEmpty(heroPortrait.LeaderboardPortraitFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.LeaderboardPortraits.{heroPortrait.LeaderboardPortraitFileName.ToLower()}");
        }

        /// <summary>
        /// Returns the target portrait iamge stream.
        /// </summary>
        /// <param name="heroPortrait"></param>
        /// <returns></returns>
        public static Stream TargetPortraitImage(this HeroPortrait heroPortrait)
        {
            if (string.IsNullOrEmpty(heroPortrait.TargetPortraitFileName))
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.TargetPortraits.{heroPortrait.TargetPortraitFileName.ToLower()}");
        }

        /// <summary>
        /// Returns the hero franchise image stream.
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public static Stream HeroFranchiseImage(this Hero hero)
        {
            if (hero.Franchise == HeroFranchise.Unknown)
                return null;

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Franchises.hero_franchise_{hero.Franchise.ToString().ToLower()}.png");
        }

        /// <summary>
        /// Returns the hero's role image stream.
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public static IEnumerable<Stream> HeroRoleImage(this Hero hero)
        {
            if (hero.Roles == null || hero.Roles.Count < 1)
                return null;

            List<Stream> roles = new List<Stream>();

            foreach (string role in hero.Roles)
            {
                roles.Add(HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Roles.hero_role_{role.ToLower()}.png"));
            }

            return roles;
        }

        /// <summary>
        /// Returns the party icon image stream.
        /// </summary>
        /// <param name="partyIconColor">The color of the party icon.</param>
        /// <returns></returns>
        public static Stream PartyIconImage(PartyIconColor partyIconColor)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.PartyIcons.ui_ingame_loadscreen_partylink_{partyIconColor.ToString().ToLower()}.png");
        }

        /// <summary>
        /// Returns the image stream of the selected icon.
        /// </summary>
        /// <param name="icon">The selected icon.</param>
        /// <returns></returns>
        public static Stream OtherIconImage(OtherIcon icon)
        {
            string fileName = string.Empty;

            switch (icon)
            {
                case OtherIcon.Silence:
                    fileName = "storm_ui_silencepenalty.png";
                    break;
                case OtherIcon.VoiceSilence:
                    fileName = "storm_ui_silencepenalty_voice.png";
                    break;
                case OtherIcon.Quest:
                    fileName = "storm_ui_taskbar_buttonicon_quests.png";
                    break;
                case OtherIcon.LongarrowLeftDisabled:
                    fileName = "storm_ui_glues_button_longarrow_left_disabled.png";
                    break;
                case OtherIcon.LongarrowLeftDown:
                    fileName = "storm_ui_glues_button_longarrow_left_down.png";
                    break;
                case OtherIcon.LongarrowLeftHover:
                    fileName = "storm_ui_glues_button_longarrow_left_hover.png";
                    break;
                case OtherIcon.LongarrowLeftNormal:
                    fileName = "storm_ui_glues_button_longarrow_left_normal.png";
                    break;
                case OtherIcon.LongarrowRightDisabled:
                    fileName = "storm_ui_glues_button_longarrow_right_disabled.png";
                    break;
                case OtherIcon.LongarrowRightDown:
                    fileName = "storm_ui_glues_button_longarrow_right_down.png";
                    break;
                case OtherIcon.LongarrowRightHover:
                    fileName = "storm_ui_glues_button_longarrow_right_hover.png";
                    break;
                case OtherIcon.LongarrowRightNormal:
                    fileName = "storm_ui_glues_button_longarrow_right_normal.png";
                    break;
                case OtherIcon.TalentAvailable:
                    fileName = "storm_ui_ingame_leader_talent_available.png";
                    break;
                case OtherIcon.TalentUnavailable:
                    fileName = "storm_ui_ingame_leader_talent_unavailable.png";
                    break;
                case OtherIcon.StatusResistShieldDefault:
                    fileName = "storm_ui_ingame_status_resistshieldc3_default.png";
                    break;
                case OtherIcon.StatusResistShieldPhysical:
                    fileName = "storm_ui_ingame_status_resistshieldc3_physical.png";
                    break;
                case OtherIcon.StatusResistShieldSpell:
                    fileName = "storm_ui_ingame_status_resistshieldc3_spell.png";
                    break;
                case OtherIcon.UpgradeQuest:
                    fileName = "storm_ui_ingame_talentpanel_upgrade_quest_icon.png";
                    break;
                case OtherIcon.FilterAssassin:
                    fileName = "storm_ui_play_filter_assassin.png";
                    break;
                case OtherIcon.FilterMulticlass:
                    fileName = "storm_ui_play_filter_multiclass.png";
                    break;
                case OtherIcon.FilterSpecialist:
                    fileName = "storm_ui_play_filter_specialist.png";
                    break;
                case OtherIcon.FilterSupport:
                    fileName = "storm_ui_play_filter_support.png";
                    break;
                case OtherIcon.FilterWarrior:
                    fileName = "storm_ui_play_filter_warrior.png";
                    break;
                case OtherIcon.Kills:
                    fileName = "storm_ui_scorescreen_icon_kill.png";
                    break;
                case OtherIcon.Assist:
                    fileName = "storm_ui_scorescreen_icon_assist.png";
                    break;
                case OtherIcon.Death:
                    fileName = "storm_ui_scorescreen_icon_death.png";
                    break;
                case OtherIcon.HeroDamage:
                    fileName = "storm_ui_scorescreen_icon_herodamage.png";
                    break;
                case OtherIcon.SiegeDamage:
                    fileName = "storm_ui_scorescreen_icon_siegedamage.png";
                    break;
                case OtherIcon.HealAbsorbedDamage:
                    fileName = "storm_ui_scorescreen_icon_healedandabsorbed.png";
                    break;
                case OtherIcon.DamageTaken:
                    fileName = "storm_ui_scorescreen_icon_damagetaken.png";
                    break;
                case OtherIcon.ExperienceContribution:
                    fileName = "storm_ui_scorescreen_icon_xpcontribution.png";
                    break;
                case OtherIcon.KillsBlue:
                    fileName = "storm_ui_scorescreen_icon_kills_blue.png";
                    break;
                case OtherIcon.KillsRed:
                    fileName = "storm_ui_scorescreen_icon_kills_red.png";
                    break;
                default:
                    return null;
            }

            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Other.{fileName}");
        }
    }
}
