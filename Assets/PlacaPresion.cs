using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{
    bool isclosed = false;

    public float x;

    public float y;

    public float z;

    public GameObject placa;

    public GameObject Puerta;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isclosed)
        {
            Vector3 Arriba =placa.transform.position = new Vector3(-7.426799f, 80.39f, 30.9f);

            rb.MovePosition(Arriba);
        }

        else if (isclosed)
        {
            Vector3 Abajo =placa.transform.position = new Vector3(-7.426799f, 80.03f, 30.9f);

            rb.MovePosition(Abajo);
        }
    }

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
}

// -7.426799 80.39 30.9 ,    80.03
