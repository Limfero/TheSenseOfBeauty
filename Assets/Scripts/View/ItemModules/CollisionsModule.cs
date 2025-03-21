using UnityEngine;

namespace View.ItemModules
{
    public class CollisionsModule : MonoBehaviour
    {
        [SerializeField] private float _pushForce = 100f;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rigidbody2D) == false)
                return;

            Vector2 direction = (collision.transform.position - transform.position).normalized;

            rigidbody2D.MovePosition(rigidbody2D.position + _pushForce * Time.deltaTime * direction);
        }
    }
}