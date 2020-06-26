using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawn : MonoBehaviour
{
    public GameObject Boss;
    Scene_Manager timer;

    private float boss_num;
    private float boss_time;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("GameManager").GetComponent<Scene_Manager>();
        boss_num = 0;
        boss_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.day_count % 3 == 0)
        {
            boss_time = timer.night_time / 2;
            if (!timer.is_day)
            {
                if (timer.time >= boss_time && boss_num == 0)
                {
                    Instantiate(Boss, gameObject.transform.position, Quaternion.identity);
                    boss_num++;
                }
            }

        }
        if (timer.is_day)
        {
            boss_num = 0;
        }
    }
}
