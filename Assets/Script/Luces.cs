using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luces : MonoBehaviour
{
    Light miLuz;

    public float cronometro;

    public bool estaMalogrado;

    public GameObject Cable;

    // Start is called before the first frame update
    void Start()
    {
        miLuz = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        estaraRoto();

        malogrado();

    }

    public void malogrado()
    {

        cronometro += Time.deltaTime;

        if (estaMalogrado == false)
        {
            if (cronometro >= 2 && cronometro <= 3 || cronometro >= 4 && cronometro <= 5)
            {
                miLuz.intensity = Mathf.PingPong(2, 2);
            }
            else
            {
                miLuz.intensity = Mathf.PingPong(1, 2);
            }

        }

        else
        {
            cronometro = 0;

            miLuz.intensity = Mathf.PingPong(3, 20);
        }

        if (cronometro >= 5)
        {
            cronometro = 0;
        }
    }

    public void estaraRoto()
    {
        estaMalogrado = Cable.GetComponent<Cables>().prenderLuces;
    }
}
