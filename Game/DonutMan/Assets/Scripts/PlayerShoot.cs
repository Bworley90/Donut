using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    private bool readyToFire = true;
    public float timeBetweenShots;

    private void Update()
    {
        if(Input.GetButton("Fire1") && readyToFire)
        {
            readyToFire = false;
            GetComponent<Animator>().SetTrigger("attack");
            StartCoroutine(IEShootCooldown());
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator IEShootCooldown()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        readyToFire = true;
    }

}
