using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinaOxigeno : MonoBehaviour
{
    public GameObject Posicion;

    public GameObject target;

    public Transform Colocar;

    public PosicionOxigeno PosiOxi;

    public static CabinaOxigeno instance;

    // Start is called before the first frame update
    void Start()
    {
       instance = this ;
    }

    // Update is called once per frame
    void Update()
    {
        PosiOxi = PosicionOxigeno.instance;

        if (Posicion != null && PosiOxi.GetComponent<PosicionOxigeno>().Sujetar == true && target == null)
        {
            target = Posicion;

            target.GetComponent<PosicionOxigeno>().Sujetar = false;

        }

        else if (target != null && PosiOxi.GetComponent<PosicionOxigeno>().Sujetar == false && Posicion != null)
        {

            target.transform.SetParent(Colocar);

            target.transform.position = Colocar.position;

            target.GetComponent<Rigidbody>().useGravity = false;

            target.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
