using Presenters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class OrderChecker : MonoBehaviour
    {
        private List<int> _itemsId = new ();

        public event Action<List<int>> Cheked;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ItemPresenter itemPresenter) == false)
                return;

            _itemsId.Add(itemPresenter.Id);
        }

        private void SendToCheck()
        {
            Cheked?.Invoke(_itemsId);
            _itemsId = new ();
        }
    }
}