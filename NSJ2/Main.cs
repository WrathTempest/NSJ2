using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.Windows;

namespace NSJ2
{
    // TODO Review this file and update to your own requirements.

    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class Main : BaseUnityPlugin
    {
        private const string MyGUID = "izayoixx";
        private const string PluginName = "NSJ2_CustomMod";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log;

        public static bool EnableModAttri = false;
        public static bool EnableSetMaxStats = false;
        public static bool EnableReduceItem = true;
        public static bool EnableGainItem = true;
        public static bool RemoveSkillRestrictions = false;
        public static bool CanCastSkillWhileHurt = true;
        public static bool RemoveCastDelay = true;
        public static bool SuperArmor = false;
        public static bool BypassAchievements = false;
        public static bool SpawnItems = true;
        public static bool SpawnMartialArt = false;
        public static bool LearnMartialArt = false;

        private bool showUI = false;
        private Rect windowRect = new Rect(20, 20, 10, 10);

        private void Awake()
        {
            Log = Logger;
            Harmony.PatchAll();
            Logger.LogInfo($"{PluginName} {VersionString} loaded.");
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.F1))
            {
                showUI = !showUI;
            }
        }

        private void OnGUI()
        {
            if (!showUI) return;
            windowRect = GUILayout.Window(123456, windowRect, DrawWindow, "NSJ2 Custom Mod Options", GUILayout.MinWidth(420), GUILayout.MaxWidth(600));
        }

        private void DrawWindow(int id)
        {
            GUILayout.BeginVertical();

            EnableModAttri = ModUI.DrawToggle("Enable ModAttri Patch (Disable whenever starting a new game)", EnableModAttri, "Mod Attri", Log);
            EnableSetMaxStats = ModUI.DrawToggle("Enable Set Max Stats (requires ModAttri)", EnableSetMaxStats, "Set Max Stats", Log);
            SpawnMartialArt = ModUI.DrawToggle("Spawn All Martial Art Scrolls (requires ModAttri)", SpawnMartialArt, "Spawn Martial Art Scrolls", Log);
            EnableReduceItem = ModUI.DrawToggle("Reduce Item Costs/Usage to 0", EnableReduceItem, "Set Item Usage to Zero", Log);
            EnableGainItem = ModUI.DrawToggle("Multiply Items Gained by 20", EnableGainItem, "Gain Item Multiplier", Log);
            RemoveSkillRestrictions = ModUI.DrawToggle("Bypass Skill Learning Requirements", RemoveSkillRestrictions, "Remove Skill Restrictions", Log);
            CanCastSkillWhileHurt = ModUI.DrawToggle("Can cast skills under hitstun", CanCastSkillWhileHurt, "Ignore Hit Stun", Log);
            RemoveCastDelay = ModUI.DrawToggle("Remove Cast Delay", RemoveCastDelay, "Remove Cast Delay", Log);
            SuperArmor = ModUI.DrawToggle("Toggle Super Armor", SuperArmor, "Super Armor", Log);
            BypassAchievements = ModUI.DrawToggle("Ignore Achievement Conditions", BypassAchievements, "Bypass Achievements", Log);
            SpawnItems = ModUI.DrawToggle("Spawn Items Requirements", SpawnItems, "Spawn Items", Log);
            LearnMartialArt = ModUI.DrawToggle("Learn All Martial Arts", LearnMartialArt, "Learn Martial Art", Log);

            GUILayout.Space(10);
            GUILayout.Label("Press F1 to close/open this window", GUILayout.ExpandWidth(true));

            GUILayout.EndVertical();
            GUI.DragWindow();
        }
    }

}
