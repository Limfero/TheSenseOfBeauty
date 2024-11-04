using UnityEngine;
using YG;

public class TextHelp : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += OnClikHelp;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= OnClikHelp;
    }

    private void OnClikHelp(int id) => _panel.SetActive(false);
}
