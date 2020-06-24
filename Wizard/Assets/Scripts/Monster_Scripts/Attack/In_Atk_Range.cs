using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Atk_Range : MonoBehaviour
{
    Nomal_Mob_Animator N_Mob_ani;

    Animator animator;
    private float atk_delay;
    public float atK_delay_time;
    // Start is called before the first frame update
    void Start()
    {
        N_Mob_ani = gameObject.transform.parent.GetComponent<Nomal_Mob_Animator>();
        atk_delay = 10;
        animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (atk_delay >= atK_delay_time)
            {
                N_Mob_ani.isAttack = true;
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
                    animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
                {
                    atk_delay = 0;
                }
            }

            if (atk_delay < atK_delay_time)
            {
                N_Mob_ani.isAttack = false;
                atk_delay += Time.deltaTime;
            }
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
