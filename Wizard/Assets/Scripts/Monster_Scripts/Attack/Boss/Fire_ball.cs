using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_ball : MonoBehaviour
{
    Transform player;
    public float speed;
    Dummy_move player_hp;
    public float damage;


    private float time;

    public int num;
    Mob_Manager_Scripts controller;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        player_hp = GameObject.FindWithTag("Player").GetComponent<Dummy_move>();
        transform.LookAt(player);

        controller = GameObject.Find("Monster_Manager").GetComponent<Mob_Manager_Scripts>();
        damage = controller.deck[num - 1].Atk;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (time > 3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player_hp.Hp = player_hp.Hp - damage;
            Destroy(gameObject);
        }
    }
}
