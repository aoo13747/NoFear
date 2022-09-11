using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    Player,

    #region Enemy

        Slimey, Rangey,Speedy,Boomer,Summomner,Minion,Tank,

    #endregion

    #region Bullet

        Pistol_Bullet, SMG_Bullet,ShotGun_Bullet,Granade,RangeyBullet

    #endregion
}
[Serializable]
public class PoolInfo
{
    public PoolObjectType type;
    public int amount;
    public GameObject prefab;
    public GameObject container;
    public bool canExpand;

    [HideInInspector]
    public List<GameObject> pool = new List<GameObject>();
}
public class ObjPoolManager : Singleton<ObjPoolManager>
{
    [SerializeField]
    List<PoolInfo> listOfPool;
    private Vector3 defaultPos = new Vector3(-500, -500, -500);
    private void Start()
    {
        for(int i=0;i<listOfPool.Count;i++)
        {
            FillPool(listOfPool[i]);
        }
    }
    void FillPool(PoolInfo info)
    {
        for(int i=0;i<info.amount;i++)
        {
            GameObject objInstace = null;
            objInstace = Instantiate(info.prefab, info.container.transform);
            objInstace.gameObject.SetActive(false);
            objInstace.transform.position = defaultPos;
            info.pool.Add(objInstace);
        }
    }
    public GameObject GetPoolObject(PoolObjectType type)
    {
        PoolInfo selected = GetPoolByType(type);
        List<GameObject> pool = selected.pool;
        GameObject objInstance = null;
        if (pool.Count>0)
        {
            objInstance = pool[pool.Count - 1];
            pool.Remove(objInstance);
        }
        else if(selected.canExpand)
        {
            objInstance = Instantiate(selected.prefab, selected.container.transform);
        }
        if (pool.Count != 0)
            return objInstance;
        else
            return null;
    }
    public void CoolObject(GameObject obj,PoolObjectType type)
    {
        obj.SetActive(false);
        obj.transform.position = defaultPos;

        PoolInfo selected = GetPoolByType(type);

        List<GameObject> pool = selected.pool;

        if (!pool.Contains(obj))
            pool.Add(obj);
    }
    private PoolInfo GetPoolByType(PoolObjectType type)
    {
        for(int i=0;i<listOfPool.Count;i++)
        {
            if (type == listOfPool[i].type)
                return listOfPool[i];
        }
        return null;
    }
}
