using System;
using UnityEngine;
[Serializable]
public class EnemyData
{
    public GameObject EnemyPrefab;
    public Transform Spawnpoint;

    public int Health;
    public int Damage;

    public int EnemyId;
}
