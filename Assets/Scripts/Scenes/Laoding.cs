using UnityEngine;
using UnityEngine.UI;

namespace LarkinTestTask_1
{
    public class Laoding : MonoBehaviour
    {
        [SerializeField] private Image progressBar;

        private void Awake()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        void Start()
        {
            progressBar.fillAmount = 0;
        }

        void Update()
        {
            progressBar.fillAmount = SceneLoader.GetLoadProgress();
        }
    }
}