using TMPro;
using UnityEngine;
using Zenject;

public class HealthCountVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthCount;

    [Inject] private HealthController _playerHealth;
    private void Start()
    {
        UpdateText(_playerHealth.MaxHealth, _playerHealth.MaxHealth);
    }
    public void OnHealthCountUpdate(int count)
    {
        UpdateText(count, _playerHealth.MaxHealth);
    }
    private void UpdateText(int current, int max)
    {
        healthCount.text = $"{current.ToString()}/{max.ToString()}";
    }
}
