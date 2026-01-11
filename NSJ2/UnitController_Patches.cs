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

        [HarmonyPatch(nameof(UnitController.PostCastDelay))]
        [HarmonyPostfix]
        public static void CastDelay_Patch(UnitController __instance, ref bool __result)
        {
            if (!WorldManager.Instance.IsPlayer(__instance.guid)) return;
            __result = true;
        }

        [HarmonyPatch(nameof(UnitController.HasFlag))]
        [HarmonyPostfix]
        public static void Flag_Patch(UnitController __instance, ref bool __result, int flag)
        {
            if (!WorldManager.Instance.IsPlayer(__instance.guid)) return;
            if (flag !=1) return;
            __result = false;
        }
    }
}