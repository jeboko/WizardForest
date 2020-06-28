using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_maneger : MonoBehaviour
{
    public Slider masterVolume;
    private float masterVol = 1f;

    public AudioClip night_Sound;
    [HideInInspector]
    public AudioSource audioSource;


    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = night_Sound;
        audioSource.Play();
        audioSource.loop = true;

        masterVol = PlayerPrefs.GetFloat("backvol", 1f);
        masterVolume.value = masterVol;
        audioSource.volume = masterVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();

    }

    public void SoundSlider()
    {
        audioSource.volume = masterVolume.value;

        masterVol = masterVolume.value;
        PlayerPrefs.GetFloat("backvol", 1f);
    }
}

