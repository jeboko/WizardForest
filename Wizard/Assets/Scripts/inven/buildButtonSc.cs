using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildButtonSc : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createBaricate()
    {
        GameObject.Find("Player").GetComponent<Player>().Create_B();
    } // 설치 UI의 바리케이트 버튼 함수

    public void createFireBarrel()
    {
        GameObject.Find("Player").GetComponent<Player>().create_F();
    } // 설치 UI의 바리케이트 버튼 함수

    public void complete_Build()
    {
        GameObject.Find("Player").GetComponent<Player>().build_complete();
    } // 설치 가능상태일 때 설치를 완료하는 함수

}
