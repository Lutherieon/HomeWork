using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMover : MonoBehaviour
{
    [SerializeField] float speed = .1f;
    Vector3 startPos;
    float repeatPos;
    void Start()
    {
        repeatPos = GetComponent<BoxCollider>().size.z / 2;
        startPos = transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - 50)
        {
            transform.position = startPos;
        }
            Mover();
    }




    void Mover()
    {
        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime, Space.World);
    }
}
