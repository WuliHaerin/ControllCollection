using System.Collections.Generic;
using UnityEngine;

namespace Ilumisoft.Collecticon
{
    [ExecuteInEditMode]
    public class PatrolPath : MonoBehaviour
    {
        [SerializeField]
        List<Vector2> waypoints = new List<Vector2>();

        /// <summary>
        /// Gets the number of waypoints
        /// </summary>
        public int Count => Waypoints.Count;

        /// <summary>
        /// Returns the list of waypoints
        /// </summary>
        public List<Vector2> Waypoints { get => this.waypoints; set => this.waypoints = value; }

        /// <summary>
        /// Returns the position of the waypoint with the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector2 Get(int index)
        {
            return (Vector2)transform.position + Waypoints[index];
        }

        /// <summary>
        /// Draw additional gizmos in the scene view to make it easier to edit patrol paths
        /// </summary>
        private void OnDrawGizmos()
        {
            for (int i = 0; i < Waypoints.Count - 1; i++)
            {
                var current = Get(i);
                var next = Get(i + 1);

                Gizmos.color = Color.yellow;

                Gizmos.DrawSphere(current, 0.1f);
                Gizmos.DrawSphere(next, 0.1f);
                Gizmos.DrawLine(current, next);
            }
        }
    }
}