using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    private Transform player;
    public Vector3 offsetFromPlayer;
    public int timeBetweenSpawn = 5;
    public bool enable = false;

    public GameObject bat;
    private bool readyToSpawn = true;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = player.position + offsetFromPlayer;
        if(readyToSpawn && enable)
        {
            StartCoroutine(SpawnBat());
        }
    }

    private IEnumerator SpawnBat()
    {
        readyToSpawn = false;
        Instantiate(bat, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenSpawn);
        readyToSpawn = true;
    }




}
