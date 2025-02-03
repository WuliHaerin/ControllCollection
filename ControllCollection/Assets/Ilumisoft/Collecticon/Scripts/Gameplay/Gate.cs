using System.Collections.Generic;
using UnityEngine;

namespace Ilumisoft.Collecticon
{
    [RequireComponent(typeof(LineCollider2D))]
    [RequireComponent(typeof(GameOverTrigger))]
    public class Gate : MonoBehaviour
    {
        [Tooltip("List of tokens which need to be collected by the player to deactivate the gate")]
        [SerializeField]
        List<Token> tokens = new List<Token>();

        [SerializeField]
        GameObject gateDisableSFX = null;

        int collectedTokens = 0;

        private void Start()
        {
            collectedTokens = 0;
        }

        private void OnEnable()
        {
            foreach (var token in tokens)
            {
                if (token != null)
                {
                    token.OnCollect.AddListener(OnCollectToken);
                }
            }
        }
        private void OnDisable()
        {
            foreach (var token in tokens)
            {
                if (token != null)
                {
                    token.OnCollect.RemoveListener(OnCollectToken);
                }
            }
        }

        private void OnCollectToken()
        {
            collectedTokens++;

            // Deactivate gate when all tokens have been collected
            if (collectedTokens >= tokens.Count)
            {
                Instantiate(gateDisableSFX);
                gameObject.SetActive(false);
            }
        }
    }
}