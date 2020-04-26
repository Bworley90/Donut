using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourBag : MonoBehaviour
{
    public float speed;
    public Vector2 direction;


    private void Update()
    {
        if (speed != 0)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
