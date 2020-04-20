using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]


public class DonutMovement : MonoBehaviour
{
    #region Private Variables

    private Rigidbody2D rb;

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
    }

    private void FixedUpdate()
    {
        Movement();
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

    #endregion



}
