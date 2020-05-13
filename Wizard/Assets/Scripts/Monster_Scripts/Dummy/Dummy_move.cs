using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_move : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public float rotaespeed;

    private float HorizontalMove;
    private float VerticallMove;
    private bool isRun;
    private bool isPickup;

    public float Hp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my_Translation();
    }

    void my_Translation()
    {
        HorizontalMove = Input.GetAxis("Horizontal");
        VerticallMove = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(HorizontalMove, 0, VerticallMove) * runspeed * Time.deltaTime);
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotaespeed);
            isRun = true;
        }
        else
        {
            isRun = false;
            transform.Translate(new Vector3(HorizontalMove, 0, VerticallMove) * speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotaespeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
