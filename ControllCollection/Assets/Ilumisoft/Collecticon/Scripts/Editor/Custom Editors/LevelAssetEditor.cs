namespace Ilumisoft.Collecticon.Editor
{
    using Ilumisoft.Collecticon;
    using UnityEditor;
    using UnityEngine;


    [CustomEditor(typeof(LevelAsset))]
    public class LevelAssetEditor : Editor
    {
        SerializedProperty hasIntroProperty;
        SerializedProperty introSceneProperty;
        SerializedProperty levelSceneProperty;

        private void OnEnable()
        {
            var levelData = target as LevelAsset;

            hasIntroProperty = serializedObject.FindProperty(nameof(levelData.HasIntro));
            introSceneProperty = serializedObject.FindProperty(nameof(levelData.IntroScene));
            levelSceneProperty = serializedObject.FindProperty(nameof(levelData.LevelScene));
        }

        public override void OnInspectorGUI()
        {
            var levelData = target as LevelAsset;

            serializedObject.Update();

            EditorGUILayout.PropertyField(hasIntroProperty);

            if (hasIntroProperty.boolValue == true)
            {
                EditorGUI.indentLevel++;

                OnSceneReferenceGUI(levelData.IntroScene, introSceneProperty);

                EditorGUI.indentLevel--;
            }

            OnSceneReferenceGUI(levelData.LevelScene, levelSceneProperty);

            serializedObject.ApplyModifiedProperties();
        }

        void OnSceneReferenceGUI(SceneReference sceneReference, SerializedProperty serializedProperty)
        {
            EditorGUILayout.PropertyField(serializedProperty);

            if (sceneReference.sceneAsset != null && sceneReference.IsInBuildSettings() == false)
            {
                EditorGUILayout.HelpBox("Scene has not been added to BuildSettings", MessageType.Warning);

                if (GUILayout.Button("Fix Now"))
                {
                    sceneReference.AddToBuildSettings();
                }
            }
        }
    }
}