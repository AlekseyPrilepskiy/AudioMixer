using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterGroup;
    [SerializeField] private Slider _masterSlider;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(HandleToggleChange);
        HandleToggleChange(_toggle.isOn);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(HandleToggleChange);
    }

    private void HandleToggleChange(bool isMuted)
    {
        if (isMuted)
        {
            AudioMath.ApplyLinearVolume(_masterGroup, _masterSlider.value);
        }
        else
        {
            _masterGroup.audioMixer.SetFloat(_masterGroup.name, AudioMath.MuteValue);
        }
    }
}
