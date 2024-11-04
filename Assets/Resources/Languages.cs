using UnityEngine;
using UnityEngine.UI;
using YG;

public class Languages : MonoBehaviour
{
    [SerializeField] private Image _text;
    [SerializeField] private Sprite _ruText;
    [SerializeField] private Sprite _engText;
    [SerializeField] private Sprite _trText;

    private readonly string _language = YandexGame.EnvironmentData.language;

    private void Start()
    {
        switch (_language)
        {
            case "ru":
                _text.sprite = _ruText;
                break;

            case "eng":
                _text.sprite = _engText;
                break;

            case "tr":
                _text.sprite = _trText;
                break;

            default:
                _text.sprite = _engText;
                break;
        }
    }
}
