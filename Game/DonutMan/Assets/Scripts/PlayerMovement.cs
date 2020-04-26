using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMovement : MonoBehaviour
{

    
    private Vector3 velocity;
    private Rigidbody2D rb;
    private Animator anim;


    [Header("Movement")]
    [Tooltip("Max Speed player can go")]
    [SerializeField]
    private float maxSpeed;

    [Tooltip("Jumpheight for player")]
    [SerializeField]
    private float jumpHeight = 5;


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

    [SerializeField]
    private GameObject flourBag;
    [SerializeField]
    private byte flourBagSpeed;

    private enum PlayerState
    {
        facedLeft,
        facedRight
    }

    private PlayerState ps;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ps = PlayerState.facedRight;
    }

    private void Update()
    {
        
        HorizontalMovement();
        Jump();
        MeleeAttack();
    }

    private void HorizontalMovement()
    {
        RaycastHit2D temp = Physics2D.Raycast(transform.position - new Vector3(0, 1.5f, 0), Vector3.left, 1.5f, 1 << LayerMask.NameToLayer("Collision"));
        RaycastHit2D temp2 = Physics2D.Raycast(transform.position - new Vector3(0, 1.5f, 0), Vector3.right, .3f, 1 << LayerMask.NameToLayer("Collision"));
        velocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") > 0 && !temp2) //Moving Right
        {
            velocity.x = 1;
            ps = PlayerState.facedRight;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && !temp)//Moving Left
        {
            velocity.x = -1;
            ps = PlayerState.facedLeft;
        }

        anim.SetFloat("velocityX", velocity.x);
        transform.Translate((Vector3)velocity * maxSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        temp = Physics2D.OverlapBox(groundCheckPlacement + transform.position, groundCheckSize, 0, 1 << LayerMask.NameToLayer("Collision"));
        if(temp != null)
        {
            grounded = true;
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce((Vector2)transform.position + Vector2.up * jumpHeight);
                anim.SetTrigger("jumped");
                
            }
        }
        else
        {
            anim.SetTrigger("landed");
        }
        anim.SetFloat("velocityY", velocity.y);
    }

    private void MeleeAttack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("melee");
            GameObject bag = Instantiate(flourBag, transform.position, flourBag.transform.rotation);
            if (ps == PlayerState.facedRight)
            {
                bag.GetComponent<FlourBag>().direction = Vector2.up;
                bag.GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                bag.GetComponent<FlourBag>().direction = Vector2.down;
                
            }
            
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
