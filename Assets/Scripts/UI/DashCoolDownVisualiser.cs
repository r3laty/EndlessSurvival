using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DashCoolDownVisualiser : MonoBehaviour
{
    [SerializeField] private Image dashImage;
    [SerializeField] private TextMeshProUGUI coolDownCountText;

    [Inject] private Movement _playerMovement;
    private void OnEnable()
    {
        _playerMovement.Dashed += OnDash;
    }

    private void OnDash()
    {
        coolDownCountText.gameObject.SetActive(true);
        ChangeColor("#C3C3C3");
        StartCoroutine(DashCDTime(_playerMovement.DashCD));
    }
    private IEnumerator DashCDTime(float duration)
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

    private void OnDisable()
    {
        _playerMovement.Dashed -= OnDash;
    }
    private void ChangeColor(string hexColor)
    {
        if (dashImage != null)
        {
            Color newColor;

            if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
            {
                dashImage.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hex color string: " + hexColor);
            }
        }
    }
}
