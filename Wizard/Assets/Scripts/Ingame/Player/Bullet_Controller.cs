using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public int bullet_num;
    public GameObject hit;
    public GameObject OBJ;
    public GameObject light;

    public float speed;
    public float damage;
    public float start_time; //생성 후 움직이는 시간
    public float destroy_time; //안 부딧히고 디스트로이 되는 시간
    public float hit_time; //부딧히고 디스트로이 되는 시간
    public float light_dec;
    public float boom_radius;

    bool ishit;
    public bool isskill;
    public bool isboom; //콜라이더가 커졌다가 줄어들때
    public bool boom_dec; //콜라이더가 줄어들 때
    public bool islight;
    public bool NO_HIT;
    float time;

    void FixedUpdate()
    {
        if (isskill && ishit == false)
        {
            time += Time.deltaTime;
            if (time > start_time)
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

        if (boom_dec && ishit)
        {
            gameObject.GetComponent<SphereCollider>().radius -= 0.1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "item" && other.gameObject.tag != "Range" && other.gameObject.tag != "Bullet")
        {
            if(NO_HIT == false)
            {
                Destroy(gameObject, hit_time);
                Hit();
            }
        }

        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Mob_controller>().Hp -= damage;
            if (bullet_num == 4)
            {
                Vector3 knockback_way;
                knockback_way = (transform.position - other.gameObject.transform.position);
                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(knockback_way.x, 0, knockback_way.z) * 6f * -1f;
            }
        }
    }

    void Hit()
    {
        OBJ.SetActive(false);
        ishit = true;
        hit.SetActive(true);
        if (islight)
        {
            light.SetActive(true);
        }

        if (isboom)
        {
            gameObject.GetComponent<SphereCollider>().radius = boom_radius;
        }
        else
        {
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
