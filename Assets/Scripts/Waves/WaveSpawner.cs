using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private WaveData waveData = new WaveData();

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

                instatiatedEnemy.GetComponent<Transform>().LookAt(player.position);
                instatiatedEnemy.GetComponent<HealthController>().MaxHealth = enemy.Health;
                instatiatedEnemy.GetComponentInChildren<IDamageable>().Damage = enemy.Damage;
            }

            Debug.Log($"Before corouitine in {waveData.SpawningFrequency} seconds");
            yield return new WaitForSeconds(waveData.SpawningFrequency);
            Debug.Log($"After corouitine in {waveData.SpawningFrequency} seconds");

            foreach (var enemy in waveData.Enemies)
            {
                enemy.Health++;
                enemy.Damage++;
            }
        }
    }
}
