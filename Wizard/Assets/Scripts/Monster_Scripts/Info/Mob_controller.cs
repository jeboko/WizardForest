using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mob_controller : MonoBehaviour
{
    // 몬스터 프리팝에 붙여서 사용한다.
    // Monster_manager의 리스트 중에 해당 몬스터의 번호를 입력하면
    // 리스트에 입력한 스탯정보를 받아온다.
    private Mob_Manager_Scripts manager;
    private Monster_AI navimash_controller;
    Scene_Manager scene_Manager;
    // 몹리스트의 몹 번호
    public int Mob_num;
    public float Hp;
    public float Atk;
    public float Speed;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0.0f, 2.0f, 0);

    private Canvas uiCanvas;
    private Image hpBarImage;
    private float initHp;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        navimash_controller = gameObject.GetComponent<Monster_AI>();
        scene_Manager = GameObject.Find("GameManager").GetComponent<Scene_Manager>();
        // num번째 정보를 불러온다.
        Hp = manager.deck[Mob_num-1].Hp;
        initHp = manager.deck[Mob_num - 1].Hp; ;
        Atk = manager.deck[Mob_num-1].Atk;
        Speed = manager.deck[Mob_num - 1].speed;

        SetHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        navimash_controller.mob_speed = Speed;
        hpBarImage.fillAmount = Hp / initHp;

        if(scene_Manager.day_night)
        {
           Hp = 0;
        }

        if(Hp <= 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }


    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UI_Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpbar = hpBar.GetComponent<Monster_HP_Bar>();
        _hpbar.targetTr = this.gameObject.transform;
        _hpbar.offset = hpBarOffset;
    }
}
