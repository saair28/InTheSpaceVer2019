using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> cb59a8c97c01b9bb729ed015fbdf285221475c5f

public class Timer : MonoBehaviour
{
    public float tiempo;

    public Text VerTiempo;

<<<<<<< HEAD
    public float PonerTiempo;

    public float T;

    // Start is called before the first frame update
    void Start()
    {
        PonerTiempo = tiempo;
=======
    // Start is called before the first frame update
    void Start()
    {
     
>>>>>>> cb59a8c97c01b9bb729ed015fbdf285221475c5f
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        T -= Time.deltaTime;

        float t = T - tiempo;

        if (t >= 1)
        {

            string Minutos = ((int)t / 60).ToString();

            string Segundos = (t % 60).ToString("f0");

            VerTiempo.text = Minutos + ":" + Segundos;
        }

        else if (t <= 0)
        {
            T = 0;

            tiempo = PonerTiempo;

            Escena();
        }
    }

    public void Escena()
    {
        SceneManager.LoadScene("Derrota");
    }
}

=======
        float t = -Time.time - tiempo;

        string Minutos = ((int)t / 60).ToString();

        string Segundos = (t % 60).ToString("f0");

        VerTiempo.text = Minutos + ":" + Segundos;
    }
}
>>>>>>> cb59a8c97c01b9bb729ed015fbdf285221475c5f
