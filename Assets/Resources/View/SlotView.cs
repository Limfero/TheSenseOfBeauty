using System;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    [SerializeField] private SlotPresenter _slotPresenter;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_slotPresenter.IsBusy == true)
            return;

        if (collision.gameObject.TryGetComponent(out ItemView itemView))
            _slotPresenter.TryBusy(itemView);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_slotPresenter.IsBusy == false)
            return;

        if (collision.gameObject.TryGetComponent(out ItemView itemView) == false)
            return;

        _slotPresenter.TryGetFree(itemView);
    }
}
