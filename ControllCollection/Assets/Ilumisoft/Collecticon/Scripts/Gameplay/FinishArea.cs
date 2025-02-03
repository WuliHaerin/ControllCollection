using UnityEngine;

namespace Ilumisoft.Collecticon
{
    /// <summary>
    /// Each level has a finish area. In order to win the level, the player needs to reach the finish area.
    /// </summary>
    public class FinishArea : MonoBehaviour
    {
        [Tooltip("Soundeffect played when the player enters the finish area")]
        [SerializeField]
        AudioClip playerEnterSFX = null;

        [SerializeField]
        GameObject successVFX = null;

        [SerializeField]
        GameObject fadeAwayVFX = null;

        /// <summary>
        /// Reference to the audio source component
        /// </summary>
        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Play the success sfx and finish the level when the player enters the finish area
            if (collision.CompareTag("Player"))
            {
                // Create vfx effect
                Instantiate(successVFX, transform.position, Quaternion.identity);

                Instantiate(fadeAwayVFX, collision.transform.position, Quaternion.identity);

                // Deactivate player
                collision.gameObject.SetActive(false);

                audioSource.PlayOneShot(playerEnterSFX);

                GameManager.Instance.Finish();
            }
        }
    }
}