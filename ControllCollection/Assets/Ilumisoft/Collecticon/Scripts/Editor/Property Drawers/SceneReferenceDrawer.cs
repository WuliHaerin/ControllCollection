using UnityEngine;
using UnityEditor;

namespace Ilumisoft.Collecticon.Editor
{
    [CustomPropertyDrawer(typeof(SceneReference))]
    public class SceneReferenceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var sceneAssetProp = property.FindPropertyRelative("sceneAsset");

            EditorGUI.PropertyField(position, sceneAssetProp, label);

            EditorGUI.EndProperty();
        }
    }
}