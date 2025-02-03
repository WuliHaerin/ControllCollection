namespace Ilumisoft.Editor.GameTemplate
{
    using UnityEngine;

    public class PackageData : ScriptableObject
    {
        /// <summary>
        /// The asset ID of the package
        /// </summary>
        [SerializeField]
        public string ID = string.Empty;

        /// <summary>
        /// The visible name of the package
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Discount in percent
        /// </summary>
        [SerializeField]
        public int Discount = 0;

        /// <summary>
        /// Gets the asset store URL of the package
        /// </summary>
        public string AssetStoreURL => $"https://assetstore.unity.com/packages/slug/{ID}?aid=1100l9P3D";
    }
}