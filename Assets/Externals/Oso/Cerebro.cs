using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerebro : MonoBehaviour
{
    private Ojos ojos;
    private Musculos musculos;

    private float retardo;

    private void Awake()
    {
        ojos = GetComponent<Ojos>();
        musculos = GetComponent<Musculos>();
        
    }

    private void Start()
    {
        retardo = 0.1f;
        StartCoroutine("Patrullar");
    }


    private IEnumerator Patrullar()
    {
        Debug.Log("Estoy Patrullando");
        bool found = false;

        Vector3 destination = new Vector3(Random.Range(-24.0f, 24.0f), 0, Random.Range(-24.0f, 24.0f));
        musculos.Move(destination);

        while (musculos.IsMoving())
        {
            if (ojos.HaSidoEncontrado())
            {
                found = true;
                break;
            }
            yield return new WaitForSeconds(retardo);
        }
        if (found)
        {
            StartCoroutine("Perseguir");
        } else
        {
            StartCoroutine("Buscar");
        }
    }

    private IEnumerator Buscar()
    {
        Debug.Log("Estoy Buscando");
        bool found = false;

        musculos.Rotate();
        while (musculos.IsRotating()) 
        {
            if (ojos.HaSidoEncontrado())
            {
                found = true;
                break;
            }
            yield return new WaitForSeconds(retardo);
        }

        musculos.Parar();

        if (found)
        {
            StartCoroutine("Perseguir");
        } else
        {
            StartCoroutine("Patrullar");
        }
        
    }

    private IEnumerator Perseguir()
    {
        Debug.Log("Estoy persiguiendo al jugador");
        bool canAttack = false;
        while (ojos.HaSidoEncontrado())
        {
            Vector3 posObjetivo = ojos.GetTarget();
            musculos.Move(posObjetivo);

            if (Vector3.Distance(transform.position, posObjetivo) < 3.0f)
            {
                canAttack = true;
                break;
            }

            yield return new WaitForSeconds(retardo);
        }

        musculos.Parar();

        if (canAttack)
        {
            StartCoroutine("Atacar");
        } else
        {
            StartCoroutine("Buscar");
        }
    }

    private IEnumerator Atacar()
    {
        Debug.Log("Me voy a pegar de ostias con el jugador");
        musculos.Atacar();
        yield return new WaitForSeconds(2.0f);
        StartCoroutine("Perseguir");
    }
}
