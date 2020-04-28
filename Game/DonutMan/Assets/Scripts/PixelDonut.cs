using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDonut : MonoBehaviour
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


    
    public Vector2 offset = new Vector2(5, 5);
    public Vector2 size = new Vector2(5, 5);
    public bool showGroundedBox = true;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HorizontalMovement();
        Jump();
    }


    private void HorizontalMovement()
    {
        direction = Vector2.zero;
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = Vector2.right;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = Vector2.left;
        }
        transform.Translate((Vector3)direction * speed * Time.deltaTime);
        anim.SetFloat("velocityX", direction.x);
    }

    private void Jump()
    {
        Collider2D grounded = Physics2D.OverlapBox((Vector2)transform.position + offset, size, 0f);
        if(grounded != null)
        {
            doubleJumpReady = false;
            jumpReady = true;      
        }
        if(jumpReady)
        {
            
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.position * Vector2.up * jumpHeight, ForceMode2D.Impulse);
                jumpReady = false;
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
        }
        
    }

    private IEnumerator DoubleJump()
    {
        yield return new WaitForSeconds(.1f);
        doubleJumpReady = true;
    }

}
