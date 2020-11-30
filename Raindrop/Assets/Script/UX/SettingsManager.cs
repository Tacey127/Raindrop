using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    AudioHandler audioHandler = null;
    void Start()
    {
        musicSlider.SetValueWithoutNotify(AudioHandler.instance.audioInfo.music);

        sfxSlider.SetValueWithoutNotify(AudioHandler.instance.audioInfo.soundFX);
    }
}
