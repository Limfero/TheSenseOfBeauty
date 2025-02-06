using UnityEngine;

[RequireComponent(typeof(AudioSaver))]
public class Audio : MonoBehaviour
{
    private const string AmbientVolume = nameof(AmbientVolume);
    private const string SfxVolume = nameof(SfxVolume);
    private const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private UnityEngine.Audio.AudioMixer _audioMixer;

    private readonly int _linearToAttenuationLevel = 20;

    private AudioSaver _audioSaver;

    private void Awake()
    {
        _audioSaver = GetComponent<AudioSaver>();
    }

    public void ChangeAmbientVolume(float volume)
    {
        _audioMixer.SetFloat(AmbientVolume, Mathf.Log10(volume) * _linearToAttenuationLevel);
        Save();
    }

    public void ChangeSfxVolume(float volume)
    {
        _audioMixer.SetFloat(SfxVolume, Mathf.Log10(volume) * _linearToAttenuationLevel);
        Save();
    }

    public void ChangeMasterVolume(float volume)
    {
        _audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * _linearToAttenuationLevel);
        Save();
    }

    private void Save()
    {
        _audioMixer.GetFloat(MasterVolume, out float master);
        _audioMixer.GetFloat(SfxVolume, out float sfx);
        _audioMixer.GetFloat(AmbientVolume, out float ambient);

        _audioSaver.Save(master, ambient, sfx);
    }
}
