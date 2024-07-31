using TMPro;
using UnityEngine;
using Zenject;

public class WavesController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wavesCountText;
    [SerializeField] private string textPattern;

    [Inject] private WaveSpawner _waveSpawner;

    private int _currentWave = 0;
    private void OnEnable()
    {
        _waveSpawner.WaveSpawned += OnWaveSpawned;
    }
    private void OnWaveSpawned(int currentWave)
    {
        _currentWave = currentWave;
        UpdateText();
    }
    private void UpdateText()
    {
        wavesCountText.text = textPattern + _currentWave.ToString();
    }
    private void OnDisable()
    {
        _waveSpawner.WaveSpawned -= OnWaveSpawned;
    }
}
