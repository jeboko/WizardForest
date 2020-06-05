using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick_Look : MonoBehaviour
{
    public Transform Player;

    public Transform Stick;

    private Vector3 StickFirstPos;
    private Vector3 JoyVec;
    private float Radius;

    bool shot;

    void Start()
    {
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
    }

    public void Drag(BaseEventData _Data)
    {
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
