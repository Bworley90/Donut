using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float aggroDistance;
    public byte speed;
    public byte damageCooldown;
    private bool beingDamaged;



    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile") && !beingDamaged)
        {
            beingDamaged = true;
            //Damaged(GetComponent<Projectile>().damage);

        }
    }

    public void Damaged(int damage)
    {
        health -= damage;
    }

  

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        beingDamaged = false;
    }




}
