using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Ilumisoft.Collecticon.Editor
{
    public static class SceneReferenceExtensions
    {
        public static void AddToBuildSettings(this SceneReference sceneReference)
        {
            if (sceneReference.sceneAsset != null)
            {
                string scenePath = AssetDatabase.GetAssetOrScenePath(sceneReference.sceneAsset);

                List<EditorBuildSettingsScene> scenes = new List<EditorBuildSettingsScene>();

                scenes.AddRange(EditorBuildSettings.scenes);
                scenes.Add(new EditorBuildSettingsScene(scenePath, true));

                EditorBuildSettings.scenes = scenes.ToArray();
            }
        }

        public static bool IsInBuildSettings(this SceneReference sceneReference)
        {
            string scenePath = AssetDatabase.GetAssetOrScenePath(sceneReference.sceneAsset);

            return SceneUtility.GetBuildIndexByScenePath(scenePath) != -1;
        }
    }
}