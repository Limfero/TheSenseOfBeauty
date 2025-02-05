using UnityEngine;

public class AudioItems : MonoBehaviour
{
    [SerializeField] private AudioSource[] _mouseDown;
    [SerializeField] private AudioSource[] _mouseUp;

    private void OnMouseDown()
    {
        _mouseDown[Random.Range(0, _mouseDown.Length)].Play();
    }

    private void OnMouseUp()
    {
        _mouseUp[Random.Range(0, _mouseUp.Length)].Play();
    }
}
