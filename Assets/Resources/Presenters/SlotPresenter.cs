using System;
using UnityEngine;

public class SlotPresenter : MonoBehaviour
{
    [SerializeField] private ItemTypes _type;

    private Transform _transform;
    private ItemView _item;

    public bool IsBusy { get; private set; } = false;

    public event Action Busy;

    private void Awake()
    {
        _transform = transform;
    }

    public void TryBusy(ItemView itemView)
    {
        IsBusy = itemView.TryPlace(_transform.position, _type);

        if (IsBusy)
        {
            _item = itemView;
            Busy?.Invoke();
        }
    }

    public void TryGetFree(ItemView itemView)
    {
        if (itemView == _item)
            IsBusy = false;
    }
}
