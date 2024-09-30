using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndWindowView : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _next;
    [SerializeField] private TextMeshProUGUI _group;
    [SerializeField] private int _countGroup;

    public event Action RestartButtonPresed;
    public event Action NextButtonPresed;

    private void OnEnable()
    {
        _restart.onClick.AddListener(Restart);
        _next.onClick.AddListener(Next);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(Restart);
        _next.onClick.RemoveListener(Next);
    }

    public void Enable(int group)
    {
        gameObject.SetActive(true);
        _group.text = $"{group + 1}/{_countGroup}";
    }

    private void Restart() => RestartButtonPresed?.Invoke();

    private void Next() => NextButtonPresed?.Invoke();
}
