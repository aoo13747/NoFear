using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
   // public Animator animator;
    public int damage;
    //Transform player;
    //public GameObject hitbox;
    //public float walkspeed;
    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        //Vector2 playerpos = player.transform.position;
        /*if (playerpos.x < transform.position.x && faceright && PauseMenu.isPause == false)
        {
            Flip();
        }
        else if (playerpos.x > transform.position.x && !faceright && PauseMenu.isPause == false)
        {
            Flip();
        }*/
        /*if (Vector2.Distance(transform.position, player.position) < 3)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,walkspeed * Time.deltaTime);
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats player = collision.GetComponent<PlayerStats>();
        if (collision.tag == "Player")
        {
            Damage(player);
        }
        /*if (player != null)
        {
            Damage(player);

           if (collision.tag == "Player")
            {
                //setanimation animator.SetBool();
                //hitbox
                hitbox.SetActive(true);
            }
            else
            {
                //resetanimation
                hitbox.SetActive(false);
            }
        }*/
    }
    void Damage(Identity target)
    {
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
    
    bool faceright = true;
    public void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }
}
