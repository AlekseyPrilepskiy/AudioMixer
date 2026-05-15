using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioMixer _mainMixer;
    [SerializeField] private AudioSource[] _sfxSources;

    private float _muteValue = -80f;
    private float _minSliderValue = 0.0001f;
    private float _maxSliderValue = 1f;
    private float _logMultiplier = 20f;

    private string GetMixerParameter(AudioChannel channel)
    {
        return channel switch
        {
            AudioChannel.Master => "MasterVolume",
            AudioChannel.Music => "MusicVolume",
            AudioChannel.Sfx => "SFXVolume",
            _ => string.Empty
        };
    }

    public void SetVolume(AudioChannel channel, float linearValue)
    {
        string parameterName = GetMixerParameter(channel);

        if (string.IsNullOrEmpty(parameterName))
        {
            return;
        }

        float clamped = Mathf.Clamp(linearValue, _minSliderValue, _maxSliderValue);
        float dB = Mathf.Log10(clamped) * _logMultiplier;

        _mainMixer.SetFloat(parameterName, dB);
    }

    public void PlaySfx(int index)
    {
        if (index >= 0 && index < _sfxSources.Length)
        {
            _sfxSources[index].Play();
        }
    }

    public void SetMute(bool isMuted, float lastLinearVolume)
    {
        string masterParam = GetMixerParameter(AudioChannel.Master);

        if (isMuted)
        {
            _mainMixer.SetFloat(masterParam, _muteValue);
        }
        else
        {
            SetVolume(AudioChannel.Master, lastLinearVolume);
        }
    }
}