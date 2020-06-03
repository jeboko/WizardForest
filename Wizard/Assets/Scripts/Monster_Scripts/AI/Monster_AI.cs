using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_AI : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent agent;

    public float mob_speed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        //회전X
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }


    private void FixedUpdate()
    {
        // "Player"라는 태그를 가진 물체를 따라간다.
        agent.SetDestination(GameObject.FindWithTag("Player").transform.position);

        agent.speed = mob_speed;
    }
}
