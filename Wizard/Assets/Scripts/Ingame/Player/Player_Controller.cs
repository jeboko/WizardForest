using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public static bool isdeath;
    public static bool iswalking;
    public static bool isruning;
    public static bool canrun;
    public static bool canwalk;
    public static bool skilling;
    public GameObject Player_UI;
    public GameObject Attacker;
    public GameObject Modelling;

    public GameObject warnning;

    //Skill
    float time;
    public static float skill_time;
    public static float skill_usetime;
    bool skill_used;

    //Move
    public float move_speed; //걷기 스피드
    Vector3 movement;

    //Turn
    public float turnspeed; //달리기 중 방향 회전 스피드
    Vector3 lookrotation;

    //Run
    public float run_speed; //달리기 스피드
    float originspeed;

    //KnockBack
    public float knockbakc_time; //넉백 시간
    public float knockback_power; //넉백 파워
    Vector3 knockback_way;

    Animator Anim;
    Rigidbody RB;

    void Start()
    {
        iswalking = false;
        isdeath = false;
        isruning = false;
        canrun = true;
        canwalk = true;
        skill_used = false;
        skilling = false;

        RB = GetComponent<Rigidbody>();
        Anim = Modelling.GetComponent<Animator>(); 

        originspeed = move_speed;
        lookrotation = new Vector3(-10000, 0, 0); // 이후 삭제
    }

    void FixedUpdate()
    {
        //방향키 입력
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (isdeath == false)
        {
            if (canwalk)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (isruning == false)
                    {
                        Attacker.GetComponent<Attack_Controller>().Skill();
                    }
                }
            }
            else if(skilling)
            {
                time += Time.deltaTime;
                if(time > skill_usetime)
                {
                    if(skill_used == false)
                    {
                        Attacker.GetComponent<Attack_Controller>().Use_Skill();
                        skill_used = true;
                    }
                    if (time > skill_time)
                    {
                        ResetPose();
                    }
                }
            }
            else
            {
                time += Time.deltaTime;
                if(time > knockbakc_time)
                {
                    ResetPose();
                }
            }
            Animation();
        }
    }

    public void Move(float h, float v)
    {
        iswalking = true;
        movement.Set(h, 0, v);
        movement = movement.normalized * move_speed * Time.deltaTime;
        RB.MovePosition(transform.position + movement);
    }

    public void Turn(float x, float y, bool shot)
    {
        if (isruning) //달리기 방향으로 전환
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            RB.rotation = Quaternion.Slerp(RB.rotation, newRotation, turnspeed * Time.deltaTime);

        }
        else if(x != 0f && y != 0f)
        {
            if(shot)
                Attacker.GetComponent<Attack_Controller>().Normal_shot();
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, y) * Mathf.Rad2Deg, 0); 
        }
    }

    public void Run(bool run)
    {
        if (run && canrun)
        {
            move_speed = run_speed;
            isruning = true;
        }
        else if (run == false || canrun == false)
        {
            move_speed = originspeed;
            isruning = false;
        }
    }

    void Animation()
    {
        Anim.SetBool("walk", iswalking);
        Anim.SetBool("run", isruning);
    }

    void KnockBack(GameObject enemy)
    {
        float x;
        knockback_way = (enemy.transform.position - gameObject.transform.position);
        knockback_way = knockback_way.normalized;
        RB.velocity = new Vector3(knockback_way.x, 0, knockback_way.z) * knockback_power * -1f;
        canwalk = false;
    }

    public void Death()
    {
        Anim.SetBool("death", true);
    }

    public void Skill_anim(int anim_num)
    {
        canwalk = false;
        skilling = true;
        if(anim_num == 1)
        {
            Anim.SetTrigger("skill1");
        }
        else if (anim_num == 2)
        {
            Anim.SetTrigger("skill2");
        }
        else if (anim_num == 3)
        {
            Anim.SetTrigger("skill3");
        }
        else if (anim_num == 4)
        {
            Anim.SetTrigger("skill4");
        }
    }

    void ResetPose()
    {
        canwalk = true;
        skill_used = false;
        time = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Player_UI.GetComponent<Player_UI_Controller>().col_dam();
            Anim.SetTrigger("attacked");
            KnockBack(collision.gameObject);
        }
        if (collision.gameObject.tag == "item")
        {
            if(collision.gameObject.GetComponent<ItemController>().item_num <= 4)
            {
                if (collision.gameObject.GetComponent<ItemController>().item_num == 0)
                    Attacker.GetComponent<Attack_Controller>().Load_Skill(0);
                else if (collision.gameObject.GetComponent<ItemController>().item_num == 1)
                    Attacker.GetComponent<Attack_Controller>().Load_Skill(1);
                else if (collision.gameObject.GetComponent<ItemController>().item_num == 2)
                    Attacker.GetComponent<Attack_Controller>().Load_Skill(2);
                else if (collision.gameObject.GetComponent<ItemController>().item_num == 3)
                    Attacker.GetComponent<Attack_Controller>().Load_Skill(3);
                else if (collision.gameObject.GetComponent<ItemController>().item_num == 4)
                    Attacker.GetComponent<Attack_Controller>().Load_Skill(4);
            }
            else
            {
                if (collision.gameObject.GetComponent<ItemController>().item_num == 5) // hp회복
                    Player_UI.GetComponent<Player_UI_Controller>().HealHP(25);
                else if (collision.gameObject.GetComponent<ItemController>().item_num == 6) // 마나 회복
                    Player_UI.GetComponent<Player_UI_Controller>().HealMP(25);
                else if (collision.gameObject.GetComponent<ItemController>().item_num == 7) // 쉴드
                {
                    collision.gameObject.transform.parent = gameObject.transform;
                    collision.gameObject.transform.position = transform.position;
                    Player_UI_Controller.shieldON = true;
                    Player_UI_Controller.ori_hp = Player_UI.GetComponent<Player_UI_Controller>().HP_amount;
                }
            }
            collision.gameObject.GetComponent<ItemController>().Hit_Player();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mob_Atk")
        {
            Anim.SetTrigger("attacked");
            KnockBack(other.gameObject);
            print("dd");
        }
        if(other.gameObject.tag == "Limit")
        {
            warnning.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Limit")
        {
            warnning.SetActive(false);
        }
    }
} 
