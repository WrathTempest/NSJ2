using HarmonyLib;
using SweetPotato;
using System;
using UnityEngine.UI;

namespace NSJ2
{
    [HarmonyPatch]
    internal class ItemStorage_Original
    {
        [HarmonyReversePatch]
        [HarmonyPatch(typeof(ItemStorage), nameof(ItemStorage.GetItemCount))]
        public static int GetItemCount(ItemStorage instance, long itemid, bool IncEqu = true)
        {
            throw new NotImplementedException("Stub");
        }

        
        [HarmonyReversePatch]
        [HarmonyPatch(typeof(ItemStorage), nameof(ItemStorage.CreateAndAddByItemId))]
        public static Item CreateItem(ItemStorage instance, long itemid, int amount, bool mbPopMsgBox = true, int weili = 0, int quality = -1)
        {
            throw new NotImplementedException("Stub");
        }
        
    }
}