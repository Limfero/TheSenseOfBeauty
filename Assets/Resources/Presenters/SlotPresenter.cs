using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotPresenter : MonoBehaviour
{
    [SerializeField] private Slot[] _slots;
    [SerializeField] private Vector2 _offset = Vector2.left;

    public IReadOnlyList<Slot> Slots => _slots;

    public bool IsBusy { get; private set; } = false;
    public ItemPresenter CurrentItem { get; private set; }


    public event Action<Groups> Occupied;

    public void Busy(ItemPresenter item)
    {
        IsBusy = true;
        CurrentItem = item;
        item.Place(transform.position, transform.rotation);
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

    public void Remove()
    {
        CurrentItem.Disable();
        CurrentItem.Place(transform.position + (Vector3)_offset, transform.rotation);
    }

    public void Replace(ItemPresenter item)
    {
        CurrentItem.Disable();

        if (item.Slot != null)
            CurrentItem.Place(item.Slot.position, item.Slot.rotation);
        else
            Remove();
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
