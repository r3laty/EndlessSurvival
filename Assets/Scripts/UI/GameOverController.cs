using UnityEngine;
using Zenject;
using System.Linq;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Canvas deathMenu;
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private Canvas inGameMenu;
    
    private Transform _player;

    [Inject] private WaveSpawner _waveSpawner;
    [Inject] private HealthController _playerHealth;
    [Inject] private Shooting _playerShooting;
    private void Awake()
    {
        _player = _playerHealth.gameObject.transform; 
    }
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
        
        _player.position = Vector3.zero;

        _waveSpawner.SetDefaultEnemySettings();

        _playerHealth.ResetHealth();

        _playerShooting.ResetBulletCound();

        deathMenu.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveButton()
    {
        mainMenu.gameObject.SetActive(true);
        inGameMenu.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
