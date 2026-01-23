using HarmonyLib;
using SweetPotato;
using System;

namespace NSJ2
{
    [HarmonyPatch(typeof(ItemStorage))]
    internal class ItemStorage_Patches
    {
        [ThreadStatic]
        public static long CurrentItem = 0;

        [HarmonyPatch(nameof(ItemStorage.RemoveItem), new Type[] {typeof(Item), typeof(int), typeof(bool)})]
        [HarmonyPrefix]
        public static void RemoveItem_Patch(ItemStorage __instance, Item pItem, ref int amount, bool mbPopMsgBox)
        {
            if (!Main.EnableReduceItem) return;
            if (__instance.m_NpcEntity == null) return;
            if (!WorldManager.Instance.IsPlayer(__instance.m_NpcEntity.guid)) return;
            ItemPrototype itemPrototype = pItem.GetItemPro();
            if (itemPrototype == null) return;
            if ((itemPrototype.type != 1 && itemPrototype.overlapMax > 1) || itemPrototype.type == 3)
            {
                Main.Log.LogInfo($"Reduced Item Consumption of Item: {ItemPrototype.GetNameItemStr(itemPrototype)} with ID: {pItem.m_pProtoId}, with type: {itemPrototype.type}, and subtype: {itemPrototype.subType}, to 0!");
                amount = 0;
            }
            else
            {
                Main.Log.LogInfo($"Consumed Item: {ItemPrototype.GetNameItemStr(itemPrototype)} with ID: {pItem.m_pProtoId}, with type: {itemPrototype.type}, and subtype: {itemPrototype.subType}");
            }
                
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
            if ((itemPrototype.type != 1 && itemPrototype.overlapMax > 1) || itemPrototype.type == 3)
            {
                amount *= 20;
                Main.Log.LogInfo($"Multiplied gain of Item: {ItemPrototype.GetNameItemStr(itemPrototype)} with ID: {itemid}, with type: {itemPrototype.type}, and subtype: {itemPrototype.subType}!");
            }
            else
            {
                Main.Log.LogInfo($"Obtained Item: {ItemPrototype.GetNameItemStr(itemPrototype)} with ID: {itemid}, with type: {itemPrototype.type}, and subtype: {itemPrototype.subType}");
            }               
        }

        [HarmonyPatch(nameof(ItemStorage.GetItemCount))]
        [HarmonyPostfix]
        public static void ItemCount_Patch(ItemStorage __instance, ref int __result, long itemid)
        {
            if (!Main.SpawnItems) return;
            if (Helpers.AddingItems) return;
            if (__instance.m_NpcEntity == null) return;
            if (!WorldManager.Instance.IsPlayer(__instance.m_NpcEntity.guid)) return;
            ItemPrototype itemPrototype = ItemPrototype.GetItemPrototype(itemid);
            if (itemPrototype == null) return;
            if (__result == 0 && CurrentItem != itemid)
            {
                CurrentItem = itemid;
                __instance.CreateAndAddByItemId(itemid, 1);
                Main.Log.LogInfo($"Spawned Item: {ItemPrototype.GetNameItemStr(itemPrototype)} with ID: {itemid} with type: {itemPrototype.type} and subtype: {itemPrototype.subType}");
                __result = ItemStorage_Original.GetItemCount(__instance, itemid);
            }
            else
            {
                CurrentItem = 0;
            }
        }


    }
}