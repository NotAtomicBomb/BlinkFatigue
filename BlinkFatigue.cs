using Exiled.API.Features;
using Exiled;
using HarmonyLib;
using Exiled.Events;

namespace BlinkFatigue
{
    public class BlinkFatigue : Plugin<Config>
    {
        internal static bool IsEnabled;
        internal static float decreaseRate;
        internal static float maxBlinkTime;
        internal static float minBlinkTime;
        internal static float minReworkBlinkTime;
        internal static float reworkAddMin;
        internal static float reworkAddMax;
        public static Harmony HarmonyInstance { set; get; }
        private static uint harmonyCounter = 0;
        public const string Version = "1.0.2";
        public override string Name => "BlinkFatigue";
        public bool enabled = false;
        public override void OnDisabled()
        {
            if (enabled == false)
            {
                return;
            }

            enabled = false;
            HarmonyInstance.UnpatchAll();
            Log.Info("Disabled BlinkFatigue.");
        }
        public override void OnEnabled()
        {
            

            if (!IsEnabled)
            {
                Log.Info("BlinkFatigue is disabled via config. Check your configs if you think this is an error.");
                return;
            }

            HarmonyInstance = new Harmony($"rogerfk.exiled.blinkfatigue{harmonyCounter}");
            HarmonyInstance.PatchAll();

            OnReloaded();

            Log.Info($"Enabled BlinkFatigue v{Version}.");
        }

        public override void OnReloaded()
        {
            // Unused, this only has to be used when dealing with variables that you'll need after changing assemblies without restarting the server.
            Log.Info("Reloading BlinkFatigue to its newest version.");
         IsEnabled= Config.IsEnabled;
         decreaseRate= Config.decreaseRate;
         maxBlinkTime= Config.maxBlinkTime;
         minBlinkTime= Config.minBlinkTime;
         minReworkBlinkTime= Config.minReworkBlinkTime;
         reworkAddMin= Config.reworkAddMin;
         reworkAddMax= Config.reworkAddMax;

    }
    }
}
