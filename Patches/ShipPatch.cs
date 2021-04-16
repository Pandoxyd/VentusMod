using HarmonyLib;
using VentusMod.VentsMap;
using VentusMod.Classes;
using UnityEngine;

namespace VentusMod
{
    [HarmonyPatch]
    public class ShipPatch
    {
        
        [HarmonyPatch(typeof(ShipStatus), "Start")]
        [HarmonyPostfix]
        public static void StartPatch(ShipStatus __instance)
        {
            string name = __instance.name;

            if (name.StartsWith("Skeld"))
            {
                Vent skeldVent = Utilities.CreateNewVent("SkeldStorageVent", new Vector3(-2.7f, -17.2f, -0f));
                Utilities.AddNewVent(skeldVent);

                bool flag = Skeld.FindSkeldVents();
                if(flag)
                {
                    Skeld.SkeldVentsFound = true;
                }
                else
                {
                    VentusPlugin.log.LogError("Not all vents were found. Vents can't be changed.");
                }
            }
            
            if (name.StartsWith("Polus"))
            {
                Vent polusVent = Utilities.CreateNewVent("PolusSpecimenVent", new Vector3(37f, -22.2f, 0f));
                Utilities.AddNewVent(polusVent);

                bool flag = Polus.FindPolusVents();
                if (flag)
                {
                    Polus.PolusVentsFound = true;
                }
                else
                {
                    VentusPlugin.log.LogError("Not all vents were found. Vents can't be changed.");
                }
            }

            if (name.StartsWith("Airship"))
            {
                bool flag = Airship.FindAirshipVents();
                if (flag)
                {
                    Airship.AirshipVentsFound = true;
                }
                else
                {
                    VentusPlugin.log.LogError("Not all vents were found. Vents can't be changed.");
                }
            }

            Timer.Initialize();
            Audio.Initialize();
        }
        
        [HarmonyPatch(typeof(ShipStatus), "FixedUpdate")]
        [HarmonyPostfix]
        public static void FixedUpdatePatch(ShipStatus __instance)
        {

            string name = __instance.name;

            if (name.StartsWith("Skeld"))
            {
                if(Skeld.SkeldVentsFound)
                {
                    Skeld.ChangeSkeldVents();
                }                
            }

            if (name.StartsWith("Polus"))
            {

                if (Polus.PolusVentsFound)
                {
                    Polus.ChangePolusVents();
                }
            }

            if (name.StartsWith("Airship"))
            {
                if(Airship.AirshipVentsFound)
                {
                    Airship.ChangeAirshipVents();
                }
                
            }
        }
    }
}
