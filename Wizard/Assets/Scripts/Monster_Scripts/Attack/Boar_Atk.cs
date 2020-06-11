using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar_Atk : MonoBehaviour
{
    Boar_Animation N_Mob_ani;
    // Start is called before the first frame update
    void Start()
    {
        N_Mob_ani = gameObject.transform.parent.GetComponent<Boar_Animation>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            N_Mob_ani.isAttack = true;
        }

        if (other.tag == "Damage")
        {
            N_Mob_ani.isDamage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            N_Mob_ani.isAttack = false;
        }

        if (other.tag == "Damage")
        {
            N_Mob_ani.isDamage = false;
        }
    }
}
