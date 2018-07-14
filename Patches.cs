using BattleTech.UI;
using Harmony;

namespace PaperdollFlip
{
    // Primary patch to force all paperdoll calls to not flip the display
    [HarmonyPatch(typeof(HUDMechArmorReadout), "Init")]
    public static class HUDMechArmorReadout_Init_Patch
    {
        public static void Postfix(HUDMechArmorReadout __instance)
        {
            __instance.flipFrontDisplay = false;
            __instance.flipRearDisplay = false;
        }
    }

    // This just ensures hovering over for armor locations doesn't flip
    [HarmonyPatch(typeof(HUDMechArmorReadout), "GetArmorLocationFromIndex")]
    public static class HUDMechArmorReadout_GetArmorLocationFromIndex_Patch
    {
        public static bool Prefix(ref bool isFlipped)
        {
            isFlipped = false;
            return true;
        }
    }

    // This ensures hovering over chassis loadouts doesn't flip
    [HarmonyPatch(typeof(HUDMechArmorReadout), "GetChassisLocationFromIndex")]
    public static class HUDMechArmorReadout_GetChassisLocationFromIndex_Patch
    {
        public static bool Prefix(ref bool isFlipped)
        {
            isFlipped = false;
            return true;
        }
    }
}
