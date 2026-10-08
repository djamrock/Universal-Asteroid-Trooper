using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public AudioMixer mainAudioMixer;

    public Slider mainVolumeSlider;

    public Slider musicVolumeSlider;

    public Slider SFXVolumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        OnMainVolumeChange();
        OnMusicVolumeChange();
        OnSFXVolumeChange();
    }


    public void OnMainVolumeChange()
    {
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }

        mainAudioMixer.SetFloat("MasterVolume", newVolume);
    }

    public void OnMusicVolumeChange()
    {
        float newVolume = musicVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }

        mainAudioMixer.SetFloat("MusicVolume", newVolume);
    }

    public void OnSFXVolumeChange()
    {
        float newVolume = SFXVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }

        mainAudioMixer.SetFloat("SFXVolume", newVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
