using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mainMixer;
    [SerializeField] private AudioSource[] _sfxSources;

    private const string MasterParameter = "MasterVolume";
    private const string MusicParameter = "MusicVolume";
    private const string SfxParameter = "SFXVolume";

    private bool _isMuted = false;
    private float _lastMasterVolume = 1f;
    private float _muteValue = -80f;
    private float _minSliderValue = 0.0001f;
    private float _maxSliderValue = 1f;
    private float _logMultiplier = 20f;

    private void ApplyVolume(string parameterName, float sliderValue)
    {
        float value = Mathf.Clamp(sliderValue, _minSliderValue, _maxSliderValue);
        float dB = Mathf.Log10(value) * _logMultiplier;

        _mainMixer.SetFloat(parameterName, dB);
    }

    public void SetMasterVolume(float value)
    {
        _lastMasterVolume = value;

        if (!_isMuted)
        {
            ApplyVolume(MasterParameter, value);
        }
    }

    public void SetMusicVolume(float value)
    {
        ApplyVolume(MusicParameter, value);
    }

    public void SetSFXVolume(float value)
    {
        ApplyVolume(SfxParameter, value);
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
            _mainMixer.SetFloat(MasterParameter, _muteValue);
        }
        else
        {
            ApplyVolume(MasterParameter, _lastMasterVolume);
        }
    }
}