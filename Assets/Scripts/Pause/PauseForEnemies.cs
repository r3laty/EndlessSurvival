using UnityEngine;
using Zenject;

public class PauseForEnemies : MonoBehaviour, IPauseable
{
    [Inject] private WaveSpawner _waveSpawner;
    [Inject] private PauseData _pauseData;
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
        foreach (var enemyHealth in _waveSpawner.InstantiatedEnemieHps)
        {
            if (enemyHealth.TryGetComponent<EnemyController>(out EnemyController controller))
            {
                controller.enabled = turner;

                var enemyAnimator = enemyHealth.GetComponentInChildren<Animator>();
                enemyAnimator.enabled = turner;

                enemyHealth.enabled = turner;
            }
        }
    }
}
