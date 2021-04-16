using HarmonyLib;
using UnityEngine;
using VentusMod.Classes;

namespace VentusMod.Patches
{
    [HarmonyPatch]
    public static class HudPatch
    {
        [HarmonyPatch(typeof(HudManager), "Start")]
        [HarmonyPostfix]
        public static void HudStartPostfix()
        {
            Credits.Initialize();
        }

        [HarmonyPatch(typeof(HudManager), "Update")]
        [HarmonyPostfix]
        public static void HudUpdatePostfix()
        {
            PlayerControl localPlayer = PlayerControl.LocalPlayer;

            if (ShipStatus.Instance && localPlayer != null)
            {                
                bool inVent = localPlayer.inVent;
                Timer.VenTimer.SetActive(inVent);                

                if (localPlayer.Data.IsDead)
                {
                    localPlayer.Visible = !inVent;
                }

                Timer.VentusDeltaTime = inVent ? (Timer.VentusDeltaTime - Time.deltaTime) : 10f;

                if (inVent)
                {
                    Timer.Update();

                    if (Timer.VentusTime == 0)
                    {
                        Timer.ForceExitVent(localPlayer);
                    }
                }               
            }
        }

        
    }
}
