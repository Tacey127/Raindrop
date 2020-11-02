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


    #region singleton
    public static AudioHandler instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    #endregion

    void Start()
    {
        OnMusicAdjusted(audioInfo.music);
        OnSFXAdjusted(audioInfo.soundFX);
    }

    

    public void OnMusicAdjusted(float amount)
    {
        audioInfo.music = amount;
        Debug.Log(amount);
        if(updateMusic.GetInvocationList().Length > 0)
        {
            updateMusic(amount);
        }
    }
    public void OnSFXAdjusted(float amount)
    {
        audioInfo.soundFX = amount;
        if (updateSFX.GetInvocationList().Length > 0)
        {
            updateSFX(amount);
        }
    }
}

public enum AudioType { SFX, Music }