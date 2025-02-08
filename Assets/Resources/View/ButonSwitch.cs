using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EndWindowView))]
public class ButonSwitch : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private EndWindowView _view;

    private void Awake()
    {
        _view = GetComponent<EndWindowView>();
    }

    private void OnEnable()
    {
        _view.Enabled += Disable;
    }

    private void OnDisable()
    {
        _view.Enabled -= Disable;
    }

    private void Disable()
    {
        foreach (var button in _buttons)
            button.gameObject.SetActive(false);
    }
}
