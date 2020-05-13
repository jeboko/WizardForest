using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObj : MonoBehaviour
{
    public bool Build_state = false;

    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        render.material.color = new Color(2.0f, render.material.color.g, render.material.color.b, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Build_state)
        {
            render.material.color = new Color(1.0f, render.material.color.g, render.material.color.b, 1.0f);
        }

        //색 변경 체크용 입력
        if (Input.GetKeyDown(KeyCode.P))
        {
            Build_state = true;
        }

    }
}
