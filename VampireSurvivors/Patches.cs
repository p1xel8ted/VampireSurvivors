using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors;

[HarmonyPatch]
public partial class VampireSurvivors
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(AspectRatioFitter), nameof(AspectRatioFitter.OnEnable))]
    [HarmonyPatch(typeof(AspectRatioFitter), nameof(AspectRatioFitter.Start))]
    public static void AspectRatioFitter_Patches(ref AspectRatioFitter __instance)
    {
        if (_expandUI.Value)
        {
            __instance.aspectRatio = Display.main.systemWidth / (float) Display.main.systemHeight;
        }
    }

}