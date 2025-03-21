using UnityEngine;

namespace View.ItemModules
{
    [RequireComponent(typeof(Collider2D))]
    public class ColliderOffModule : MonoBehaviour
    {
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnMouseDrag()
        {
            _collider.enabled = false;
        }

        private void OnMouseUp()
        {
            _collider.enabled = true;
        }
    }
}