using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

namespace VentusMod.Classes
{
    public class Timer
    {
        public static void Initialize()
        {
            VenTimer = UnityEngine.Object.Instantiate(HudManager.Instance.KillButton.TimerText.gameObject);
            VenTimer.gameObject.name = "VenTimer";
            VenTimer.transform.SetParent(HudManager.Instance.gameObject.transform);
            VenTimer.transform.localPosition = new Vector2(0f, 0.3f);
            VenTimerTxt = VenTimer.GetComponent<TextMeshPro>();

            VenTimer.SetActive(false);
        }

        public static void Update()
        {
            VentusTime = Mathf.Ceil(VentusDeltaTime);

            string color = "<color=white>";

            if (VentusTime < 5 && VentusTime >= 3)
            {
                color = "<color=orange>";
            }
            if (VentusTime < 3 && VentusTime >= 0)
            {
                color = "<color=red>";
            }

            VenTimerTxt.text = color + VentusTime;
        }

        public static void ForceExitVent(PlayerControl localPlayer)
        {
            foreach (Vent v in ShipStatus.Instance.AllVents)
            {
                v.SetButtons(false);
            }
            localPlayer.MyPhysics.RpcExitVent(VentPatch.CurrVent.Id);
        }

        public static GameObject VenTimer;
        public static TextMeshPro VenTimerTxt;
        public static float VentusDeltaTime, VentusTime;
    }
}
