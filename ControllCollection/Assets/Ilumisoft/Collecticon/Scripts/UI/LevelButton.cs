using UnityEngine;
using UnityEngine.UI;

namespace Ilumisoft.Collecticon.UI
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        [SerializeField]
        TMPro.TextMeshProUGUI text;

        LevelManager levelManager;
        Button button;

        public LevelAsset LevelAsset { get; set; } = null;

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>();
            button = GetComponent<Button>();
        }

        private void Start()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            levelManager.Load(LevelAsset);
        }

        public void SetLevelIndex(int index)
        {
            text.text = index.ToString();
        }
    }
}