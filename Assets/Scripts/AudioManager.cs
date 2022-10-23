using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider SFXSlider; 
    public Slider BGMSlider; 
    public AudioMixer mixer;
    // Start is called before the first frame update

    AudioSource audioClip;
    void Start()
    {
        float db;
        if(mixer.GetFloat("SfxVolume", out db))
            SFXSlider.value = (db + 80) / 80;
        if(mixer.GetFloat("MusicVolume", out db))
            BGMSlider.value = (db + 80) / 80;
    }

    public void SFXVolume(float value)

    {

        value = value * 80 - 80;

        mixer.SetFloat("SfxVolume", value);
    }
    
    public void BGMVolume(float value)

    {

        value = value * 80 - 80;

        mixer.SetFloat("MusicVolume", value);
    }


}



