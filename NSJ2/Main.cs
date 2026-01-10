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

        public static bool EnableModAttri = true;
        public static bool EnableSetMaxStats = false;

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

            GUILayout.Space(10);
            GUILayout.Label("Press F1 to close/open this window", GUILayout.ExpandWidth(true));

            GUILayout.EndVertical();
            GUI.DragWindow();
        }
    }

}
