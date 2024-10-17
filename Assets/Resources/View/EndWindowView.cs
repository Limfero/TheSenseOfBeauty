using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWindowView : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _next;
    [SerializeField] private List<StarView> _stars;

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

    public void Enable(int finalId)
    {
        gameObject.SetActive(true);
        //из PlayerPrefs брать уже готовые звуздочки и сохранять только что сделанную
        _stars[finalId - 1].On();
    }

    private void Restart() => RestartButtonPresed?.Invoke();

    private void Next() => NextButtonPresed?.Invoke();
}
