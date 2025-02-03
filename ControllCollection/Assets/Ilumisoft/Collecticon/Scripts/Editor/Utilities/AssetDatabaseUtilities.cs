using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Collecticon.Editor
{
    public static class AssetDatabaseUtilities
    {
        public static T FindAsset<T>() where T : Object
        {
            var loadedAssets = Resources.FindObjectsOfTypeAll<T>();

            if (loadedAssets.Length > 0)
            {
                return loadedAssets[0];
            }

            var guids = AssetDatabase.FindAssets($"t:{typeof(T)}");

            if (guids.Length > 0)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[0]);

                return AssetDatabase.LoadAssetAtPath<T>(path);
            }
            else
                return null;
        }
    }
}