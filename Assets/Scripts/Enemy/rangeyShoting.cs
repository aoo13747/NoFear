using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeyShoting : MonoBehaviour
{
    public float fireRate;
    float nextTimeToFire = 0.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    Transform player;
    public Transform parent;
    Vector2 target;
    float speed;
    private Rigidbody2D rb;
    public Animator animator;
    private void Start()
    {
        //fireRate = 1f;
        //nextRate = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 direction = (PlayerController.Position - rb.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;        
        rb.rotation = angle;
        gameObject.transform.position = parent.transform.position;
        CheckTime();
      
    }
    void CheckTime()
    {
        if (Time.time >= nextTimeToFire)
        {
            GameObject bullet = ObjPoolManager.instance.GetPoolObject(PoolObjectType.RangeyBullet);
            animator.SetTrigger("Attack");
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;
            bullet.SetActive(true);
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }
}
