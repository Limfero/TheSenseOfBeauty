using System;
using UnityEngine;

[Serializable]
public class Slot
{
    [SerializeField] private int[] _itemsId;
    [SerializeField] private Groups _group;
    [SerializeField] private bool _isBusy;

    public bool IsBusy => _isBusy;

    public int[] ItemsId => _itemsId;

    public Groups Group => _group;

    public void Take() => _isBusy = true;

    public void Release() => _isBusy = false;
}
