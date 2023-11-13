using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Musculos : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 destination;
    private Animator animator;
    private bool moving;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        moving = false;
    }

    public void Move(Vector3 destino)
    {
        this.destination = destino;
        moving = true;
        agent.SetDestination(destino);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            animator.SetFloat("Velocidad", 1);
        }
        else
        {
            animator.SetFloat("Velocidad", 0);
        }

        if (Vector3.Distance(this.transform.position, this.destination) < 2.0f)
        {
            agent.ResetPath();

            moving = false;
        }
    }
}
