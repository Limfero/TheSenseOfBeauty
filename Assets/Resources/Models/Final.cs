using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Final
{
    [SerializeField] private int _finalId;
    [SerializeField] private List<ItemsInSlot> _itemsInSlots;

    public IReadOnlyList<ItemsInSlot> ItemsInSlots => _itemsInSlots;
    public int FinalId => _finalId;
}
