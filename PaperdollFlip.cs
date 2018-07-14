using System;
using System.Reflection;
using Harmony;
using Newtonsoft.Json;

namespace ArmorRepairDevTest
{
   
    public class ArmorRepairDevTest
    {
        // Mod Settings
        public static Settings ModSettings;
        public static string ModDirectory;
        
        public static void Init(string modDirectory, string settingsJSON)
        {

            new Logger();

            Logger.LogInfo("Mod Initialising...");

            var harmony = HarmonyInstance.Create("io.github.citizenSnippy.PaperdollFlip");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            
            // Serialise settings from mod.json
            ModDirectory = modDirectory;
            try
            {
                ModSettings = JsonConvert.DeserializeObject<Settings>(settingsJSON);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                ModSettings = new Settings();
            }

            Logger.LogDebug("Mod Directory: " + ModDirectory);
            Logger.LogDebug("Mod Settings Debug: " + ModSettings.Debug);
            Logger.LogInfo("Mod Initialised.");

        }

    }

}
