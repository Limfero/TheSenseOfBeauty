using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChenger : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _idScene;

    private void OnEnable()
    {
        _button.onClick.AddListener(Change);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Change);
    }

    private void Change()
    {
        SceneManager.LoadScene(_idScene);
    }
}
