using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerebro : MonoBehaviour
{
    private Ojos ojos;
    private Musculos musculos;

    private void Awake()
    {
        ojos = GetComponent<Ojos>();
        musculos = GetComponent<Musculos>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (ojos.HaSidoEncontrado())
        {
            musculos.Move(ojos.GetTarget());
        }   
    }
}
