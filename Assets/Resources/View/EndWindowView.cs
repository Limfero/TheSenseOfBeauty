using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWindowView : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _next;
    [SerializeField] private List<Transform> starsPositions;
    [SerializeField] private Transform StarsOff;
    [SerializeField] private Transform StarsOn;

    public event Action RestartButtonPresed;
    public event Action NextButtonPresed;

    private void Start()
    {
        for (int i = 0; i < starsPositions.Count; i++)
            starsPositions[i] = Instantiate(StarsOff, starsPositions[i].position, starsPositions[i].rotation, transform);
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
        //из PlayerPrefs брать уже готовые звуздочки и сохранять только что сделанную
        Debug.Log(finalId - 1);
        Instantiate(StarsOn, starsPositions[finalId - 1].position, starsPositions[finalId - 1].rotation, transform);
        Destroy(starsPositions[finalId - 1].gameObject);
    }

    private void Restart() => RestartButtonPresed?.Invoke();

    private void Next() => NextButtonPresed?.Invoke();
}
