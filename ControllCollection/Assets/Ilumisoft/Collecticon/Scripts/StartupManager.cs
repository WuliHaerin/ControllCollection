using UnityEngine;

namespace Ilumisoft.Collecticon
{
    public static class StartupManager
    {
        /// <summary>
        /// Automatically instantiates the persistent systems game object when the game starts and marks it as DontDestroyOnLoad.
        /// You can add any system you want to have persistent to this game object
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Initialize()
        {
            // Load the prefab from the resources folder
            var prefab = Resources.Load("Collecticon/Persistent Systems");

            var instance = Object.Instantiate(prefab);

            instance.name = prefab.name;

            Object.DontDestroyOnLoad(instance);
        }
    }
}