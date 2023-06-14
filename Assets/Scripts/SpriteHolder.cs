using System.Threading.Tasks;
using UnityEngine;

namespace LarkinTestTask_1
{
    public class SpriteHolder : MonoBehaviour
    {
        [SerializeField] private string serverUrl;
        [SerializeField] private int imagesCount;
        [SerializeField] private bool preloadSprite;
        [SerializeField] private int preloadSpriteCount;

        private Sprite[] sprites;
        private readonly int startNumberOffset = 1;
        private SpriteLoader loader;

        public int ImagesCount => imagesCount;
        public Sprite ChosenSprite { get; set; }
        public static SpriteHolder Instance;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            loader = new(serverUrl);            
            sprites = new Sprite[imagesCount];

            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            if (preloadSprite)
            {
                for (int i = 0; i < preloadSpriteCount; i++)
                {
                    _ = GetSpriteAsync(i);
                }
            }
        }

        public async Task<Sprite> GetSpriteAsync(int spriteNumber)
        {
            if (sprites[spriteNumber] == null)
            {
                sprites[spriteNumber] = await loader.GetSpriteAsync(spriteNumber + startNumberOffset);
            }

            return sprites[spriteNumber];
        }
    }
}