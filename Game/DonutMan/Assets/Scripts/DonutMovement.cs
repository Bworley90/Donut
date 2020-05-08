using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]


public class DonutMovement : MonoBehaviour
{
    #region Private Variables

    private CharacterController controller;
    private Animator anim;

    #endregion

    #region Serializable Variables
    [Tooltip("Speed of the Character")]
    [SerializeField]
    private byte speed = 5;
     /*
    [Tooltip("Max Speed of Character")]
    [SerializeField]
    private byte maxSpeed = 5;

    [Tooltip("Jump Height")]
    [SerializeField]
    private byte jumpHeight = 5;
    */

    #endregion

    #region MonoBehavior Callbacks

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
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
            controller.SimpleMove(Vector3.right * speed);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            controller.SimpleMove(Vector3.left * speed);
        }
    }

    private void Animations()
    {
        anim.SetFloat("xSpeed", Input.GetAxisRaw("Horizontal"));
    }


    private void Jump()
    {
       
    }

    #endregion



}
