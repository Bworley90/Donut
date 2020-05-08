using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public bool hit = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            hit = true;
            other.GetComponent<Health>().health--;
            Destroy(gameObject);
        }
        else if(other.CompareTag("Collision"))
        {
            hit = true;
            Destroy(gameObject, .1f);
        }
    }
}
