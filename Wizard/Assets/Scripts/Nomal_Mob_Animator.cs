using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomal_Mob_Animator : MonoBehaviour
{
    // 애니메이션 사용을 위해 Animator 클래스 변수 선언
    Animator animator;

    // 플레이어와 충돌을 확인하고 공격가능 상태인지 확인할 변수
    public bool isAttack;
    // 플레이어의 공격에 피격되었는지 확인할 변수
    public bool isDamage;
    // 추후 함수 추가 후 몹의 hp를 가져올 변수
    public float HP;
    void Start()
    {
        animator = GetComponent<Animator>();
        isAttack = false;
        // 몬스터 관리 오브젝트 생성 후 추가 예정
        //HP = GetComponent<Mob_info>()
    }

    private void FixedUpdate()
    {
        // isAttack가 참이라면 공격 애니메이션 실행
        if(isAttack)
        {
            animator.SetBool("attack", true);
        }
        // isDamage가 참이라면 피격 애니메이션 실행
        if(isDamage)
        {
            animator.SetBool("damage", true);
        }
        if(HP <= 0)
        {
            animator.SetBool("die", true);
            
        }

        // 애니메이션이 종료되었는지 확인 할 함수
        // 애니메이션 종료 = 몬스터 사망 이므로 해당 오브젝트를 삭제한다.
        /*if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            Destroy(gameObject);
        }*/

        //animator.SetBool("walk", true);
    }

    // Player태그를 가진 오브젝트와 몬스터의 콜라이더가 충돌한다면 isAttack을 true로 바꾼다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isAttack = true;
        }

        if (other.tag == "Damage")
        {
            isDamage = true;
        }
    }


    // 콜라이더 충돌이 없는경우 = 플레이어가 공격범위 밖에 있는경우
    // isAttack값을 false로 바꾸고 공격을 멈추게 한다.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isAttack = false;
        }

        if (other.tag == "Damage")
        {
            isDamage = false;
        }
    }
}
