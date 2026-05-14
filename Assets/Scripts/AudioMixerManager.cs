using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mainMixer;
    [SerializeField] private AudioSource[] _sfxSources;

    private const string MasterParameter = "MasterVolume";

    private float _muteValue = -80f;
    private float _minSliderValue = 0.0001f;
    private float _maxSliderValue = 1f;
    private float _logMultiplier = 20f;

    public void SetGroupVolume(string parameterName, float linearValue)
    {
        float dB = LinearToDecibel(linearValue);
        _mainMixer.SetFloat(parameterName, dB);
    }

    public void PlaySfx(int index)
    {
        if (index >= 0 && index < _sfxSources.Length)
            _sfxSources[index].Play();
    }

    public void SetMute(bool isMuted, float lastLinearVolume)
    {
        float targetDb = isMuted ? _muteValue : LinearToDecibel(lastLinearVolume);
        _mainMixer.SetFloat(MasterParameter, targetDb);
    }

    private float LinearToDecibel(float linear)
    {
        float clamped = Mathf.Clamp(linear, _minSliderValue, _maxSliderValue);
        return Mathf.Log10(clamped) * _logMultiplier;
    }
}