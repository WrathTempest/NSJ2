using HarmonyLib;
using ModSpace;
using SweetPotato;
using System.Collections.Generic;
using UnityEngine.UI;

namespace NSJ2
{
    [HarmonyPatch(typeof(JingJiePartView))]
    internal class JingJiePartView_Patches
    {
        /*
        [HarmonyPatch("GuLingCondition")]
        [HarmonyPrefix]
        public static void GuLing_Patch(JingJieGraphView __instance, JingJie_node jingJieNodeProp)
        {
            NpcEntity m_NpcEntity = Helpers.GetPrivateProperty<NpcEntity>(__instance, "m_NpcEntity");
            foreach (KeyValuePair<int, int> kv in jingJieNodeProp.needItemDic)
            {
                if (WorldManager.Instance.m_PlayerEntity.m_itemStorage.GetItemCount((long)kv.Key, true) < kv.Value)
                {
                    m_NpcEntity.m_itemStorage.CreateAndAddByItemId(kv.Key, kv.Value);
                }
                
            }
        }

        [HarmonyPatch("YongLingCondition")]
        [HarmonyPrefix]
        public static void YongLing_Patch(JingJieGraphView __instance, JingJie_node jingJieNodeProp)
        {
            NpcEntity m_NpcEntity = Helpers.GetPrivateProperty<NpcEntity>(__instance, "m_NpcEntity");
            foreach (KeyValuePair<int, int> kv in jingJieNodeProp.needYLItemDic)
            {
                if(WorldManager.Instance.m_PlayerEntity.m_itemStorage.GetItemCount((long)kv.Key, true) < kv.Value)
                {
                    m_NpcEntity.m_itemStorage.CreateAndAddByItemId(kv.Key, kv.Value);
                }
            }
        }
        */

    }
}