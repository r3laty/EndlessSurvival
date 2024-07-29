using TMPro;
using UnityEngine;

public class BulletsCountVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletsCount;
    public void OnBulletCountUpdate(int count)
    {
        bulletsCount.text = $"{count.ToString()}/10";
    }
}
