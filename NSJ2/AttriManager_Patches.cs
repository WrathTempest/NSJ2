using HarmonyLib;
//using ModSpace;
using SweetPotato;
using System.Collections.Generic;

namespace NSJ2
{
    [HarmonyPatch(typeof(AttriManager))]
    internal class AttriManager_Patches
    {
        [HarmonyPatch(nameof(AttriManager.ModAttriField))]
        [HarmonyPrefix]
        public static void ModAttriField_Patch(AttriManager __instance, AttriType attritype, ref int change)
        {
            //return; //patch needs to be disabled when starting a new game
            if (!Main.EnableModAttri) return;
            NpcEntity entity = Helpers.GetPrivateField<NpcEntity>(__instance, "m_UnitEntity");
            if (entity == null) return;
            if (!WorldManager.Instance.IsPlayer(entity.guid)) return;
            if (attritype == AttriType.Level || attritype == AttriType.DaoDe) return;
            int mult = 1;
            if (Main.EnableSetMaxStats)
            {
                Helpers.SetMaxValues(__instance);
            }
            if (__instance.GetAttriResult(Attr.Beauty, true) < 1000)
            {
                __instance.SetAttriField(Attr.Beauty, 1000);
            }
            if (Main.SpawnMartialArt)
            {
                Helpers.AddAllMartialScrolls(entity.m_itemStorage);
            }         
            if ((attritype == AttriType.Money || attritype == AttriType.XiuWei || attritype == AttriType.GanWu))
            {
                mult = 1;
                if (change < 0)
                {
                    change /= mult;
                }
                else
                {
                    change *= mult;
                }
                Main.Log.LogInfo($"Successfully modified attribute change of type: {attritype}");
                return;
            }                    
            //Combat Stats
            if ((sbyte)attritype >= 34 || (sbyte)attritype <= 41)
            {
                mult = 4;
                change *= mult;
                Main.Log.LogInfo($"Successfully modified attribute change of type: {attritype}");
                return;
            }
            //Attributes
            if ((sbyte)attritype >= 5 || (sbyte)attritype <= 11)
            {
                mult = 2;
                change *= mult;
                Main.Log.LogInfo($"Successfully modified attribute change of type: {attritype}");
                return;
            }
            return;
        }

        [HarmonyPatch(nameof(AttriManager.BornRandomAttri))]
        [HarmonyPostfix]
        public static void BornAttri_Patch(AttriManager __instance, PlayerPrototype playerPrototype)
        {
            new Dictionary<int, int[]>();
            List<FormulaBaseAttri> infoListByGroupId = FormulaBaseAttri.GetInfoListByGroupId((long)playerPrototype.attrId);
            if (infoListByGroupId == null)
            {
                return;
            }
            for (int i = 0; i < infoListByGroupId.Count; i++)
            {
                AttriType attriType = (AttriType)infoListByGroupId[i].attriType;
                __instance.SetAttriField(attriType, 1000, -1, -1, false);
                Main.Log.LogInfo($"Successfully patched attribute: {attriType}, with ID: {infoListByGroupId[i].attriType}");
            }
        }
    }
}