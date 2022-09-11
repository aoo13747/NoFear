﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private static List<Rigidbody2D> enemyRBs;
    public float moveSpeed;

    [Range(0f, 1f)]
    public float turnSpeed;
    [Range(0f, 5f)]
    public float repelRange;
    [Range(0f, 5f)]
    public float repelAmount;

    public float startMaxChaseDistance;
    private float maxChaseDistance;

    private Rigidbody2D rb;

    #region EnemyType
    #region Melee
    [Header("Melee")]
    public bool isMeleeType;
    public float meleeDistance;
    public Transform attackPoint;
    public GameObject attckPrefab;
    public float attackRate;
    public float nextTimeToAttack = 1f;
    #endregion
    #region Shooter
    [Header("Shooting")]    
    public bool isShooterType;
    public float strafeSpeed;
    public float shootDistance;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate;
    public float nextTimeToFire = 0.5f;
    #endregion
    public bool isExplosiveType;
    public bool isSummonerType;
    public bool isMinionType;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (enemyRBs == null)
        {
            enemyRBs = new List<Rigidbody2D>();
        }
        enemyRBs.Add(rb);
    }

    private void OnDestroy()
    {
        enemyRBs.Remove(rb);
    }

    void Update()
    {

        maxChaseDistance = startMaxChaseDistance;

        float distance = Vector2.Distance(rb.position, PlayerController.Position);

        if (distance > maxChaseDistance)
        {
            //Destroy(gameObject);
            return;
        }

        Vector2 direction = (PlayerController.Position - rb.position).normalized;

        Vector2 newPos;
        if(isMeleeType)
        {
            /*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;*/

            if (distance > meleeDistance)
            {
                newPos = MoveRegular(direction);
            }
            else
            {
                newPos = MoveRegular(direction);            
            }
            if (distance <= meleeDistance)
            {
                Attack();
            }

            newPos -= rb.position;
            rb.AddForce(newPos);
        }
        if(isShooterType)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            if (distance > shootDistance)
            {
                newPos = MoveRegular(direction);
            }
            else
            {
                newPos = MoveStrafing(direction);
            }
            if (distance <= shootDistance)
            {
                Shoot();
            }

            newPos -= rb.position;


            rb.AddForce(newPos, ForceMode2D.Force);

        }
        //else
        //{
        //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        //    rb.rotation = Mathf.LerpAngle(rb.rotation, angle, turnSpeed);

        //    newPos = MoveRegular(direction);

        //    rb.MovePosition(newPos);
        //}
    }
    void Attack()
    {
        if(Time.time >= nextTimeToAttack)
        {
            GameObject hitbox = Instantiate(attckPrefab, attackPoint.position, attackPoint.rotation);
            Destroy(hitbox, 1f);
            nextTimeToAttack = Time.time + 1f / attackRate;
        }
    }

    void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);            
            Destroy(bullet, 5f);
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    Vector2 MoveStrafing(Vector2 direction)
    {
        Vector2 newPos = transform.position + transform.right * Time.fixedDeltaTime * strafeSpeed;
        return newPos;
    }

    Vector2 MoveRegular(Vector2 direction)
    {
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in enemyRBs)
        {
            if (enemy == rb)
                continue;

            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }

        Vector2 newPos = transform.position + transform.up * Time.fixedDeltaTime * moveSpeed;
        newPos += repelForce * Time.fixedDeltaTime * repelAmount;

        return newPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, maxChaseDistance);
    }

}
