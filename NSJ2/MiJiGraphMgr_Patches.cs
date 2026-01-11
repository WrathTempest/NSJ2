using HarmonyLib;
using SweetPotato;
using UnityEngine.UI;

namespace NSJ2
{
    [HarmonyPatch(typeof(MiJiGraphMgr))]
    internal class MiJiGraphMgr_Patches
    {
        [HarmonyPatch(nameof(MiJiGraphMgr.UpGradeNode))]
        [HarmonyPostfix]
        public static void ShowNode_Patch(MiJiGraphMgr __instance, ref bool __result)
        {
            if (!Main.RemoveSkillRestrictions) return;
            MiJiMgr _miJiMgr = Helpers.GetPrivateField<MiJiMgr>(__instance, "_miJiMgr");
            if (!WorldManager.Instance.IsPlayer(_miJiMgr.m_UnitEntity.guid)) return;
            __result = true;
            Main.Log.LogInfo("MiJiGraphMgr Postfix Triggered!");
        }

        [HarmonyPatch(nameof(MiJiGraphMgr.UpGradeNode))]
        [HarmonyPrefix]
        public static void ShowNodePrefix_Patch(MiJiGraphMgr __instance, ref bool bForceUpdate, ref bool bForceFromScript)
        {
            if (!Main.RemoveSkillRestrictions) return;
            MiJiMgr _miJiMgr = Helpers.GetPrivateField<MiJiMgr>(__instance, "_miJiMgr");
            if (!WorldManager.Instance.IsPlayer(_miJiMgr.m_UnitEntity.guid)) return;
            bForceUpdate = true;
            bForceFromScript = true;
            Main.Log.LogInfo("MiJiGraphMgr Prefix Triggered!");
        }
    }
}