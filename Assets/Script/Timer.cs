using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float tiempo;

    public Text VerTiempo;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        float t = -Time.time - tiempo;

        string Minutos = ((int)t / 60).ToString();

        string Segundos = (t % 60).ToString("f0");

        VerTiempo.text = Minutos + ":" + Segundos;
    }
}
