using HarmonyLib;
using SweetPotato;
using System;
using System.Collections.Generic;

namespace NSJ2
{
    [HarmonyPatch(typeof(AchievementView))]
    internal class AchievementView_Patches
    {
        [HarmonyPatch(nameof(AchievementView.CheckFinish), new Type[] {typeof(AchievementTrigger)})]
        [HarmonyPostfix]
        public static void Finish1_Patch(AchievementView __instance, AchievementTrigger data, ref int __result)
        {
            if (!Main.BypassAchievements) return;
            List<long> list = __instance.isMainView ? AppGame.Instance.m_AchievementList : WorldManager.Instance.m_PlayerEntity.m_AchievementList;
            if (list.Contains(data.id))
            {
                return;
            }
            __result = 1;
        }

        [HarmonyPatch(nameof(AchievementView.CheckFinish), new Type[] { typeof(AchievementPrefab) })]
        [HarmonyPostfix]
        public static void Finish2_Patch(AchievementView __instance, AchievementPrefab prefab, ref bool __result)
        {
            if (!Main.BypassAchievements) return;
            if ((__instance.isMainView ? AppGame.Instance.m_AchievementList : WorldManager.Instance.m_PlayerEntity.m_AchievementList).Contains(prefab.data.id))
            {
                return;
            }
            prefab.btn_finish.SetActivate(!__instance.isMainView);
            __result = true;

        }

        [HarmonyPatch(nameof(AchievementView.CheckFinish), new Type[] { typeof(AchievementTip) })]
        [HarmonyPostfix]
        public static void Finish2_Patch(AchievementView __instance, AchievementTip prefab, ref bool __result)
        {
            if (!Main.BypassAchievements) return;
            if (WorldManager.Instance.m_PlayerEntity.m_AchievementList.Contains(prefab.data.id))
            {
                return;
            }
            prefab.btn_finish.SetActivate(!__instance.isMainView);
            __result = true;

        }
    }
}