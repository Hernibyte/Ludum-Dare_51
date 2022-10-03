using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider VolumeSlider;
    [SerializeField] string sfxGroup = "sfx";
    [SerializeField] string bgmGroup = "bgm";

    float volumenBGM;
    float volumenSFX;
    public void SetSFX(float porcentaje)
    {
        volumenSFX = 20 * Mathf.Log10(Mathf.Clamp(porcentaje, 0.01f, 1f));
        audioMixer.SetFloat(sfxGroup, volumenSFX);
    }

    public void SetBGM(float porcentaje)
    {
        volumenBGM = 20 * Mathf.Log10(Mathf.Clamp(porcentaje, 0.01f, 1f));
        audioMixer.SetFloat(bgmGroup, volumenBGM);
    }


    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVol"))
        {
            PlayerPrefs.SetFloat("musicVol", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVol()
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }

    void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVol");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("musicVol", VolumeSlider.value);
    }

}
