using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    [SerializeField] Image CircleImg;
    //[SerializeField] Text txtProgress;

    [SerializeField] [Range(0, 1)] float progress = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            progress = progress + 0.001f;
            CircleImg.fillAmount = progress;
            
        }
    }
}
