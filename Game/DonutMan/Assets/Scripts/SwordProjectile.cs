using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : Projectile
{
    public Sprite leftFacing;
    public Sprite rightFacing;
    private GameObject player;
    private enum Direction
    {
        left,
        right
    }

    private Direction direction;

    private void Update()
    {
        Movement();
    }


    private void Start()
    {
        Destroy(gameObject, lifeDuration);
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<KnightMovement>().facingDirection == KnightMovement.FacingDirection.right)
        {
            direction = Direction.right;
        }
        else if (player.GetComponent<KnightMovement>().facingDirection == KnightMovement.FacingDirection.left)
        {
            direction = Direction.left;
        }
    }
    private void Movement()
    {
        if(direction == Direction.right)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().sprite = rightFacing;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().sprite = leftFacing;
        }
        
    }

  
}
