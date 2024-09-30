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
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down);

        if (hits.Length == 0)
            return false;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(out ItemPresenter presenter))
                if (presenter != this)
                    return true;
        }

        return false;
    }
}
