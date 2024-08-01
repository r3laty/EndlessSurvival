using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class BoosterVisualiser : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boosterNameText;
    [SerializeField] private TextMeshProUGUI boosterTimeText;

    [Inject] private ItemPickUpper _pickUpper;

    private IBoostable _currentBooster;

    private void OnEnable()
    {
        _pickUpper.BoostCreated += OnBoostCreating;
    }

    private void OnBoostCreating(IBoostable booster)
    {
        _currentBooster = booster;
        boosterNameText.text = _currentBooster.GetName();
        StartCoroutine(UpdateBoosterTime(_currentBooster.GetDuration()));
    }
    private IEnumerator UpdateBoosterTime(float duration)
    {
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            boosterTimeText.text = remainingTime.ToString("F1") + "s";
            yield return new WaitForSeconds(0.1f);
            remainingTime -= 0.1f;
        }
        boosterTimeText.text = "0s";
        boosterNameText.text = "booster";
    }
    private void OnDisable()
    {
        _pickUpper.BoostCreated -= OnBoostCreating;
    }
}
