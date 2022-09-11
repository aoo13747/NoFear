using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Player Weapon",menuName = "Weapon")]
[System.Serializable]
public class Weapons : ScriptableObject
{
    public string weaponName;
    public float fireRate;
    public int maxAmmo;
    public int currentAmmo;
    public string weaponBulletTag;
    public GameObject bulletPrefab;

    [Header("ShootRayCast")]    
    public bool shootRayCast = false;
    public int rayCastDamage;    
    public void Shoot(Transform firePoint)
    {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Destroy(bullet, 5f);
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(bulletPrefab,weaponBulletTag);
        if(bullet != null)
        {
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;
            bullet.SetActive(true);                        
        }
    }    
}
