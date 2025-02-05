using Assets.Resources.Models;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderLoader : MonoBehaviour
{
    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _ambientVolume;
    [SerializeField] private Slider _sfxVolume;
    [SerializeField] private AudioSettingsSaver _audioSettings;

    private readonly int _logarithmBase = 10;
    private readonly int _linearToAttenuationLevel = 20;

    private void Start()
    {
        AudioSetting audioSettings = _audioSettings.Load();

        if (audioSettings == null)
            return;

        _masterVolume.value = Mathf.Pow(_logarithmBase, audioSettings.MasterVolume / _linearToAttenuationLevel);
        _ambientVolume.value = Mathf.Pow(_logarithmBase, audioSettings.AmbientVolume / _linearToAttenuationLevel);
        _sfxVolume.value = Mathf.Pow(_logarithmBase, audioSettings.SfxVolume / _linearToAttenuationLevel);
    }
}
