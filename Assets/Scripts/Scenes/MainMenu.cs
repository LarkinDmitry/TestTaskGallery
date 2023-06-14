using UnityEngine;
using UnityEngine.UI;

namespace LarkinTestTask_1
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button StartButton;

        private void Awake()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        private void OnEnable()
        {
            StartButton.onClick.AddListener(() => _ = SceneLoader.OpenAsync("Gallery", 2));
        }

        private void OnDisable()
        {
            StartButton.onClick.RemoveAllListeners();
        }
    }
}