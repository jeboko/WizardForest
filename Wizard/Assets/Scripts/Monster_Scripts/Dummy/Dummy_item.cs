using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_item : MonoBehaviour
{
    public float power;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * power);
    }
}
