using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sound : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        if (isRun && animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            Debug.Log("re");
            audioSource.clip = Run_Sound;
            audioSource.Play();
            //audioSource.PlayOneShot(Run_Sound); //오디오 재생
            isRun = false;
        }

        if (isHit && animator.GetCurrentAnimatorStateInfo(0).IsName("damage"))
        {
            Debug.Log("da");
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
            Debug.Log("di");
            audioSource.PlayOneShot(Die_Sound);
            isDie = false;
        }
    }
}
