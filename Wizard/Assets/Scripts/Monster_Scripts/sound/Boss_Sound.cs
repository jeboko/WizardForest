﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sound : MonoBehaviour
{
    public AudioClip Atk_Sound1;
    public AudioClip Atk_Sound2;
    public AudioClip Take_off_Sound;
    public AudioClip Fly_Sound;
    public AudioClip Die_Sound;
    [HideInInspector] public AudioSource audioSource;

    Animator animator;

    bool isPlay;
    bool isDie;
    bool isTake_off;
    bool isFly;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isPlay = true;
        isDie = true;
        isTake_off = true;
        isFly = true;
    }

    void Update()
    {
        m_sound();
    }

    void m_sound()
    {
        //근거리
        if (isPlay && animator.GetCurrentAnimatorStateInfo(0).IsName("attack") &&
                    animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            audioSource.PlayOneShot(Atk_Sound1); //오디오 재생
            isPlay = false;
        }

        //원거리
        if (isPlay && animator.GetCurrentAnimatorStateInfo(0).IsName("fireball_ground") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            audioSource.PlayOneShot(Atk_Sound2); //오디오 재생
            isPlay = false;
        }

        if (isPlay && animator.GetCurrentAnimatorStateInfo(0).IsName("fireball_sky") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            audioSource.PlayOneShot(Atk_Sound2); //오디오 재생
            isPlay = false;
        }

        // 날아오를떄
        if (isTake_off && animator.GetCurrentAnimatorStateInfo(0).IsName("takeoff") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            audioSource.PlayOneShot(Take_off_Sound); //오디오 재생
            isTake_off = false;
            isFly = true;
        }

        //나는 중
        if (isFly && animator.GetCurrentAnimatorStateInfo(0).IsName("fly_forward") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            audioSource.PlayOneShot(Fly_Sound); //오디오 재생
            isFly = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("run") || animator.GetCurrentAnimatorStateInfo(0).IsName("fly_forward"))
        {
            isPlay = true;
        }

        if (isDie && animator.GetCurrentAnimatorStateInfo(0).IsName("dead"))
        {
            audioSource.PlayOneShot(Die_Sound);
            isDie = false;
        }
    }
}