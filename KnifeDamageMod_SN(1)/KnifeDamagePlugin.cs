using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace Hykter26.KnifeDamageModSN
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class KnifeDamagePlugin_SN : BaseUnityPlugin
    {
        private const string myGUID = "Hykter26/𝕸𝖞𝖑𝖔𝖟.𝖘𝖈𝖞𝖙#5037.knifedamagemodsn";
        private const string pluginName = "Knife Damage Mod SN";
        private const string versionString = "1.0.0";

        // Enhancing the MOD
        // Declare damage multiplier config entry
        public static ConfigEntry<float> ConfigKnifeDamageMultiplier;

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger = new ManualLogSource(pluginName);

        private void Awake()
        {
            // Enhancing the MOD
            // Setup damage multiplier config entry
            ConfigKnifeDamageMultiplier = Config.Bind("General",        // The section under which the option is shown
                "KnifeDamageMultiplier",                                // The key of the configuration option
                1.0f,                                                   // The default value
                "Knife damage multiplier.");   							// Description of the config value

            // Patch in our MOD
            harmony.PatchAll();
            Logger.LogInfo($"PluginName: {pluginName}, VersionString: {versionString} is loaded.");
            logger = Logger;
        }
    }
}