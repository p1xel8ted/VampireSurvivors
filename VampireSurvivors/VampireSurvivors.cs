using Il2CppVampireSurvivors.UI;
using MelonLoader;
using UnityEngine;

[assembly:
    MelonInfo(typeof(VampireSurvivors.VampireSurvivors), "Vampire Survivors UltraWide Fixes", "0.0.2", "p1xel8ted")]
[assembly: MelonGame("poncle", "VampireSurvivors")]

namespace VampireSurvivors;

public partial class VampireSurvivors : MelonMod
{
    private MelonPreferences_Category _modCategory;
    private static MelonPreferences_Entry<bool> _expandUI;

    public override void OnInitializeMelon()
    {
        _modCategory = MelonPreferences.CreateCategory("Vampire Survivors UltraWide Fixes");
        _expandUI = _modCategory.CreateEntry("Expand UI", false);
        MelonLogger.Msg("Vampire Survivors UltraWide Fixes Loaded");
        MelonPreferences.Save();
    }
    
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
       var am= Resources.FindObjectsOfTypeAll<AspectMask>();
       foreach (var a in am)
       {
              a.enabled = false;
              a.gameObject.SetActive(false);
       }
    }
}