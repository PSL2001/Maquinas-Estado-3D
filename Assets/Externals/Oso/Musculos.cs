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
    private bool isRotating;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        moving = false;
    }

    public bool IsMoving()
    {
        return moving;
    }

    public bool IsRotating()
    {
        return isRotating;
    }

    private IEnumerator GoToDestination()
    {
        moving = true;
        agent.SetDestination(this.destination);

        while (Vector3.Distance(this.transform.position, this.destination) > 2.0f)
        {
            yield return new WaitForEndOfFrame();
            
        }

        moving = false;
        //agent.ResetPath();
        agent.SetDestination(this.transform.position);
        

    }

    public void Move(Vector3 destino)
    {
        this.destination = destino;
        StartCoroutine("GoToDestination");
        
    }

    public void Rotate()
    {
        StartCoroutine("DoArotation");
    }

    public void Atacar()
    {
        animator.SetTrigger("Ataque");
    }

    public void Parar()
    {
        agent.SetDestination(this.transform.position);
        moving = false;
        isRotating = false;
    }

    private IEnumerator DoArotation()
    {
        isRotating = true;
        int rotation = 0;

        while (rotation < 360 && isRotating == true)
        {
            rotation++;
            transform.Rotate(Vector3.up, 1);
            yield return new WaitForEndOfFrame();
        }

        isRotating = false;
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

       
    }
}
