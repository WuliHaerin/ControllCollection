using UnityEngine;

namespace Ilumisoft.Collecticon
{
    [CreateAssetMenu(menuName = "Levels/Level Asset")]
    public class LevelAsset : ScriptableObject
    {
        public bool HasIntro = false;

        public SceneReference IntroScene;
        public SceneReference LevelScene;
    }
}