using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ItemPresenter))]
[RequireComponent(typeof(SpriteRenderer))]
public class ItemView : MonoBehaviour
{
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private ItemPresenter _presenter;
    private Coroutine _coroutine;

    private readonly int _upOrder = 2;
    private readonly int _downOrder = 1;
    private readonly float _smoothDecreaseDuration = 0.5f;

    private void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _presenter = GetComponent<ItemPresenter>();
    }

    private void Start()
    {
        _presenter.SetPosition(_transform.position);
    }

    private void OnMouseDrag()
    {
        _spriteRenderer.sortingOrder = _upOrder;
        _transform.rotation = Quaternion.identity;
        Vector3 newPosition = new(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        _transform.position = Camera.main.ScreenToWorldPoint(newPosition);
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
    }
}
