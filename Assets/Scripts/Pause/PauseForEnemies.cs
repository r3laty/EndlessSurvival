using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseForEnemies : MonoBehaviour, IPauseable
{
    [Inject] private WaveSpawner _waveSpawner;
    [Inject] private PauseData _pauseData;
    private List<EnemyController> _enemyControllersOnScene;
    private void Start()
    {
        _pauseData.Pauseables.Add(this);
    }

    public void GamePause()
    {
        _waveSpawner.enabled = false;
        SetEnemies(false);
    }

    public void GameReset()
    {
        _waveSpawner.enabled = true;
        SetEnemies(true);

    }
    private void SetEnemies(bool turner)
    {
        foreach (var enemy in _waveSpawner.InstantiatedEnemieHps)
        {
            var enemyController = enemy.GetComponent<EnemyController>();
            enemyController.enabled = turner;

            var enemyAnimator = enemy.GetComponentInChildren<Animator>();
            enemyAnimator.enabled = turner;
        }
    }
}
