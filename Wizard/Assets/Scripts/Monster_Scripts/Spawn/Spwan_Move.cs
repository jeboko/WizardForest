using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan_Move : MonoBehaviour
{
    public float start_x;
    public float fin_x;
    public float start_z;
    public float fin_z;

    private float pos_x;
    private float pos_z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos_x = Random.Range(start_x, fin_x);
        pos_z = Random.Range(start_z, fin_z);
        
        gameObject.transform.SetPositionAndRotation(new Vector3(pos_x, 0f, pos_z), Quaternion.identity);
    }
}
