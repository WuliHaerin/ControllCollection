namespace Ilumisoft.Collecticon.Messages
{
    using UnityEngine;
    using UnityEngine.Events;

    public class MessageCompleteAction : MonoBehaviour
    {
        [SerializeField] Message message = null;
        [SerializeField] UnityEvent messageCompleteAction = new UnityEvent();

        private void OnEnable()
        {
            // Register listeners
            if (message != null)
            {
                message.OnMessageComplete += messageCompleteAction.Invoke;
            }
        }

        private void OnDisable()
        {
            // Unregister listeners
            if (message != null)
            {
                message.OnMessageComplete -= messageCompleteAction.Invoke;
            }
        }

        private void Reset()
        {
            // Try to auto assign the message component when the component is created or reset
            if (message == null)
            {
                message = GetComponent<Message>();
            }
        }
    }
}