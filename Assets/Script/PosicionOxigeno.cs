using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionOxigeno : MonoBehaviour
{
    public bool Sujetar = true;

    public static PosicionOxigeno instance;

    public bool Entrar = false;

    public CabinaOxigeno cabina;

    public void Start()
    {
        instance = this;
    }

    private void Update()
    {
        cabina = CabinaOxigeno.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ponlo")
        {
            cabina.GetComponent<CabinaOxigeno>().Posicion = this.gameObject;

            Entrar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ponlo")
        {

            cabina.GetComponent<CabinaOxigeno>().Posicion = null;

            Entrar = false;
        }
    }
}
