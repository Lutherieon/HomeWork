using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObsticleMover : MonoBehaviour
{
    [SerializeField] float speed = 1f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
