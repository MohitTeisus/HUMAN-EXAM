using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("masterAudioVolume"))
        {
            PlayerPrefs.SetFloat("masterAudioVolume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("masterAudioVolume", slider.value);
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("masterAudioVolume");
    }

}
