﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public static Player2 instance;

    public float saltoFuerza = 5.0f;

    public bool salto = false;
    
    public bool LoSujeta;
    
    public GameObject Manos;

    public GameObject Agarra;

    public Transform ZoneInteraction;

    public bool loToma = false;
    
    public bool deteccionSuelo = false;

    //public Rigidbody rb;

    public Transform cam;

    public CharacterController controller;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
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
       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f *gravity);
            Debug.Log("JUMP");
        }





    }
    /*
    void PlayerSalto()
    {
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

    void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

    }
    */
}
