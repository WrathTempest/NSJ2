using HarmonyLib;
using SweetPotato;

namespace NSJ2
{
    [HarmonyPatch(typeof(AnswerViewNew))]
    internal class AnswerViewNew_Patches
    {
        [HarmonyPatch(nameof(AnswerViewNew.CheckHaveMiji))]
        [HarmonyPostfix]
        public static void Miji_Patch(AnswerViewNew __instance, ref bool __result)
        {
            __result = true;
        }
    }
}