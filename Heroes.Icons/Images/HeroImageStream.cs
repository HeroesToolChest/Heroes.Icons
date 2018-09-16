using Heroes.Icons.Models;
using Heroes.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Heroes.Icons.Images
{
    internal class HeroImageStream : IHeroImagesStream
    {
        private readonly Assembly HeroesIconsAssembly = Assembly.GetExecutingAssembly();
        private readonly string StreamFilePath = "Heroes.Icons.Images";
        private readonly Dictionary<OtherIcon, string> OtherIcons = new Dictionary<OtherIcon, string>();

        public HeroImageStream()
        {
            SetOtherIcons();
        }

        public Stream TalentImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Talents.{fileName}");
        }

        public Stream MatchAwardImage(string fileName, MVPAwardColor awardColor)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Awards.{fileName.Replace("{mvpColor}", awardColor.ToString().ToLower())}");
        }

        public Stream BattlegroundImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Battlegrounds.{fileName}");
        }

        public Stream HomescreenImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Homescreens.{fileName}");
        }

        public Stream HeroSelectImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.HeroSelectPortraits.{fileName}");
        }

        public Stream LeaderboardImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.LeaderboardPortraits.{fileName}");
        }

        public Stream TargetPortraitImage(string fileName)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.TargetPortraits.{fileName}");
        }

        public Stream HeroFranchiseImage(HeroFranchise heroFranchise)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Franchises.hero_franchise_{heroFranchise.ToString().ToLower()}.png");
        }

        public Stream HeroRoleImage(string heroRole)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Roles.hero_role_{heroRole.ToLower()}.png");
        }

        public Stream PartyIconImage(PartyIconColor partyIconColor)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.PartyIcons.ui_ingame_loadscreen_partylink_{partyIconColor.ToString().ToLower()}.png");
        }

        public Stream OtherIconImage(OtherIcon icon)
        {
            return HeroesIconsAssembly.GetManifestResourceStream($"{StreamFilePath}.Other.{OtherIcons[icon]}");
        }

        private void SetOtherIcons()
        {
            OtherIcons.Add(OtherIcon.Quest, "storm_ui_taskbar_buttonicon_quests.png");
            OtherIcons.Add(OtherIcon.UpgradeQuest, "storm_ui_ingame_talentpanel_upgrade_quest_icon.png");
            OtherIcons.Add(OtherIcon.Silence, "storm_ui_silencepenalty.png");
            OtherIcons.Add(OtherIcon.VoiceSilence,  "storm_ui_silencepenalty_voice.png");

            OtherIcons.Add(OtherIcon.LongarrowLeftDisabled, "storm_ui_glues_button_longarrow_left_disabled.png");
            OtherIcons.Add(OtherIcon.LongarrowLeftDown, "storm_ui_glues_button_longarrow_left_down.png");
            OtherIcons.Add(OtherIcon.LongarrowLeftHover, "storm_ui_glues_button_longarrow_left_hover.png");
            OtherIcons.Add(OtherIcon.LongarrowLeftNormal, "storm_ui_glues_button_longarrow_left_normal.png");
            OtherIcons.Add(OtherIcon.LongarrowRightDisabled, "storm_ui_glues_button_longarrow_right_disabled.png");
            OtherIcons.Add(OtherIcon.LongarrowRightDown, "storm_ui_glues_button_longarrow_right_down.png");
            OtherIcons.Add(OtherIcon.LongarrowRightHover, "storm_ui_glues_button_longarrow_right_hover.png");
            OtherIcons.Add(OtherIcon.LongarrowRightNormal, "storm_ui_glues_button_longarrow_right_normal.png");

            OtherIcons.Add(OtherIcon.TalentAvailable, "storm_ui_ingame_leader_talent_available.png");
            OtherIcons.Add(OtherIcon.TalentUnavailable, "storm_ui_ingame_leader_talent_unavailable.png");

            OtherIcons.Add(OtherIcon.StatusResistShieldDefault, "storm_ui_ingame_status_resistshieldc3_default.png");
            OtherIcons.Add(OtherIcon.StatusResistShieldPhysical, "storm_ui_ingame_status_resistshieldc3_physical.png");
            OtherIcons.Add(OtherIcon.StatusResistShieldSpell, "storm_ui_ingame_status_resistshieldc3_spell.png");

            OtherIcons.Add(OtherIcon.FilterAssassin, "storm_ui_play_filter_assassin-on.png");
            OtherIcons.Add(OtherIcon.FilterMulticlass, "storm_ui_play_filter_multiclass-on.png");
            OtherIcons.Add(OtherIcon.FilterSpecialist, "storm_ui_play_filter_specialist-on.png");
            OtherIcons.Add(OtherIcon.FilterSupport, "storm_ui_play_filter_support-on.png");
            OtherIcons.Add(OtherIcon.FilterWarrior, "storm_ui_play_filter_warrior-on.png");

            OtherIcons.Add(OtherIcon.Kills, "storm_ui_scorescreen_icon_kill.png");
            OtherIcons.Add(OtherIcon.Assist, "storm_ui_scorescreen_icon_assist.png");
            OtherIcons.Add(OtherIcon.Death, "storm_ui_scorescreen_icon_death.png");
            OtherIcons.Add(OtherIcon.SiegeDamage, "storm_ui_scorescreen_icon_siegedamage.png");
            OtherIcons.Add(OtherIcon.HeroDamage, "storm_ui_scorescreen_icon_herodamage.png");
            OtherIcons.Add(OtherIcon.HealAbsorbedDamage, "storm_ui_scorescreen_icon_healedandabsorbed.png");
            OtherIcons.Add(OtherIcon.DamageTaken, "storm_ui_scorescreen_icon_damagetaken.png");
            OtherIcons.Add(OtherIcon.ExperienceContribution, "storm_ui_scorescreen_icon_xpcontribution.png");

            OtherIcons.Add(OtherIcon.KillsBlue, "storm_ui_scorescreen_icon_kills_blue.png");
            OtherIcons.Add(OtherIcon.KillsRed, "storm_ui_scorescreen_icon_kills_red.png");
        }
    }
}
