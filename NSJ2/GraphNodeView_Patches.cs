using HarmonyLib;
using SweetPotato;
using UnityEngine.UI;

namespace NSJ2
{
    [HarmonyPatch(typeof(GraphNodeView))]
    internal class GraphNodeView_Patches
    {
        [HarmonyPatch(nameof(GraphNodeView.ShowNodeInfo))]
        [HarmonyPostfix]
        public static void ShowNode_Patch(GraphNodeView __instance)
        {
            if (!Main.RemoveSkillRestrictions) return;
            __instance.btnChongJi.interactable = true;
            __instance.btnXiLian.interactable = true;
            Main.Log.LogInfo("GraphNodeView Patch Triggered!");
        }
    }
}