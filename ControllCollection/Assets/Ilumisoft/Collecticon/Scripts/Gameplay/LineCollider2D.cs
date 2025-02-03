using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ilumisoft.Collecticon
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(LineRenderer))]
    [RequireComponent(typeof(EdgeCollider2D))]
    public class LineCollider2D : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private EdgeCollider2D edgeCollider2D;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            edgeCollider2D = GetComponent<EdgeCollider2D>();
        }


#if UNITY_EDITOR
        private void Update()
        {
            Vector3[] positions = new Vector3[lineRenderer.positionCount];

            lineRenderer.GetPositions(positions);

            List<Vector2> points = new List<Vector2>();

            for (var index = 0; index < positions.Length; index++)
            {
                var position = positions[index];

                //Ensure z is always 0
                position.z = 0;

                //Update collider positions
                points.Add(position);

                positions[index] = position;
            }

            if (lineRenderer.loop && lineRenderer.positionCount > 2)
            {
                points.Add(points.First());
            }

            lineRenderer.SetPositions(positions);
            edgeCollider2D.points = points.ToArray();
        }
#endif
    }
}