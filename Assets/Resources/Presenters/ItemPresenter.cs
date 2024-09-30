using System;
using UnityEngine;

public class ItemPresenter : MonoBehaviour
{
    [SerializeField] private int _id;

    public int Id => _id;

    public Transform Slot { get; private set; }

    public event Action<Vector2, Quaternion> Placed;
    public event Action Disabled;

    public void Place(Vector2 posiiton, Quaternion rotation) => Placed?.Invoke(posiiton, rotation);

    public void Disable() => Disabled?.Invoke();

    public void SetSlot(Transform slot) => Slot = slot;

    public bool CheckSlot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if(hit.collider == null) 
            return false;

        if(hit.collider.TryGetComponent(out SlotPresenter _) == false)
            return false;

        return true;
    }
}
