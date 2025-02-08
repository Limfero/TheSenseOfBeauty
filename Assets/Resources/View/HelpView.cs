using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

[RequireComponent(typeof(HelpPresenter))]
public class HelpView : MonoBehaviour
{
    [SerializeField] private Button _buttonHelp;
    [SerializeField] private float _delay = 0.7f;

    private HelpPresenter _presenter;
    private bool _canGiveHelp = true;

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

    private void OnClikHelp(int id)
    {
        if(_canGiveHelp == false)
            return;

        _presenter.Help();

        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        _canGiveHelp = false;
        _buttonHelp.interactable = false;

        yield return new WaitForSeconds(_delay);

        _canGiveHelp = true;
        _buttonHelp.interactable = true;
    }
}
