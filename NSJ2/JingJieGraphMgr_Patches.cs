using HarmonyLib;
using SweetPotato;
using UnityEngine.UI;

namespace NSJ2
{
    [HarmonyPatch(typeof(JingJieGraphMgr))]
    internal class JingJieGraphMgr_Patches
    {
        [HarmonyPatch(nameof(JingJieGraphMgr.UpGradeNode))]
        [HarmonyPrefix]
        public static void ShowNodePrefix_Patch(JingJieGraphMgr __instance, ref bool bForceUpdate)
        {
            if (!Main.RemoveSkillRestrictions) return;
            NpcEntity m_UnitEntity = Helpers.GetPrivateField<NpcEntity>(__instance, "m_UnitEntity");
            if (!WorldManager.Instance.IsPlayer(m_UnitEntity.guid)) return;
            bForceUpdate = true;
            Main.Log.LogInfo("JingJieGraphMgr Prefix Triggered!");
        }
    }
}