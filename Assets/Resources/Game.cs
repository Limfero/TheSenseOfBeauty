using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private List<SlotPresenter> _slots;
    [SerializeField] private EndWindowView _endWindow;
    [SerializeField] private int _idNextScene;

    private void OnEnable()
    {
        foreach (SlotPresenter slot in _slots)
            slot.Occupied += OnBusy;

        _endWindow.NextButtonPresed += LoadNextScene;
        _endWindow.RestartButtonPresed += RestartScene;
    }

    private void OnDisable()
    {
        foreach(SlotPresenter slot in _slots)
            slot.Occupied -= OnBusy;

        _endWindow.NextButtonPresed -= LoadNextScene;
        _endWindow.RestartButtonPresed -= RestartScene;
    }

    private void OnBusy(Groups group)
    {
        List<Slot> slots = _slots.SelectMany(presenter => presenter.Slots).ToList();

        foreach (Slot slot in slots.Where(slot => slot.Group == group))
            if (slot.IsBusy == false)
                return;

        _endWindow.Enable((int)group);
    }

    private void LoadNextScene() => SceneManager.LoadScene(_idNextScene);

    private void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
