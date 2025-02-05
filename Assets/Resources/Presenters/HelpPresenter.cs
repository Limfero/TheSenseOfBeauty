using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpPresenter : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private PlayerResults _results;
    [SerializeField] private List<ItemPresenter> _items;

    private int _sceneId;
    private Final _final;
    private bool _isHaveFinal = true;

    public bool IsHaveFinal => _isHaveFinal;

    private void OnEnable()
    {
        _sceneId = SceneManager.GetActiveScene().buildIndex;

        foreach (Final final in _game.AllFinals)
        {
            if (_results.CheckFinal(final.FinalId, _sceneId) == false)
            {
                _final = final;
                return;
            }
        }

        _isHaveFinal = false;
    }

    public void Help()
    {
        foreach (ItemsInSlot itemsInSlot in _final.ItemsInSlots)
        {
            if (itemsInSlot.Items.All(itemsInSlot.Slot.Items.Select(item => item.Id).Contains))
                continue;

            List<int> ids = itemsInSlot.Items.Where(id => itemsInSlot.Slot.Items.Select(item => item.Id).Contains(id) == false).ToList();

            List<ItemPresenter> items = _items.Where(item => ids.Contains(item.Id)).ToList();

            foreach (ItemPresenter item in items) 
            { 
                if(CheckItem(item) == false)
                {
                    item.Disable();
                    item.Replace(itemsInSlot.Slot.transform.position);
                    item.transform.rotation = Quaternion.identity;
                    item.enabled = false;

                    return;
                }
            }
        }
    }

    private bool CheckItem(ItemPresenter item)
    {
        foreach (ItemsInSlot itemsInSlot in _final.ItemsInSlots)
            if (itemsInSlot.Slot.Items.Contains(item) && itemsInSlot.Items.Contains(item.Id))
                return true;

        return false;
    }
}
