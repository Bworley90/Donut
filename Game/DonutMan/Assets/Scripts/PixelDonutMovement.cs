using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PixelDonutMovement : MonoBehaviour
{
    /*private CharacterController cc;


    [Tooltip("Character Horizontal Speed")]
    public float horizontalSpeed = 5;

    private bool grounded = false;


    [Tooltip("Gravity applied to character after jump height is reached")]
    [SerializeField]
    private float gravity = -9.8f;


    bool isJumping = false; // Checking is jump got pressed
    
    [Tooltip("Speed at which the character moves upward")]
    [SerializeField]
    float jumpSpeedUpward = 5;

    [Tooltip("Height at which the character will start to feel gravity || In Seconds")]
    [SerializeField]
    float jumpHeight;

    public Vector3 movement;

    
    

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    private void Update()
    {
        cc.Move(movement);
        CheckForGround();
        Gravity();
        Jump();
        Movement();
    }

    private void CheckForGround()
    {
        Collider2D temp = Physics2D.OverlapBox(transform.position, Vector2.one * 1.1f, 0, LayerMask.NameToLayer("Collisions"));
        if(temp != null)
        {
            grounded = true;
            isJumping = false;
        }
        
    }

    private void Movement()
    {
        movement.x = 0;
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            movement.x = horizontalSpeed * Time.deltaTime;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            movement.x = -horizontalSpeed * Time.deltaTime;
        }
    }

    private void Gravity()
    {
        movement.y = 0;
        if (!grounded)
        {
            movement.y = -gravity * Time.deltaTime;
        }

    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            isJumping = true;
            StartCoroutine(JumpTimer());
        }
        if(isJumping)
        {
            movement.y = jumpSpeedUpward * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector2.one * 1.1f);
        
    }

    private IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(jumpHeight);
        print("here");
        isJumping = false;
        grounded = false;
    }

    */

    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private float oGravity = 20f;

    public Vector3 moveDirection = Vector3.zero;
    public Collider2D temp;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        oGravity = gravity;
    }

    void Update()
    {
        temp = Physics2D.OverlapBox(transform.position, Vector2.one * 1.1f, 0, LayerMask.NameToLayer("Collisions"));
        moveDirection.x = Input.GetAxisRaw("Horizontal") * speed;
        if(temp)
        {
          
            moveDirection.y = 0;
            gravity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
                print("Here");
            }
        }
        else if(!temp)
        {
            gravity = oGravity;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
