using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 원거리 몬스터 공격구체 스크립트
public class Ball_scripts : MonoBehaviour
{
    // 플레이어의 좌푤르 받아온다.
    Transform player;
    public float speed;
    Player_UI_Controller player_hp;
    public GameObject Hit_Effect;
    public float damage;


    private float time;

    public int num;
    Mob_Manager_Scripts controller;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        player_hp = GameObject.Find("Player_UI").GetComponent<Player_UI_Controller>();

        transform.LookAt(player);

        controller = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        damage = controller.deck[num-1].Atk;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (gameObject.transform.position.y <= 0.5f)
        {
            gameObject.transform.Translate(0, 0.2f, 0);
        }
        /*
        if (gameObject.transform.position.y > 0.6f)
        {
            gameObject.transform.Translate(0, -0.2f, 0);
        }
        */
        if (time > 3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(Hit_Effect, gameObject.transform.position, Quaternion.identity);
            player_hp.HP_amount = player_hp.HP_amount - damage;
            Destroy(gameObject);
        }

        if (other.tag == "baricate" || other.tag == "baricate2" || other.tag == "baricate3")
        {
            Instantiate(Hit_Effect, gameObject.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Obj_Ability>().Hp -= (int)damage;
            Destroy(gameObject);
        }

        if(other.tag == "wood" || other.tag == "rock")
        {
            Instantiate(Hit_Effect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
