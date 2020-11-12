using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public GameObject AreaActiva;
    AreaDeAccionamiento AreaDeActivacion;
    public Transform startMarker;
    public Transform endMarker;
    private float startTime;
    public float speed;
    public float journeyLength = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        AreaDeActivacion = AreaActiva.GetComponent<AreaDeAccionamiento>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AreaDeActivacion.PlayerEnArea == true)
        {
            float distCovered = (Time.time - startTime) * speed;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered / journeyLength);
        }
    }


}
