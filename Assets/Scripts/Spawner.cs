using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject gameObjectS;
    [SerializeField] int repeatRate = 2;
    [SerializeField] int timeDelay = 2;
    Vector3 spawnPos;
    void Start()
    {

        InvokeRepeating("Spawner_", timeDelay, repeatRate);
    }

    void Update()
    {
         spawnPos.x = Random.Range(10, 30);
    }

    void Spawner_() 
    {

        Instantiate(gameObjectS, new Vector3(spawnPos.x, transform.position.y, transform.position.z), Quaternion.identity);
        
    }
}
