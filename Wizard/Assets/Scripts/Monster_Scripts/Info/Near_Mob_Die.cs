using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Near_Mob_Die : MonoBehaviour
{
    public GameObject dead_Effect;
    private Mob_controller controller;
    private bool isDie;
    // Start is called before the first frame update
    void Start()
    {
        isDie = true;
        controller = gameObject.GetComponent<Mob_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.Hp <= 0 && isDie)
        {
            Instantiate(dead_Effect, gameObject.transform.position, Quaternion.identity);
            isDie = false;
        }
    }
}
