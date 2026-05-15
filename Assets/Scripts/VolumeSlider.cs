using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(HandleSliderChange);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(HandleSliderChange);
    }

    private void HandleSliderChange(float value)
    {
        AudioMath.ApplyLinearVolume(_mixerGroup, value);
    }
}
