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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStats player = collision.collider.GetComponent<PlayerStats>();
        if(player != null)
        {
            player.TakeDamage(attackDamage);
        }
    }
    public override void Die()
    {
        GameProgression.instance.AddScore(score);
        SpawnItem();
        base.Die();
    }
    public void Remove()
    {
        base.Die();
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
