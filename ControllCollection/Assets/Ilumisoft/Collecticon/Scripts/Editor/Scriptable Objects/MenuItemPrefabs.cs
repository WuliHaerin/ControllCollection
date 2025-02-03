using UnityEngine;

namespace Ilumisoft.Collecticon.Editor
{
    [CreateAssetMenu(menuName = "Editor/Menu Item Prefabs")]
    public class MenuItemPrefabs : ScriptableObject
    {
        public GameObject BoundaryLinePrefab = null;
        public GameObject DataToken = null;
        public GameObject Finish = null;
        public GameObject GatePrefab = null;
        public GameObject Seeker = null;
    }
}