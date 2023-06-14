using UnityEngine;
using UnityEngine.UI;

namespace LarkinTestTask_1
{
    public class FullScreenImage : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button closeBtn;

        private void Awake()
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        private void OnEnable()
        {
            closeBtn.onClick.AddListener(() => _ = SceneLoader.OpenAsync("Gallery"));
            image.sprite = SpriteHolder.Instance.ChosenSprite;
        }

        private void OnDisable()
        {
            closeBtn.onClick.RemoveAllListeners();
        }
    }
}