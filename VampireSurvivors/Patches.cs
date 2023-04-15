// using HarmonyLib;
// using Il2CppVampireSurvivors.Objects;
// using UnityEngine;
// using UnityEngine.Purchasing;
//
// namespace VampireSurvivors
// {
//     [HarmonyPatch]
//     public static class Patches
//     {
//         [HarmonyPrefix]
//         [HarmonyPatch(typeof(Stage), nameof(Stage.EnemySpawnLocations), MethodType.Getter)]
//         public static bool Stage_EnemySpawnLocations(ref Il2CppSystem.Collections.Generic.List<Vector2> __result)
//         {
//             Il2CppSystem.Collections.Generic.List<Vector2> resultList = __result;
//             int count = resultList.Count;
//
//             for (int index = 0; index < count; index++)
//             {
//                 Vector2 modifiedVector = new Vector2(-20, 0);
//                 resultList.RemoveAt(index);
//                 resultList.Insert(index, modifiedVector);
//             }
//
//             __result = resultList;
//             return false;
//         }
//     }
// }