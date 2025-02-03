using UnityEngine;

namespace Ilumisoft.Collecticon
{
    /// <summary>
    /// The border of a level. 
    /// The player is not allowed to touch the border and will lose the game if he does.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(LineCollider2D))]
    public class Border : MonoBehaviour
    {
        private Rigidbody2D rb2D;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Trigger game over if the player touches the border
            if (collision.CompareTag("Player"))
            {
                GameManager.Instance.PreGameOver();
            }
        }

        private void Reset()
        {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.bodyType = RigidbodyType2D.Static;

            var edgeCollider2D = GetComponent<EdgeCollider2D>();
            edgeCollider2D.isTrigger = true;
        }
    }
}