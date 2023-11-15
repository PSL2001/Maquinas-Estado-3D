using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    int vida;
    void Start()
    {
        vida = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Zarpa"))
        {
            vida--;

            if (vida == 3)
            {
                this.GetComponent<Renderer>().material.color = Color.blue;
            }

            if (vida == 2)
            {
                this.GetComponent<Renderer>().material.color = Color.yellow;
            }

            if (vida == 1)
            {
                this.GetComponent<Renderer>().material.color = Color.red;
            }

            if (vida == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
