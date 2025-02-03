using System.Collections.Generic;
using UnityEngine;

namespace Ilumisoft.Collecticon
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        LevelList levelList = null;

        int currentLevelIndex = 0;

        public List<LevelAsset> Levels { get => this.levelList.Levels; set => this.levelList.Levels = value; }

        public LevelAsset GetCurrentLevelAsset()
        {
            if (currentLevelIndex < Levels.Count)
            {
                return Levels[currentLevelIndex];
            }
            else
            {
                return null;
            }
        }

        private void Awake()
        {
            string path = GetCurrentScenePath();

            // Determine the index of the current level
            for (int i = 0; i < Levels.Count; i++)
            {
                if (Levels[i].IntroScene.Path == path || Levels[i].LevelScene.Path == path)
                {
                    currentLevelIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// Returns the path of the current scene
        /// </summary>
        /// <returns></returns>
        string GetCurrentScenePath()
        {
            var scene = gameObject.scene;

            // Remove "Assets/" from the beginning
            string path = scene.path.Substring("Assets/".Length);

            // Remove ".unity" from the end
            path = path.Remove(path.Length - ".unity".Length);

            return path;
        }

        /// <summary>
        /// Load the given level. If the level has an intro the intro scene will be loaded, otherwise the gameplay scene
        /// </summary>
        /// <param name="level"></param>
        public void Load(LevelAsset level)
        {
            if (level.HasIntro)
            {
                LoadIntro(level);
            }
            else
            {
                LoadContent(level);
            }
        }

        public bool HasNextLevel()
        {
            return currentLevelIndex < Levels.Count-1;
        }

        /// <summary>
        /// Loads he intro scene of the given level
        /// </summary>
        /// <param name="levelData"></param>
        public void LoadIntro(LevelAsset levelData)
        {
            LoadScene(levelData.IntroScene.Path);
        }

        /// <summary>
        /// Loads the gameplay scene of the given level
        /// </summary>
        /// <param name="levelData"></param>
        public void LoadContent(LevelAsset levelData)
        {
            LoadScene(levelData.LevelScene.Path);
        }

        /// <summary>
        /// Loads the next level
        /// </summary>
        public void LoadNextLevel()
        {
            Load(GetNextLevel());
        }

        LevelAsset GetNextLevel()
        {
            return Levels[currentLevelIndex + 1];
        }

        /// <summary>
        /// Loads the scene at the given path
        /// </summary>
        /// <param name="path"></param>
        void LoadScene(string path)
        {
            var sceneManager = FindObjectOfType<SceneManager>();
            sceneManager.LoadScene(path);
        }
    }
}