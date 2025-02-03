namespace Ilumisoft.Collecticon.Messages
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class MessageBox : MonoBehaviour
    {
        [SerializeField] private Transform messageContainer;

        [SerializeField] private TMPro.TMP_Text _text;
        [SerializeField] private Button _button;

        [SerializeField] private float typingSpeed;

        [SerializeField] private UnityEvent onMessageBoxClosed;


        private List<Message> messages;

        private int currentMessageIndex = 0;

        private float timeScale;

        private void Awake()
        {
            FindMessages();
        }

        private void FindMessages()
        {
            messages = new List<Message>();

            if (messageContainer != null)
            {
                for (int i = 0; i < messageContainer.childCount; i++)
                {
                    var message = messageContainer.GetChild(i).GetComponent<Message>();

                    if (message != null)
                    {
                        messages.Add(message);
                    }
                }
            }
        }

        private void OnEnable()
        {
            timeScale = Time.timeScale;

            Time.timeScale = 0.0f;
        }

        private void OnDisable()
        {
            Time.timeScale = timeScale;
        }

        void Start()
        {
            _button.onClick.AddListener(ShowNextMessage);

            StartCoroutine(TypingCoroutine());
        }

        private void ShowNextMessage()
        {
            messages[currentMessageIndex].OnMessageComplete?.Invoke();

            currentMessageIndex++;

            StopAllCoroutines();

            if (currentMessageIndex < messages.Count)
            {
                StartCoroutine(TypingCoroutine());
            }
            else
            {
                onMessageBoxClosed.Invoke();

                gameObject.SetActive(false);
            }
        }

        IEnumerator TypingCoroutine()
        {
            _text.text = string.Empty;

            string message = messages[currentMessageIndex].Text;

            for (int i = 0; i < message.Length; i++)
            {
                _text.text = string.Format("{0}{1}", _text.text, message[i].ToString());

                yield return new WaitForSecondsRealtime(typingSpeed);
            }

            string normal = _text.text;
            string other = normal + "_";

            bool assign = false;

            while (true)
            {
                assign = !assign;

                _text.text = assign ? normal : other;

                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
    }
}