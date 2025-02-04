using System;
using UnityEngine;
using Assets.Resources.Models;

public class AudioSettingsSaver : MonoBehaviour
{
    private const string MasterKey = "Master_volume";
    private const string AmbientKey = "Ambient_volume";
    private const string SfxKey = "Sfx_volume";

    private readonly float _defaultValue = -1000f;

    public void Save(AudioSetting setting)
    {
        if (setting == null)
            throw new NullReferenceException($"{setting} is null");

        PlayerPrefs.SetFloat(MasterKey, setting.MasterVolume);
        PlayerPrefs.SetFloat(AmbientKey, setting.AmbientVolume);
        PlayerPrefs.SetFloat(SfxKey, setting.SfxVolume);
        PlayerPrefs.Save();
    }

    public AudioSetting Load() 
    {
        float master = PlayerPrefs.GetFloat(MasterKey, _defaultValue);
        float ambient = PlayerPrefs.GetFloat(AmbientKey, _defaultValue);
        float sfx = PlayerPrefs.GetFloat(SfxKey, _defaultValue);

        if (master == _defaultValue || ambient == _defaultValue || sfx == _defaultValue)
            return null;

        return new(master, ambient, sfx);
    }
}
