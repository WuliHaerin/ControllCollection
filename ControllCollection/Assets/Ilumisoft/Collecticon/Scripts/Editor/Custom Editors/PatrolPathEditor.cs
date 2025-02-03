namespace Ilumisoft.Collecticon.Editor
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(PatrolPath)), CanEditMultipleObjects]
    public class PatrolPathEditor : Editor
    {
        protected virtual void OnSceneGUI()
        {
            PatrolPath patrolPath = (PatrolPath)target;

            // Allow to edit all waypoints in the scene view with a position handle
            for (int i = 0; i < patrolPath.Waypoints.Count; i++)
            {
                var position = patrolPath.Get(i);

                EditorGUI.BeginChangeCheck();

                // Get the new position by the position handle
                Vector3 newPosition = Handles.PositionHandle(position, Quaternion.identity) - patrolPath.transform.position;

                if (EditorGUI.EndChangeCheck())
                {
                    // Record change in the undo system
                    Undo.RecordObject(patrolPath, "Change Waypoint Position");

                    // Update the edited waypoint
                    patrolPath.Waypoints[i] = newPosition;
                }
            }
        }
    }
}