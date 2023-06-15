using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using BepInEx.Logging;
using System.CodeDom;
using static VFXParticlesPool;
using Hykter26.KnifeDamageModSN;

namespace KnifeDamageMod_SN_1_
{
    public static class KnifeDamageMod_SN
    {
        [HarmonyPatch(typeof(PlayerTool))]
        public static class PlayerTool_Patch
        {
            [HarmonyPatch(nameof(PlayerTool.Awake))]
            [HarmonyPostfix]
            public static void Awake_Postfix(PlayerTool __instance)
            {
                // Check to see if this is the knife
                if (__instance.GetType() == typeof(Knife))
                {

                    // Get the damage multiplier from the config file.
                    float damageMultiplier = KnifeDamagePlugin_SN.ConfigKnifeDamageMultiplier.Value;

                    Knife knife = __instance as Knife;
                    //double the knife damage v
                    float knifeDamage = knife.damage;
                    float newKnifeDamage = knifeDamage * 2.0f;
                    knife.damage = newKnifeDamage;

                    KnifeDamagePlugin_SN.logger.Log(LogLevel.Info, $"Knife damage was: {knifeDamage}," +
                        $" is now: {newKnifeDamage}");

                }
            }
        }
    }
}