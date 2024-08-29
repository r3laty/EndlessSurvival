using TMPro;
using UnityEngine;

public class BulletsCountVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletsCount;
    public void OnBulletCountUpdate(int count)
    {
        UpdateText(count);
    }
    private void UpdateText(int current)
    {
        bulletsCount.text = $"{current.ToString()}";
    }
}
