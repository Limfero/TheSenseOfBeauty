using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ItemPresenter))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class ItemView : MonoBehaviour
{
    [SerializeField] private int _upOrder = 2;
    [SerializeField] private int _downOrder = 1;

    private Transform _transform;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private ItemPresenter _presenter;
    private Coroutine _coroutine;
    private Vector3 _offset;
    private Vector3 _lastPosition;

    private readonly float _smoothDecreaseDuration = 0.5f;
    private readonly float _distanceToCameraZ = 10f;

    private void Awake()
    { 
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _presenter = GetComponent<ItemPresenter>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _presenter.SetPosition(_transform.position);
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        _offset = transform.position - mousePosition;
        _lastPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        _spriteRenderer.sortingOrder = _upOrder;
        _transform.rotation = Quaternion.identity;
        Vector3 mousePosition = GetMouseWorldPosition();
        transform.position = mousePosition + _offset;
    }

    private void OnMouseUp()
    {
        _spriteRenderer.sortingOrder = _downOrder;
    }

    public void SetPosition(Vector3 position)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Countdown(position));
    }

    public void ReturnToLastPosition() => SetPosition(_lastPosition);

    public void Enable() => _collider.enabled = true;

    public void Disable() => _collider.enabled = false;

    private IEnumerator Countdown(Vector2 position)
    {
        float elasedTime = 0f;
        Vector2 currentPosition = _transform.position;

        while (elasedTime < _smoothDecreaseDuration)
        {
            elasedTime += Time.deltaTime;
            float normalizedPosition = elasedTime / _smoothDecreaseDuration;

            _transform.position = Vector2.Lerp(currentPosition, position, normalizedPosition);

            yield return null;
        }

        Enable();
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = _distanceToCameraZ;

        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
