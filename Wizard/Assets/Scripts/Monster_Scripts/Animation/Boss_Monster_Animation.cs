using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Monster_Animation : MonoBehaviour
{
    
    // 애니메이션 사용을 위해 Animator 클래스 변수 선언
    Animator animator;
    
    // Hp값을 불러올 스크립트
    private Mob_controller controller;
    // 지속적으로 업데이트 되는 HP변수
    [HideInInspector] public float HP;
    // 기본HP값을 저장할 HP변수
    [HideInInspector] public float tempHP;

    //몬스터 속도
    private Mob_Manager_Scripts manager;
    // Mob_Manager에서 몇번째 몹 정보를 받아올것인지
    public int Mob_num;
    private float init_Speed;

    // 플레이어와 충돌을 확인하고 공격가능 상태인지 확인할 변수
    // C = 가까울때, F = 멀때
    [HideInInspector] public bool isAttack_C;
    [HideInInspector] public bool isAttack_F;
    [HideInInspector] public bool Fly_Attack;
    // 플레이어의 공격에 피격되었는지 확인할 변수
    private bool isDamage;
    // 날고있는지 파악할 변수
    private bool isFly;

    // 플레이어의 좌표값을 받아올 변수들
    private GameObject Player;
    private float Distance_B_P;

    public bool fireball_atk;
    public bool bite_atk;
    public bool fireball_sky;

    void Start()
    {
        manager = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        animator = GetComponent<Animator>();
        controller = gameObject.GetComponent<Mob_controller>();
        Player = GameObject.FindWithTag("Player");
        init_Ani();
        init_Speed = manager.deck[Mob_num - 1].speed;
        tempHP = controller.Hp;
    }

    private void FixedUpdate()
    {
        HP = controller.Hp;
        Boss_Animation();
        my_Atk();
        Boss_Fly();
    }

    void init_Ani()
    {
        animator.SetBool("walk", true);
        animator.SetBool("attack", false);
        animator.SetBool("fireball_ground", false);
        animator.SetBool("land", false);
        animator.SetBool("takeoff", false);
        animator.SetBool("die", false);
    }

    void Boss_Animation()
    {
        Distance_B_P = Vector3.Distance(gameObject.transform.position, Player.transform.position);
        

        if (HP <= 0)
        {
            controller.Speed = 0;
            animator.SetBool("die", true);
            animator.SetBool("attack", false);
            animator.SetBool("fireball_ground", false);
        }

        if (isAttack_C || isAttack_F)
        {
            controller.Speed = 0;
            if (isAttack_C)
            {
                animator.SetBool("attack", true);
            }
            if (isAttack_F)
            {
                animator.SetBool("fireball_ground", true);
            }
        }

        if (!isAttack_C && !isAttack_F)
        {
            controller.Speed = init_Speed;
        }

        if (!isAttack_C)
        {
            animator.SetBool("attack", false);
        }

        if (!isAttack_F)
        {
            animator.SetBool("fireball_ground", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.run"))
        {
            fireball_atk = false;
            bite_atk = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dead") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            Destroy(gameObject);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dead") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            controller.Speed = 0;
        }
    }

    private void my_Atk()
    {

        // 원거리공격 판정?
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.fireball_ground") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
        {
            fireball_atk = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.fireball_ground") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            fireball_atk = false;
        }

        //근거리 공격판정
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
        {
            bite_atk = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            bite_atk = false;
        }

        // 하늘공격
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.fireball_sky") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
        {
            fireball_sky = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.fireball_sky") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            fireball_sky = false;
        }


        // 애니메이션 루프
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            animator.Play("attack", -1, 0f);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.fireball_ground") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            animator.Play("fireball_ground", -1, 0f);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.fireball_sky") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            animator.Play("fireball_sky", -1, 0f);
        }
    }

   void Boss_Fly()
    {
        if((HP / tempHP) <= 0.7)
        {
            animator.SetBool("takeoff", true);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.takeoff") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            isFly = true;
        }

        if ((HP / tempHP) <= 0.3)
        {
            animator.SetBool("land", true);
            animator.SetBool("takeoff", false) ;
        }

        if(Fly_Attack)
        {
            animator.SetBool("fireball_sky", true);
        }

        if (!Fly_Attack)
        {
            animator.SetBool("fireball_sky", false);
        }
    }


    // 오브젝트와 몬스터의 콜라이더가 충돌시 처리함수
    private void OnTriggerStay(Collider other)
    {
        if (!isFly)
        {
            if (other.tag == "Player")
            {
                if (Distance_B_P < 6f)
                {
                    isAttack_C = true;
                    isAttack_F = false;
                }

                if (Distance_B_P >= 6f)
                {
                    isAttack_F = true;
                    isAttack_C = false;
                }
            }
        }

        if (isFly)
        {
            if (other.tag == "Player")
            {
                Fly_Attack = true;
                isAttack_C = false;
                isAttack_F = false;
            }
        }
    }

    // 콜라이더 충돌이 없는경우
    // 플레이어가 공격범위 밖에 있는경우 >> isAttack값을 false로 바꾸고 공격을 멈추게 한다.
    // 데미지 오브젝트 와 충돌이 끝나면 데미지 애니메이션 종료
    private void OnTriggerExit(Collider other)
    {
        if (!isFly)
        {
            if (other.tag == "Player")
            {
                isAttack_C = false;
                isAttack_F = false;
            }
        }

        if (isFly)
        {
            if (other.tag == "Player")
            {
                Fly_Attack = false;
            }
        }
    }
}

