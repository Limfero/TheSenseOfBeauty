using Presenters;
using UnityEngine;

namespace View.SlotModules
{
    public class RemoveModule : SlotModule
    {
        [SerializeField] private Vector2 _offset;

        private void OnEnable()
        {
            SlotPresenter.Added += Remove;
        }

        private void OnDisable()
        {
            SlotPresenter.Added -= Remove;
        }

        private void Remove(ItemPresenter presenter)
        {
            foreach (var item in SlotPresenter.Items)
                if (item != presenter)
                    item.SetPosition(item.transform.position + (Vector3)_offset);
        }
    }
}