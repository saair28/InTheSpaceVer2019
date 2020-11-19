﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinaOxigeno : MonoBehaviour
{
    public GameObject Posicion;

    public GameObject target;

    public Transform Colocar;

    public bool loSujeta;

    //public PosicionOxigeno PosiOxi;

    //public static CabinaOxigeno instance;

    // Start is called before the first frame update
    void Start()
    {
        // instance = this ;

    }

    void Update()
    {
       // Player player = new Player();

        loSujeta = Player.instance.LoSujeta;

        if (Posicion != null && target == null && loSujeta != true)
        {
            if (loSujeta != true)
            {
                target = Posicion;
            }
            else { }
        }

        Mantener();

    }

    public void Mantener()
    {

        if (target != null && Posicion != null)
        {

            target.transform.SetParent(Colocar);

            target.transform.position = Colocar.position;

            target.GetComponent<Rigidbody>().useGravity = false;

            target.GetComponent<Rigidbody>().isKinematic = true;
        }

        else
        {

        }
    }

    public bool PreguntarLibre()
    {
        if (Posicion != null)
        {
            return false;
        }

        else
        {
            return true;
        }
    }
}
