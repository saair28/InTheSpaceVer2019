﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed = 1f;
    
    //JECTPACK

    public float JetpackFuerza = 3f;

    public bool Flotar = false;

    public float Combustible = 100f;

    public float CombustibleGastado = 20f;

    public float CombustibleRecarga = 20f;

    public float RetrasoRecarga = 2f;

    public float ActualComb;

    public bool TenerCombustible = true;

    public float timer = 0f;

    //

    Vector3 Velocity;

    public Slider FuelSlider;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ActualComb = Combustible;
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = Vector3.zero;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(h, 0f, v) * Speed * Time.deltaTime;

        rb.MovePosition(playerMovement + transform.position);

        FuelSlider.value = ActualComb / Combustible;

        Flotar = Input.GetMouseButton(1);

        if (ActualComb >= 0f)
        {
            if (Flotar && TenerCombustible)
            {
                rb.AddForce(Vector2.up * JetpackFuerza);

                ActualComb -= CombustibleGastado * Time.deltaTime;
            }
            else if (!Flotar && TenerCombustible)
            {
                Recarga();
            }
        }

        if (ActualComb <= 0)
        {
            TenerCombustible = false;

            ActualComb = 0;
        }

        if (!TenerCombustible)
        {
            timer += Time.deltaTime;

            if (timer >= RetrasoRecarga)
            {
                TenerCombustible = true;

                timer = 0;
            }
        }
    }

    public void Recarga()
    {
        if (ActualComb < Combustible)
        {
            ActualComb += CombustibleRecarga * Time.deltaTime;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Placa"))
        {

        }
    }

}
