using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace LarkinTestTask_1
{
    public class SpriteLoader
    {
        private string url;

        public SpriteLoader(string serverUrl)
        {
            url = serverUrl;
        }

        public async Task<Sprite> GetSpriteAsync(int spriteNumber)
        {
            Texture2D texture = await DownloadTextureAsync($"{url}{spriteNumber}.jpg");
            Rect rect = new(0.0f, 0.0f, texture.width, texture.height);
            return Sprite.Create(texture, rect, Vector2.one * 0.5f);
        }

        private async Task<Texture2D> DownloadTextureAsync(string url)
        {
            try
            {
                UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    return DownloadHandlerTexture.GetContent(request);
                }
                else
                {
                    Debug.Log(request.result.ToString());
                    return null;
                }
            }
            catch
            {
                Debug.Log($"Oops! :( Failed to download texture \"{url}\"");
                return null;
            }
        }
    }

    public static class UnityWebRequestExtension
    {
        public static TaskAwaiter<UnityWebRequest.Result> GetAwaiter(this UnityWebRequestAsyncOperation reqOp)
        {
            TaskCompletionSource<UnityWebRequest.Result> tsc = new();
            reqOp.completed += asyncOp => tsc.TrySetResult(reqOp.webRequest.result);

            if (reqOp.isDone)
            {
                tsc.TrySetResult(reqOp.webRequest.result);
            }

            return tsc.Task.GetAwaiter();
        }
    }
}