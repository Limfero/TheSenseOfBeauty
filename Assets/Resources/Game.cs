using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private List<SlotPresenter> slots;

    private void OnEnable()
    {
        foreach (SlotPresenter slot in slots)
            slot.Busy += OnBusy;
    }

    private void OnDisable()
    {
        foreach(SlotPresenter slot in slots)
            slot.Busy -= OnBusy;
    }

    private void OnBusy()
    {
        foreach (SlotPresenter slot in slots)
            if (slot.IsBusy == false)
                return;

        Debug.Log("FINISH");
    }
}
