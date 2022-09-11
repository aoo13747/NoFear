using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeStatus : MonoBehaviour
{
    public GameObject upgradeUI;

    private PlayerStats health;
    private PlayerController speed;
    private Bullet damage;

    public int hpUp;
    public int spdUp;
    public int dmgUp;

    private bool isUpgrade;

    private void Start()
    {
        health = GetComponent<PlayerStats>();
        speed = GetComponent<PlayerController>();
        damage = GetComponent<Bullet>();

        isUpgrade = false;
    }
 
    void Update()
    {
        if(GameProgression.currentWave % 5 == 0)
        {
            upgradeUI.SetActive(true);
        }
    }

    public void onUpgrade()
    {
        if(isUpgrade == true)
        {
            upgradeUI.SetActive(false);
        }
    }
    
    public void healthPlus()
    {
        health.maxHealth += hpUp;
        isUpgrade = true;
    }

    public void speedPlus()
    {
        speed.startMoveSpeed += spdUp;
        isUpgrade = true;
    }

    public void damagePlus()
    {
        damage.damage += dmgUp;
        isUpgrade = true;
    }
}
