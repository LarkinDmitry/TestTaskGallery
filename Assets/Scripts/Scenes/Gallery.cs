using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LarkinTestTask_1
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private RectTransform viewPort;
        [SerializeField] private RectTransform contentParent;
        [SerializeField] private GridLayoutGroup grid;
        [SerializeField] private GameObject contentItemPrefab;

        private List<GameObject> items = new();

        private void Awake()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        private void Update()
        {
            if (IsScreenHasEmpty())
            {
                AddRow();
            }
        }

        private bool IsScreenHasEmpty()
        {
            float contentHeight = items.Count / grid.constraintCount * grid.cellSize.y;
            float visibleWindowHeight = contentHeight - contentParent.anchoredPosition.y;

            return visibleWindowHeight < viewPort.rect.height;
        }

        private void AddRow()
        {
            for (int i = 0; i < grid.constraintCount; i++)
            {
                CreateItem();
            }
        }

        private void CreateItem()
        {
            if (items.Count < SpriteHolder.Instance.ImagesCount)
            {
                GameObject item = Instantiate(contentItemPrefab, contentParent);
                item.AddComponent<Item>().SetImage(items.Count);
                items.Add(item);
            }
        }
    }
} 