using UnityEngine;

namespace Ilumisoft.Collecticon
{
    public class LevelLoader : MonoBehaviour
    {
        [System.Serializable]
        public enum Type
        {
            Intro,
            Gameplay
        }

        [SerializeField]
        Type type = Type.Gameplay;

        [SerializeField]
        LevelAsset level;

        LevelManager levelManager;

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>();
        }

        public void LoadLevel()
        {
            switch (type)
            {
                case Type.Intro:
                    levelManager.Load(level);
                    break;
                case Type.Gameplay:
                    levelManager.LoadContent(level); ;
                    break;
            }
        }
    }
}