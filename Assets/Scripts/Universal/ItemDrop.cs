using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemDrop
{
    public ItemType[] items;
}
[System.Serializable]
public class ItemType
{
    public GameObject ItemPrefab;
    [Range(0f, 100f)]
    public float spawnChance;
}

