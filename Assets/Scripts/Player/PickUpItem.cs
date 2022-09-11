using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private PlayerStats health;    
    private PlayerShooter playerShooter;
    public Weapons[] weapons;
    public AudioClip getItemSound;   

    private void Start()
    {
        health = GetComponent<PlayerStats>();       
        playerShooter = GetComponent<PlayerShooter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Potion
        if (health.currentHealth < health.maxHealth)
        {
            if (collision.gameObject.CompareTag("PotionS"))
            {
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                health.currentHealth += 10;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("PotionM"))
            {
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                health.currentHealth += 30;
                Destroy(collision.gameObject);
            }
            if (health.currentHealth > health.maxHealth)
            {
                health.currentHealth = health.maxHealth;
            }
            if (health.currentHealth == health.maxHealth)
            {
                return;
            }
        }          
        #endregion
        #region AmmoBox
        if (collision.gameObject.CompareTag("SMGammo"))
        {
            if (weapons[1].currentAmmo < weapons[1].maxAmmo)
            {
                weapons[1].currentAmmo += 90;
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                Destroy(collision.gameObject);
            }
            else if (weapons[1].currentAmmo > weapons[1].maxAmmo)
            {
                weapons[1].currentAmmo = weapons[1].maxAmmo;
            }
            else
                return;
              
        }
        if (collision.gameObject.CompareTag("Shotgunammo"))
        {            
            if (weapons[2].currentAmmo < weapons[2].maxAmmo)
            {
                weapons[2].currentAmmo += 6;
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                Destroy(collision.gameObject);
            }
            else if (weapons[2].currentAmmo > weapons[2].maxAmmo)
            {
                weapons[2].currentAmmo = weapons[2].maxAmmo;
            }
            else
                return;

        }
        if (collision.gameObject.CompareTag("Heavyammo"))
        {
           
            if (weapons[3].currentAmmo < weapons[3].maxAmmo)
            {
                weapons[3].currentAmmo += 20;
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                Destroy(collision.gameObject);
            }
            else if (weapons[3].currentAmmo > weapons[3].maxAmmo)
            {
                weapons[3].currentAmmo = weapons[3].maxAmmo;
            }
            else
                return;

        }
        if (collision.gameObject.CompareTag("Grenadeammo"))
        {            
            if (weapons[4].currentAmmo < weapons[4].maxAmmo)
            {
                weapons[4].currentAmmo += 3;
                AudioSource.PlayClipAtPoint(getItemSound, transform.position);
                Destroy(collision.gameObject);
            }
            else if (weapons[4].currentAmmo > weapons[4].maxAmmo)
            {
                weapons[4].currentAmmo = weapons[4].maxAmmo;
            }
            else
                return;
        }
        #endregion
    }   
}
