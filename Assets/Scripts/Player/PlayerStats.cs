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

    // Update is called once per frame
    void Update()
    {
        //TextHPbar////////////////////
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentHealth -= 10;
            hpBar.SetHealth(currentHealth);
            Debug.Log(currentHealth);
        }
        ///////////////////////////////
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        GameManager.instance.PlayerDied();
        base.Die();
    }
    private void FixedUpdate()
    {
        hpBar.SetHealth(currentHealth);
    }


}
