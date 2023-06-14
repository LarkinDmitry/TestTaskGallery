using UnityEngine;

namespace LarkinTestTask_1
{
    public class NativeButtons : MonoBehaviour
    {
        [SerializeField] private string backButtonGoToScene = string.Empty;

        void Update()
        {
            if (!string.IsNullOrEmpty(backButtonGoToScene))
            {
#if PLATFORM_ANDROID
                if (Input.GetKey(KeyCode.Escape))
                {
                    _ = SceneLoader.OpenAsync(backButtonGoToScene);
                }
#endif
            }
        }
    }
}