using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaveSpawner : MonoBehaviour
{
    [HideInInspector] public List<GameObject> InstatiatedEnemies = new List<GameObject>();

    [SerializeField] private WaveData waveData = new WaveData();

    [Inject] private Transform _player;

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

                instatiatedEnemy.GetComponent<EnemyController>().Player = _player;
                instatiatedEnemy.GetComponent<HealthController>().MaxHealth = enemy.Health;
                instatiatedEnemy.GetComponentInChildren<IDamageable>().Damage = enemy.Damage;

                InstatiatedEnemies.Add(instatiatedEnemy);
            }

            yield return new WaitForSeconds(waveData.SpawningFrequency);

            foreach (var enemy in waveData.Enemies)
            {
                enemy.Health++;
                enemy.Damage++;
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
