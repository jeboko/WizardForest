using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_HP_Bar : MonoBehaviour
{
    private Camera ui_cam;
    private Canvas ui_canvas;
    private RectTransform rectBack;
    private RectTransform rectFront;

    public Vector3 offset = Vector3.zero;
    public Transform targetTr;

    void Start()
    {
        ui_canvas = GetComponentInParent<Canvas>();
        ui_cam = ui_canvas.worldCamera;
        rectBack = ui_canvas.GetComponent<RectTransform>();
        rectFront = this.gameObject.GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if(targetTr != null)
        {
            var screenPos = Camera.main.WorldToScreenPoint(targetTr.position + offset);

            if (screenPos.z < 0.0f)
            {
                screenPos *= -1.0f;
            }

            var localPos = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectBack, screenPos,
                ui_cam, out localPos);

            rectFront.localPosition = localPos;
        }

        if (targetTr == null)
        {
            Destroy(this.gameObject);
        }

    }
}
