namespace Ilumisoft.Collecticon
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Playables;
    using UnityEngine.SceneManagement;

    [RequireComponent(typeof(PlayableDirector))]
    [RequireComponent(typeof(Animator))]
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private bool playSceneLoadedAnimation = true;

        [SerializeField] private PlayableAsset loadedPlayable = null;
        [SerializeField] private PlayableAsset unloadPlayable = null;

        private PlayableDirector playableDirector;

        /// <summary>
        /// Gets the currently active scene
        /// </summary>
        public Scene CurrentScene => gameObject.scene;

        private void Awake()
        {
            playableDirector = GetComponent<PlayableDirector>();
        }

        private void Start()
        {
            if (playSceneLoadedAnimation)
            {
                playableDirector.playableAsset = loadedPlayable;
                playableDirector.Play();
            }
        }

        /// <summary>
        /// Loads the next scene after the given delay (optional)
        /// </summary>
        /// <param name="delay"></param>
        public void LoadNextScene(float delay = 0.0f)
        {
            Scene currentScene = CurrentScene;

            StartCoroutine(LoadSceneCoroutine(currentScene.buildIndex + 1, delay));
        }

        /// <summary>
        /// Loads the scene with the given build index
        /// </summary>
        /// <param name="buildIndex"></param>
        public void LoadScene(int buildIndex)
        {
            StartCoroutine(LoadSceneCoroutine(buildIndex));
        }

        /// <summary>
        /// Loads the scene with the given name
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }

        /// <summary>
        /// Loads the scene with the given name after the given delay (in seconds)
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="delay"></param>
        public void LoadSceneDelayed(string sceneName, float delay)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName, delay));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName, float delay = 0.0f)
        {
            //Play the unload timeline and wait until it is finished
            yield return UnloadCoroutine(delay);

            //Load the given scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        private IEnumerator LoadSceneCoroutine(int buildIndex, float delay = 0.0f)
        {
            //Play the unload timeline and wait until it is finished
            yield return UnloadCoroutine(delay);

            //Load the given scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(buildIndex);
        }

        IEnumerator UnloadCoroutine(float delay = 0.0f)
        {
            //Wait for the given delay
            yield return new WaitForSecondsRealtime(delay);

            playableDirector.playableAsset = unloadPlayable;

            //Get the duration of the timeline
            var duration = playableDirector.duration;

            //Play the timeline
            playableDirector.Play();

            //Wait until it is finsihed
            yield return new WaitForSecondsRealtime((float)duration);
        }
    }
}