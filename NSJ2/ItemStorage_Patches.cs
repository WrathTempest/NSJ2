using HarmonyLib;
using SweetPotato;
using System;

namespace NSJ2
{
    [HarmonyPatch(typeof(ItemStorage))]
    internal class ItemStorage_Patches
    {
        
        [HarmonyPatch(nameof(ItemStorage.RemoveItem), new Type[] {typeof(Item), typeof(int), typeof(bool)})]
        [HarmonyPrefix]
        public static void RemoveItem_Patch(ItemStorage __instance, Item pItem, ref int amount, bool mbPopMsgBox)
        {
            if (!Main.EnableReduceItem) return;
            if (__instance.m_NpcEntity == null) return;
            if (!WorldManager.Instance.IsPlayer(__instance.m_NpcEntity.guid)) return;
            ItemPrototype itemPrototype = pItem.GetItemPro();
            if (itemPrototype == null) return;
            if (!((long)itemPrototype.type != 1L && itemPrototype.overlapMax > 1))
            {
                return;
            }
            Main.Log.LogInfo("Reduced Item Consumption to 0!");
            amount = 0;
        }

        [HarmonyPatch(nameof(ItemStorage.CreateAndAddByItemId))]
        [HarmonyPrefix]
        public static void CreateItem_Patch(ItemStorage __instance, long itemid, ref int amount, bool mbPopMsgBox, int weili, int quality)
        {
            if(!Main.EnableGainItem) return;
            if (__instance.m_NpcEntity == null) return;
            if (!WorldManager.Instance.IsPlayer(__instance.m_NpcEntity.guid)) return;
            ItemPrototype itemPrototype = ItemPrototype.GetItemPrototype(itemid);
            if (itemPrototype == null) return;
            if ((long)itemPrototype.type != 1L && itemPrototype.overlapMax > 1)
            {
                amount *= 20;
                Main.Log.LogInfo($"Multiplied gain of Item: {ItemPrototype.GetNameItemStr(itemPrototype)} by 20!");
            }
        }

    }
}