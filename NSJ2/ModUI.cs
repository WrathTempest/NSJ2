using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BepInEx.Logging;

namespace NSJ2
{

    public static class ModUI
    {
        private static GUIStyle _wrapToggle;
        private static GUIStyle _wrapLabel;
        private static bool _stylesReady;

        private static void InitStyles()
        {
            if (_stylesReady) return;

            _wrapToggle = new GUIStyle(GUI.skin.toggle)
            {
                wordWrap = true,
                alignment = TextAnchor.UpperLeft
            };

            _wrapLabel = new GUIStyle(GUI.skin.label)
            {
                wordWrap = true,
                alignment = TextAnchor.UpperLeft
            };

            _stylesReady = true;
        }

        // ===== Toggle =====
        public static bool DrawToggle(string label, bool value, string logName = null, ManualLogSource log = null)
        {
            InitStyles();

            bool newValue = GUILayout.Toggle(value, label, _wrapToggle, GUILayout.ExpandWidth(true));

            if (newValue != value)
            {
                if (log != null && logName != null)
                    log.LogInfo($"{logName}: {newValue}");

                return newValue;
            }

            return value;
        }

        // ===== Integer slider =====
        public static int DrawInt(string label, int value, int min, int max, string logName = null, ManualLogSource log = null)
        {
            InitStyles();

            GUILayout.Label($"{label}: {value}", _wrapLabel);
            int newValue = Mathf.RoundToInt(GUILayout.HorizontalSlider(value, min, max));

            if (newValue != value)
            {
                if (log != null && logName != null)
                    log.LogInfo($"{logName}: {newValue}");

                return newValue;
            }

            return value;
        }

        // ===== Integer text box =====
        public static int DrawIntBox(string label, int value, int min, int max, string logName = null, ManualLogSource log = null)
        {
            InitStyles();

            GUILayout.BeginHorizontal();
            GUILayout.Label(label, _wrapLabel);

            string text = GUILayout.TextField(value.ToString(), GUILayout.Width(80));
            GUILayout.EndHorizontal();

            if (int.TryParse(text, out int parsed))
            {
                parsed = Mathf.Clamp(parsed, min, max);

                if (parsed != value)
                {
                    if (log != null && logName != null)
                        log.LogInfo($"{logName}: {parsed}");

                    return parsed;
                }
            }

            return value;
        }
    }

}
