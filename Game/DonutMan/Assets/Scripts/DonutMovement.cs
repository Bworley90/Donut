using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]


public class DonutMovement : MonoBehaviour
{
    #region Private Variables

    private Rigidbody2D rb;
    private Animator anim;

    #endregion

    #region Serializable Variables
    [Tooltip("Speed of the Character")]
    [SerializeField]
    private byte speed;

    [Tooltip("Max Speed of Character")]
    [SerializeField]
    private byte maxSpeed;

    [Tooltip("Jump Height")]
    [SerializeField]
    private byte jumpHeight;

    #endregion

    #region MonoBehavior Callbacks

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
        Animations();
        Jump();
    }

    #endregion

    #region Private Methods

    private void Movement()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.MovePosition((Vector2)transform.position + Vector2.right * speed * Time.deltaTime);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.MovePosition((Vector2)transform.position + Vector2.left * speed * Time.deltaTime);
        }
    }

    private void Animations()
    {
        anim.SetFloat("xSpeed", Input.GetAxisRaw("Horizontal"));
    }


    private void Jump()
    {
        bool canJump;
        if(rb.velocity.y == 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        if(canJump && Input.GetButtonDown("Jump"))
        {
            rb.AddForce((Vector2)transform.position + Vector2.up * jumpHeight);
        }
    }

    #endregion



}
