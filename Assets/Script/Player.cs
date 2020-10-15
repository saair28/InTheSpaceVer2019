using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed = 1f;

    public static Player instance;

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

    //SUJETAR

    public bool LoSujeta;

    public GameObject Manos;

    public GameObject Agarra;

    public Transform ZoneInteraction;

    Vector3 Velocity;

    public Slider FuelSlider;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ActualComb = Combustible;

        instance = this;
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

        Flotar = Input.GetKey(KeyCode.Space);

        if (Manos != null && Manos.GetComponent<Agarrar>().Sujetar == true && Agarra == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Agarra = Manos;

                Agarra.GetComponent<Agarrar>().Sujetar = false;

                Agarra.transform.SetParent(ZoneInteraction);

                Agarra.transform.position = ZoneInteraction.position;

                Agarra.GetComponent<Rigidbody>().useGravity = false;

                Agarra.GetComponent<Rigidbody>().isKinematic = true;

                LoSujeta = true;
            }
        }

        else if (Agarra != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Agarra.GetComponent<Agarrar>().Sujetar = true;

                Agarra.transform.SetParent(null);

                Agarra.GetComponent<Rigidbody>().useGravity = true;

                Agarra.GetComponent<Rigidbody>().isKinematic = false;

                Agarra = null;

                LoSujeta = false;
            }
        }

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
