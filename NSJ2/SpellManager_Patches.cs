using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(SpellManager))]
    internal class SpellManager_Patches
    {
        [HarmonyPatch(nameof(SpellManager.GetSpellCDLeft))]
        [HarmonyPostfix]
        public static void GetSpellCD_Patch(SpellManager __instance, ref float __result)
        {
            NpcEntity entity = Helpers.GetPrivateField<NpcEntity>(__instance, "m_UnitEntity");
            if (entity == null) return;
            if (!WorldManager.Instance.IsPlayer(entity.guid)) return;
            __result = 0f;
        }
    }
}