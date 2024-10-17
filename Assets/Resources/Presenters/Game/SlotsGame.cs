using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlotsGame : Game
{
    [SerializeField] private SlotGameVariant _variant;

    public override event Action<int> Ended;

    private void OnEnable()
    {
        foreach (Final final in Finals)
            foreach (ItemsInSlot itemsInSlot in final.ItemsInSlots)
                itemsInSlot.Slot.Added += OnAdd;
    }

    private void OnDisable()
    {
        foreach (Final final in Finals)
            foreach (ItemsInSlot itemsInSlot in final.ItemsInSlots)
                itemsInSlot.Slot.Added -= OnAdd;
    }

    private void OnAdd(ItemPresenter item)
    {
        foreach (Final final in Finals)
        {
            if (CheckFinal(final) == true)
            {
                Ended?.Invoke(final.FinalId);
                return;
            }
        }
    }

    private bool CheckFinal(Final final)
    {
        foreach (ItemsInSlot itemsInSlot in final.ItemsInSlots)   
            if (EqualsList(itemsInSlot.Items, itemsInSlot.Slot.Items.Select(item => item.Id).ToList()) == false)
                return false;
        
        return true;
    }

    private bool EqualsList(List<int> first, List<int> second)
    {
        switch (_variant)
        {
            case SlotGameVariant.Add:
                return first.All(second.Contains);

            case SlotGameVariant.Or:
                return ContainsOne(first, second);
        }

        return false;
    }

    private bool ContainsOne(List<int> first, List<int> second)
    {
        foreach (var id in second)
            if (first.Contains(id))
                return true;

        return false;
    }
}
