using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_In_Atk_Range : MonoBehaviour
{
    Boss_Monster_Animation N_Mob_ani;
    // Start is called before the first frame update
    void Start()
    {
        N_Mob_ani = gameObject.transform.parent.GetComponent<Boss_Monster_Animation>();
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (!N_Mob_ani.isFly)
        {
            if (other.tag == "Player")
            {
                if (N_Mob_ani.Distance_B_P < 6f)
                {
                    N_Mob_ani.isAttack_C = true;
                    N_Mob_ani.isAttack_F = false;
                }

                if (N_Mob_ani.Distance_B_P >= 6f)
                {
                    N_Mob_ani.isAttack_F = true;
                    N_Mob_ani.isAttack_C = false;
                }
            }
        }

        if (N_Mob_ani.isFly)
        {
            if (other.tag == "Player")
            {
                N_Mob_ani.Fly_Attack = true;
                N_Mob_ani.isAttack_C = false;
                N_Mob_ani.isAttack_F = false;
            }
        }
    }

    // 콜라이더 충돌이 없는경우
    // 플레이어가 공격범위 밖에 있는경우 >> isAttack값을 false로 바꾸고 공격을 멈추게 한다.
    // 데미지 오브젝트 와 충돌이 끝나면 데미지 애니메이션 종료
    private void OnTriggerExit(Collider other)
    {
        if (!N_Mob_ani.isFly)
        {
            if (other.tag == "Player")
            {
                N_Mob_ani.isAttack_C = false;
                N_Mob_ani.isAttack_F = false;
            }
        }

        if (N_Mob_ani.isFly)
        {
            if (other.tag == "Player")
            {
                N_Mob_ani.Fly_Attack = false;
            }
        }
    }
}
