using UnityEngine;

namespace Ilumisoft.Collecticon
{
    public class PatrolBehaviour : MonoBehaviour
    {
        [SerializeField]
        float velocity = 1.0f;

        [SerializeField]
        PatrolPath patrolPath = null;

        int targetWaypointIndex = 0;

        void Update()
        {
            if (patrolPath != null && patrolPath.Count > 0)
            {
                var targetWaypoint = patrolPath.Get(targetWaypointIndex);

                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, velocity * Time.deltaTime);

                transform.up = Vector3.RotateTowards(transform.up, targetWaypoint - (Vector2)transform.position, 5.0f * Time.deltaTime, 0.0f);

                if (Vector3.Distance(transform.position, targetWaypoint) < 0.1f)
                {
                    targetWaypointIndex = (targetWaypointIndex + 1) % patrolPath.Count;
                }
            }
        }
    }
}