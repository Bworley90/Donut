using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : Enemy
{
    private bool dripped;
    public byte timeBetweenDrips;
    [SerializeField]
    public GameObject drip;

    private void Start()
    {
        speed = 0;
        health = 1;
        damageCooldown = 0;
    }

    private void Update()
    {
        if(!dripped)
        {
            dripped = true;
            StartCoroutine(Drip());
        }
    }


    private IEnumerator Drip()
    {
        
        Instantiate(drip, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenDrips);
        dripped = false;

    }


}
