namespace Ilumisoft.UI.Messages
{
    using Ilumisoft.Collecticon.Messages;
    using UnityEditor;
    using UnityEngine;

    public static class MenuItems
    {
        // Add a menu item to create custom GameObjects.
        // Priority 1 ensures it is grouped with the other menu items of the same kind
        // and propagated to the hierarchy dropdown and hierarchy context menus.
        [MenuItem("GameObject/Messages/Message", false, 10)]
        static void CreateMessage(MenuCommand menuCommand)
        {
            // Create a custom game object
            var go = new GameObject("Message", typeof(RectTransform));

            go.AddComponent<Message>();
            
            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            
            Selection.activeObject = go;
        }
    }
}