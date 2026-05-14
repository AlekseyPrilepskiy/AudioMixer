using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerManager _manager;
    [SerializeField] private string _mixerParameter;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.onValueChanged.AddListener(value => _manager.SetGroupVolume(_mixerParameter, value));
    }
}
