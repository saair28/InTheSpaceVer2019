using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public bool estaAgarrado = false;

    public Transform manos;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        estaAgarrado = Player.instance.loToma;

        if (estaAgarrado == true)
        {
            EstaCerca();
        }
        else
        {
            Sale();
        }

       
    }
    private void EstaCerca()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = manos.position;
        this.transform.parent = GameObject.Find("Agarrar").transform;
    }

     void Sale()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
