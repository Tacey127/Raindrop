using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]AudioType audioType;

    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        switch (audioType)
        {
            case AudioType.SFX:
                AudioHandler.updateSFX += AdjustAudio;
                break;
            case AudioType.Music:
                AudioHandler.updateMusic += AdjustAudio;
                break;
            default:
                break;
        }

    }

    void AdjustAudio(float amount)
    {
        audioSource.volume = amount;
    }

    void OnDestroy()
    {
        switch (audioType)
        {
            case AudioType.SFX:
                AudioHandler.updateSFX -= AdjustAudio;
                break;
            case AudioType.Music:
                AudioHandler.updateMusic -= AdjustAudio;
                break;
            default:
                break;
        }
    }
}
