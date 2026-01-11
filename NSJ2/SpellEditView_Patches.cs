using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(SpellEditView))]
    internal class SpellEditView_Patches
    {
        [HarmonyPatch(nameof(SpellEditView.CheckCondition))]
        [HarmonyPostfix]
        public static void Condition_Patch(SpellEditView __instance, ref bool __result)
        {
            if (!WorldManager.Instance.IsPlayer(__instance.m_Entity.guid)) return;
            Main.Log.LogInfo("Condition Patch Triggered!");
            __result = true;
        }
    }
}