using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar_Animation : MonoBehaviour
{
    // 애니메이션 사용을 위해 Animator 클래스 변수 선언
    Animator animator;
    // 플레이어와 충돌을 확인하고 공격가능 상태인지 확인할 변수
    public bool isAttack;
    // 플레이어의 공격에 피격되었는지 확인할 변수
    public bool isDamage;


    // Hp값을 불러올 스크립트
    private Mob_controller controller;
    // 추후 함수 추가 후 몹의 hp를 가져올 변수
    public float HP;
    // 공격동안 몬스터의 스피드를 0으로 만들어 제자리 공격을 하게 하고
    // 스피드를 0으로 만들기 전에 원래 스피드를 저장할 값
    public float temp_speed;

    public bool long_atk;
    public bool short_atk;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("walk", true);
        controller = gameObject.GetComponent<Mob_controller>();
        temp_speed = controller.Speed;
        isAttack = false;
        long_atk = false;
    }

    private void FixedUpdate()
    {

        HP = controller.Hp;
        animationtime();
        my_Atk();
    }

    void animationtime()
    {
        // isAttack가 참이라면 공격 애니메이션 실행
        if (isAttack)
        {
            animator.SetBool("attack", true);
        }
        if (!isAttack)
        {
            animator.SetBool("attack", false);
            controller.Speed = temp_speed;
        }
        // isDamage가 참이라면 피격 애니메이션 실행
        if (isDamage)
        {
            animator.SetBool("damage", true);
            controller.Speed = 0;
        }
        if (isDamage)
        {
            animator.SetBool("damage", false);
            controller.Speed = temp_speed;
        }

        if (HP <= 0)
        {
            controller.Speed = 0;
            animator.SetBool("die", true);
            animator.SetBool("walk", false);
            animator.SetBool("damage", false);
            animator.SetBool("attack", false);
        }

        // dead라는 이름의 애니메이션 클립이 끝나면 해당 오브젝트를 삭제한다.
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dead") &&
           animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            Destroy(gameObject);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            controller.Speed = 0;
        }
    }

    private void my_Atk()
    {
        // 원거리공격 판정?
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f)
        {
            long_atk = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        {
            long_atk = false;
        }

        //근거리 공격판정
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
        {
            short_atk = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        {
            short_atk = false;
        }

        // 애니메이션 루프
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            animator.Play("attack", -1, 0f);
        }
    }
}
