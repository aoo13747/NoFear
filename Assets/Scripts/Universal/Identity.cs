using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identity : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public virtual void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
    
}
