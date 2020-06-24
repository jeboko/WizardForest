using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//player의 건설 관련 능력 스크립트임

public class Player : MonoBehaviour
{
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

  
    private void OnTriggerEnter(Collider col)
	{
		
			if (col.gameObject.tag == "rock")
			{
            Debug.Log("돌과 충돌");
				Destroy(col.gameObject);
				rock_count++;
			}
			else if (col.gameObject.tag == "wood")
			{
				Destroy(col.gameObject);
				wood_count++;
			}
            else if (col.gameObject.tag == "B_flower")
            {
                Destroy(col.gameObject);
                blue_count++;
            }
            else if (col.gameObject.tag == "Y_flower")
            {
                Destroy(col.gameObject);
                yellow_count++;
            }
            else if (col.gameObject.tag == "R_flower")
            {
                Destroy(col.gameObject);
                red_count++;
            }
       
           
    }	



	void Update()
	{
		// 재료 카운트 텍스트에 입력
		countRock.text = "바위 X " + rock_count;
		countWood.text = "목재 X " + wood_count;
        countRed.text = "빨간 꽃 X " + red_count;
        countYellow.text = "노란 꽃 X " + yellow_count;
        countBlue.text = "파란 꽃 X " + blue_count;

		
        if (building_state)
            build_comp_Bt.SetActive(true);
        else if(!building_state)
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
           
            }

            else if(tempo.tag == "fire_barrel")
            {

                tempo2 = Instantiate(fire_b, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                red_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;
            }

            else if (tempo.tag == "slow_trap")
            {

                tempo2 = Instantiate(slow_T, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                blue_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;
            }

            else if (tempo.tag == "poison_trap")
            {

                tempo2 = Instantiate(poison_T, build_checker.transform.position, gameObject.transform.rotation);
                Destroy(tempo);
                yellow_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;
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
            tempo = transform.Find("build_checker").transform.Find("sample_build(Clone)").gameObject;

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
