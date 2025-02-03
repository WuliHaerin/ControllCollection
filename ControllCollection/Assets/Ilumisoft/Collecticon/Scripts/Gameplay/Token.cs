using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace Ilumisoft.Collecticon
{
    public class Token : MonoBehaviour
    {
        public UnityEvent OnCollect = new UnityEvent();

        private PlayableDirector _director;
        private bool _collected = false;

        private void Awake()
        {
            _director = GetComponent<PlayableDirector>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                OnPlayerEnter(player);
            }
        }

        void OnPlayerEnter(Player player)
        {
            if (_collected)
            {
                return;
            }

            _collected = true;

            _director.Play();

            OnCollect.Invoke();
        }
    }
}