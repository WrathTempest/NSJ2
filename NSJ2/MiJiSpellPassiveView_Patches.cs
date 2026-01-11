using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(MiJiSpellPassiveView))]
    internal class MiJiSpellPassiveView_Patches
    {
        [HarmonyPatch(nameof(MiJiSpellPassiveView.OnRefresh))]
        [HarmonyPostfix]
        public static void RefreshPassive_Patch(MiJiSpellPassiveView __instance)
        {
            if (!Main.RemoveSkillRestrictions) return;
            __instance.btnLingWu.interactable = true;
            Main.Log.LogInfo("MiJiSpellPassiveView Patch Triggered!");
        }
    }
}