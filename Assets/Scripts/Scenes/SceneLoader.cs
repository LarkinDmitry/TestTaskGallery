using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace LarkinTestTask_1
{
    public static class SceneLoader
    {
        private static readonly int loadingStepsCount = 50;
        private static float progress;

        // To load scenes async, need use SceneManager.LoadSceneAsync(),
        // but the task says "show the loading screen for 2-3 seconds"...
        // Ok, this time can be used to download the first sprites.
        // This will make the "SpriteHolder" see "preloadSprite".
        public static async Task OpenAsync(string sceneName, float fakeLoadSeconds = 0)
        {
            SceneManager.LoadScene("Loading");

            if (fakeLoadSeconds != 0)
            {
                await Delay(fakeLoadSeconds * 1000);
            }

            SceneManager.LoadScene(sceneName);
        }

        public static async Task Delay(float microSeconds)
        {
            progress = 0;

            for (int i = 0; i < loadingStepsCount; i++)
            {
                await Task.Delay((int)(microSeconds / loadingStepsCount));
                progress += 1 / (float)loadingStepsCount;
            }
        }

        public static float GetLoadProgress()
        {
            return progress;
        }
    }
}