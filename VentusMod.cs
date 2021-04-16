using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using Reactor;

namespace VentusMod
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    
    public class VentusPlugin : BasePlugin
    {
        public const string Id = "pxnd.VentusMod";
        public static ManualLogSource log;        

        public Harmony Harmony { get; } = new Harmony(Id);

        public VentusPlugin()
        {
            log = Log;
        }

        public override void Load()
        {
            log.LogMessage("VentusMod loaded!");            
            Harmony.PatchAll();            
        }

        [HarmonyPatch(typeof(StatsManager), nameof(StatsManager.AmBanned), MethodType.Getter)]
        public static class AmBannedPatch
        {
            public static void Postfix(out bool __result)
            {
                __result = false;
            }
        }
    }
}
