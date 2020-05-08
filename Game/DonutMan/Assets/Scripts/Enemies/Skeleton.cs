using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private Vector3 groundCheckLeft = new Vector3(1, .4f, 0);
    private Vector3 groundCheckLeftOffset = new Vector3(-1.01f, -.7f, 0);
    private Vector3 groundCheckRight = new Vector3(1, .4f, 0);
    private Vector3 groundCheckRightOffset = new Vector3(1.01f, -.7f, 0);
    private Vector2 velocity = Vector2.right;
    private bool edgeReached = false;

    public GameObject deathParticleSystem;


    [SerializeField]
    private bool showGizmos = false;

    [SerializeField]
    private int spottingDistance = 4;

    public GameObject attackProjectile;




    private void Update()
    {
        CheckForGround();
        Death();
    }

    private void CheckForGround()

    {
        if(!edgeReached)
        {
            Collider2D rightCheck = Physics2D.OverlapBox(transform.position + groundCheckRightOffset, groundCheckRight, 0);
            Collider2D leftCheck = Physics2D.OverlapBox(transform.position + groundCheckLeftOffset, groundCheckLeft, 0);

            if (rightCheck == null && leftCheck != null) // Found Right Edge
            {
                StartCoroutine(IEEdgeReached(Vector2.left));
            }
            else if (leftCheck == null && rightCheck != null) // Found Left edge
            {
                StartCoroutine(IEEdgeReached(Vector2.right));
            }
            transform.Translate(velocity * speed * Time.deltaTime);
            GetComponent<Animator>().SetFloat("velocityX", velocity.x);
        }
        
    }

  


    private void Death()
    {
        if(health <= 0)
        {
            Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if(showGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + groundCheckLeftOffset, groundCheckLeft);
            Gizmos.DrawWireCube(transform.position + groundCheckRightOffset, groundCheckRight);
        }
        
    }

    IEnumerator IEEdgeReached(Vector2 nextDirection)
    {
        edgeReached = true;
        velocity = Vector2.zero;
        yield return new WaitForSeconds(.5f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector2.Distance(transform.position, player.transform.position) < spottingDistance)
        {
            GetComponent<Animator>().SetTrigger("attack");
            GameObject sword = Instantiate(attackProjectile, transform.position, Quaternion.identity);
            sword.GetComponent<EnemySwordProjectile>().direction = Vector2.left;

        }
        yield return new WaitForSeconds(1);
        velocity = nextDirection;
        edgeReached = false;
        transform.Translate(velocity * speed * Time.deltaTime);
    }
}
