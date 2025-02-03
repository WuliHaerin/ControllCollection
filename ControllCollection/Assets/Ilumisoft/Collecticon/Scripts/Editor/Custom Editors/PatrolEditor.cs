namespace Ilumisoft.Collecticon.Editor
{
    using UnityEditor;

    [CustomEditor(typeof(PatrolBehaviour))]
    public class PatrolEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Makes the object patrol on the set path", MessageType.Info);
            base.OnInspectorGUI();
        }
    }
}