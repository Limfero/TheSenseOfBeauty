using UnityEngine;
using UnityEngine.UI;
using YG;

[RequireComponent(typeof(HelpPresenter))]
public class HelpView : MonoBehaviour
{
    [SerializeField] private Button _buttonHelp;

    private HelpPresenter _presenter;

    private void Start()
    {
        if(_presenter.IsHaveFinal == false)
            _buttonHelp.gameObject.SetActive(false);
    }

    private void Awake()
    {
        _presenter = GetComponent<HelpPresenter>();
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += OnClikHelp;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= OnClikHelp;
    }

    private void OnClikHelp(int id) => _presenter.Help();
}
