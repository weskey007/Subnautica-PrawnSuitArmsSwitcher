using Harmony;

namespace PrawnSuitArmSwitcher
{
    public static class QPatch
    {
        public static void Patch()
        {
            Logger.Log("Patching...");
            var harmony = HarmonyInstance.Create("weskey.subnautica.showavailableitems.mod");

            var exosuitSlotKeyDown_Original = AccessTools.Method(typeof(Exosuit), "SlotKeyDown");
            var exosuitSlotKeyDown_Prefix = AccessTools.Method(typeof(ExosuitSlotKeyDown_HarmonyPatch), "Prefix");

            var uGUI_QuickSlots_Original = AccessTools.Method(typeof(uGUI_QuickSlots), "Update");
            var uGUI_QuickSlots_Postfix = AccessTools.Method(typeof(uGUI_QuickSlots_HarmonyPatch), "Postfix");


            harmony.Patch(exosuitSlotKeyDown_Original, new HarmonyMethod(exosuitSlotKeyDown_Prefix), null);
            harmony.Patch(uGUI_QuickSlots_Original, null, new HarmonyMethod(uGUI_QuickSlots_Postfix));

            Logger.Log("Patching complete");
        }
    }
}
