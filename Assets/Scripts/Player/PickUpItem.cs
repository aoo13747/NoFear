using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private PlayerStats health;
    public AudioClip getItemSound;

    private void Start()
    {
        health = GetComponent<PlayerStats>();        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Potion
        if (health.currentHealth < health.maxHealth)
        {
            if (collision.CompareTag("PotionS"))
            {
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                health.currentHealth += 10;
                Destroy(collision.gameObject);
            }
            if (collision.CompareTag("PotionM"))
            {
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                health.currentHealth += 30;
                Destroy(collision.gameObject);
            }
            if (health.currentHealth > health.maxHealth)
                health.currentHealth = health.maxHealth;
        }
        else
        {
            return;
        }
        #endregion
        #region AmmoBox
        //if(weapons[].currentAmmo < weapons[].maxAmmo)
        {

        }
        #endregion
    }
}
