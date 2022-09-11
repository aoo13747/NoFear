using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats player = collision.GetComponent<PlayerStats>();
        if (player != null)
        {
            Damage(player);
        }
    }
    void Damage(Identity target)
    {
        if (target != null)
        {
            target.TakeDamage(damage);
        }
        Remove();
    }
    void Remove()
    {
        Destroy(gameObject);
    }
}
