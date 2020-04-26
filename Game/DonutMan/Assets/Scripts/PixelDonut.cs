using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDonut : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalMovement();
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
    }



}
