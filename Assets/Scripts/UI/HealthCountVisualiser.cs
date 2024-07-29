using TMPro;
using UnityEngine;

public class HealthCountVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthCount;
    public void OnHealthCountUpdate(int count)
    {
        healthCount.text = $"{count.ToString()}/50";
    }
}
