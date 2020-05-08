using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    #region Variables

    [Tooltip("Sprite for full heart UI")]
    public Sprite fullHeart;

    [Tooltip("Sprite for empty heart UI")]
    public Sprite emptyHeart;

    [Tooltip("List of the hearts for the players health")]
    public Image[] healthCount;


    [Tooltip("Current Health of the player")]
    public int health = 3;

    [Tooltip("Max health of the player")]
    [SerializeField]
    private int maxHealth = 7;

    [Tooltip("Time between damage taken")]
    [SerializeField]
    private float damageCooldown = .25f;

    private bool damaged = false;

    #endregion



    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < healthCount.Length; i++)
        {
            if(i < health)
            {
                healthCount[i].sprite = fullHeart;
            }
            else
            {
                healthCount[i].sprite = emptyHeart;
            }

            if(i < maxHealth)
            {
                healthCount[i].enabled = true;
            }
            else
            {
                healthCount[i].enabled = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!damaged)
            {
                damaged = true;
                health--;
                StartCoroutine(IEDamageCooldown());
                StartCoroutine(IEFlashDamage());
            }
        }
    }

    private IEnumerator IEDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        damaged = false;
    }

    private IEnumerator IEFlashDamage()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;

    }



}
