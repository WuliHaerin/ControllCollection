namespace Ilumisoft.Collecticon.Messages
{
    using UnityEngine;
    using UnityEngine.Events;

    public class Message : MonoBehaviour
    {
        [SerializeField, TextArea(3, 20)] private string text = string.Empty;

        public string Text => text;

        public UnityAction OnMessageComplete { get; set; } = null;
    }
}