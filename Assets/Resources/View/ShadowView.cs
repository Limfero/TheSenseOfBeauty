using System.Collections;
using UnityEngine;

public class ShadowView : MonoBehaviour
{
    [SerializeField] private Vector2 _up;

    private Vector3 _currentPosition;
    private Coroutine _coroutine;
    private readonly float _smoothDecreaseDuration = 0.5f;

    private void Start()
    {
        _currentPosition = transform.localPosition;
    }

    public void OnUp() => Put(_currentPosition + (Vector3)_up);

    public void OnDown() => Put(_currentPosition);

    private void Put(Vector2 position)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Countdown(position));
    }

    private IEnumerator Countdown(Vector2 position)
    {
        float elasedTime = 0f;
        Vector2 currentPosition = transform.localPosition;

        while (elasedTime < _smoothDecreaseDuration)
        {
            elasedTime += Time.deltaTime;
            float normalizedPosition = elasedTime / _smoothDecreaseDuration;

            transform.localPosition = Vector2.Lerp(currentPosition, position, normalizedPosition);

            yield return null;
        }
    }
}
