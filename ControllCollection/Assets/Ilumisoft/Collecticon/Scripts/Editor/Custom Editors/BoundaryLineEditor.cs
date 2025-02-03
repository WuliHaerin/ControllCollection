using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Collecticon.Editor
{
    [CustomEditor(typeof(Border))]
    public class BoundaryLineEditor : UnityEditor.Editor
    {
        private Border _border;

        private LineRenderer _lineRenderer;
        private EdgeCollider2D _edgeCollider2D;

        private void OnEnable()
        {
            _border = (Border)target;

            _lineRenderer = _border.GetComponent<LineRenderer>();
            _edgeCollider2D = _border.GetComponent<EdgeCollider2D>();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.HelpBox("Ensures all positions of the lineRenderer have a z-value of 0 and updates  the points of the edge collider.", MessageType.Info);
        }
    }
}