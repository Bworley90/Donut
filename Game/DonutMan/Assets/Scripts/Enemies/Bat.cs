using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    public ParticleSystem deathPs;
    private Vector3 axis;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        Destroy(gameObject, 10);
        axis = transform.up;  // May or may not be the axis you want

    }

    void Update()
    {
        pos += Vector3.left * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        Death();
    }

    private void Death()
    {
        if(health <= 0)
        {
            Instantiate(deathPs, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
