using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float speed = 1.0F;
	public int rock_count = 0;
	public int wood_count = 0;

    public GameObject build_comp_Bt;
    //건물 최종 설치 버튼 활성화 오브젝트

    public Text countRock;
	public Text countWood;

	public GameObject baricate;
    public GameObject fire_b;
    //생성할 건설 오브젝트

    public GameObject build_checker;
	private GameObject tempo;
    private GameObject tempo2;
    //플레이어가 임시로 설치할 건물을 들고있을 때 그 건물을 저장할 오브젝트 변수

    private bool building_state = false;
	//플레이어가 이미 건설 준비중이면 새로운 오브젝트를 손에 들지 못하게 하기 위한 불 변수

	private void OnTriggerStay(Collider col)
	{
		if(Input.GetKey(KeyCode.Space))
		{
			if (col.gameObject.tag == "rock")
			{
				Destroy(col.gameObject);
				rock_count++;
			}
			else if (col.gameObject.tag == "wood")
			{
				Destroy(col.gameObject);
				wood_count++;
			}
		}
    }	



	void Update()
	{
		// 재료 카운트 텍스트에 입력
		countRock.text = "바위 X " + rock_count;
		countWood.text = "목재 X " + wood_count;

		if (Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * speed * Time.deltaTime);


		if (Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * speed * Time.deltaTime);


		if (Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * speed * Time.deltaTime);


		if (Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.back * speed * Time.deltaTime);


		
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
                tempo2 = Instantiate(baricate, build_checker.transform.position, Quaternion.identity);
                Destroy(tempo);
                rock_count--;
                wood_count--;
                tempo2.GetComponent<BuildObj>().state = true;
                building_state = false;
            }

            else if(tempo.tag == "fire_barrel")
            {

                tempo2 = Instantiate(fire_b, build_checker.transform.position, Quaternion.identity);
                Destroy(tempo);
                rock_count--;
                wood_count--;
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
			Instantiate(baricate, build_checker.transform.position, Quaternion.identity).transform.parent = build_checker.transform;
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
}
