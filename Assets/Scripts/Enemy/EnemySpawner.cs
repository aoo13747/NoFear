using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float startSpawnRadius;
    private float spawnRadius;
    public Transform spawnerPos;

    [HideInInspector]
    public Wave currentWave;
    private float nextSpawnTime = 1f;

    private void Start()
    {
        spawnRadius = startSpawnRadius;
    }
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnWave();
            nextSpawnTime = Time.time + 1f / currentWave.spawnRate;
        }
    }
    void SpawnWave()
    {
        foreach (EnemyType enemyType in currentWave.enemies)
        {
            int random = Mathf.RoundToInt(Random.Range(1, 7));
            Debug.Log(random);            
            switch (random)
            {
                case 1:
                    SpawnEnemy(enemyType.enemyPrefab, PoolObjectType.Slimey);
                    break;
                case 2:
                    SpawnEnemy(enemyType.enemyPrefab, PoolObjectType.Speedy);
                    break;
                case 3:
                    SpawnEnemy(enemyType.enemyPrefab, PoolObjectType.Tank);
                    break;
                case 4:
                    SpawnEnemy(enemyType.enemyPrefab, PoolObjectType.Boomer);
                    break;
                case 5:
                    SpawnEnemy(enemyType.enemyPrefab, PoolObjectType.Rangey);
                    break;                
                default:
                    break;
            }
        }
    }
    void SpawnEnemy(GameObject enemyPrefab,PoolObjectType type)
    {
        Vector2 spawnPos = new Vector2(Random.Range(-5, 16), Random.Range(-5.5f, 3.5f));
        //spawnPos += Random.insideUnitCircle * spawnRadius;
        GameObject spawnedEnemy = ObjPoolManager.instance.GetPoolObject(type);
        spawnedEnemy.transform.position = spawnPos;
        spawnedEnemy.transform.rotation = Quaternion.identity;
        spawnedEnemy.SetActive(true);
    }
    
}
