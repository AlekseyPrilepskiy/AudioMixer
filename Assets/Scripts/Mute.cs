using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    [SerializeField] private AudioSystem _audioSystem;
    [SerializeField] private Slider _masterSlider;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(HandleToggleChange);

        _audioSystem.SetMute(!_toggle.isOn, _masterSlider.value);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(HandleToggleChange);
    }

    private void HandleToggleChange(bool isMuted)
    {
        _audioSystem.SetMute(!isMuted, _masterSlider.value);
    }
}
