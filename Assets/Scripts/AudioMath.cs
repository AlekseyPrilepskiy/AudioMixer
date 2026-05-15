using UnityEngine;
using UnityEngine.Audio;

public static class AudioMath
{
    public const float MuteValue = -80f;
    private const float MinValue = 0.0001f;
    private const float MaxValue = 1f;
    private const float LogMultiplier = 20f;

    public static void ApplyLinearVolume(AudioMixerGroup group, float linearValue)
    {
        float clamped = Mathf.Clamp(linearValue, MinValue, MaxValue);
        float dB = Mathf.Log10(clamped) * LogMultiplier;

        group.audioMixer.SetFloat(group.name, dB);
    }
}
