using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int WavesCount => _wavesCount;
    public event Action<int> WaveSpawned;

    [HideInInspector] public List<GameObject> InstatiatedEnemies = new List<GameObject>();

    [SerializeField] private WaveData waveData = new WaveData();
    private int _wavesCount = 0;
    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            foreach (var enemy in waveData.Enemies)
            {
                var instatiatedEnemy = Instantiate(enemy.EnemyPrefab, enemy.Spawnpoint.position, Quaternion.identity);

                instatiatedEnemy.GetComponent<HealthController>().MaxHealth = enemy.Health;
                instatiatedEnemy.GetComponentInChildren<IDamageable>().Damage = enemy.Damage;

                InstatiatedEnemies.Add(instatiatedEnemy);
            }
            _wavesCount++;
            WaveSpawned?.Invoke(_wavesCount);
            yield return new WaitForSeconds(waveData.SpawningFrequency);

            foreach (var enemy in waveData.Enemies)
            {
                enemy.Health++;
                enemy.Damage++;
                enemy.Spawnpoint.position = new Vector3(UnityEngine.Random.Range(-22, 22), 3, UnityEngine.Random.Range(23.28f, -23.28f));
            }
        }
    }

    public void SetDefaultEnemySettings()
    {
        foreach (var enemy in waveData.Enemies)
        {
            switch (enemy.EnemyId)
            {
                case 1:
                    enemy.Health = DefaultEnemySettings.TankHealth;
                    enemy.Damage = DefaultEnemySettings.TankDamage;
                    break;
                case 2: 
                    enemy.Health = DefaultEnemySettings.RangedHealth;
                    enemy.Damage = DefaultEnemySettings.RangedDamage;
                    break;
                case 3:
                    enemy.Health = DefaultEnemySettings.DodgerHealth;
                    enemy.Damage = DefaultEnemySettings.DodgerDamage;
                    break;
            }
        }
    }
}
