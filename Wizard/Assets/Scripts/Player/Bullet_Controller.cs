using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float speed;
    public float destroy_time;
    float time;

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        Destroy(gameObject, destroy_time);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
