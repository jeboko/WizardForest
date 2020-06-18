using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Near_Mob_Die : MonoBehaviour
{
    public GameObject dead_Effect;
    private Mob_controller controller;
    private bool isDie;
    public float effect_time;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        isDie = true;
        controller = gameObject.GetComponent<Mob_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.Hp <= 0 && isDie)
        {
            time += Time.deltaTime;
            if(time >= effect_time)
            {
                Instantiate(dead_Effect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z), Quaternion.identity);
                isDie = false;
            }
        }
    }
}
