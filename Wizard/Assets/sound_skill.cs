using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_skill : MonoBehaviour
{
    [HideInInspector]public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        audioSource.volume = GameObject.Find("Player").transform.Find("wizard_01").GetComponent<Player_sound>().audioSource.volume;
    }
}
