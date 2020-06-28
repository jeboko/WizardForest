using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public AudioClip Atk_Sound;
    public AudioClip Die_Sound;
    [HideInInspector] public AudioSource audioSource;

    bool isPlay;
    bool isDie;
    Animator animator;
    Mob_controller controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<Mob_controller>();
        isPlay = true;
        isDie = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay && animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            audioSource.PlayOneShot(Atk_Sound); //오디오 재생
            isPlay = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            isPlay = true;
        }

        if (isDie && controller.Hp <= 0)
        {
            audioSource.PlayOneShot(Die_Sound);
            isDie = false;
        }
    }
}

//        if (isPlay && animator.GetCurrentAnimatorStateInfo(0).IsName("attack") &&
//             animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
//audioSource.volume = 1.0f; //0.0f ~ 1.0f사이의 숫자로 볼륨을 조절
//audioSource.loop = false; //반복 여부
//audioSource.mute = false; //오디오 음소거