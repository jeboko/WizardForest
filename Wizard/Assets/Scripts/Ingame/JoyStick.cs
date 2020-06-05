using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    public Transform Player;

    public Transform Stick;
    private Vector3 StickFirstPos;
    private Vector3 JoyVec;
    private float Radius;
    private bool MoveFlag;

    float h;
    float v;
    bool run;

    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;

        MoveFlag = false;
    }

    private void FixedUpdate()
    {
        if (MoveFlag && Player_Controller.canwalk)
        {
            Player.GetComponent<Player_Controller>().Move(h, v);
            Player.GetComponent<Player_Controller>().Run(run);
        }
    }

    public void Drag(BaseEventData _Data)
    {
        MoveFlag = true;
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        JoyVec = (Pos - StickFirstPos).normalized;

        float Dis = Vector3.Distance(Pos, StickFirstPos);

        if (Dis < Radius)
        {
            Stick.position = StickFirstPos + JoyVec * Dis;
            run = false;
        }
        else
        {
            Stick.position = StickFirstPos + JoyVec * Radius;
            run = true;
        }
        
        if (Stick.position.x > transform.position.x + 50)
        {
            h = 1;
        }
        else if (Stick.position.x < transform.position.x - 50)
        {
            h = -1;
        }
        else
        {
            h = 0;
        }

        if (Stick.position.y > transform.position.y + 50)
        {
            v = 1;
        }
        else if (Stick.position.y < transform.position.y - 50)
        {
            v = -1;
        }
        else
        {
            v = 0;
        }
    }

    public void DragEnd()
    {
        Stick.position = StickFirstPos; 
        JoyVec = Vector3.zero; 
        MoveFlag = false;
        Player_Controller.isruning = false;
        Player_Controller.iswalking = false;
    }
}
