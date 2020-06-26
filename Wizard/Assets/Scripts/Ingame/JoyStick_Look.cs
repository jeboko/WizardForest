using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick_Look : MonoBehaviour
{
    public Transform Player;
    public GameObject Attacker;

    public Transform Stick;

    private Vector3 StickFirstPos;
    private Vector3 JoyVec;
    private float Radius;

    bool shot;
    bool skill_enable;

    float time;

    void Start()
    {
        skill_enable = true;
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;
        shot = false;
    }

    private void FixedUpdate()
    {
        if (Player_Controller.canwalk)
        {
            Player.GetComponent<Player_Controller>().Turn(JoyVec.x, JoyVec.y, shot);
        }
        if(skill_enable == false)
        {
            time += Time.deltaTime;
            if(time >= 0.3f)
            {
                time = 0;
                skill_enable = true;
            }
        }
    }

    public void Drag(BaseEventData _Data)
    {
        if(Scene_Manager.day_night == false)
            shot = true;
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        JoyVec = (Pos - StickFirstPos).normalized;

        float Dis = Vector3.Distance(Pos, StickFirstPos);

        if (Dis < Radius)
        {
            Stick.position = StickFirstPos + JoyVec * Dis;
        }
        else
        {
            Stick.position = StickFirstPos + JoyVec * Radius;
            if (Player_Controller.isruning == false && skill_enable && Scene_Manager.day_night == false)
            {
                Attacker.GetComponent<Attack_Controller>().Skill();
                skill_enable = false;
            }
            shot = false;
        }
    }

    public void DragEnd()
    {
        shot = false;
        Stick.position = StickFirstPos;
        JoyVec = Vector3.zero;
        Player_Controller.iswalking = false;
    }
}
