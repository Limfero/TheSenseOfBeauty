using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndWindowView : MonoBehaviour
{
    [SerializeField] private PlayerResults _results;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _next;
    [SerializeField] private List<StarView> _stars;

    private int _sceneId;

    public event Action RestartButtonPresed;
    public event Action NextButtonPresed;

    private void Awake()
    {
        _sceneId = SceneManager.GetActiveScene().buildIndex;
    }

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

        _results.Save(finalId, _sceneId);

        for (int i = 0; i < _stars.Count; i++)
            if (_results.CheckFinal(i + 1, _sceneId))
                _stars[i].On();
    }

    private void Restart() => RestartButtonPresed?.Invoke();

    private void Next() => NextButtonPresed?.Invoke();
}
