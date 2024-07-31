using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{ 
    [SerializeField] private Slider shotSoundSlider;
    [SerializeField] private Slider boostSoundSlider;
    private void Start()
    {
        Debug.Log("Start method");
        if (AudioManager.Instance != null)
        {
            Debug.Log("AudioManager != null");

            shotSoundSlider.value = AudioManager.Instance.ShotVolume;
            boostSoundSlider.value = AudioManager.Instance.BoosterVolume;

            shotSoundSlider.onValueChanged.AddListener(SetShotVolume);
            boostSoundSlider.onValueChanged.AddListener(SetBoostVolume);
        }
    }
    private void SetShotVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ShotVolume = value;
        }
    }

    private void SetBoostVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.BoosterVolume = value;
        }
    }
}
