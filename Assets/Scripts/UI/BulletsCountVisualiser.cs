using TMPro;
using UnityEngine;
using Zenject;

public class BulletsCountVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletsCount;

    [Inject] private Shooting _playerShooting;
    private void Start()
    {
        UpdateText(_playerShooting.InitialBulletCount, _playerShooting.InitialBulletCount);
    }
    public void OnBulletCountUpdate(int count)
    {
        UpdateText(count, _playerShooting.InitialBulletCount);
    }
    private void UpdateText(int current, int max)
    {
        bulletsCount.text = $"{current.ToString()}/{max.ToString()}";
    }
}
