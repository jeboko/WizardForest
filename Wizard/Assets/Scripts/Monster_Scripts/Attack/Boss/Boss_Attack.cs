using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    public GameObject bite_atk;
    public GameObject fire_ball;

    public GameObject fire_ball_pos;

    private Boss_Monster_Animation ani_atk;
    private float time;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        ani_atk = gameObject.GetComponent<Boss_Monster_Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        position = fire_ball_pos.transform.position;
        if (ani_atk.fireball_atk && time > 1f)
        {
            Instantiate(fire_ball, position, Quaternion.identity);
            time = 0;
            ani_atk.fireball_atk = false;
        }

        if (ani_atk.bite_atk)
        {
            bite_atk.SetActive(true);
        }

        if (!ani_atk.bite_atk)
        {
            bite_atk.SetActive(false);
        }
    }
}
