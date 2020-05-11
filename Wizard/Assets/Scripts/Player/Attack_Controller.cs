using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{
    float time;

    public GameObject nomal_attack;
    public float normal_cooltime;


    void Start()
    {
        time = normal_cooltime;
    }

    void FixedUpdate()
    {
        if(time < normal_cooltime)
        {
            time += Time.deltaTime;
        }
        print(time);
    }

    public void Normal_shot()
    {
        if(time >= normal_cooltime)
        {
            time = 0;
            Instantiate(nomal_attack, transform.position, transform.rotation);
        }
    }
}
