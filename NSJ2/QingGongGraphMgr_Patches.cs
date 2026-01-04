using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(QingGongGraphMgr))]
    internal class QingGongGraphMgr_Patches
    {
        [HarmonyPatch(nameof(QingGongGraphMgr.UpGradeNode))]
        [HarmonyPrefix]
        public static void Upgrade_Patch(QingGongGraphMgr __instance, int nodeGroup, bool bCheck, ref bool bForceUpdate, bool bForceFromScript, bool showTip)
        {
            bForceUpdate = true; //force it to always upgrade
            int num = -1;
            int num2 = -1;
            if (__instance.m_DirActiveNode.ContainsKey(nodeGroup))
            {
                num = __instance.m_DirActiveNode[nodeGroup];
                QingGong_node infoById = QingGong_node.GetInfoById(num);
                if (infoById != null)
                {
                    num2 = infoById.nextid;
                }
            }
            else
            {
                num = -1;
                QingGong_node infoLevelOne = QingGong_node.GetInfoLevelOne(nodeGroup);
                if (infoLevelOne != null)
                {
                    num2 = infoLevelOne.id;
                }
            }
            QingGong_node infoById2 = QingGong_node.GetInfoById(num);
            QingGong_node infoById3 = QingGong_node.GetInfoById(num2);
            if (infoById3 == null)
            {
                return;
            }
            WorldManager.Instance.m_PlayerEntity.m_AttriManager.ModAttriField(AttriType.GanWu, infoById3.needGanWu, false, -1, -1, true, true, false, true, false);
            Main.Log.LogInfo("Qinggong Upgrade Patch Triggered!");
        }
    }
}