using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Inheritance")]
    Rigidbody rb;
    isGrounded isGrounded;

    [Header("Input")]
    float HorizontalInput;
    float VerticalInput;

    [Header("MoveValue")]
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpSpeed = 1.0f;
    [SerializeField] float fallMultiplier = 2.5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = GetComponent<isGrounded>();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        BetterJump();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.checkGrounded)
        { 
            Jumping();
        }

        if(transform.position.z > 20)
        {
            Time.timeScale = 0f;
        }
        
    }

    void FixedUpdate()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        Vector3 dir = new (HorizontalInput, 0,VerticalInput);
        Move(dir);
    }


    void Move(Vector3 dir)
    {
        rb.velocity = new Vector3(dir.x * speed * Time.deltaTime, rb.velocity.y, VerticalInput * speed * Time.deltaTime);
    }

    void Jumping()
    {
        rb.velocity = new Vector3(rb.velocity.x, 1, rb.velocity.z);
        Vector3 dirY = new(0, 1, 0);
        rb.velocity += dirY * jumpSpeed ;
    }


    void BetterJump()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }



}
