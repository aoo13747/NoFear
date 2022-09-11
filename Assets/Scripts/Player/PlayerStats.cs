using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Identity
{
    public HPBar hpBar;    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hpBar.SetMaxHealth(maxHealth);
    }   
    public override void Die(PoolObjectType type)
    {
        GameManager.instance.PlayerDied();
        base.Die(PoolObjectType.Player);
    }
    private void FixedUpdate()
    {
        hpBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die(PoolObjectType.Player);
        }
    }


}
