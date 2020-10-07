using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MessageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Message;
    public Transform SpawnerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnMessage();
        }
    }

    private void SpawnMessage()
    {
        GameObject Mes = Instantiate(Message, SpawnerPos.position, Quaternion.identity);
    }
}
