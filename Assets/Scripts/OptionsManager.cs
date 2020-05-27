using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderSFX;
    public Slider sliderBG;
    void Start()
    {
        if(PlayerPrefs.HasKey("SFX"))
        {
            sliderSFX.value = PlayerPrefs.GetFloat("SFX");
        }
        if (PlayerPrefs.HasKey("BG"))
        {
            sliderSFX.value = PlayerPrefs.GetFloat("BG");
        }
    }
    void Update()
    {
        mixer.SetFloat("SFX", sliderSFX.value);
        mixer.SetFloat("BG", sliderBG.value);

    }
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("SFX", sliderSFX.value);
        PlayerPrefs.SetFloat("BG", sliderBG.value);
        PlayerPrefs.Save();
       
    }

    
}
