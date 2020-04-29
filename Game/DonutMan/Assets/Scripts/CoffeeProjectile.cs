using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeProjectile : Projectile
{
    private void Update()
    {
        Movement();
    }

    private enum Direction
    {
        right, 
        left
    }

    private Direction direction;
    
    private void Start()
    {
        Destroy(gameObject, lifeDuration);
        SetDirection();
    }
    private void Movement()
    {
        if(direction == Direction.left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (direction == Direction.right)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void SetDirection()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = Direction.right;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = Direction.left;
        }
    }
}
