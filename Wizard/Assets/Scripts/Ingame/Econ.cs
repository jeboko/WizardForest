using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Econ : MonoBehaviour
{
    public float HP;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            HP_DEC(other.gameObject.GetComponent<Bullet_Controller>().damage);
        }
    }

    void HP_DEC(float damege)
    {
        HP -= damege;
        if(HP <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
