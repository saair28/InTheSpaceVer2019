using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{
    public bool ispressed = false;

    public float x;

    public float y;

    public float z;

    public float restarY;

    public GameObject placa;

    public GameObject Puerta;


    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        x = transform.position.x;

        y = transform.position.y;

        z = transform.position.z;
    }

    void Update()
    {
        if (!ispressed)
        {
            Vector3 Arriba = new Vector3(x, y, z);

            transform.position = Arriba;
        }

        else if (ispressed)
        {
            Vector3 Abajo = new Vector3(x, y - restarY, z);

            transform.position = Abajo;
        }
    }

    public void Presionar()
    {
        ispressed = true;
    }

    public void Soltar()
    {
        ispressed = false;
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isclosed = true;
        }

        if (collision.gameObject.CompareTag("Cubo"))
        {
            isclosed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isclosed = false;
    }
    */
}

// -7.426799 80.39 30.9 ,    80.03
