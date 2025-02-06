using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioSingleton : MonoBehaviour
{
    private static AudioSingleton s_instance;

    private const string Menu = nameof(Menu);

    [SerializeField] private AudioClip _menu;
    [SerializeField] private AudioClip _levels;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();

        if (s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene first, Scene second)
    {
        if (second.name == Menu)
            _source.clip = _menu;
        else if(_source.clip != _levels)
            _source.clip = _levels;
        else
            return;

        _source.Play();
    }
}
