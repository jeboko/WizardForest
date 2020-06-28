﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Short_atk_box : MonoBehaviour
{
    Player_UI_Controller player_hp;
    public float damage;

    public int num;
    Mob_Manager_Scripts controller;

    // Start is called before the first frame update
    void Start()
    {
        player_hp = GameObject.Find("Player_UI").GetComponent<Player_UI_Controller>();
        controller = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        damage = controller.deck[num-1].Atk;
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.tag == "Player")
            {
                player_hp.HP_amount -= damage;
            }

            if (other.tag == "baricate" || other.tag == "baricate2" || other.tag == "baricate3")
            {
                other.gameObject.GetComponent<Obj_Ability>().Hp -= (int)damage;
            }
        }
        catch(NullReferenceException ex)
        {
        }

        if(other == null)
        {

        }

        else return;
    }
}
