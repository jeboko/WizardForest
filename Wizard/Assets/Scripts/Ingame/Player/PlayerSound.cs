using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip death;
    public AudioClip demage;
    public AudioClip run;

    AudioSource AD;


    void Start()
    {
        AD = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Player_Controller.isruning)
        {
            AD.clip = run;
            AD.loop = true;
            AD.Play();
        }
        else if (Player_Controller.isdeath)
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
