using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioSystem _audioSystem;
    [SerializeField] private AudioChannel _channel;

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
        _audioSystem.SetVolume(_channel, value);
    }
}
