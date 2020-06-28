using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//player의 건설 관련 능력 스크립트임

public class Player : MonoBehaviour
{
    Scene_Manager S_M;
    public int rock_count = 0;
    public int wood_count = 0;

    public int red_count = 0;
    public int yellow_count = 0;
    public int blue_count = 0;

    public GameObject build_comp_Bt;
    //건물 최종 설치 버튼 활성화 오브젝트

    public Text countRock;
    public Text countWood;
    public Text countRed;
    public Text countYellow;
    public Text countBlue;

    public GameObject baricate;
    public GameObject baricate2;
    public GameObject baricate3;
    public GameObject fire_b;
    public GameObject poison_T;
    public GameObject slow_T;
    //생성할 건설 오브젝트

    public GameObject build_checker;
    private GameObject tempo;
    private GameObject tempo2;

    //플레이어가 임시로 설치할 건물을 들고있을 때 그 건물을 저장할 오브젝트 변수

    private bool building_state = false;
    //플레이어가 이미 건설 준비중이면 새로운 오브젝트를 손에 들지 못하게 하기 위한 불 변수

    private void Start()
    {
        S_M = GameObject.Find("GameManager").GetComponent<Scene_Manager>();
    }

    private void OnTriggerStay(Collider col)
    {
        if(S_M.is_day)
        {
            if (GameObject.Find("farming_Bt").GetComponent<pauseUI>().farming_state == true)
            {

                if (col.gameObject.tag == "rock")
                {
                    Destroy(col.gameObject);
                    rock_count++;
                    GameObject.Find("farming_Bt").GetComponent<pauseUI>().farming_state = false;
                }
                else if (col.gameObject.tag == "wood")
                {
                    Destroy(col.gameObject);
                    wood_count++;
                    GameObject.Find("farming_Bt").GetComponent<pauseUI>().farming_state = false;
                }
                else if (col.gameObject.tag == "B_flower")
                {
                    Destroy(col.gameObject);
                    blue_count++;
                    GameObject.Find("farming_Bt").GetComponent<pauseUI>().farming_state = false;
                }
                else if (col.gameObject.tag == "Y_flower")
                {
                    Destroy(col.gameObject);
                    yellow_count++;
                    GameObject.Find("farming_Bt").GetComponent<pauseUI>().farming_state = false;
                }
                else if (col.gameObject.tag == "R_flower")
                {
                    Destroy(col.gameObject);
                    red_count++;
                    GameObject.Find("farming_Bt").GetComponent<pauseUI>().farming_state = false;
                }

            }
        }
    }



    void Update()
    {
        // 재료 카운트 텍스트에 입력
        countRock.text = " X " + rock_count;
        countWood.text = " X " + wood_count;
        countRed.text = " X " + red_count;
        countYellow.text = " X " + yellow_count;
        countBlue.text = " X " + blue_count;


        if (building_state)
            build_comp_Bt.SetActive(true);
        else if (!building_state)
            build_comp_Bt.SetActive(false);

    }

    public void build_complete()
    {
        if (tempo.GetComponent<BuildObj>().Build_state == 2)
        {
            if (tempo.tag == "baricate")
            {
                tempo2 = Instantiate(baricate, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                rock_count--;
                wood_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;

                if (GameObject.Find("build_List_Bt").GetComponent<pauseUI>().buildOn == true)
                {
                    GameObject.Find("build_List_Bt").GetComponent<pauseUI>().activebuild();
                }

            }

            else if (tempo.tag == "baricate2")
            {
                tempo2 = Instantiate(baricate2, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                rock_count -= 2;
                wood_count -= 2;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;

                if (GameObject.Find("build_List_Bt").GetComponent<pauseUI>().buildOn == true)
                {
                    GameObject.Find("build_List_Bt").GetComponent<pauseUI>().activebuild();
                }

            }

            else if (tempo.tag == "baricate3")
            {
                tempo2 = Instantiate(baricate3, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                rock_count -= 3;
                wood_count -= 3;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;

                if (GameObject.Find("build_List_Bt").GetComponent<pauseUI>().buildOn == true)
                {
                    GameObject.Find("build_List_Bt").GetComponent<pauseUI>().activebuild();
                }

            }

            else if (tempo.tag == "fire_barrel")
            {

                tempo2 = Instantiate(fire_b, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                red_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;

                if (GameObject.Find("build_List_Bt").GetComponent<pauseUI>().buildOn == true)
                {
                    GameObject.Find("build_List_Bt").GetComponent<pauseUI>().activebuild();
                }
            }

            else if (tempo.tag == "slow_trap")
            {

                tempo2 = Instantiate(slow_T, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                blue_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;

                if (GameObject.Find("build_List_Bt").GetComponent<pauseUI>().buildOn == true)
                {
                    GameObject.Find("build_List_Bt").GetComponent<pauseUI>().activebuild();
                }
            }

            else if (tempo.tag == "poison_trap")
            {

                tempo2 = Instantiate(poison_T, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                yellow_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;

                if (GameObject.Find("build_List_Bt").GetComponent<pauseUI>().buildOn == true)
                {
                    GameObject.Find("build_List_Bt").GetComponent<pauseUI>().activebuild();
                }
            }

        }

        else
            Debug.Log("건설할 오브젝트를 들고 있지 않음");
    }
    //건설이 가능할 때 최종설치하는 함수


    public void Create_B()// 건설 준비 버튼(바리케이드)
    {
        if (building_state == false) // 설치 준비
        {
            building_state = true;
            Instantiate(baricate, build_checker.transform.position, gameObject.transform.rotation).transform.parent = build_checker.transform;
            tempo = transform.Find("build_checker").transform.Find("Barricade1(Clone)").gameObject;

        }
    }

    public void Create_B2()// 건설 준비 버튼(바리케이드)2. 2번쨰 크기
    {
        if (building_state == false) // 설치 준비
        {
            building_state = true;
            Instantiate(baricate2, build_checker.transform.position, gameObject.transform.rotation).transform.parent = build_checker.transform;
            tempo = transform.Find("build_checker").transform.Find("Barricade2(Clone)").gameObject;

        }
    }

    public void Create_B3()// 건설 준비 버튼(바리케이드)3. 3번쨰 크기
    {
        if (building_state == false) // 설치 준비
        {
            building_state = true;
            Instantiate(baricate3, build_checker.transform.position, gameObject.transform.rotation).transform.parent = build_checker.transform;
            tempo = transform.Find("build_checker").transform.Find("Barricade3(Clone)").gameObject;

        }
    }

    public void create_F()// 건설 준비 버튼(불꽃 통)
    {

        if (building_state == false) // 설치 준비
        {
            building_state = true;
            Instantiate(fire_b, build_checker.transform.position, Quaternion.identity).transform.parent = build_checker.transform;
            tempo = transform.Find("build_checker").transform.Find("fire_barrel(Clone)").gameObject;

        }
    }

    public void create_S()// 건설 준비 버튼(이감 통)
    {

        if (building_state == false) // 설치 준비
        {
            building_state = true;
            Instantiate(slow_T, build_checker.transform.position, Quaternion.identity).transform.parent = build_checker.transform;
            tempo = transform.Find("build_checker").transform.Find("slow_trap(Clone)").gameObject;

        }
    }


    public void create_P()// 건설 준비 버튼(독 함정)
    {

        if (building_state == false) // 설치 준비
        {
            building_state = true;
            Instantiate(poison_T, build_checker.transform.position, Quaternion.identity).transform.parent = build_checker.transform;
            tempo = transform.Find("build_checker").transform.Find("posion_trap(Clone)").gameObject;

        }
    }

    public void cancel_B()
    {
        Destroy(tempo);
        building_state = false;
    }
}

