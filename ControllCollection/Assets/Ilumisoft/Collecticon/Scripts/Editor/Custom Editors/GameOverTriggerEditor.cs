namespace Ilumisoft.Collecticon.Editor
{
    using Ilumisoft.Collecticon;
    using UnityEditor;

    [CustomEditor(typeof(GameOverTrigger))]
    public class GameOverTriggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Ends the game when the player enters the trigger.", MessageType.Info);
            base.OnInspectorGUI();
        }
    }
}