using HarmonyLib;
using UnityEngine;
using VentusMod.Classes;

namespace VentusMod.Version
{
    [HarmonyPatch]
    public class VersionPatch
    {
        [HarmonyPatch(typeof(VersionShower), "Start")]
        public static void Postfix(VersionShower __instance)
        {
            __instance.text.text += " + " + Credits.ModName + Credits.ModVer + " " + Credits.Pandox;
        }        
    }
}
