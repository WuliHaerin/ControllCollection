using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Collecticon.Editor
{
    public static class MenuItems
    {
        [MenuItem("GameObject/Game/Boundary Line", false, 10)]
        static void CreateBoundaryLine(MenuCommand menuCommand)
        {
            if (TryGetPrefabList(out var prefabs))
            {
                InstantiatePrefab(menuCommand, prefabs.BoundaryLinePrefab);
            }
        }

        [MenuItem("GameObject/Game/Data Token", false, 10)]
        static void CreateDataToken(MenuCommand menuCommand)
        {
            if (TryGetPrefabList(out var prefabs))
            {
                InstantiatePrefab(menuCommand, prefabs.DataToken);
            }
        }

        [MenuItem("GameObject/Game/Finish", false, 10)]
        static void CreateFinish(MenuCommand menuCommand)
        {
            if (TryGetPrefabList(out var prefabs))
            {
                InstantiatePrefab(menuCommand, prefabs.Finish);
            }
        }

        [MenuItem("GameObject/Game/Gate", false, 10)]
        static void CreateGate(MenuCommand menuCommand)
        {
            if (TryGetPrefabList(out var prefabs))
            {
                InstantiatePrefab(menuCommand, prefabs.GatePrefab);
            }
        }

        [MenuItem("GameObject/Game/Seeker", false, 10)]
        static void CreateSeeker(MenuCommand menuCommand)
        {
            if (TryGetPrefabList(out var prefabs))
            {
                InstantiatePrefab(menuCommand, prefabs.Seeker);
            }
        }

        [MenuItem("GameObject/Game/Patrol Path", false, 10)]
        static void CreatePatrolPath(MenuCommand menuCommand)
        {
            GameObject gameObject = new GameObject("Patrol Path");

            GameObjectUtility.SetParentAndAlign(gameObject, menuCommand.context as GameObject);

            // Add the patrol path component
            var patrolPath = gameObject.AddComponent<PatrolPath>();

            // Add two default waypoints to the path
            patrolPath.Waypoints.AddRange(new Vector2[] { new Vector2(-1, 0), new Vector2(1, 0) });

            Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);

            Selection.activeObject = gameObject;
        }

        static bool TryGetPrefabList(out MenuItemPrefabs prefabList)
        {
            prefabList = AssetDatabaseUtilities.FindAsset<MenuItemPrefabs>();

            if (prefabList != null)
            {
                return true;
            }

            return false;
        }

        static void InstantiatePrefab(MenuCommand menuCommand, GameObject prefab)
        {
            if (prefab != null)
            {
                var gameobject = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                gameobject.name = prefab.name;
                GameObjectUtility.SetParentAndAlign(gameobject, menuCommand.context as GameObject);
                Undo.RegisterCreatedObjectUndo(gameobject, "Create " + gameobject.name);
                Selection.activeObject = gameobject;
            }
        }
    }
}