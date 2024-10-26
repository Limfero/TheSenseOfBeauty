using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class SpriteModule : MonoBehaviour
{
    [SerializeField] private Sprite _upSprite;

    private SpriteRenderer _renderer;
    private Sprite _downSprite;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _downSprite = _renderer.sprite;
    }

    private void OnMouseDrag()
    {
        _renderer.sprite = _upSprite;
    }

    private void OnMouseUp()
    {
        _renderer.sprite = _downSprite;
    }
}
