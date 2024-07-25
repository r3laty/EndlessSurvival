using TMPro;
using UnityEngine;

public class HealthCountVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthCount;
    public void OnHealthCountUpdate(int count)
    {
        healthCount.text = $"{count.ToString()}/50";
    }
}
