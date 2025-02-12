using Agava.WebUtility;
using Assets.Resources.Models;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSaver), typeof(Audio))]
public class AudioApplicator : MonoBehaviour
{
    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _ambientVolume;
    [SerializeField] private Slider _sfxVolume;

    private AudioSaver _audioSaver;
    private Audio _audio;

    private readonly int _logarithmBase = 10;
    private readonly int _linearToAttenuationLevel = 20;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void Awake()
    {
        WebApplication.CallbackLogging = true;
        _audio = GetComponent<Audio>();
        _audioSaver = GetComponent<AudioSaver>();
    }

    private void Start()
    {
        AudioSetting settings = _audioSaver.Load();

        if (settings == null)
            return;

        ApplyAudioSetting(settings);
        ApplySlidersSettings(settings);
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
    }

    private void ApplySlidersSettings(AudioSetting setting)
    {
        _masterVolume.value = Mathf.Pow(_logarithmBase, setting.MasterVolume / _linearToAttenuationLevel);
        _ambientVolume.value = Mathf.Pow(_logarithmBase, setting.AmbientVolume / _linearToAttenuationLevel);
        _sfxVolume.value = Mathf.Pow(_logarithmBase, setting.SfxVolume / _linearToAttenuationLevel);
    }

    private void ApplyAudioSetting(AudioSetting setting)
    {
        _audio.ChangeMasterVolume(setting.MasterVolume);
        _audio.ChangeAmbientVolume(setting.AmbientVolume);
        _audio.ChangeSfxVolume(setting.SfxVolume);
    }
}
