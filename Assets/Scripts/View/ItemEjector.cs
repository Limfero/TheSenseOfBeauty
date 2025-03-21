using UnityEngine;

namespace View
{
    public class ItemEjector : MonoBehaviour
    {
        [SerializeField] private Vector2 _direction;
        [SerializeField] private float _pushForce;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rigidbody2D) == false)
                return;

            rigidbody2D.MovePosition(rigidbody2D.position + _pushForce * Time.deltaTime * _direction);
        }
    }
}