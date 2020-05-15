using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public GameObject hit;
    public GameObject OBJ;
    public GameObject light;

    public float speed;
    public float start_time;
    public float destroy_time;
    public float hit_time;
    public float light_dec;

    bool ishit;
    public bool isskill;
    public bool islight;
    float time;

    void FixedUpdate()
    {
        if (isskill && ishit == false)
        {
            time += Time.deltaTime;
            if(time > start_time)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
                Destroy(gameObject, destroy_time);
            }
        }
        else if(ishit == false)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Destroy(gameObject, destroy_time);
        }
        else
        {
            if(islight)
                light.GetComponent<Light>().intensity -= light_dec;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit();
        Destroy(gameObject,hit_time);
    }

    void Hit()
    {
        OBJ.SetActive(false);
        GetComponent<SphereCollider>().enabled = false;
        ishit = true;
        hit.SetActive(true);
        if (islight)
            light.SetActive(true);
    }
}
