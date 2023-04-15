using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppVampireSurvivors.UI;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(VampireSurvivors.VampireSurvivors), "Vampire Survivors UltraWide Fixes", "0.0.2", "p1xel8ted")]
[assembly: MelonGame("poncle", "VampireSurvivors")]

namespace VampireSurvivors
{
    public class VampireSurvivors : MelonMod
    {
        private MelonPreferences_Category _modCategory;
        private static MelonPreferences_Entry<bool> _expandUI;
        private GameObject _map;
        private GameObject _left;
        private Il2CppArrayBase<AspectMask> _aspectMasks;

        public override void OnInitializeMelon()
        {
            _modCategory = MelonPreferences.CreateCategory("Vampire Survivors UltraWide Fixes");
            _expandUI = _modCategory.CreateEntry("Expand UI", false);
            MelonLogger.Msg("Vampire Survivors UltraWide Fixes Loaded");
            MelonPreferences.Save();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_expandUI.Value && _map != null && _left != null)
            {
                SetParentAndPosition(_map, _left, new Vector3(0, -1138, 0));
            }

            foreach (var aspectMask in _aspectMasks)
            {
                if (aspectMask.gameObject.activeSelf)
                {
                    aspectMask.gameObject.SetActive(false);
                }
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);

            _aspectMasks = Resources.FindObjectsOfTypeAll<AspectMask>();
            foreach (var a in _aspectMasks)
            {
                a.enabled = false;
                a.gameObject.SetActive(false);
            }

            if (_expandUI.Value)
            {
                var ar = Resources.FindObjectsOfTypeAll<AspectRatioFitter>();
                foreach (var a in ar)
                {
                    a.aspectRatio = Display.main.systemWidth / (float) Display.main.systemHeight;
                }

                _left = GameObject.Find("GAME UI/Canvas - Game UI/Safe Area/View - Paused/Left");
                _map = GameObject.Find("GAME UI/Canvas - Game UI/Safe Area/View - Paused/MapGroup");

                var charSelection = GameObject.Find("UI/Canvas - App/Safe Area/View - CharacterSelection/Panel");
                if (charSelection != null)
                {
                    var confirmButton =
                        GameObject.Find("UI/Canvas - App/Safe Area/View - CharacterSelection/ConfirmButton");
                    var buyButton = GameObject.Find("UI/Canvas - App/Safe Area/View - CharacterSelection/BuyButton");
                    var startButton =
                        GameObject.Find("UI/Canvas - App/Safe Area/View - CharacterSelection/StartButton");
                    GameObject[] buttons = {confirmButton, buyButton, startButton};
                    SetParentAndPositionForButtons(charSelection, buttons, new Vector3(693.5758f, 81.4038f, 0));
                }

                var selectPanel = GameObject.Find("UI/Canvas - App/Safe Area/View - StageSelection/Panel");
                if (selectPanel != null)
                {
                    var stageSelectButton =
                        GameObject.Find("UI/Canvas - App/Safe Area/View - StageSelection/SelectButton");
                    var stageConfirmButton =
                        GameObject.Find("UI/Canvas - App/Safe Area/View - StageSelection/ConfirmButton");
                    var stageStartButton =
                        GameObject.Find("UI/Canvas - App/Safe Area/View - StageSelection/StartButton");
                    GameObject[] stageButtons = {stageSelectButton, stageConfirmButton, stageStartButton};
                    SetParentAndPositionForButtons(selectPanel, stageButtons, new Vector3(693.5758f, 81.4038f, 0));
                }
            }
        }

        private static void SetParentAndPosition(GameObject child, GameObject parent, Vector3 localPosition)
        {
            if (child == null || parent == null) return;
            child.transform.SetParent(parent.transform);
            child.transform.localPosition = localPosition;
        }

        private static void SetParentAndPositionForButtons(GameObject parent, IEnumerable<GameObject> buttons,
            Vector3 localPosition)
        {
            foreach (var button in buttons)
            {
                SetParentAndPosition(button, parent, localPosition);
            }
        }
    }
}