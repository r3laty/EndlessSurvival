using TMPro;
using UnityEngine;
using Zenject;

public class BulletsCountVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletsCount;

    [Inject] private Shooting _playerShooting;

    private void Start()
    {
        UpdateText(_playerShooting.InitialBulletCount);
    }
    public void OnBulletCountUpdate(int count)
    {
        UpdateText(count);
    }
    private void UpdateText(int current)
    {
        bulletsCount.text = $"{current.ToString()}";
    }
}
