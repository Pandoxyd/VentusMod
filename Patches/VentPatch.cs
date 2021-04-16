using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.IO;
using Reactor;
using VentusMod.Classes;

namespace VentusMod
{
    [HarmonyPatch]
    public class VentPatch
    {
        [HarmonyPatch(typeof(Vent), "Use")]
        [HarmonyPostfix]

        public static void UsePostfix(Vent __instance)
        {
            CurrVent = __instance;
        }
        
        [HarmonyPatch(typeof(Vent), "CanUse")]
        public static bool Prefix(Vent __instance, ref float __result, [HarmonyArgument(0)] ref GameData.PlayerInfo pc, [HarmonyArgument(1)] ref bool canUse, [HarmonyArgument(2)] ref bool couldUse)
        {
            float num = float.MaxValue;
            PlayerControl @object = pc.Object;            

            bool tasksFinished = PlayerTask.AllTasksCompleted(@object);

            bool commsSaboted = Utilities.CheckCommsTask(@object);

            bool isImpostor = @object.Data.IsImpostor;

            bool isDead = @object.Data.IsDead;

            couldUse = (isImpostor && (@object.CanMove || @object.inVent)) || (!isImpostor && isDead && !commsSaboted && (@object.CanMove || @object.inVent))
                || (!isImpostor && !isDead && !tasksFinished && !commsSaboted && (@object.CanMove || @object.inVent));

            canUse = couldUse;
            if (canUse)
            {
                Vector2 truePosition = @object.GetTruePosition();
                Vector3 position = __instance.transform.position;
                num = Vector2.Distance(truePosition, position);
                canUse &= (num <= __instance.UsableDistance && !PhysicsHelpers.AnythingBetween(truePosition, position, Constants.ShipOnlyMask, false));
            }
            __result = num;

            return false;
        }

        [HarmonyPatch(typeof(Vent), "DoMove")]
        [HarmonyPostfix]
        public static void DoMovePostFix()
        {
            Audio.CoPlay(Audio.Assets.MoveVentSound);            
        }

        public static Vent CurrVent;
    }
}
