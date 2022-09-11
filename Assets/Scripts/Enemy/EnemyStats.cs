using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Identity
{
    public int attackDamage;
    public ItemDrop itemDrop;
    private float dropRadius = 0.5f;
    public int score = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnEnable()
    {
        currentHealth = maxHealth;
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStats player = collision.collider.GetComponent<PlayerStats>();
        if(player != null)
        {
            player.TakeDamage(attackDamage);
        }
    }*/
    public override void Die(PoolObjectType type)
    {               
        switch (objType)
        {
            default:               
                break;
            case 1:
                GameProgression.instance.AddScore(score);
                SpawnItem();
                base.Die(PoolObjectType.Slimey);
                break;
            case 2:
                GameProgression.instance.AddScore(score);
                SpawnItem();
                base.Die(PoolObjectType.Speedy);
                break;
            case 3:
                GameProgression.instance.AddScore(score);
                SpawnItem();
                base.Die(PoolObjectType.Tank);
                break;
            case 4:
                GameProgression.instance.AddScore(score);
                SpawnItem();
                base.Die(PoolObjectType.Boomer);
                break;
            case 5:
                GameProgression.instance.AddScore(score);
                SpawnItem();
                base.Die(PoolObjectType.Rangey);
                break;
            case 6:
                GameProgression.instance.AddScore(score);
                SpawnItem();
                base.Die(PoolObjectType.Summomner);
                break;
            case 7:
                GameProgression.instance.AddScore(score);
                SpawnItem();
                base.Die(PoolObjectType.Minion);
                break;

        }
    }
    public void Remove()
    {
        switch (objType)
        {
            default:
                break;
            case 1:                
                base.Die(PoolObjectType.Slimey);
                break;
            case 2:                
                base.Die(PoolObjectType.Speedy);
                break;
            case 3:
                base.Die(PoolObjectType.Tank);
                break;
            case 4:
                base.Die(PoolObjectType.Boomer);
                break;
            case 5:
                base.Die(PoolObjectType.Rangey);
                break;
            case 6:
                base.Die(PoolObjectType.Summomner);
                break;
            case 7:
                base.Die(PoolObjectType.Minion);
                break;

        }
    }
    void SpawnItem()
    {
        foreach(ItemType itemType in itemDrop.items)
        {
            if (Random.Range(0,100) <= itemType.spawnChance)
            {
                DropItem(itemType.ItemPrefab);
            }            
        }
    }
    void DropItem(GameObject itemPrefab)
    {
        Vector2 spawnPos = gameObject.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * dropRadius;
        Instantiate(itemPrefab, spawnPos, Quaternion.identity);
    }

}
