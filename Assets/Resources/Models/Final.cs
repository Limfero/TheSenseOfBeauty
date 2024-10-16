using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Final
{
    [SerializeField] private List<ItemsInSlot> _itemsInSlots;
    [SerializeField] private int _finalId;

    public List<ItemsInSlot> ItemsInSlots => _itemsInSlots;

    public int FinalId => _finalId;
}
