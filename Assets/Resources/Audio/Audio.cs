using UnityEngine;
using Assets.Resources.Models;

public class Audio : MonoBehaviour
{
    private const string AmbientVolume = nameof(AmbientVolume);
    private const string SfxVolume = nameof(SfxVolume);
    private const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private UnityEngine.Audio.AudioMixer _audioMixer;
    [SerializeField] private AudioSettingsSaver _audioSettingsSaver;

    private readonly int _linearToAttenuationLevel = 20;

    private void Start()
    {
        LoadAudioSetting();
    }

    public void ChangeAmbientVolume(float volume)
    {
        _audioMixer.SetFloat(AmbientVolume, Mathf.Log10(volume) * _linearToAttenuationLevel);

        SaveAudioSetting();
    }

    public void ChangeSfxVolume(float volume)
    {
        _audioMixer.SetFloat(SfxVolume, Mathf.Log10(volume) * _linearToAttenuationLevel);

        SaveAudioSetting();
    }

    public void ChangeMasterVolume(float volume)
    {
        _audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * _linearToAttenuationLevel);

        SaveAudioSetting();
    }

    private void SaveAudioSetting()
    {
        if (_audioMixer.GetFloat(MasterVolume, out float master) == false)
            return;

        if (_audioMixer.GetFloat(AmbientVolume, out float ambient) == false)
            return;

        if (_audioMixer.GetFloat(SfxVolume, out float sfx) == false)
            return;

        _audioSettingsSaver.Save(new AudioSetting(master, ambient, sfx));
    }

    private void LoadAudioSetting()
    {
        AudioSetting setting = _audioSettingsSaver.Load();

        if (setting == null)
            return;

        _audioMixer.SetFloat(MasterVolume, Mathf.Log10(setting.MasterVolume) * _linearToAttenuationLevel);
        _audioMixer.SetFloat(AmbientVolume, Mathf.Log10(setting.AmbientVolume) * _linearToAttenuationLevel);
        _audioMixer.SetFloat(SfxVolume, Mathf.Log10(setting.SfxVolume) * _linearToAttenuationLevel);
    }
}
