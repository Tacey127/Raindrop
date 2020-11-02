using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioInfo audioInfo;

    public delegate void UpdateSFX(float num);
    public static UpdateSFX updateSFX;

    public delegate void UpdateMusic(float num);
    public static UpdateMusic updateMusic;

    public void OnSFXAdjusted(float amount)
    {
        updateSFX(amount);
    }

    public void OnMusicAdjusted(float amount)
    {
        updateMusic(amount);
    }

    void Start()
    {
        OnMusicAdjusted(audioInfo.music);
        OnSFXAdjusted(audioInfo.soundFX);
    }
}

public enum AudioType { SFX, Music }