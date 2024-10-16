using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemsInSlot
{
    [SerializeField] private SlotPresenter _slot;
    [SerializeField] private List<int> _items;

    public SlotPresenter Slot => _slot;
    public List<int> Items => _items;
}
