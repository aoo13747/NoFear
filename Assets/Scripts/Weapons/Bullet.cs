using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    private Rigidbody2D rb;

    public GameObject impactEffect;

    public bool explodeOnImpact = false;
    public bool explodeAfterTime = false;
    public float explosionRange;
    public float explosionDelayTime;
    private float explosionTime;

    public bool enemyBullet;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        if (enemyBullet)
        {
            //rb.velocity = transform.up * speed;
            //rb.AddTorque(10f, ForceMode2D.Impulse);
        }
        explosionTime = Time.time + explosionDelayTime;
        InvokeRepeating("DelayDestroyBullet",5f, 5f);
    }
    private void Update()
    {
        rb.velocity = transform.up * speed;
        if (!explodeAfterTime)
            return;
        if(Time.time >= explosionTime)
        {
            Explode(null);
            return;
        }        
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (explodeAfterTime)
            return;
        if(!enemyBullet)
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            if(enemy != null)
            {
                Explode(enemy);
            }
        }
        else
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            if(player != null)
            {
                Explode(player);
            }
        }
    }
    void Explode(Identity target)
    {
        if(target != null)
        {
            target.TakeDamage(damage);
        }
        if(explodeOnImpact && !enemyBullet)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(rb.position, explosionRange);
            foreach(Collider2D t in targets)
            {
                EnemyStats enemy = t.GetComponent<EnemyStats>();
                if(enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
                Bullet bullet = t.GetComponent<Bullet>();
                if(bullet != null && bullet != this)
                {
                    bullet.Remove();
                }
            }
        }
        Remove();
    }
    public void Remove()
    {
        //GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        //effect.transform.localScale = transform.localScale;
        //Destroy(effect, 2f);
        gameObject.SetActive(false);
    }
    void DelayDestroyBullet()
    {        
        gameObject.SetActive(false);
    }
}
