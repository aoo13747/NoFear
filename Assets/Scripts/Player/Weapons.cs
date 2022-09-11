using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Weapon", menuName = "Weapon")]
[System.Serializable]
public class Weapons : ScriptableObject
{
    public string weaponName;
    public float fireRate;
    public int maxAmmo;
    public int currentAmmo;    
    public GameObject bulletPrefab;
    public AudioClip fireSound;
    [Header("ShootRayCast")]
    public bool shootRayCast = false;
    public int rayCastDamage;

    public void Shoot(Transform firePoint,PoolObjectType type)
    {       
        GameObject bullet = ObjPoolManager.instance.GetPoolObject(type);
        bullet.transform.position = firePoint.transform.position;
        bullet.transform.rotation = firePoint.transform.rotation;
        bullet.SetActive(true);
    }
    public void ShotGunShoot(Transform firePoint, PoolObjectType type)
    {
        for (int i = 0; i <= 5; i++)
        {
            GameObject bullet = ObjPoolManager.instance.GetPoolObject(type);
            switch (i)
            {
                default:
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation * Quaternion.Euler(0, 0f, Random.Range(-45f, 45f));
                    bullet.SetActive(true);
                    break;
                case 1:
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-45f, 45f));
                    bullet.SetActive(true);
                    break;

                case 2:
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-45f, 45f));
                    bullet.SetActive(true);
                    break;
                case 3:
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-45f, 45f));
                    bullet.SetActive(true);
                    break;
                case 4:
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-45f, 45f));
                    bullet.SetActive(true);
                    break;
                case 5:
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation * Quaternion.Euler(0f, 0f, Random.Range(-45f, 45f));
                    bullet.SetActive(true);
                    break;
            }
        }
    }

}
