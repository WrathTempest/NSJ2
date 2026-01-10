using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(UnitController))]
    internal class UnitController_Patches
    {
        [HarmonyPatch(nameof(UnitController.IsInCoolDown))]
        [HarmonyPostfix]
        public static void Cooldown_Patch(UnitController __instance, ref bool __result)
        {
            if (!WorldManager.Instance.IsPlayer(__instance.guid)) return;
            __result = false;
        }
    }
}