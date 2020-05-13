using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Short_atk_box : MonoBehaviour
{
    Dummy_move player_hp;
    public float damage;

    public int num;
    Mob_Manager_Scripts controller;

    // Start is called before the first frame update
    void Start()
    {
        player_hp = GameObject.FindWithTag("Player").GetComponent<Dummy_move>();
        controller = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        damage = controller.deck[num-1].Atk;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player_hp.Hp = player_hp.Hp - damage;
        }

        else return;
    }
}
