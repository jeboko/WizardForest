using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Die_Sound : MonoBehaviour
{
    public AudioClip Die_Sound;
    [HideInInspector] public AudioSource audioSource;
    bool isdie;
    // Start is called before the first frame update
    void Start()
    {
        isdie = true;

    }

    private void Update()
    {
        SoundSlider();
        if (isdie)
        {
            audioSource.Play();
            isdie = false;
        }
    }

    public void SoundSlider()
    {
        audioSource.volume = GameObject.Find("Player").transform.Find("wizard_01").GetComponent<Player_sound>().audioSource.volume;
    }
}
