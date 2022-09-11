using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPathFinding : EnemyStats
{
    //public Transform npcEnemy;
    //public GameObject target;

    //private bool faceleft = true;    
    //public float nextWayPointDistance = 3f;
    //private int currentWayPoint = 0;
    //private bool reachEndOfPath = false;

    //Path path;
    //Seeker seeker;

    //Rigidbody2D rb2D;
    //private void Start()
    //{
    //    seeker = GetComponent<Seeker>();
    //    rb2D = GetComponent<Rigidbody2D>();
    //    target = GameObject.FindGameObjectWithTag("Player");
    //    InvokeRepeating("UpdatePath", 0f, 0.5f);
    //}
    //void UpdatePath()
    //{
    //    if(seeker.IsDone())
    //    {
    //        seeker.StartPath(rb2D.position, target.transform.position, OnPathComplete);
    //    }
    //}
    //void OnPathComplete(Path p)
    //{
    //    if(!p.error)
    //    {
    //        path = p;
    //        currentWayPoint = 0;
    //    }
    //}
    //private void FixedUpdate()
    //{
    //    if (path == null)
    //        return;
    //    if(currentWayPoint >= path.vectorPath.Count)
    //    {
    //        reachEndOfPath = true;
    //        return;
    //    }
    //    else
    //    {
    //        reachEndOfPath = false;
    //    }

    //    Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb2D.position).normalized;
    //    Vector2 force = direction * speed * Time.deltaTime;

    //    rb2D.AddForce(force,ForceMode2D.Impulse);
    //    float distance = Vector2.Distance(rb2D.position, path.vectorPath[currentWayPoint]);
    //    if(distance < nextWayPointDistance)
    //    {
    //        currentWayPoint++;
    //    }
    //    if(rb2D.velocity.x >= 0.01f && faceleft)
    //    {
    //        Flip();
    //    }
    //    else if(rb2D.velocity.x <= -0.01f && !faceleft)
    //    {
    //        Flip();
    //    }
    //}
    //void Flip()
    //{
    //    faceleft = !faceleft;
    //    transform.Rotate(0f,180f,0f);
    //}
}

