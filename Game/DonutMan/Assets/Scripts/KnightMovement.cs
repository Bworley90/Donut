﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    [HideInInspector]
    public Vector2 direction = Vector2.zero;


    [Tooltip("Speed of the player left and right")]
    public float speed = 5;
    private float jumpHeight = 50;
    public int jumpSpeed = 7;
    [SerializeField]
    private bool jumpReady = false;
    private bool doubleJumpReady = false;

    public Vector3 rightOffset;
    public Vector3 rightSize;
    public Vector3 leftSize;
    public Vector3 leftOffset;
    


    
    public Vector2 offset = new Vector2(5, 5);
    public Vector2 size = new Vector2(5, 5);
    public bool showGroundedBox = true;

    public enum FacingDirection
    {
        right,
        left
    }
    public FacingDirection facingDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingDirection = FacingDirection.right;
    }

    private void Update()
    {
        HorizontalMovement();
        Jump();
    }


    private void HorizontalMovement()
    {
        Collider2D rightbox = Physics2D.OverlapBox(transform.position + rightOffset, rightSize, 0f);
        Collider2D leftbox = Physics2D.OverlapBox(transform.position + leftOffset, leftSize, 0f);
        direction = Vector2.zero;
        if (Input.GetAxisRaw("Horizontal") > 0 && rightbox == null)//This causes stutter movement when firing. 
        {
            direction = Vector2.right;
            facingDirection = FacingDirection.right;

        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && leftbox == null)
        {
            direction = Vector2.left;
            facingDirection = FacingDirection.left;
        }
        transform.Translate((Vector3)direction * speed * Time.deltaTime);
        anim.SetFloat("velocityX", direction.x);
    }

    private void Jump()
    {
        Collider2D grounded = Physics2D.OverlapBox((Vector2)transform.position + offset, size, 0f);
        if (grounded != null)
        {
            if(grounded.gameObject.CompareTag("Collision"))
            {
                doubleJumpReady = false;
                jumpReady = true;
                Debug.Log("Here");
            }
                
        }
        if(jumpReady)
        {
            
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.position * Vector2.up * jumpHeight, ForceMode2D.Impulse);
                StartCoroutine(DoubleJump());
            }
        }
        if (doubleJumpReady)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.position * Vector2.up * jumpHeight, ForceMode2D.Impulse);
                doubleJumpReady = false;
            }
        }
        if(rb.velocity.y > jumpSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        if(showGroundedBox)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube((Vector2)transform.position + offset, size);
            Gizmos.DrawCube(transform.position + rightOffset, rightSize);
            Gizmos.DrawCube(transform.position + leftOffset, leftSize);
        }
        
    }

    private IEnumerator DoubleJump()
    {
        yield return new WaitForSeconds(.1f);
        jumpReady = false;
        doubleJumpReady = true;
    }

}
