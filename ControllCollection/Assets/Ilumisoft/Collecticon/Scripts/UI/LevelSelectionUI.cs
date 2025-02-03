using UnityEngine;

namespace Ilumisoft.Collecticon.UI
{
    public class LevelSelectionUI : MonoBehaviour
    {
        [SerializeField]
        LevelButton levelButtonPrefab;

        [SerializeField]
        Transform container = null;

        LevelManager levelManager;

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>();
        }

        void Start()
        {
            int levelIndex = 1;

            foreach (var level in levelManager.Levels)
            {
                var button = Instantiate(levelButtonPrefab, container);

                button.LevelAsset = level;
                button.SetLevelIndex(levelIndex);

                levelIndex++;
            }
        }
    }
}