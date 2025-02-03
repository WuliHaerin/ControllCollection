using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Ilumisoft.Collecticon.Core
{
    /// <summary>
    /// Useful extensions for other classes
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Extension for MonoBehaviours allowing to invoke a method call after a delay, using a coroutine.
        /// </summary>
        /// <param name="monoBehaviour"></param>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        public static void InvokeDelayed(this MonoBehaviour monoBehaviour, UnityAction action, float delay)
        {
            monoBehaviour.StartCoroutine(InvokeDelayedCoroutine(action, delay));
        }

        /// <summary>
        /// Invokes the method call after the given delay
        /// </summary>
        /// <param name="action"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        static IEnumerator InvokeDelayedCoroutine(UnityAction action, float delay)
        {
            yield return new WaitForSeconds(delay);

            action?.Invoke();
        }
    }
}