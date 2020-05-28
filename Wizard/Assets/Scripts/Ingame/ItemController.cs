using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int item_num;
    public GameObject obj;
    public GameObject hit;
    public bool ishit;
    public float destroy_time; //충돌 후 부셔지는 시간


    public void Hit_Player()
    {
        if (ishit)
        {
            GetComponent<SphereCollider>().enabled = false;
            obj.SetActive(false);
            hit.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject, destroy_time);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
