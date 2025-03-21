using System;
using System.Collections.Generic;
using UnityEngine;

namespace Presenters
{
    public class SlotPresenter : MonoBehaviour
    {
        private readonly List<ItemPresenter> _items = new ();

        public event Action<ItemPresenter> Added;
        public event Action<ItemPresenter> Removed;

        public IReadOnlyList<ItemPresenter> Items => _items;

        public void Add(ItemPresenter item)
        {
            _items.Add(item);

            Added?.Invoke(item);
        }

        public void Remove(ItemPresenter item)
        {
            _items.Remove(item);

            Removed?.Invoke(item);
        }
    }
}