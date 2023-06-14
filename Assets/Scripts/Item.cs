using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LarkinTestTask_1
{
    public class Item : MonoBehaviour, IPointerClickHandler
    {
        private bool isLoading = false;

        public async void SetImage(int spriteNumber)
        {
            GetComponent<Image>().sprite = await SpriteHolder.Instance.GetSpriteAsync(spriteNumber);
            isLoading = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isLoading)
            {
                SpriteHolder.Instance.ChosenSprite = GetComponent<Image>().sprite;
                _ = SceneLoader.OpenAsync("FullScreenImage");
            }
        }
    }
}