using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Space]
    [Min(0)] public int CurrentWave;
    [SerializeField] private List<WaveData> waves = new List<WaveData>();

    private void Start()
    {
        foreach (var enemy in waves[CurrentWave].Enemies)
        {
            var instatiatedEnemy = Instantiate(enemy.EnemyPrefab, enemy.Spawnpoint.position, Quaternion.identity);
            instatiatedEnemy.GetComponent<Transform>().LookAt(player.position);
            instatiatedEnemy.GetComponent<HealthController>().MaxHealth = enemy.Health;
            instatiatedEnemy.GetComponentInChildren<IDamageable>().Damage = enemy.Damage;
        }
    }

    //private IEnumerator SpawnWaves()
    //{
    //    while (true)
    //    {
    //        foreach (var enemy in waves[CurrentWave].Enemies)
    //        {
    //            var instatiatedEnemy = Instantiate(enemy.EnemyPrefab, enemy.Spawnpoint.position, Quaternion.identity);
    //            instatiatedEnemy.GetComponent<Transform>().LookAt(player.position);
    //            instatiatedEnemy.GetComponent<HealthController>().MaxHealth = enemy.Health;
    //            instatiatedEnemy.GetComponentInChildren<IDamageable>().Damage = enemy.Damage;
    //        }

    //        yield return new WaitForSeconds(waves[CurrentWave].SpawningFrequency);
    //        Debug.Log($"After corouitine in {waves[CurrentWave].SpawningFrequency} seconds");
    //        break;
    //    }
    //}
}
