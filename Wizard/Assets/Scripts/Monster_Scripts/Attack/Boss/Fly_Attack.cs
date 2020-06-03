using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Attack : MonoBehaviour
{
    public GameObject attack_ball;

    public GameObject fire_ball_pos;

    private float time;
    private Boss_Monster_Animation can_atk;
    private Vector3 position;
    void Start()
    {
        can_atk = gameObject.GetComponent<Boss_Monster_Animation>();
        time = 0;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        position = fire_ball_pos.transform.position;
        if (can_atk.fireball_sky && time > 1f)
        {
            Instantiate(attack_ball, position, Quaternion.identity);
            time = 0;
            can_atk.fireball_sky = false;
        }
    }
}
