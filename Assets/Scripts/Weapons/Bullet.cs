using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public int typeBullet;
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
        
        if (!explodeAfterTime)
            return;
        if (Time.time >= explosionTime)
        {
            Explode(null);
            return;
        }
    }
    private void OnEnable()
    {        
        switch(typeBullet)
        {
            default:
                StartCoroutine(DelayRemove(PoolObjectType.Pistol_Bullet));
                break;
            case 1:
                StartCoroutine(DelayRemove(PoolObjectType.SMG_Bullet));
                break;
            case 2:
                StartCoroutine(DelayRemove(PoolObjectType.ShotGun_Bullet));
                break;
            //case 4:
            //    StartCoroutine(DelayRemove(PoolObjectType.Granade));
            //    break;
            case 7:
                StartCoroutine(DelayRemove(PoolObjectType.RangeyBullet));
                break;
        }
        if(enemyBullet)
        {
            StartCoroutine(DelayRemove(PoolObjectType.RangeyBullet));
        }

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

        explosionTime = Time.time + explosionDelayTime;        

        if (!explodeAfterTime)
            return;
        if (Time.time >= explosionTime)
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
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
            foreach (Collider2D t in targets)
            {
                EnemyStats enemy = t.GetComponent<EnemyStats>();
                if(enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
                Bullet bullet = t.GetComponent<Bullet>();
                if(bullet != null && bullet != this)
                {                    
                    switch (typeBullet)
                    {
                        default:                            
                            break;
                        case 4:                            
                            DestroyBullet(PoolObjectType.Granade);
                            break;
                    }                  
                }
            }
        }
        switch (typeBullet)
        {
            default:
                DestroyBullet(PoolObjectType.Pistol_Bullet);
                break;
            case 1:
                DestroyBullet(PoolObjectType.SMG_Bullet);
                break;
            case 2:
                DestroyBullet(PoolObjectType.ShotGun_Bullet);
                break;
            case 4:
                DestroyBullet(PoolObjectType.Granade);
                break;
            case 7:
                DestroyBullet(PoolObjectType.RangeyBullet);
                break;
        }       
    }
    public void DestroyBullet(PoolObjectType type)
    {
        //GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        //effect.transform.localScale = transform.localScale;
        //Destroy(effect, 2f);
        ObjPoolManager.instance.CoolObject(gameObject, type);

    }
    public void Remove()
    {
        switch (typeBullet)
        {
            default:
                DestroyBullet(PoolObjectType.Pistol_Bullet);
                break;
            case 1:
                DestroyBullet(PoolObjectType.SMG_Bullet);
                break;
            case 2:
                DestroyBullet(PoolObjectType.ShotGun_Bullet);
                break;
            case 4:
                DestroyBullet(PoolObjectType.Granade);
                break;
            case 7:
                DestroyBullet(PoolObjectType.RangeyBullet);
                break;
        }
    }
    IEnumerator DelayRemove(PoolObjectType type)
    {
        yield return new WaitForSeconds(2.5f);
        ObjPoolManager.instance.CoolObject(gameObject, type);
    }
}
