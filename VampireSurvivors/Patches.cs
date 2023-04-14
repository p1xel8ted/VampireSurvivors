using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using Screen = UnityEngine.Device.Screen;

namespace VampireSurvivors;

[HarmonyPatch]
public static class Patches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(AspectRatioFitter), nameof(AspectRatioFitter.OnEnable))]
    [HarmonyPatch(typeof(AspectRatioFitter), nameof(AspectRatioFitter.Start))]
    public static void AspectRatioFitter_Patches(ref AspectRatioFitter __instance)
    {
        __instance.aspectRatio = Display.main.systemWidth / (float)Display.main.systemHeight;
        var maxFramerate = Screen.resolutions.Where(x => x.width == Display.main.systemWidth && x.height == Display.main.systemHeight).Max(x => x.refreshRate);
        Application.targetFrameRate = maxFramerate;
    }
    
}