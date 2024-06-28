using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenuManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;

    private void OnEnable()
    {
        masterVol.value = GetMasterVolume();
        musicVol.value = GetMusicVolume();
        sfxVol.value = GetSfxVolume();
    }

    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    public float GetMasterVolume()
    {
        float volumeValue;
        // "MasterVol" is an exposed volume variable from MainMixer
        // it's weird that "GetFloat" actually returns a bool value, not float
        bool result = mainAudioMixer.GetFloat("MasterVol", out volumeValue);
        if (result)
            return volumeValue;
        else
            return 0f;
    }

    public float GetMusicVolume()
    {
        float volumeValue;
        bool result = mainAudioMixer.GetFloat("MusicVol", out volumeValue);
        if (result)
            return volumeValue;
        else
            return 0f;
    }

    public float GetSfxVolume()
    {
        float volumeValue;
        bool result = mainAudioMixer.GetFloat("SfxVol", out volumeValue);
        if (result)
            return volumeValue;
        else
            return 0f;
    }

    public void ChangeMasterVolume()
    { 
        // "MasterVol" is an exposed volume variable from MainMixer
        mainAudioMixer.SetFloat("MasterVol", masterVol.value);
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVol", musicVol.value);
    }

    public void ChangeSfxVolume()
    {
        mainAudioMixer.SetFloat("SfxVol", sfxVol.value);
    }
}
