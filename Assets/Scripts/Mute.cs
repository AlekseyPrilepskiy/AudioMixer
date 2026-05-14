using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerManager _manager;
    [SerializeField] private Slider _masterSlider;

    private bool _isMuted = false;

    public void Toggle()
    {
        _isMuted = !_isMuted;
        _manager.SetMute(_isMuted, _masterSlider.value);
    }
}
