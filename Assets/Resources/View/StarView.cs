using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class StarView : MonoBehaviour
{
    [SerializeField] private Sprite StarOn;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void On()
    {
        _image.sprite = StarOn;
    }
}
