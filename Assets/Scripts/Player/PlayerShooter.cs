using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShooter : MonoBehaviour
{
    public Transform firePoint;
    public Weapons[] weapons;
    [HideInInspector]
    public int currentWeapon;    
    private float nextTimeOfFire = 0f;    

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI weaponNameText;
    public GameObject player;    
    bool canShoot;

    public SpriteRenderer gun_SpriteRenderer;
    public Image gunUI;
    public Sprite[] gunSprite;
    public LineRenderer lineRenderer;
    public GameObject flashPoint;
    private void Start()
    {
        gun_SpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        //Use For Prototype Test,Not Effective Way.It Will Obselate in Later Version
        weapons[0].currentAmmo = 1;
        weapons[1].currentAmmo = 0;
        weapons[2].currentAmmo = 0;
        weapons[3].currentAmmo = 0;
        weapons[4].currentAmmo = 0;
    }
    private void FixedUpdate()
    {                
        FlipGun();
        weaponNameText.text = weapons[currentWeapon].weaponName;
    }
    private void Update()
    {
        SwapWeapon();
        CheckAmmo();
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= nextTimeOfFire)
            {
                if (canShoot)
                {
                    if (weapons[currentWeapon].shootRayCast)
                    {
                        ShootRayCast();
                    }
                    else
                    {
                        switch(currentWeapon)
                        {
                            default:
                                weapons[currentWeapon].Shoot(firePoint, PoolObjectType.Pistol_Bullet);
                                break;
                            case 1:
                                weapons[currentWeapon].Shoot(firePoint, PoolObjectType.SMG_Bullet);
                                break;
                            case 2:
                                weapons[currentWeapon].ShotGunShoot(firePoint, PoolObjectType.ShotGun_Bullet);
                                break;
                            case 4:
                                weapons[currentWeapon].Shoot(firePoint, PoolObjectType.Granade);
                                break;
                        }
                        StartCoroutine(WeaponFlash());
                    }
                    if (weapons[currentWeapon].currentAmmo > 0)
                    {
                        if (weapons[currentWeapon] != weapons[0])
                            weapons[currentWeapon].currentAmmo--;
                    }
                    else if (weapons[currentWeapon].currentAmmo <= 0)
                    {
                        weapons[currentWeapon].currentAmmo = 0;
                    }
                    nextTimeOfFire = Time.time + 1 / weapons[currentWeapon].fireRate;
                    AudioSource.PlayClipAtPoint(weapons[currentWeapon].fireSound, firePoint.transform.position);
                }
            }
        }
    }
    void ShootRayCast()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(firePoint.position, lineRenderer.startWidth, firePoint.up);
        foreach (RaycastHit2D hit in hits)
        {
            EnemyStats enemy = hit.collider.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(weapons[currentWeapon].rayCastDamage);
            }
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);            
        }
        StartCoroutine(FlashLineRenderer());
    }
    IEnumerator FlashLineRenderer()
    {
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.1f);

        lineRenderer.enabled = false;
    }
    IEnumerator WeaponFlash()
    {
        flashPoint.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flashPoint.SetActive(false);
    }
      
    private void CheckAmmo()
    {        
        if (weapons[currentWeapon].currentAmmo > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
        if(weapons[currentWeapon] != weapons[0])
        {
            ammoText.text = weapons[currentWeapon].currentAmmo.ToString() + ("/") + weapons[currentWeapon].maxAmmo.ToString();
        }
        else if (weapons[currentWeapon] == weapons[0])
        {
            ammoText.text = Mathf.Infinity.ToString() + ("/") + Mathf.Infinity.ToString();
        }
        
    }
    void SwapWeapon()
    {        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentWeapon = 4;            
        }
        ChangeSprite();
        
    }
    void ChangeSprite()
    {
        gun_SpriteRenderer.sprite = gunSprite[currentWeapon];
        gunUI.sprite = gun_SpriteRenderer.sprite;
    }
    void FlipGun()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        ////////filpgun
        if (rotZ < -90 || rotZ > 90)
        {
            if (player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
            }
        }
    }


}
