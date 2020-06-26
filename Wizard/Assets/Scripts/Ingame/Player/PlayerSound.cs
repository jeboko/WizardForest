using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip death;
    public AudioClip demage;
    public AudioClip run;

    AudioSource AD;

    bool isrun;
    void Start()
    {
        AD = GetComponent<AudioSource>();
        isrun = true;
    }

    void FixedUpdate()
    {
        if (isrun && Player_Controller.isruning)
        {
            AD.clip = run;
            AD.loop = true;
            AD.Play();
            isrun = false;
        }

        if(Player_Controller.isruning == false)
        {
            isrun = true;
        }

        if (Player_Controller.isdeath)
        {
            AD.clip = death;
            AD.loop = false;
            AD.Play();
        }

        else
        {
            AD.loop = false;
            AD.Stop();
        }
    }

    public void dem_sound()
    {
        AD.clip = demage;
        AD.loop = false;
        AD.Play();
    }
}
