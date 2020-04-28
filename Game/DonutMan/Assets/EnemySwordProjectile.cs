using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordProjectile : MonoBehaviour
{
    public Vector2 direction = Vector2.zero;
    public int speed;


    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        if(direction == Vector2.left)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {

        }
        transform.Translate(direction * speed * Time.deltaTime);
    }


}
