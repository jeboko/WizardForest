using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawn : MonoBehaviour
{
    public GameObject Boss;

    private int boss_num;
    // Start is called before the first frame update
    void Start()
    {
        boss_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(boss_num == 0)
        {
            Instantiate(Boss, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            boss_num++;
        }
    }
}
