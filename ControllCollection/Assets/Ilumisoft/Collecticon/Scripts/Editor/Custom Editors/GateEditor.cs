namespace Ilumisoft.Collecticon.Editor
{
    using Ilumisoft.Collecticon;
    using UnityEditor;

    [CustomEditor(typeof(Gate))]
    public class GateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("The player needs to collect the list of tokens in order to deactivate the gate.", MessageType.Info);
            base.OnInspectorGUI();
        }
    }
}