using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildButtonSc : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().rock_count <= 0 || GameObject.Find("Player").GetComponent<Player>().wood_count <= 0)
        {
            GameObject.Find("baricate_B").GetComponent<Button>().interactable = false;
        }
        else if (GameObject.Find("Player").GetComponent<Player>().rock_count >= 1 && GameObject.Find("Player").GetComponent<Player>().wood_count >= 1)
        {
            GameObject.Find("baricate_B").GetComponent<Button>().interactable = true;
        }


        if (GameObject.Find("Player").GetComponent<Player>().rock_count < 2 || GameObject.Find("Player").GetComponent<Player>().wood_count < 2)
        {
            GameObject.Find("baricate_B2").GetComponent<Button>().interactable = false;
        }
        else if (GameObject.Find("Player").GetComponent<Player>().rock_count >= 2 && GameObject.Find("Player").GetComponent<Player>().wood_count >= 2)
        {
            GameObject.Find("baricate_B2").GetComponent<Button>().interactable = true;
        }

        if (GameObject.Find("Player").GetComponent<Player>().rock_count < 3 || GameObject.Find("Player").GetComponent<Player>().wood_count < 3)
        {
            GameObject.Find("baricate_B3").GetComponent<Button>().interactable = false;
        }
        else if (GameObject.Find("Player").GetComponent<Player>().rock_count >= 3 && GameObject.Find("Player").GetComponent<Player>().wood_count >= 3)
        {
            GameObject.Find("baricate_B3").GetComponent<Button>().interactable = true;
        }

        if (GameObject.Find("Player").GetComponent<Player>().red_count == 0)
        {
            GameObject.Find("firebarrel_B").GetComponent<Button>().interactable = false;
        }
        else if (GameObject.Find("Player").GetComponent<Player>().red_count >= 1)
        {
            GameObject.Find("firebarrel_B").GetComponent<Button>().interactable = true;
        }

        if (GameObject.Find("Player").GetComponent<Player>().yellow_count == 0)
        {
            GameObject.Find("poison_B").GetComponent<Button>().interactable = false;
        }
        else if (GameObject.Find("Player").GetComponent<Player>().yellow_count >= 1)
        {
            GameObject.Find("poison_B").GetComponent<Button>().interactable = true;
        }

        if (GameObject.Find("Player").GetComponent<Player>().blue_count == 0)
        {
            GameObject.Find("slow_B").GetComponent<Button>().interactable = false;
        }
        else if (GameObject.Find("Player").GetComponent<Player>().blue_count >= 1)
        {
            GameObject.Find("slow_B").GetComponent<Button>().interactable = true;
        }
    }

    public void createBaricate()
    {
        GameObject.Find("Player").GetComponent<Player>().Create_B();
        GameObject.Find("buildScreen").SetActive(false);
    } // 설치 UI의 바리케이트 버튼 함수

    public void createBaricate2()
    {
        GameObject.Find("Player").GetComponent<Player>().Create_B2();
        GameObject.Find("buildScreen").SetActive(false);
    } // 설치 UI의 바리케이트 버튼 함수

    public void createBaricate3()
    {
        GameObject.Find("Player").GetComponent<Player>().Create_B3();
        GameObject.Find("buildScreen").SetActive(false);
    } // 설치 UI의 바리케이트 버튼 함수


    public void createFireBarrel()
    {
        GameObject.Find("Player").GetComponent<Player>().create_F();
        GameObject.Find("buildScreen").SetActive(false);
    } // 설치 UI의 불꽃통 버튼 함수

    public void createPoison_Trap()
    {
        GameObject.Find("Player").GetComponent<Player>().create_P();
        GameObject.Find("buildScreen").SetActive(false);
    } // 설치 UI의 독 함정 버튼 함수

    public void createSlowTrap()
    {
        GameObject.Find("Player").GetComponent<Player>().create_S();
        GameObject.Find("buildScreen").SetActive(false);
    } // 설치 UI의 이감 함정 버튼 함수


    public void complete_Build()
    {
        GameObject.Find("Player").GetComponent<Player>().build_complete();
    } // 설치 가능상태일 때 설치를 완료하는 함수

    public void cancel_Build()
    {
        GameObject.Find("Player").GetComponent<Player>().cancel_B();
    }// 건설 준비상태를 취소하는 버튼

}