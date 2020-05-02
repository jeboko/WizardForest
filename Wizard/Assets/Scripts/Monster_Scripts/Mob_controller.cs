using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_controller : MonoBehaviour
{
    // 몬스터 프리팝에 붙여서 사용한다.
    // Monster_manager의 리스트 중에 해당 몬스터의 번호를 입력하면
    // 리스트에 입력한 스탯정보를 받아온다.
    public Mob_Manager_Scripts manager;
    // 몹리스트의 몹 번호
    public int Mob_num;
    public float Hp;
    public float Atk;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Mob_Manager").GetComponent<Mob_Manager_Scripts>();
        // num번째 정보를 불러온다.
        Hp = manager.deck[Mob_num-1].Hp;
        Atk = manager.deck[Mob_num-1].Atk;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
