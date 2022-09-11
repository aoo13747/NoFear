using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : EnemyStats
{
    //public EnemyPathFinding enemyPathFinding;    

    //public Transform rayCast;
    //public LayerMask rayCastMask;

    //public float rayCastLength;
    //public float attackDistance;
    //private float distance;
    //private RaycastHit2D hitLeft;
    //private RaycastHit2D hitRight;
    //private GameObject target;

    //private bool onCoolDown;
    //private float attackCoolDown = 1f;
    //private float coolDownTime;

    //public Transform attackPoint;
    //public Transform firePoint;
    //public LayerMask playerLayer;

    //bool attacking = false;

    //#region EnemyType
    //public bool isMeleeType;
    //public bool isShooterType;
    //public bool isExplosiveType;
    //public bool isSummonerType;
    //public bool isMinionType;
    //#endregion
    //private void Start()
    //{
    //    target = GameObject.FindWithTag("Player");
    //    coolDownTime = attackCoolDown;
    //}
    //private void Update()
    //{
    //    hitLeft = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
    //    hitRight = Physics2D.Raycast(rayCast.position, Vector2.right, rayCastLength, rayCastMask);
    //    if(hitLeft.collider != null || hitRight.collider != null)
    //    {
    //        EnemyDecision();
    //    }
    //}
    //void EnemyDecision()
    //{
    //    distance = Vector2.Distance(rayCast.position, target.transform.position);
    //    if(distance > attackDistance)
    //    {
    //        Move();
    //    }
    //    else if(distance <= attackDistance && onCoolDown == false)
    //    {
    //        if(isMeleeType)
    //        {
    //            Attack();
    //        }    
    //    }
    //    if(onCoolDown)
    //    {
    //        AttackCoolDown();
    //    }
    //}
    //void Attack()
    //{
    //    attackCoolDown = coolDownTime;
    //    StopMove();
    //    attacking = true;
    //    Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
    //    foreach(Collider2D player in hitPlayer)
    //    {
    //        player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
    //    }
    //    onCoolDown = true;
    //}
    //private void OnDrawGizmosSelected()
    //{
    //    if(attackPoint == null)
    //    {
    //        return;
    //    }
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}
    //void AttackCoolDown()
    //{
    //    attackCoolDown -= Time.deltaTime;
    //    if(attackCoolDown <= 0 && onCoolDown)
    //    {
    //        onCoolDown = false;
    //        attackCoolDown = coolDownTime;
    //    }
    //}
    //void Move()
    //{
    //    enemyPathFinding.enabled = true;
    //}
    //void StopMove()
    //{
    //    enemyPathFinding.enabled = false;
    //}
}
