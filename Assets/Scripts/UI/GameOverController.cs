using UnityEngine;
using Zenject;
using System.Linq;
using UnityEngine.SceneManagement;

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
        //foreach (var enemy in _waveSpawner.InstatiatedEnemies.ToList())
        //{
        //    Destroy(enemy);
        //    _waveSpawner.InstatiatedEnemies.Remove(enemy);
        //}
        
        //_player.position = Vector3.zero;

        //_waveSpawner.SetDefaultEnemySettings();

        //_playerHealth.ResetHealth();

        //_playerShooting.ResetBulletCound();

        //deathMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }

    /// <summary>
    /// Method on button
    /// </summary>
    public void OnLeaveButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
