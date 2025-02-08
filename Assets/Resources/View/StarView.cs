using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class StarView : MonoBehaviour
{
    private const string On = nameof(On);

    [SerializeField] private Sprite _starOn;
    [SerializeField] private Image _startOff;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnStar()
    {
        _animator.SetTrigger(On);
    }

    public void ChangeStar()
    {
        _startOff.sprite = _starOn;
    }
}
