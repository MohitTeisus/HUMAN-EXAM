using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("sensitivity"))
        {
            PlayerPrefs.SetFloat("sensitivity", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeSens()
    {
        Observer.changeSensitivity(slider.value);
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("sensitivity", slider.value);
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("sensitivity");
    }

}
