using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(InteractTip))]
    internal class InteractTip_Patches
    {
        [HarmonyPatch("onInteractClick")]
        [HarmonyPrefix]
        public static void Interact_Patch(InteractTip __instance)
        {
            __instance.m_locked = false;
        }
    }
}