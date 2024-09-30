using UnityEngine;

[RequireComponent (typeof(SlotPresenter))]
public class SlotView : MonoBehaviour
{
    [SerializeField] Type _type;

    private SlotPresenter _slotPresenter;

    private void Awake()
    {
        _slotPresenter = GetComponent<SlotPresenter>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ItemPresenter itemPresenter) == false)
            return;

        if (_slotPresenter.CurrentItem == itemPresenter)
            return;

        if (_type == Type.OnlyRigth && _slotPresenter.TryGetSlot(out Slot _, itemPresenter.Id) == false)
            return;

        if (_slotPresenter.IsBusy)
            OnBusy(itemPresenter, _type);

        _slotPresenter.Busy(itemPresenter);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ItemPresenter itemPresenter) == false)
            return;

        _slotPresenter.GetFree(itemPresenter);
    }

    private void OnBusy(ItemPresenter itemPresenter, Type type)
    {
        switch (type)
        {
            case Type.Replace:
                _slotPresenter.Replace(itemPresenter);
                break;

            case Type.OnlyRigth:
            case Type.Remove:
                _slotPresenter.Remove();
                break;
        }
    }
}
