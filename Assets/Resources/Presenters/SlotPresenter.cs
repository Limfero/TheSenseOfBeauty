using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotPresenter : MonoBehaviour
{
    [SerializeField] private Slot[] _slots;

    public IReadOnlyList<Slot> Slots => _slots;

    public bool IsBusy { get; private set; } = false;
    public ItemPresenter CurrentItem { get; private set; }


    public event Action<Groups> Occupied;

    public void Busy(ItemPresenter item)
    {
        IsBusy = true;
        CurrentItem = item;
        item.SetSlot(transform);

        if (TryGetSlot(out Slot slot, item.Id))
        {
            slot.Take();
            Occupied?.Invoke(slot.Group);
        }
    }

    public void GetFree(ItemPresenter item)
    {
        IsBusy = false;
        CurrentItem = null;

        if (TryGetSlot(out Slot slot, item.Id))
            slot.Release();
    }

    public void Replace(ItemPresenter item)
    {
        CurrentItem.Disable();

        if (item.Slot != null)
            CurrentItem.Place(item.Slot.position, item.Slot.rotation);

        item.Place(transform.position, transform.rotation);
    }

    public bool TryGetSlot(out Slot slot, int itemId)
    {
        slot = null;

        foreach (Slot item in _slots)
        {
            if (item.ItemId == itemId)
            {
                slot = item;
                return true;
            }
        }

        return false;
    }
}
