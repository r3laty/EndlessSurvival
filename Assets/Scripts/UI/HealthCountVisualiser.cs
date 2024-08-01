using TMPro;
using UnityEngine;
using Zenject;

public class HealthCountVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthCount;

    [Inject] private HealthController _playerHealth;

    private void Start()
    {
        UpdateText(_playerHealth.MaxHealthProperty);
    }
    public void OnHealthCountUpdate(int count)
    {
        UpdateText(count);
    }
    private void UpdateText(int current)
    {
        healthCount.text = $"{current.ToString()}";
    }
}
