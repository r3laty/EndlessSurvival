using UnityEngine;
using Zenject;
using System.Linq;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Canvas deathMenu;

    [Inject] private WaveSpawner _waveSpawner;
    [Inject] private HealthController _playerHealth;
    [Inject] private Shooting _playerShooting;
    /// <summary>
    /// Method on button
    /// </summary>
    public void ResetAll()
    {
        foreach (var enemy in _waveSpawner.InstatiatedEnemies.ToList())
        {
            Destroy(enemy);
            _waveSpawner.InstatiatedEnemies.Remove(enemy);
        }
        
        _waveSpawner.SetDefaultEnemySettings();

        _playerHealth.ResetHealth();

        _playerShooting.ResetBulletCound();

        deathMenu.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}
