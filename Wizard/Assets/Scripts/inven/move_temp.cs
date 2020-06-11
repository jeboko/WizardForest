using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_temp : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void up()
    {
        player.transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
    }

    public void down()
    {
        player.transform.Translate(Vector3.back * 10.0f * Time.deltaTime);
    }

    public void left()
    {
        player.transform.Translate(Vector3.left * 10.0f * Time.deltaTime);
    }

    public void right()
    {
        player.transform.Translate(Vector3.right * 10.0f * Time.deltaTime);
    }
}
