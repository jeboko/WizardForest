using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildButtonSc : MonoBehaviour
{

    public GameObject Error_text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().rock_count == 0 || GameObject.Find("Player").GetComponent<Player>().wood_count == 0)
        {
            GameObject.Find("baricate_B").GetComponent<Button>().interactable = false;
        }
        else if (GameObject.Find("Player").GetComponent<Player>().rock_count >= 1 && GameObject.Find("Player").GetComponent<Player>().wood_count >= 1)
        {
            GameObject.Find("baricate_B").GetComponent<Button>().interactable = true;
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
    } // 설치 UI의 바리케이트 버튼 함수

    public void createFireBarrel()
    {
        GameObject.Find("Player").GetComponent<Player>().create_F();
    } // 설치 UI의 불꽃통 버튼 함수

    public void createPoison_Trap()
    {
        GameObject.Find("Player").GetComponent<Player>().create_P();
    } // 설치 UI의 독 함정 버튼 함수

    public void createSlowTrap()
    {
        GameObject.Find("Player").GetComponent<Player>().create_S();
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
