﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public static bool isdeath;
    public static bool isruning;
    public static bool canrun;
    public GameObject Player_UI;

    //Move
    public float move_speed; //걷기 스피드
    Vector3 movement;

    //Turn
    public float turnspeed; //달리기 중 방향 회전 스피드
    Vector3 lookrotation;

    //Run
    public float run_speed; //달리기 스피드
    float originspeed;


    Rigidbody RB;


    void Start()
    {
        isdeath = false;
        isruning = false;
        canrun = true;
        RB = GetComponent<Rigidbody>();
        originspeed = move_speed;
    }

    void FixedUpdate()
    {
        //방향키 입력
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (isdeath == false)
        {
            Move(h, v);

            Turn(h, v);

            Run();
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * move_speed * Time.deltaTime;
        RB.MovePosition(transform.position + movement);
    }

    void Turn(float h, float v)
    {
        if (isruning) //달리기 방향으로 전환
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            RB.rotation = Quaternion.Slerp(RB.rotation, newRotation, turnspeed * Time.deltaTime);
        }
        else //방향키로 전환
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                lookrotation = new Vector3(-99999, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                lookrotation = new Vector3(99999, 0, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                lookrotation = new Vector3(0, 0, 99999);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                lookrotation = new Vector3(0, 0, -99999);
            }
            Quaternion newRotation = Quaternion.LookRotation(lookrotation);
            RB.rotation = Quaternion.Slerp(RB.rotation, newRotation, turnspeed * Time.deltaTime);
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (canrun)
            {
                move_speed = run_speed;
                isruning = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || canrun == false)
        {
            move_speed = originspeed;
            isruning = false;
        }
    }
} 