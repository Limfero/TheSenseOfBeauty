using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemView : MonoBehaviour
{
    [SerializeField] ItemPresenter _presenter;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        _transform.rotation = Quaternion.identity;
        _rigidbody.bodyType = RigidbodyType2D.Static;
        Vector3 newPosition = new(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        _transform.position = Camera.main.ScreenToWorldPoint(newPosition);
    }

    private void OnMouseUp()
    {
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    public bool TryPlace(Vector3 position, ItemTypes type)
    {
        if (_presenter.IsCorrectType(type) == false)
            return false;

        _transform.position = position;

        return true;
    }
}
