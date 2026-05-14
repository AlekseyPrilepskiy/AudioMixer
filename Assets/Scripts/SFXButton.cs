using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SfxButton : MonoBehaviour
{
    [SerializeField] private AudioMixerManager _manager;
    [SerializeField] private int _sfxIndex;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => _manager.PlaySfx(_sfxIndex));
    }
}
