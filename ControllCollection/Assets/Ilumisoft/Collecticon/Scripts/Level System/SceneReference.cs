using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Ilumisoft.Collecticon
{
    [System.Serializable]
    public class SceneReference : ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField]
        public SceneAsset sceneAsset;
#endif

        [SerializeField]
        string scenePath = string.Empty;

        public string Path { get => this.scenePath; }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            scenePath = string.Empty;

            if (sceneAsset != null)
            {
                var path = AssetDatabase.GetAssetOrScenePath(sceneAsset);

                path = path.Remove(0, "Assets/".Length);

                scenePath = path.Remove(path.Length - ".unity".Length);
            }
#endif
        }

        public void OnAfterDeserialize()
        {

        }
    }
}