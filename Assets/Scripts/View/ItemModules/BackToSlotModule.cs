using Presenters;
using UnityEngine;

namespace View.ItemModules
{
    [RequireComponent(typeof(ItemView))]
    public class BackToSlotModule : MonoBehaviour
    {
        private ItemView _itemView;

        private void Awake()
        {
            _itemView = GetComponent<ItemView>();
        }

        private void OnMouseUp()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent(out SlotPresenter _) == false)
                    continue;

                return;
            }

            _itemView.Disable();
            _itemView.ReturnToLastPosition();
        }
    }
}