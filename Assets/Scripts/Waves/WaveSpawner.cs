using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int WavesCount => _wavesCount;
    public event Action<int> WaveSpawned;

    [HideInInspector] public List<HealthController> InstantiatedEnemies = new List<HealthController>();

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
                var instantiatedEnemy = Instantiate(enemy.EnemyPrefab, enemy.Spawnpoint.position, Quaternion.identity);

                var enemyHealth = instantiatedEnemy.GetComponent<HealthController>();
                enemyHealth.MaxHealth = enemy.Health;

                var enemyIDamageable = instantiatedEnemy.GetComponentInChildren<IDamageable>();
                enemyIDamageable.Damage = enemy.Damage;

                InstantiatedEnemies.Add(enemyHealth);
            }

            _wavesCount++;
            WaveSpawned?.Invoke(_wavesCount);

            while (InstantiatedEnemies.Count > 0)
            {
                InstantiatedEnemies.RemoveAll(enemy => enemy.IsDead);
                yield return null;
            }

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
