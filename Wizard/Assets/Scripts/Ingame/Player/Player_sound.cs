﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_sound : MonoBehaviour
{
    public Slider masterVolume;
    private float masterVol = 1f;


    public AudioClip Run_Sound;
    public AudioClip Hit_Sound;
    public AudioClip Die_Sound;
    [HideInInspector] public AudioSource audioSource;

    bool isHit;
    bool isDie;
    bool isRun;
    Animator animator;
    Player_UI_Controller u_c;
    // Start is called before the first frame update
    void Start()
    {
        isHit = true;
        isDie = true;
        isRun = true;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        u_c = GameObject.Find("Player_UI").GetComponent<Player_UI_Controller>();

        masterVol = PlayerPrefs.GetFloat("backvol", 1f);
        masterVolume.value = masterVol;
        audioSource.volume = masterVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();

        if (isRun && animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {

            audioSource.clip = Run_Sound;
            audioSource.Play();
            audioSource.loop = true;
            //audioSource.PlayOneShot(Run_Sound); //오디오 재생
            isRun = false;
        }

        if (isHit && animator.GetCurrentAnimatorStateInfo(0).IsName("damage"))
        {
            audioSource.PlayOneShot(Hit_Sound); //오디오 재생
            isHit = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            audioSource.Stop();
            isRun = true;
            isHit = true;
        }

        if (isDie && u_c.HP_amount <= 0)
        {
            audioSource.PlayOneShot(Die_Sound);
            isDie = false;
            isRun = false;
            isHit = false;
        }
    }

    public void SoundSlider()
    {
        audioSource.volume = masterVolume.value;

        masterVol = masterVolume.value;
        PlayerPrefs.GetFloat("backvol", 1f);
    }
}
