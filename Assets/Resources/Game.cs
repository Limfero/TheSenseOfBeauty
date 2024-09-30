using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private List<SlotPresenter> _slots;

    private void OnEnable()
    {
        foreach (SlotPresenter slot in _slots)
            slot.Occupied += OnBusy;
    }

    private void OnDisable()
    {
        foreach(SlotPresenter slot in _slots)
            slot.Occupied -= OnBusy;
    }

    private void OnBusy(Groups group)
    {
        List<Slot> slots = _slots.SelectMany(presenter => presenter.Slots).ToList();

        foreach (Slot slot in slots.Where(slot => slot.Group == group))
            if (slot.IsBusy == false)
                return;

        Debug.Log("FINISH");
    }
}
