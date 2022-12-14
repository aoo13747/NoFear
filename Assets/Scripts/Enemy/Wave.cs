using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float spawnRate = 1f;
    public EnemyType[] enemies;
}
[System.Serializable]
public class EnemyType
{
	public GameObject enemyPrefab;    
    [Range(0,6)]
	public int spawnChance;
}
[System.Serializable]
public class Levels
{
    public int scoreToUnlock;
    public Wave wave;
    public bool endGame;   

    [HideInInspector]
    public bool isUnlock = false;
}
