using UnityEngine;
using UnityEngine.UI;
using Utils;
using YG;

namespace View
{
    [RequireComponent(typeof(Button))]
    public class TextHelp : MonoBehaviour
    {
        [SerializeField] private Ads _ads;
        [SerializeField] private GameObject _panel;

        private Button _button;
        private bool _isShowing = false;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClik);
            YandexGame.RewardVideoEvent += OnRevardedShow;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= OnRevardedShow;
        }

        private void OnClik()
        {
            _ads.OpenRewardAd();
            _isShowing = true;
        }

        private void OnRevardedShow(int id)
        {
            if (_isShowing)
                _panel.SetActive(false);
        }
    }
}