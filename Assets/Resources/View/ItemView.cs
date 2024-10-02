using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(ItemPresenter), typeof(SpriteRenderer))]
public class ItemView : MonoBehaviour
{
    [SerializeField] private TypeMovement _type;
    [SerializeField] private ShadowView _shadowView;

    private Vector2 _lastPosition;
    private Coroutine _coroutine;

    private ItemPresenter _presenter;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private readonly float _smoothDecreaseDuration = 0.5f;
    private readonly int _upOrder = 2;
    private readonly int _downOrder = 1;

    private void Awake()
    {
        _transform = transform;
        _lastPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _presenter = GetComponent<ItemPresenter>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _presenter.Placed += Put;
        _presenter.Disabled += Disable;
    }

    private void OnDisable()
    {
        _presenter.Placed -= Put;
        _presenter.Disabled -= Disable;
    }

    private void OnMouseDrag()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        Disable();
        _spriteRenderer.sortingOrder = _upOrder;
        _transform.rotation = Quaternion.identity;
        Vector3 newPosition = new(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        _transform.position = Camera.main.ScreenToWorldPoint(newPosition);
        _shadowView.OnUp();
    }

    private void OnMouseUp()
    {
        _spriteRenderer.sortingOrder = _downOrder;
        Enable();
        OnUp();
        _shadowView.OnDown();
    }

    private void OnUp()
    {
        if(_type == TypeMovement.Replace && _presenter.CheckSlot() == false)
            Return();
    }

    private void Return()
    {
        Disable();
        Put(_lastPosition, _transform.rotation);
    }

    private void Put(Vector2 position, Quaternion rotation)
    {
        _lastPosition = position;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Countdown(position, rotation));
    }

    private IEnumerator Countdown(Vector2 position, Quaternion rotation)
    {
        float elasedTime = 0f;
        Vector2 currentPosition = _transform.position;
        Quaternion currentRotation = _transform.rotation;

        while (elasedTime < _smoothDecreaseDuration)
        {
            elasedTime += Time.deltaTime;
            float normalizedPosition = elasedTime / _smoothDecreaseDuration;

            _transform.SetPositionAndRotation(Vector2.Lerp(currentPosition, position, normalizedPosition), Quaternion.Lerp(currentRotation, rotation, normalizedPosition));

            yield return null;
        }

        Enable();
    }

    private void Disable() => _rigidbody.bodyType = RigidbodyType2D.Static;

    private void Enable() => _rigidbody.bodyType = RigidbodyType2D.Kinematic;
}
