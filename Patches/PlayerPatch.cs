using System;
using System.Collections;
using System.Text;
using HarmonyLib;
using UnityEngine;
using VentusMod.Classes;

namespace VentusMod
{
    [HarmonyPatch(typeof(PlayerControl), "FixedUpdate")]
    class PlayerPatch
    {
        public static void Postfix()
        {
            PlayerControl localPlayer = PlayerControl.LocalPlayer;

            if (ShipStatus.Instance && localPlayer != null)
            {
                AnimationClip enterVentPlayer = localPlayer.MyPhysics.EnterVentAnim;
                AnimationClip exitVentPlayer = localPlayer.MyPhysics.ExitVentAnim;

                PowerTools.SpriteAnim animatorPlayer = localPlayer.MyPhysics.Animator;
                
                if (animatorPlayer.IsPlaying(enterVentPlayer))
                {
                    Audio.CoPlay(Audio.Assets.JumpInSound);
                }
                if(animatorPlayer.IsPlaying(exitVentPlayer))
                {
                    Audio.CoPlay(Audio.Assets.JumpOutSound);
                }
            }
        }
    }
}
