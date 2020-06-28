using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObj : MonoBehaviour
{
    public int Build_state = 0;
    // 건물 설치 상태 확인 1.설치불가 2.설치 가능 3. 설치 완료
    public bool state = false;
    // 최종적으로 건설된 오브젝트면 이 스크립트를 쓰지 않기 위한 bool 변수

    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "rock")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "wood")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "baricate")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "baricate2")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "baricate3")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "fire_barrel")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "slow_trap")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "poison_trap")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "B_flower")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "R_flower")
        {
            Build_state = 1;
        }

        if (col.gameObject.tag == "Y_flower")
        {
            Build_state = 1;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (Build_state == 1)
            Build_state = 2;
    }


    // Update is called once per frame
    void Update()
    {
        if (state)
            Build_state = 3;

        else if (Build_state == 0)
            Build_state = 2;

        else if (Build_state == 2)
        {
            render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);

            if (gameObject.tag == "poison_trap")
            {
                render = gameObject.transform.Find("rpgpp_lt_vase_02").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
            }

            if (gameObject.tag == "slow_trap")
            {
                render = gameObject.transform.Find("rpgpp_lt_bowl_metal_01").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
            }

            if (gameObject.tag == "baricate")
            {
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01a").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
            }

            if (gameObject.tag == "baricate2")
            {
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01b").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01a (1)").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
            }

            if (gameObject.tag == "baricate3")
            {
                render = gameObject.transform.Find("rpgpp_lt_log_wood_01").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01a (1)").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01b").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(render.material.color.r, 1.0f, render.material.color.b, 1.0f);
            }

        }

        else if (Build_state == 1)
        {
            render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

            if (gameObject.tag == "poison_trap")
            {
                render = transform.Find("posion_trap").transform.Find("rpgpp_lt_vase_02").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }

            if (gameObject.tag == "slow_trap")
            {
                render = gameObject.transform.Find("rpgpp_lt_bowl_metal_01").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }

            if (gameObject.tag == "baricate")
            {
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01a").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }

            if (gameObject.tag == "baricate2")
            {
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01b").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01a (1)").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }

            if (gameObject.tag == "baricate3")
            {
                render = gameObject.transform.Find("rpgpp_lt_log_wood_01").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01a (1)").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                render = gameObject.transform.Find("rpgpp_lt_wood_path_01b").gameObject.GetComponent<Renderer>();
                render.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
        }

        //else if (Build_state == 3)
        //{
        //    render.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //    state = true;
        //}

    }
}
