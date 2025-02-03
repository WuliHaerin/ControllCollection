using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Editor.GameTemplate
{
    public class WindowPackageListContent : WindowContent
    {
        List<PackageData> packageList;

        public override void Initialize(EditorWindow editorWindow, PackageInfo packageInfo)
        {
            base.Initialize(editorWindow, packageInfo);

            LoadPackageList();
        }

        private void LoadPackageList()
        {
            packageList = ScriptableObjectUtility.Load<PackageData>();
        }

        public override void OnGUI()
        {
            var headerStyle = new GUIStyle(EditorStyles.miniLabel)
            {
                wordWrap = true
            };

            GUILayout.Space(14);

            DrawHeadline("Upgrade Options");

            GUILayout.Label($"Would you like to get more of our assets? You can upgrade with a discount to the following packages:", headerStyle);
            GUILayout.Space(8);

            var textStyle = new GUIStyle(EditorStyles.boldLabel);
            textStyle.normal.textColor = Config.Style.HighlightColor;

            foreach (var package in packageList)
            {
                using (var horizontalScope = new GUILayout.HorizontalScope())
                {
                    GUILayout.Label(new GUIContent($"{package.Name} ({package.Discount}% OFF)"), textStyle);

                    if (GUILayout.Button("Show", GUILayout.Width(100)))
                    {
                        Application.OpenURL(package.AssetStoreURL);
                    }
                }
            }
        }
    }
}