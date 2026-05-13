using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mainMixer;
    [SerializeField] private AudioSource[] _sfxSources;

    private bool _isMuted = false;
    private float _lastMasterVolume = 1f;
    private float _muteValue = -80f;

    private void ApplyVolume(string parameterName, float sliderValue)
    {
        float value = Mathf.Clamp(sliderValue, 0.0001f, 1f);
        float dB = Mathf.Log10(value) * 20;

        _mainMixer.SetFloat(parameterName, dB);
    }

    public void SetMasterVolume(float value)
    {
        _lastMasterVolume = value;

        if (!_isMuted)
        {
            ApplyVolume("MasterVolume", value);
        }
    }

    public void SetMusicVolume(float value)
    {
        ApplyVolume("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        ApplyVolume("SFXVolume", value);
    }

    public void PlaySFX(int index)
    {
        if (index >= 0 && index < _sfxSources.Length)
        {
            _sfxSources[index].Play();
        }
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            _mainMixer.SetFloat("MasterVolume", _muteValue);
        }
        else
        {
            ApplyVolume("MasterVolume", _lastMasterVolume);
        }
    }
}