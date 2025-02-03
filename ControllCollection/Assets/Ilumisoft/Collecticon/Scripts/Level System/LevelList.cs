using System.Collections.Generic;
using UnityEngine;

namespace Ilumisoft.Collecticon
{
    [CreateAssetMenu(menuName = "Levels/Level List")]
    public class LevelList : ScriptableObject
    {
        [SerializeField]
        List<LevelAsset> levels = new List<LevelAsset>();

        public List<LevelAsset> Levels { get => this.levels; set => this.levels = value; }
    }
}