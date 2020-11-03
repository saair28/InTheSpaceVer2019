using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cables : MonoBehaviour
{
    public bool message = false;
    public GameObject circle_Img;
    public GameObject circle;
    public GameObject my_circle;
    Circle my_circle_script;
    public GameObject circleFill;
    public bool prenderLuces;

    // Start is called before the first frame update
    void Start()
    {
        my_circle_script = my_circle.GetComponent<Circle>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivarCables();
        if(my_circle_script.desactivaCircle == true)
        {
            DesactivaCircle();
        }
        
        
        DeboPrenderLuces();
        
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            message = true;
            Debug.Log("activaCables");
        }
    }
    public void ActivarCables()
    {
        if (message == true)
        {
            circle.SetActive(true);
            circle_Img.SetActive(true);
        }
        else
        {
            circle.SetActive(false);
            circle_Img.SetActive(false);
        }
    }

    public void DesactivaCircle()
    {
        circleFill.SetActive(false);
        circle.SetActive(false);
        circle_Img.SetActive(false);
        my_circle_script.progress = 0;
        prenderLuces = true;
    }

    public bool DeboPrenderLuces()
    {
        if (prenderLuces == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
