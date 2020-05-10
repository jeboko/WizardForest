using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_controller : MonoBehaviour
{
    // 몬스터 프리팝에 붙여서 사용한다.
    // Monster_manager의 리스트 중에 해당 몬스터의 번호를 입력하면
    // 리스트에 입력한 스탯정보를 받아온다.
    private Mob_Manager_Scripts manager;
    private Monster_AI navimash_controller;
    // 몹리스트의 몹 번호
    public int Mob_num;
    public float Hp;
    public float Atk;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        navimash_controller = gameObject.GetComponent<Monster_AI>();
        // num번째 정보를 불러온다.
        Hp = manager.deck[Mob_num-1].Hp;
        Atk = manager.deck[Mob_num-1].Atk;
        Speed = manager.deck[Mob_num - 1].speed;
    }

    // Update is called once per frame
    void Update()
    {
        navimash_controller.mob_speed = Speed;
        //Hp = Hp - 0.05f;
    }
}
