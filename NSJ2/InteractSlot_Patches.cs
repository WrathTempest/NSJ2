using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(InteractSlot))]
    internal class InteractSlot_Patches
    {
        [HarmonyPatch("OnInteractWithNpc")]
        [HarmonyPrefix]
        public static void Interact_Patch(InteractSlot __instance)
        {
            __instance.m_locked = false;
        }
    }
}