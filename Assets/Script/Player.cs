using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    public float MaxSpeed;

    public GameObject referencia;

    public static Player instance;

    public float saltoFuerza = 5.0f;

    public bool salto = false;

    


   
    //SUJETAR

    public bool LoSujeta;

    public GameObject Manos;

    public GameObject Agarra;

    public Transform ZoneInteraction;

    Vector3 Velocity;

    public bool deteccionSuelo = false;

    public bool loToma = false;

    // public Slider FuelSlider;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //ActualComb = Combustible;

        instance = this;
    }

    

    // Update is called once per frame
    void Update()
    {

        

        if (Manos != null && Manos.GetComponent<Agarrar>().Sujetar == true && Agarra == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Agarra = Manos;

                /* Agarra.GetComponent<Agarrar>().Sujetar = false;

                 Agarra.transform.parent =ZoneInteraction.transform;

                 Agarra.GetComponent<BoxCollider>().enabled = false;

                // this.transform.parent = ZoneInteraction.transform;

                // Agarra.transform.position = ZoneInteraction.position;

                 Agarra.GetComponent<Rigidbody>().useGravity = false;

                 //Agarra.GetComponent<Rigidbody>().isKinematic = true;

                 */
                loToma = true;

                LoSujeta = true;
            }
        }

        else if (Agarra != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Agarra.GetComponent<Agarrar>().Sujetar = true;

                /*  Agarra.transform.parent = null;

                 // this.transform.parent = null;

                  Agarra.GetComponent<BoxCollider>().enabled = true;

                  Agarra.GetComponent<Rigidbody>().useGravity = true;

                 // Agarra.GetComponent<Rigidbody>().isKinematic = false;
                 */
                Agarra = null;

                loToma = false;

                LoSujeta = false;
            }
        }

        

    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float MHorizontal = Input.GetAxis("Horizontal");
        float MVertical = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * MaxSpeed;
        }

        rb.AddForce(MVertical * referencia.transform.forward * speed);
        rb.AddForce(MHorizontal * referencia.transform.right * speed);

        salto = Input.GetKey(KeyCode.Space);

        Vector3 suelo = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, suelo, 3.07f))
        {
            deteccionSuelo = true;
        }
        else
        {
            deteccionSuelo = false;
        }

        if (salto && deteccionSuelo)
        {
            rb.AddForce(new Vector3(0, saltoFuerza, 0), ForceMode.Impulse);
        }
    }

    void PlayerMovement1()
    {
        
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0,  speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector3 playerMovement = new Vector3(h, 0f, v) * Speed * Time.deltaTime;
        //transform.Translate(playerMovement, Space.Self);

        salto = Input.GetKey(KeyCode.Space);

        Vector3 suelo = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, suelo, 3.07f))
        {
            deteccionSuelo = true;
        }
        else
        {
            deteccionSuelo = false;
        }

        if (salto && deteccionSuelo)
        {
            rb.AddForce(new Vector3(0, saltoFuerza, 0), ForceMode.Impulse);
        }
    }
}