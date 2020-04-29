using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public byte speed;
    public float damageCooldown;
    private bool beingDamaged;



    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile") &&!beingDamaged)
        {
            beingDamaged = true;
            try
            {
                health -= other.GetComponent<Projectile>().damage;
            }
            catch
            {
                Debug.Log("Could not take damage, missing Projectile Damage component");
            }
            StartCoroutine(DamageCooldown());
            Destroy(other.gameObject);
            
        }
        else if(other.CompareTag("Projectile") && beingDamaged)
        {
            Destroy(other.gameObject);
        }
    }

   



    IEnumerator DamageCooldown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.05f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.05f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.05f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.05f);
        yield return new WaitForSeconds(damageCooldown);
        beingDamaged = false;
    }




}
