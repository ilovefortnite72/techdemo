using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float movespeed = 10;
    private float xAxis;
    private float JumpForce = 10;

    private bool isGrounded;
    [SerializeField]
    public Transform groundCheck;
    public float checkDistance = 0.2f;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        InputControls();
        Move();
        Jump();
        
    }

    private void InputControls()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

    }

    private void Move()
    {
        rb.velocity = new Vector2(xAxis * movespeed, rb.velocity.y);
        
    }

    public bool IsGrounded()
    {
        if (Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            print("Jump");
        }
    }
}
