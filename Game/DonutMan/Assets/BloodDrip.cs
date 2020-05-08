using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDrip : EnemyProjectile
{
    public GameObject bloodDripSplatter;
    private void Update()
    {
        if(hit)
        {
            Instantiate(bloodDripSplatter, transform.position, Quaternion.identity);
            hit = false;
        }
    }
}
