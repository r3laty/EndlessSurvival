using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RechargeVisualiser : MonoBehaviour
{
    [SerializeField] private Image shootImage;
    [SerializeField] private TextMeshProUGUI coolDownCountText;

    [Inject] private BaseGun _playerShooting;
    private void Start()
    {
        _playerShooting.Recharge += OnRecharge;
    }

    private void OnRecharge()
    {
        coolDownCountText.gameObject.SetActive(true);
        ChangeColor("#C3C3C3");
        StartCoroutine(ShootingCDTime(_playerShooting.RechargingTime));
    }
    private IEnumerator ShootingCDTime(float duration)
    {
        float remainingTime = duration;

        while (remainingTime > 0)
        {
            coolDownCountText.text = remainingTime.ToString("F1") + "s";
            yield return new WaitForSeconds(0.1f);
            remainingTime -= 0.1f;
        }

        coolDownCountText.text = "0s";
        coolDownCountText.gameObject.SetActive(false);
        ChangeColor("#FFFFFF");
    }
    private void ChangeColor(string hexColor)
    {
        if (shootImage != null)
        {
            Color newColor;

            if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
            {
                shootImage.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hex color string: " + hexColor);
            }
        }
    }
    private void OnDisable()
    {
        _playerShooting.Recharge -= OnRecharge;
    }
}
