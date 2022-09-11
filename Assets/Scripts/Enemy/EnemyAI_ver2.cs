using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_ver2 : MonoBehaviour
{
    public float walkspeed;
    public Animator animator;
    public float stoppingDitancec;
    public GameObject hitbox;
    //public int damage;
    Transform player;

    public bool melee;
    public bool bomb;
    public bool summon;
    public bool minion;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerpos = player.transform.position;
        if (Vector2.Distance(transform.position, player.position) > stoppingDitancec)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, walkspeed * Time.deltaTime);
        }
        if (playerpos.x < transform.position.x && faceright)
        {
            Flip();
        }
        else if (playerpos.x > transform.position.x && !faceright)
        {
            Flip();
        }
        if (walkspeed > 0)
        {
            animator.SetBool("walk", true);
        }
        if (walkspeed <= 0)
        {
            animator.SetBool("walk", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //PlayerStats player = collision.GetComponent<PlayerStats>();
        if (melee == true)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("hit");
                meleeattack();
                StartCoroutine("cooldown");
            }
            /*else
            {
                Debug.Log("reset");
                animator.SetBool("walk", true);
            }*/
        }
        if (bomb == true)
        {
            StartCoroutine(cooldownBomb());
            //ObjPoolManager.instance.CoolObject(gameObject, PoolObjectType.Boomer);
        }
        if (minion == true)
        {
            StartCoroutine(minionTime());
            //Destroy(this.gameObject);
        }
        if (summon == true)
        {            
            SummonMinion();            
        }
    }
    void SummonMinion() 
    {
        animator.SetTrigger("Attack");
            for (int i = 0; i <= 5; i++)
            {
                GameObject minion = ObjPoolManager.instance.GetPoolObject(PoolObjectType.Minion);
                Vector2 spawnPos = hitbox.transform.position * new Vector2(Random.Range(0, 1), Random.Range(0, 1));
                switch (i)
                {
                    default:
                    minion.transform.position = spawnPos;
                    minion.transform.rotation = hitbox.transform.rotation;
                    minion.SetActive(true);
                        break;
                    case 1:
                    minion.transform.position = spawnPos;
                        minion.transform.rotation = hitbox.transform.rotation;
                    minion.SetActive(true);
                        break;

                    case 2:
                    minion.transform.position = spawnPos;
                        minion.transform.rotation = hitbox.transform.rotation;
                        minion.SetActive(true);
                        break;
                    case 3:
                    minion.transform.position = spawnPos;
                        minion.transform.rotation = hitbox.transform.rotation; 
                        minion.SetActive(true);
                        break;
                    case 4:
                    minion.transform.position = spawnPos;
                        minion.transform.rotation = hitbox.transform.rotation;
                        minion.SetActive(true);
                        break;
                    case 5:
                    minion.transform.position = spawnPos;
                    minion.transform.rotation = hitbox.transform.rotation;
                        minion.SetActive(true);
                        break;
                }
            }
        
    }
    void meleeattack()
    {
        animator.SetTrigger("Attack");
    }
    IEnumerator cooldown()
    {
        yield return new  WaitForSeconds(2f);
        animator.SetBool("walk",true);
    }
    IEnumerator cooldownBomb()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.8f);
        ObjPoolManager.instance.CoolObject(gameObject, PoolObjectType.Boomer);
    }
    IEnumerator minionTime()
    {
        yield return new WaitForSeconds(1f);
        ObjPoolManager.instance.CoolObject(gameObject, PoolObjectType.Minion);
    }
    bool faceright = true;
    public void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }

}
