using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloSistema : MonoBehaviour
{
    public bool llegoDestino = false;

    public Transform Colocar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (llegoDestino == true)
        {
            transform.position = Colocar.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("llegada"))
        {
            llegoDestino = true;
        }
    }
}
