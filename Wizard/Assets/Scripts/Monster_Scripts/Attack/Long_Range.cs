using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Range : MonoBehaviour
{
    // 공격 오브젝트
    public GameObject attack_ball;

    private float time;
    private Nomal_Mob_Animator can_atk;
    private Vector3 position;
    void Start()
    {
        can_atk = gameObject.GetComponent<Nomal_Mob_Animator>();
        time = 0;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        position = new Vector3(gameObject.transform.position.x - 0.3f , gameObject.transform.position.y + 1, gameObject.transform.position.z + 0.1f);
        if (can_atk.long_atk && time > 1f)
        {
            Instantiate(attack_ball, position, Quaternion.identity);
            time = 0;
            can_atk.long_atk = false;
        }
    }
}
