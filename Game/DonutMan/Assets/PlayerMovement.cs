﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMovement : MonoBehaviour
{

    
    private Vector3 velocity;
    private Rigidbody2D rb;



    public float gravity;

    [Header("Movement")]
    [Tooltip("Max Speed player can go")]
    [SerializeField]
    private float maxSpeed;

    [Tooltip("Jumpheight for player")]
    [SerializeField]
    private float jumpHeight;


    #region GroundCheck Variables
    [Header("GroundCheck")]
    
    [Tooltip("Place to check for ground collisions")]
    [SerializeField]
    private Vector3 groundCheckPlacement;

    [Tooltip("Size of the collision check")]
    [SerializeField]
    private Vector3 groundCheckSize;

    [Tooltip("Show the collision box for grounding")]
    [SerializeField]
    private bool showGroundCheck;

    [Tooltip("Is the player grounded")]
    [SerializeField]
    private bool grounded;

    [SerializeField]
    Collider2D temp;

    #endregion






    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        HorizontalMovement();
        Jump();
    }

    private void HorizontalMovement()
    {
        velocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") > 0) //Moving Right
        {
            velocity.x = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)//Moving Left
        {
            velocity.x = -1;
        }


        transform.Translate((Vector3)velocity * maxSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        temp = Physics2D.OverlapBox(groundCheckPlacement + transform.position, groundCheckSize, 0, 1 << LayerMask.NameToLayer("Collision"));
        if(temp != null)//Grounded
        {
            grounded = true;
            Debug.Log("Here");
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce((Vector2)transform.position + Vector2.up * jumpHeight);
                Debug.Log("hit");
            }
        }
        if(temp == null)
        {
            print("Null");
        }
    }

    private void OnDrawGizmos()
    {
        
        if(showGroundCheck)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube((transform.position + groundCheckPlacement), groundCheckSize);
        }
    }

    
}