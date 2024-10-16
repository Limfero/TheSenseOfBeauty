using System.Linq;
using UnityEngine;

[RequireComponent (typeof(SlotPresenter))]
public class SlotView : MonoBehaviour
{
    private SlotPresenter _slotPresenter;

    private void Awake()
    {
        _slotPresenter = GetComponent<SlotPresenter>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ItemPresenter itemPresenter) == false)
            return;

        if (_slotPresenter.Items.Contains(itemPresenter))
            return;

        _slotPresenter.Add(itemPresenter);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ItemPresenter itemPresenter) == false)
            return;

        if (_slotPresenter.Items.Contains(itemPresenter) == false)
            return;

        _slotPresenter.Remove(itemPresenter);
    }
}
