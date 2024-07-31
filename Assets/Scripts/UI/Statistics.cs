using TMPro;
using UnityEngine;
using Zenject;

public class Statistics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wavesCount;
    [SerializeField] private TextMeshProUGUI bonusCount;

    private string _wavesCountTextPattern = "Waves count: "; 
    private string _bonusCountTextPattern = "Bonus count: "; 
    [Inject] private WaveSpawner _waveSpawner;
    [Inject] private ItemPickUpper _pickUpper;
    [Inject] private Shooting _playerShooting;
    [Inject] private HealthController _playerHealth;
    private void OnEnable()
    {
        _playerHealth.Dead += OnDeath;
    }
    private void OnDeath()
    {
        wavesCount.text =_wavesCountTextPattern + _waveSpawner.WavesCount.ToString();
        bonusCount.text = _bonusCountTextPattern + _pickUpper.PickUpedCount.ToString();
    }
    private void OnDisable()
    {
        _playerHealth.Dead -= OnDeath;
    }
}