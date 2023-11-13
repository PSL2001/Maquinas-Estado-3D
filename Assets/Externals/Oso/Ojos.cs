using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojos : MonoBehaviour
{
    private GameObject[] retinas;
    private RaycastHit hit;
    private Vector3 destination;
    private bool hasFound;

    private void Awake()
    {
        retinas = new GameObject[11];
        retinas[0] = transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        retinas[1] = transform.GetChild(0).transform.GetChild(1).transform.gameObject;
        retinas[2] = transform.GetChild(0).transform.GetChild(2).transform.gameObject;
        retinas[3] = transform.GetChild(0).transform.GetChild(3).transform.gameObject;
        retinas[4] = transform.GetChild(0).transform.GetChild(4).transform.gameObject;
        retinas[5] = transform.GetChild(0).transform.GetChild(5).transform.gameObject;
        retinas[6] = transform.GetChild(0).transform.GetChild(6).transform.gameObject;
        retinas[7] = transform.GetChild(0).transform.GetChild(7).transform.gameObject;
        retinas[8] = transform.GetChild(0).transform.GetChild(8).transform.gameObject;
        retinas[9] = transform.GetChild(0).transform.GetChild(9).transform.gameObject;
        retinas[10] = transform.GetChild(0).transform.GetChild(10).transform.gameObject;
    }

    

    // Update is called once per frame
    void Update()
    {
        hasFound = false;
        for (int i = 0; i < retinas.Length; i++)
        {
            if (Physics.Raycast(retinas[i].transform.position, retinas[i].transform.forward, out hit, 20))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    hasFound = true;
                    destination = hit.point;
                    Debug.DrawRay(retinas[i].transform.position, retinas[i].transform.forward * hit.distance, Color.red);
                }
                else
                {
                    Debug.DrawRay(retinas[i].transform.position, retinas[i].transform.forward * hit.distance, Color.white);
                }
            }
            else
            {
                Debug.DrawRay(retinas[i].transform.position, retinas[i].transform.forward * 20, Color.white);
            }
        }
    }

    public bool HaSidoEncontrado()
    {
        return hasFound;
    }

    public Vector3 GetTarget()
    {
        return destination;
    }
}
