using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject inven;
    private bool inven_state = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inven_state == false)
            {
                inven.SetActive(true);
                inven_state = true;
            }
            else if (inven_state == true)
            {
                inven.SetActive(false);
                inven_state = false;
            }
        }
    }
}

